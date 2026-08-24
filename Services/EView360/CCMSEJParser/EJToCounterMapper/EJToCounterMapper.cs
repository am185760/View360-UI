using ServicesDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;

namespace EJToCounterMapper
{
    public static class EJToCounterMapper
    {
        private static int TrxnsMarginalIntervalInSeconds = ConfigurationManager.AppSettings["TrxnsMarginalIntervalInSeconds"] != null ? int.Parse(ConfigurationManager.AppSettings["TrxnsMarginalIntervalInSeconds"]) : 5;

        public static void EjParsedTransactionMigrator(EjParsedTransactions ejParsedTransaction)
        {
            SqlCommand cmd = null;
            LogableTask task = LogableTask.NewTask("EjParsedTransactionMigrator");

            try
            {
                cmd = ConnectionFactory.GetNewCommand(true, DatabaseName.Cash);
                ParsedTransaction objParsedtransaction = new ParsedTransaction();

                if (ejParsedTransaction.Amount.HasValue)
                    objParsedtransaction.Amount = ejParsedTransaction.Amount.Value;
                objParsedtransaction.AtmId = ejParsedTransaction.AtmId.Value;
                if (ejParsedTransaction.NotesDispensedType1.HasValue)
                    objParsedtransaction.CashDispensed1 = ejParsedTransaction.NotesDispensedType1.Value;
                if (ejParsedTransaction.NotesDispensedType2.HasValue)
                    objParsedtransaction.CashDispensed2 = ejParsedTransaction.NotesDispensedType2.Value;
                if (ejParsedTransaction.NotesDispensedType3.HasValue)
                    objParsedtransaction.CashDispensed3 = ejParsedTransaction.NotesDispensedType3.Value;
                if (ejParsedTransaction.NotesDispensedType4.HasValue)
                    objParsedtransaction.CashDispensed4 = ejParsedTransaction.NotesDispensedType4.Value;


                objParsedtransaction.CashDispensed5 = 0;
                objParsedtransaction.CashDispensed6 = 0;
                objParsedtransaction.CashDispensed7 = 0;
                if (ejParsedTransaction.NotesRemainingType1.HasValue)
                {
                    if (ejParsedTransaction.NotesDispensedType1.HasValue)
                        objParsedtransaction.CashRemaining1 = ejParsedTransaction.NotesRemainingType1.Value + ejParsedTransaction.NotesDispensedType1.Value;
                    else
                        objParsedtransaction.CashRemaining1 = ejParsedTransaction.NotesRemainingType1.Value;
                }
                if (ejParsedTransaction.NotesRemainingType2.HasValue)
                {
                    if (ejParsedTransaction.NotesDispensedType2.HasValue)
                        objParsedtransaction.CashRemaining2 = ejParsedTransaction.NotesRemainingType2.Value + ejParsedTransaction.NotesDispensedType2.Value;
                    else
                        objParsedtransaction.CashRemaining2 = ejParsedTransaction.NotesRemainingType2.Value;
                }
                if (ejParsedTransaction.NotesRemainingType3.HasValue)
                {
                    if (ejParsedTransaction.NotesDispensedType3.HasValue)
                        objParsedtransaction.CashRemaining3 = ejParsedTransaction.NotesRemainingType3.Value + ejParsedTransaction.NotesDispensedType3.Value;
                    else
                        objParsedtransaction.CashRemaining3 = ejParsedTransaction.NotesRemainingType3.Value;
                }
                if (ejParsedTransaction.NotesRemainingType4.HasValue)
                {
                    if (ejParsedTransaction.NotesDispensedType4.HasValue)
                        objParsedtransaction.CashRemaining4 = ejParsedTransaction.NotesRemainingType4.Value + ejParsedTransaction.NotesDispensedType4.Value;
                    else
                        objParsedtransaction.CashRemaining4 = ejParsedTransaction.NotesRemainingType4.Value;
                }
                objParsedtransaction.Pan = ejParsedTransaction.Pan;
                objParsedtransaction.ParsedTransactionId = ejParsedTransaction.EjParsedTransactionsId;
                objParsedtransaction.ProcessingDatetime = ejParsedTransaction.ProcessingDatetime.Value;
                objParsedtransaction.TaskId = ejParsedTransaction.TaskId.Value;
                objParsedtransaction.TrxnDatetime = ejParsedTransaction.TrxnDatetime;
                objParsedtransaction.Tsn = ejParsedTransaction.Tsn;

                cmd.CommandText = "isTrxnInIntervalExists";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("trxnDatetime", SqlDbType.DateTime));
                cmd.Parameters[0].Value = objParsedtransaction.TrxnDatetime;
                cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
                cmd.Parameters[1].Value = objParsedtransaction.AtmId;
                cmd.Parameters.Add(new SqlParameter("amount", SqlDbType.Decimal));
                cmd.Parameters[2].Value = objParsedtransaction.Amount;
                cmd.Parameters.Add(new SqlParameter("intervalInSeconds", SqlDbType.Int));
                cmd.Parameters[3].Value = TrxnsMarginalIntervalInSeconds;

                //if ((int)cmd.ExecuteScalar() > 0)
                if ((int)cmd.ExecuteScalar() > 0 || (objParsedtransaction.CashRemaining1 == 0 && objParsedtransaction.CashRemaining2 == 0 && objParsedtransaction.CashRemaining3 == 0 && objParsedtransaction.CashRemaining4 == 0))
                {
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Transaction " + objParsedtransaction.TrxnDatetime.ToString() + " for Task Id " + objParsedtransaction.TaskId + ".because this already exists in parsed_transaction table.");
                    return;
                }
                objParsedtransaction.IsBillDispenser = ejParsedTransaction.IsDispensedFromRecycler;
                objParsedtransaction.Save();

                ///To integrate with View360BusinessRuleProcessor
                if (!ejParsedTransaction.IsDispensedFromRecycler.Value)
                {
                    ParserPostProcessingTask parserPostProcessingTask = new ParserPostProcessingTask();
                    parserPostProcessingTask.AtmId = objParsedtransaction.AtmId;
                    parserPostProcessingTask.CreationTime = DateTime.Now;
                    parserPostProcessingTask.EntityId = objParsedtransaction.ParsedTransactionId;
                    parserPostProcessingTask.EventInfo = objParsedtransaction.TrxnDatetime.ToString("MM/dd/yyyy HH:mm:ss") + "|CashWithdrawal|0|" + objParsedtransaction.CashRemaining1 + "|" + objParsedtransaction.CashRemaining2 + "|" + objParsedtransaction.CashRemaining3 + "|" + objParsedtransaction.CashRemaining4 + "|0|0|0|" + objParsedtransaction.CashDispensed1 + "|" + objParsedtransaction.CashDispensed2 + "|" + objParsedtransaction.CashDispensed3 + "|" + objParsedtransaction.CashDispensed4 + "|0|0|0|0|0|0|0|0|0|0|0|0|0|0";
                    parserPostProcessingTask.EventOccuredAt = objParsedtransaction.TrxnDatetime;
                    parserPostProcessingTask.EventType = "CashWithdrawal";
                    parserPostProcessingTask.TaskId = objParsedtransaction.TaskId;
                    parserPostProcessingTask.Save(DatabaseName.Cash);
                }
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Error, ex.Message + ex.StackTrace);
                LogableTask.LogMonoActivityTask("EjParsedTransactionMigrator--", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                throw new Exception("Error while saving/extracting transaction", ex);
            }
            finally
            {
                if (cmd != null)
                    if (cmd.Connection != null)
                        cmd.Connection.Close();
            }


        }

        public static void EjParsedReplenishmentMigrator(EjParsedReplenishments ejParsedReplenishment, SqlTransaction trxn)
        {
            SqlCommand cmd = null;
            LogableTask task = LogableTask.NewTask("EjParsedTransactionMigrator");

            try
            {
                cmd = ConnectionFactory.GetNewCommand(true, DatabaseName.Cash);
                Replenishment objReplenishment = new Replenishment();

                objReplenishment.AtmId = ejParsedReplenishment.AtmId.Value;
                objReplenishment.CashAdded1 = ejParsedReplenishment.NotesAddedType1.Value;
                objReplenishment.CashAdded2 = ejParsedReplenishment.NotesAddedType2.Value;
                objReplenishment.CashAdded3 = ejParsedReplenishment.NotesAddedType3.Value;
                objReplenishment.CashAdded4 = ejParsedReplenishment.NotesAddedType4.Value;
                objReplenishment.TaskId = ejParsedReplenishment.TaskId.Value;
                objReplenishment.RepDatetime = ejParsedReplenishment.RepDatetime;
                objReplenishment.RepStatus = "";

                //
                cmd.CommandText = "isReplenishmentInHourExists";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("RepDate", SqlDbType.DateTime));
                cmd.Parameters[0].Value = objReplenishment.RepDatetime;
                cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
                cmd.Parameters[1].Value = objReplenishment.AtmId;
                cmd.Parameters.Add(new SqlParameter("notes1", SqlDbType.Int));
                cmd.Parameters[2].Value = objReplenishment.CashAdded1;
                cmd.Parameters.Add(new SqlParameter("notes2", SqlDbType.Int));
                cmd.Parameters[3].Value = objReplenishment.CashAdded2;
                cmd.Parameters.Add(new SqlParameter("notes3", SqlDbType.Int));
                cmd.Parameters[4].Value = objReplenishment.CashAdded3;
                cmd.Parameters.Add(new SqlParameter("notes4", SqlDbType.Int));
                cmd.Parameters[5].Value = objReplenishment.CashAdded4;

                if ((int)cmd.ExecuteScalar() > 0)
                {
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Replenishment " + objReplenishment.RepDatetime.ToString() + " for Task Id " + objReplenishment.TaskId + ".because this already exists in replenishment table.");
                    return;
                }

                objReplenishment.Save(trxn.Connection, trxn);
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Error, ex.Message + ex.StackTrace);
                throw new Exception("Error while saving/extracting replenishment", ex);
            }
            finally
            {
                if (cmd != null)
                    if (cmd.Connection != null)
                        cmd.Connection.Close();
            }
        }


        private static int[] ActualDepositAfterDeductingReplenishmentCounter(SqlCommand cmd, EjParsedBnaTransaction ejParsedBNATransaction)
        {
            int[] result = new int[7];
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetLatestRecyclerReplenishment";
            cmd.Parameters.Add("@TxDate", SqlDbType.VarChar);
            cmd.Parameters.Add("@AtmId", SqlDbType.Int);
            cmd.Parameters[0].Value = ejParsedBNATransaction.TrxnDatetime.ToString("dd/MM/yyyy HH:mm:ss");
            cmd.Parameters[1].Value = ejParsedBNATransaction.AtmId;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result[0] = int.Parse(ds.Tables[0].Rows[0]["cash_added1"].ToString());
                    result[1] = int.Parse(ds.Tables[0].Rows[0]["cash_added2"].ToString());
                    result[2] = int.Parse(ds.Tables[0].Rows[0]["cash_added3"].ToString());
                    result[3] = int.Parse(ds.Tables[0].Rows[0]["cash_added4"].ToString());

                }
            }
            return result;

        }
        public static void EjParsedBNAMigrator(EjParsedBnaTransaction ejParsedBNATransaction, List<EjParsedBnaTransactionDetail> depositDetail
            , List<EjParsedBnaTransactionDetail> totalDepositDetail)
        {
            SqlCommand cmd = null;
            LogableTask task = LogableTask.NewTask("EjParsedTransactionMigrator");

            cmd = ConnectionFactory.GetNewCommand(true, DatabaseName.Cash);
            try
            {
                bool createDepositPosition = false;
                int cassette1Counter = 0;
                int cassette2Counter = 0;
                int cassette3Counter = 0;
                int cassette4Counter = 0;
                int cassette1Denomination = 0;
                int cassette1Deposited = 0;
                int cassette2Denomination = 0;
                int cassette2Deposited = 0;
                int cassette3Denomination = 0;
                int cassette3Deposited = 0;
                int cassette4Denomination = 0;
                int cassette4Deposited = 0;

                int cassette1Remaining = 0;
                int cassette2Remaining = 0;
                int cassette3Remaining = 0;
                int cassette4Remaining = 0;
                int rejectedCounters = 0;

                Atm atm = Atm.LoadAtmByPk(ejParsedBNATransaction.AtmId);
                NoteSetType noteSetType = NoteSetType.LoadNoteSetTypeByPk(atm.NoteSetTypeId);
                int[] noteSetTypeArray = { noteSetType.DenominationType1.Value, noteSetType.DenominationType2.Value, noteSetType.DenominationType3.Value, noteSetType.DenominationType4.Value };
                int[] replenishment = ActualDepositAfterDeductingReplenishmentCounter(cmd, ejParsedBNATransaction);
                if (depositDetail != null)
                {
                    for (int i = 0; i < depositDetail.Count; i++)
                    {
                        if (depositDetail[i].NoteType == noteSetTypeArray[0])
                        {
                            //cassette1Counter += depositDetail[i].NotesCount < 0 ? depositDetail[i].NotesCount * -1 : depositDetail[i].NotesCount - replenishment[0];

                            //if (depositDetail[i].NotesCount > 0)
                            cassette1Counter = depositDetail[i].NotesCount;
                            //else
                            //   cassette1Remaining = depositDetail[i].NotesCount * -1;

                            cassette1Denomination = noteSetTypeArray[0];
                            //cassette1Deposited = cassette1Counter;

                            //cassette1Remaining += depositDetail[i].NotesCount < 0 ? 0 : depositDetail[i].NotesCount - replenishment[0];

                            //if (cassette1Remaining < 0)
                            //    cassette1Remaining = cassette1Remaining * -1;

                            //if (cassette1Deposited < 0)
                            //    cassette1Deposited = cassette1Deposited * -1;

                        }

                        else if (depositDetail[i].NoteType == noteSetTypeArray[1])
                        {
                            //                            cassette2Counter += depositDetail[i].NotesCount < 0 ? depositDetail[i].NotesCount * -1 : depositDetail[i].NotesCount - replenishment[1];
                            //if (depositDetail[i].NotesCount > 0)
                            cassette2Counter = depositDetail[i].NotesCount;
                            //else
                            //  cassette2Remaining = depositDetail[i].NotesCount * -1;
                            cassette2Denomination = noteSetTypeArray[1];
                            //cassette2Deposited = cassette2Counter;
                            //cassette2Remaining += depositDetail[i].NotesCount < 0 ? 0 : depositDetail[i].NotesCount - replenishment[1];

                            //if (cassette2Remaining < 0)
                            //    cassette2Remaining = cassette2Remaining * -1;

                            //if (cassette2Deposited < 0)
                            //    cassette2Deposited = cassette2Deposited * -1;

                        }

                        else if (depositDetail[i].NoteType == noteSetTypeArray[2])
                        {
                            //                            cassette3Counter += depositDetail[i].NotesCount < 0 ? depositDetail[i].NotesCount * -1 : depositDetail[i].NotesCount - replenishment[2];

                            //if (depositDetail[i].NotesCount > 0)
                            cassette3Counter = depositDetail[i].NotesCount;
                            //else
                            //  cassette3Remaining= depositDetail[i].NotesCount * -1;

                            cassette3Denomination = noteSetTypeArray[2];
                            //cassette3Deposited = cassette3Counter;
                            //cassette3Remaining += depositDetail[i].NotesCount < 0 ? 0 : depositDetail[i].NotesCount - replenishment[2];

                            //if (cassette3Remaining < 0)
                            //    cassette3Remaining = cassette3Remaining * -1;

                            //if (cassette3Deposited < 0)
                            //    cassette3Deposited = cassette3Deposited * -1;

                        }

                        else if (depositDetail[i].NoteType == noteSetTypeArray[3])
                        {
                            //                            cassette4Counter += depositDetail[i].NotesCount < 0 ? depositDetail[i].NotesCount * -1 : depositDetail[i].NotesCount - replenishment[3];

                            //if (depositDetail[i].NotesCount > 0)
                            cassette4Counter = depositDetail[i].NotesCount;
                            //else
                            //  cassette4Remaining += depositDetail[i].NotesCount * -1;

                            cassette4Denomination = noteSetTypeArray[3];
                            //cassette4Deposited = cassette4Counter;
                            //cassette4Remaining += depositDetail[i].NotesCount < 0 ? 0 : depositDetail[i].NotesCount - replenishment[3];

                            //if (cassette4Remaining < 0)
                            //    cassette4Remaining = cassette4Remaining * -1;

                            //if (cassette4Deposited < 0)
                            //    cassette4Deposited = cassette4Deposited * -1;

                        }

                    }
                }

                if (totalDepositDetail != null)
                {
                    //Remaining = Rejected to avoid updating colunn in db...
                    for (int i = 0; i < totalDepositDetail.Count; i++)
                    {
                        if (totalDepositDetail[i].NoteType == noteSetTypeArray[0])
                        {
                            if (totalDepositDetail[i].NotesCount > 0)
                                cassette1Deposited = totalDepositDetail[i].NotesCount;
                            else
                                cassette1Remaining = totalDepositDetail[i].NotesCount * -1;
                        }
                        else if (totalDepositDetail[i].NoteType == noteSetTypeArray[1])
                        {
                            if (totalDepositDetail[i].NotesCount > 0)
                                cassette2Deposited = totalDepositDetail[i].NotesCount;
                            else
                                cassette2Remaining = totalDepositDetail[i].NotesCount * -1;
                        }
                        else if (totalDepositDetail[i].NoteType == noteSetTypeArray[2])
                        {
                            if (totalDepositDetail[i].NotesCount > 0)
                                cassette3Deposited = totalDepositDetail[i].NotesCount;
                            else
                                cassette3Remaining = totalDepositDetail[i].NotesCount * -1;
                        }
                        else if (totalDepositDetail[i].NoteType == noteSetTypeArray[3])
                        {
                            if (totalDepositDetail[i].NotesCount > 0)
                                cassette4Deposited = totalDepositDetail[i].NotesCount;
                            else
                                cassette4Remaining = totalDepositDetail[i].NotesCount * -1;
                        }


                    }
                }

                DepositPosition DepositPositionObj = DepositPosition.LoadDepositPosition("atm_id =" + ejParsedBNATransaction.AtmId);

                if (DepositPositionObj != null)
                {
                    if (DepositPositionObj.LastBnaDepositAt > ejParsedBNATransaction.TrxnDatetime)
                        createDepositPosition = false;
                    else
                        createDepositPosition = true;
                }
                else
                {
                    DepositPositionObj = new DepositPosition();
                    createDepositPosition = true;
                }

                if (createDepositPosition)
                {
                    DepositPositionObj.AtmId = ejParsedBNATransaction.AtmId;
                    DepositPositionObj.LastBnaDepositAt = ejParsedBNATransaction.TrxnDatetime;

                    if (DepositPositionObj.Cassette1Deposit == null)
                        DepositPositionObj.Cassette1Deposit = cassette1Counter;
                    else
                        DepositPositionObj.Cassette1Deposit += cassette1Counter;

                    if (DepositPositionObj.Cassette2Deposit == null)
                        DepositPositionObj.Cassette2Deposit = cassette2Counter;
                    else
                        DepositPositionObj.Cassette2Deposit += cassette2Counter;

                    if (DepositPositionObj.Cassette3Deposit == null)
                        DepositPositionObj.Cassette3Deposit = cassette3Counter;
                    else
                        DepositPositionObj.Cassette3Deposit += cassette3Counter;

                    if (DepositPositionObj.Cassette4Deposit == null)
                        DepositPositionObj.Cassette4Deposit = cassette4Counter;
                    else
                        DepositPositionObj.Cassette4Deposit += cassette4Counter;

                    DepositPositionObj.Save();
                }

                cmd.CommandText = "isBNATrxnInIntervalExists";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("trxnDatetime", SqlDbType.DateTime));
                cmd.Parameters[0].Value = ejParsedBNATransaction.TrxnDatetime;
                cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
                cmd.Parameters[1].Value = ejParsedBNATransaction.AtmId;
                cmd.Parameters.Add(new SqlParameter("intervalInSeconds", SqlDbType.Int));
                cmd.Parameters[2].Value = TrxnsMarginalIntervalInSeconds;
                if ((int)cmd.ExecuteScalar() > 0)
                {
                    LogableTask.LogMonoActivityTask("BNAMigrate", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Transaction " + ejParsedBNATransaction.TrxnDatetime.ToString() + " for Task Id " + ejParsedBNATransaction.TaskId + ".because this already exists in parsed_bna_counter table.");
                    return;
                }
                ParsedBnaCounter objParsedBNACounter = new ParsedBnaCounter();
                objParsedBNACounter.AtmId = ejParsedBNATransaction.AtmId;
                objParsedBNACounter.TaskId = ejParsedBNATransaction.TaskId;
                objParsedBNACounter.LastDepositAt = ejParsedBNATransaction.TrxnDatetime;
                objParsedBNACounter.Cassette1Counter1 = cassette1Counter;
                objParsedBNACounter.Cassette2Counter1 = cassette2Counter;
                objParsedBNACounter.Cassette3Counter1 = cassette3Counter;
                objParsedBNACounter.Cassette4Counter1 = cassette4Counter;
                objParsedBNACounter.PurgeCounter1 = 0;
                ///<Summary>
                ///Edited by Ali Shah on 2nd July, 2016
                ///As BNA Counters were not displaying on CCMS UI
                objParsedBNACounter.Cassette1Counter2 = 0;
                objParsedBNACounter.Cassette1Counter3 = 0;
                objParsedBNACounter.Cassette1Counter4 = 0;
                objParsedBNACounter.Cassette1Counter5 = 0;
                objParsedBNACounter.Cassette1Counter6 = 0;
                objParsedBNACounter.Cassette1Counter7 = 0;
                objParsedBNACounter.Cassette1Counter8 = 0;
                objParsedBNACounter.Cassette1Counter9 = 0;
                objParsedBNACounter.Cassette1Counter10 = 0;
                objParsedBNACounter.Cassette1Counter11 = 0;
                objParsedBNACounter.Cassette1Counter12 = 0;
                objParsedBNACounter.Cassette1Counter13 = 0;
                objParsedBNACounter.Cassette1Counter14 = 0;
                objParsedBNACounter.Cassette1Counter15 = 0;
                objParsedBNACounter.Cassette1Counter16 = 0;
                objParsedBNACounter.Cassette1Counter17 = 0;
                objParsedBNACounter.Cassette1Counter18 = 0;
                objParsedBNACounter.Cassette1Counter19 = 0;
                objParsedBNACounter.Cassette1Counter20 = 0;
                objParsedBNACounter.Cassette1Counter21 = 0;
                objParsedBNACounter.Cassette1Counter22 = 0;
                objParsedBNACounter.Cassette1Counter23 = 0;
                objParsedBNACounter.Cassette1Counter24 = 0;
                objParsedBNACounter.Cassette1Counter25 = 0;
                objParsedBNACounter.Cassette1Counter26 = 0;
                objParsedBNACounter.Cassette1Counter27 = 0;
                objParsedBNACounter.Cassette1Counter28 = 0;
                objParsedBNACounter.Cassette1Counter29 = 0;
                objParsedBNACounter.Cassette1Counter30 = 0;
                objParsedBNACounter.Cassette1Counter31 = 0;
                objParsedBNACounter.Cassette1Counter32 = 0;
                objParsedBNACounter.Cassette1Counter33 = 0;
                objParsedBNACounter.Cassette1Counter34 = 0;
                objParsedBNACounter.Cassette1Counter35 = 0;
                objParsedBNACounter.Cassette1Counter36 = 0;
                objParsedBNACounter.Cassette1Counter37 = 0;
                objParsedBNACounter.Cassette1Counter38 = 0;
                objParsedBNACounter.Cassette1Counter39 = 0;
                objParsedBNACounter.Cassette1Counter40 = 0;
                objParsedBNACounter.Cassette1Counter41 = 0;
                objParsedBNACounter.Cassette1Counter42 = 0;
                objParsedBNACounter.Cassette1Counter43 = 0;
                objParsedBNACounter.Cassette1Counter44 = 0;
                objParsedBNACounter.Cassette1Counter45 = 0;
                objParsedBNACounter.Cassette1Counter46 = 0;
                objParsedBNACounter.Cassette1Counter47 = 0;
                objParsedBNACounter.Cassette1Counter48 = 0;
                objParsedBNACounter.Cassette1Counter49 = 0;
                objParsedBNACounter.Cassette1Counter50 = 0;

                ///


                objParsedBNACounter.Cassette2Counter2 = 0;
                objParsedBNACounter.Cassette2Counter3 = 0;
                objParsedBNACounter.Cassette2Counter4 = 0;
                objParsedBNACounter.Cassette2Counter5 = 0;
                objParsedBNACounter.Cassette2Counter6 = 0;
                objParsedBNACounter.Cassette2Counter7 = 0;
                objParsedBNACounter.Cassette2Counter8 = 0;
                objParsedBNACounter.Cassette2Counter9 = 0;
                objParsedBNACounter.Cassette2Counter10 = 0;
                objParsedBNACounter.Cassette2Counter11 = 0;
                objParsedBNACounter.Cassette2Counter12 = 0;
                objParsedBNACounter.Cassette2Counter13 = 0;
                objParsedBNACounter.Cassette2Counter14 = 0;
                objParsedBNACounter.Cassette2Counter15 = 0;
                objParsedBNACounter.Cassette2Counter16 = 0;
                objParsedBNACounter.Cassette2Counter17 = 0;
                objParsedBNACounter.Cassette2Counter18 = 0;
                objParsedBNACounter.Cassette2Counter19 = 0;
                objParsedBNACounter.Cassette2Counter20 = 0;
                objParsedBNACounter.Cassette2Counter21 = 0;
                objParsedBNACounter.Cassette2Counter22 = 0;
                objParsedBNACounter.Cassette2Counter23 = 0;
                objParsedBNACounter.Cassette2Counter24 = 0;
                objParsedBNACounter.Cassette2Counter25 = 0;
                objParsedBNACounter.Cassette2Counter26 = 0;
                objParsedBNACounter.Cassette2Counter27 = 0;
                objParsedBNACounter.Cassette2Counter28 = 0;
                objParsedBNACounter.Cassette2Counter29 = 0;
                objParsedBNACounter.Cassette2Counter30 = 0;
                objParsedBNACounter.Cassette2Counter31 = 0;
                objParsedBNACounter.Cassette2Counter32 = 0;
                objParsedBNACounter.Cassette2Counter33 = 0;
                objParsedBNACounter.Cassette2Counter34 = 0;
                objParsedBNACounter.Cassette2Counter35 = 0;
                objParsedBNACounter.Cassette2Counter36 = 0;
                objParsedBNACounter.Cassette2Counter37 = 0;
                objParsedBNACounter.Cassette2Counter38 = 0;
                objParsedBNACounter.Cassette2Counter39 = 0;
                objParsedBNACounter.Cassette2Counter40 = 0;
                objParsedBNACounter.Cassette2Counter41 = 0;
                objParsedBNACounter.Cassette2Counter42 = 0;
                objParsedBNACounter.Cassette2Counter43 = 0;
                objParsedBNACounter.Cassette2Counter44 = 0;
                objParsedBNACounter.Cassette2Counter45 = 0;
                objParsedBNACounter.Cassette2Counter46 = 0;
                objParsedBNACounter.Cassette2Counter47 = 0;
                objParsedBNACounter.Cassette2Counter48 = 0;
                objParsedBNACounter.Cassette2Counter49 = 0;
                objParsedBNACounter.Cassette2Counter50 = 0;

                objParsedBNACounter.Cassette3Counter2 = 0;
                objParsedBNACounter.Cassette3Counter3 = 0;
                objParsedBNACounter.Cassette3Counter4 = 0;
                objParsedBNACounter.Cassette3Counter5 = 0;
                objParsedBNACounter.Cassette3Counter6 = 0;
                objParsedBNACounter.Cassette3Counter7 = 0;
                objParsedBNACounter.Cassette3Counter8 = 0;
                objParsedBNACounter.Cassette3Counter9 = 0;
                objParsedBNACounter.Cassette3Counter10 = 0;
                objParsedBNACounter.Cassette3Counter11 = 0;
                objParsedBNACounter.Cassette3Counter12 = 0;
                objParsedBNACounter.Cassette3Counter13 = 0;
                objParsedBNACounter.Cassette3Counter14 = 0;
                objParsedBNACounter.Cassette3Counter15 = 0;
                objParsedBNACounter.Cassette3Counter16 = 0;
                objParsedBNACounter.Cassette3Counter17 = 0;
                objParsedBNACounter.Cassette3Counter18 = 0;
                objParsedBNACounter.Cassette3Counter19 = 0;
                objParsedBNACounter.Cassette3Counter20 = 0;
                objParsedBNACounter.Cassette3Counter21 = 0;
                objParsedBNACounter.Cassette3Counter22 = 0;
                objParsedBNACounter.Cassette3Counter23 = 0;
                objParsedBNACounter.Cassette3Counter24 = 0;
                objParsedBNACounter.Cassette3Counter25 = 0;
                objParsedBNACounter.Cassette3Counter26 = 0;
                objParsedBNACounter.Cassette3Counter27 = 0;
                objParsedBNACounter.Cassette3Counter28 = 0;
                objParsedBNACounter.Cassette3Counter29 = 0;
                objParsedBNACounter.Cassette3Counter30 = 0;
                objParsedBNACounter.Cassette3Counter31 = 0;
                objParsedBNACounter.Cassette3Counter32 = 0;
                objParsedBNACounter.Cassette3Counter33 = 0;
                objParsedBNACounter.Cassette3Counter34 = 0;
                objParsedBNACounter.Cassette3Counter35 = 0;
                objParsedBNACounter.Cassette3Counter36 = 0;
                objParsedBNACounter.Cassette3Counter37 = 0;
                objParsedBNACounter.Cassette3Counter38 = 0;
                objParsedBNACounter.Cassette3Counter39 = 0;
                objParsedBNACounter.Cassette3Counter40 = 0;
                objParsedBNACounter.Cassette3Counter41 = 0;
                objParsedBNACounter.Cassette3Counter42 = 0;
                objParsedBNACounter.Cassette3Counter43 = 0;
                objParsedBNACounter.Cassette3Counter44 = 0;
                objParsedBNACounter.Cassette3Counter45 = 0;
                objParsedBNACounter.Cassette3Counter46 = 0;
                objParsedBNACounter.Cassette3Counter47 = 0;
                objParsedBNACounter.Cassette3Counter48 = 0;
                objParsedBNACounter.Cassette3Counter49 = 0;
                objParsedBNACounter.Cassette3Counter50 = 0;

                objParsedBNACounter.Cassette4Counter2 = 0;
                objParsedBNACounter.Cassette4Counter3 = 0;
                objParsedBNACounter.Cassette4Counter4 = 0;
                objParsedBNACounter.Cassette4Counter5 = 0;
                objParsedBNACounter.Cassette4Counter6 = 0;
                objParsedBNACounter.Cassette4Counter7 = 0;
                objParsedBNACounter.Cassette4Counter8 = 0;
                objParsedBNACounter.Cassette4Counter9 = 0;
                objParsedBNACounter.Cassette4Counter10 = 0;
                objParsedBNACounter.Cassette4Counter11 = 0;
                objParsedBNACounter.Cassette4Counter12 = 0;
                objParsedBNACounter.Cassette4Counter13 = 0;
                objParsedBNACounter.Cassette4Counter14 = 0;
                objParsedBNACounter.Cassette4Counter15 = 0;
                objParsedBNACounter.Cassette4Counter16 = 0;
                objParsedBNACounter.Cassette4Counter17 = 0;
                objParsedBNACounter.Cassette4Counter18 = 0;
                objParsedBNACounter.Cassette4Counter19 = 0;
                objParsedBNACounter.Cassette4Counter20 = 0;
                objParsedBNACounter.Cassette4Counter21 = 0;
                objParsedBNACounter.Cassette4Counter22 = 0;
                objParsedBNACounter.Cassette4Counter23 = 0;
                objParsedBNACounter.Cassette4Counter24 = 0;
                objParsedBNACounter.Cassette4Counter25 = 0;
                objParsedBNACounter.Cassette4Counter26 = 0;
                objParsedBNACounter.Cassette4Counter27 = 0;
                objParsedBNACounter.Cassette4Counter28 = 0;
                objParsedBNACounter.Cassette4Counter29 = 0;
                objParsedBNACounter.Cassette4Counter30 = 0;
                objParsedBNACounter.Cassette4Counter31 = 0;
                objParsedBNACounter.Cassette4Counter32 = 0;
                objParsedBNACounter.Cassette4Counter33 = 0;
                objParsedBNACounter.Cassette4Counter34 = 0;
                objParsedBNACounter.Cassette4Counter35 = 0;
                objParsedBNACounter.Cassette4Counter36 = 0;
                objParsedBNACounter.Cassette4Counter37 = 0;
                objParsedBNACounter.Cassette4Counter38 = 0;
                objParsedBNACounter.Cassette4Counter39 = 0;
                objParsedBNACounter.Cassette4Counter40 = 0;
                objParsedBNACounter.Cassette4Counter41 = 0;
                objParsedBNACounter.Cassette4Counter42 = 0;
                objParsedBNACounter.Cassette4Counter43 = 0;
                objParsedBNACounter.Cassette4Counter44 = 0;
                objParsedBNACounter.Cassette4Counter45 = 0;
                objParsedBNACounter.Cassette4Counter46 = 0;
                objParsedBNACounter.Cassette4Counter47 = 0;
                objParsedBNACounter.Cassette4Counter48 = 0;
                objParsedBNACounter.Cassette4Counter49 = 0;
                objParsedBNACounter.Cassette4Counter50 = 0;

                objParsedBNACounter.PurgeCounter2 = 0;
                objParsedBNACounter.PurgeCounter3 = 0;
                objParsedBNACounter.PurgeCounter4 = 0;
                objParsedBNACounter.PurgeCounter5 = 0;
                objParsedBNACounter.PurgeCounter6 = 0;
                objParsedBNACounter.PurgeCounter7 = 0;
                objParsedBNACounter.PurgeCounter8 = 0;
                objParsedBNACounter.PurgeCounter9 = 0;
                objParsedBNACounter.PurgeCounter10 = 0;
                objParsedBNACounter.PurgeCounter11 = 0;
                objParsedBNACounter.PurgeCounter12 = 0;
                objParsedBNACounter.PurgeCounter13 = 0;
                objParsedBNACounter.PurgeCounter14 = 0;
                objParsedBNACounter.PurgeCounter15 = 0;
                objParsedBNACounter.PurgeCounter16 = 0;
                objParsedBNACounter.PurgeCounter17 = 0;
                objParsedBNACounter.PurgeCounter18 = 0;
                objParsedBNACounter.PurgeCounter19 = 0;
                objParsedBNACounter.PurgeCounter20 = 0;
                objParsedBNACounter.PurgeCounter21 = 0;
                objParsedBNACounter.PurgeCounter22 = 0;
                objParsedBNACounter.PurgeCounter23 = 0;
                objParsedBNACounter.PurgeCounter24 = 0;
                objParsedBNACounter.PurgeCounter25 = 0;
                objParsedBNACounter.PurgeCounter26 = 0;
                objParsedBNACounter.PurgeCounter27 = 0;
                objParsedBNACounter.PurgeCounter28 = 0;
                objParsedBNACounter.PurgeCounter29 = 0;
                objParsedBNACounter.PurgeCounter30 = 0;
                objParsedBNACounter.PurgeCounter31 = 0;
                objParsedBNACounter.PurgeCounter32 = 0;
                objParsedBNACounter.PurgeCounter33 = 0;
                objParsedBNACounter.PurgeCounter34 = 0;
                objParsedBNACounter.PurgeCounter35 = 0;
                objParsedBNACounter.PurgeCounter36 = 0;
                objParsedBNACounter.PurgeCounter37 = 0;
                objParsedBNACounter.PurgeCounter38 = 0;
                objParsedBNACounter.PurgeCounter39 = 0;
                objParsedBNACounter.PurgeCounter40 = 0;
                objParsedBNACounter.PurgeCounter41 = 0;
                objParsedBNACounter.PurgeCounter42 = 0;
                objParsedBNACounter.PurgeCounter43 = 0;
                objParsedBNACounter.PurgeCounter44 = 0;
                objParsedBNACounter.PurgeCounter45 = 0;
                objParsedBNACounter.PurgeCounter46 = 0;
                objParsedBNACounter.PurgeCounter47 = 0;
                objParsedBNACounter.PurgeCounter48 = 0;
                objParsedBNACounter.PurgeCounter49 = 0;
                objParsedBNACounter.PurgeCounter50 = 0;


                objParsedBNACounter.DenominationType1 = cassette1Denomination;
                objParsedBNACounter.DenominationType1Remaining = cassette1Remaining;
                objParsedBNACounter.DenominationType1Deposited = cassette1Deposited;

                objParsedBNACounter.DenominationType2 = cassette2Denomination;
                objParsedBNACounter.DenominationType2Remaining = cassette2Remaining;
                objParsedBNACounter.DenominationType2Deposited = cassette2Deposited;

                objParsedBNACounter.DenominationType3 = cassette3Denomination;
                objParsedBNACounter.DenominationType3Remaining = cassette3Remaining;
                objParsedBNACounter.DenominationType3Deposited = cassette3Deposited;

                objParsedBNACounter.DenominationType4 = cassette4Denomination;
                objParsedBNACounter.DenominationType4Remaining = cassette4Remaining;
                objParsedBNACounter.DenominationType4Deposited = cassette4Deposited;

                objParsedBNACounter.Save();


            }
            finally
            {
                if (cmd != null)
                    if (cmd.Connection != null)
                        cmd.Connection.Close();
            }
        }

        public static void EjParsedCPMMigrator(EjParsedCpmTransaction ejParsedCPMTransaction, int counters, SqlTransaction trxn)
        {
            //      DepositPosition DepositPositionObj = DepositPosition.LoadDepositPosition("atm_id =" + ejParsedCPMTransaction.AtmId + " and ((last_bna_deposit_at >=convert(datetime,'" + ejParsedCPMTransaction.TrxnDatetime.Value.ToString("dd/MM/yyyy") + "',103) " +
            //    " and last_bna_deposit_at <=convert(datetime,'" + ejParsedCPMTransaction.TrxnDatetime.Value.ToString("dd/MM/yyyy") + " 23:59:59',103)) Or (last_cpm_deposit_at >=convert(datetime,'" + ejParsedCPMTransaction.TrxnDatetime.Value.ToString("dd/MM/yyyy") + "',103) " +
            //" and last_cpm_deposit_at <=convert(datetime,'" + ejParsedCPMTransaction.TrxnDatetime.Value.ToString("dd/MM/yyyy") + " 23:59:59',103)))");
            DepositPosition DepositPositionObj = DepositPosition.LoadDepositPosition("atm_id =" + ejParsedCPMTransaction.AtmId);

            if (DepositPositionObj == null)
                DepositPositionObj = new DepositPosition();

            DepositPositionObj.AtmId = ejParsedCPMTransaction.AtmId;
            DepositPositionObj.LastCpmDepositAt = ejParsedCPMTransaction.TrxnDatetime;

            if (DepositPositionObj.Bin1 == null)
                DepositPositionObj.Bin1 = counters;
            else
                DepositPositionObj.Bin1 += counters;
            DepositPositionObj.Save(trxn.Connection, trxn);

            ///<Summary>
            ///Edited by Ali Shah on 01st Oct, 2020.
            ///ParserBNACounter entry will be made for ATMs running on Windows 7 as they are not having Multi-Vendor agent
            ///Hence no handling of reading counters and parsed through CurrencyParser.
            //Atm atm = Atm.LoadAtmByPk(ejParsedCPMTransaction.AtmId);

            //if (atm.AtmType.ToLower().Contains("win") && atm.AtmType.Contains("7"))
            //{
            //    ParsedCpmCounter objParsedCPMCounter = new ParsedCpmCounter();
            //    objParsedCPMCounter.AtmId = ejParsedCPMTransaction.AtmId;
            //    objParsedCPMCounter.TaskId = ejParsedCPMTransaction.TaskId;
            //    objParsedCPMCounter.DepositAt = ejParsedCPMTransaction.TrxnDatetime.Value;
            //    objParsedCPMCounter.Bin1 = counters;

            //    objParsedCPMCounter.Save(trxn.Connection, trxn);
            //}

            //trxn.Commit();
        }

        public static void ClearBNACounter(DateTime trxnDatetime, int atmid, SqlTransaction trxn)
        {
            //      DepositPosition DepositPositionObj = DepositPosition.LoadDepositPosition("atm_id =" + atmid + " and ((last_bna_deposit_at >=convert(datetime,'" + trxnDatetime.ToString("dd/MM/yyyy") + "',103) " +
            //    " and last_bna_deposit_at <=convert(datetime,'" + trxnDatetime.ToString("dd/MM/yyyy") + " 23:59:59',103)) Or (last_cpm_deposit_at >=convert(datetime,'" + trxnDatetime.ToString("dd/MM/yyyy") + "',103) " +
            //" and last_cpm_deposit_at <=convert(datetime,'" + trxnDatetime.ToString("dd/MM/yyyy") + " 23:59:59',103)))");
            DepositPosition DepositPositionObj = DepositPosition.LoadDepositPosition("atm_id =" + atmid);
            //Edited by Ali Shah on 29th June, 2016
            //This was throwing error "Object reference not set to an instance of an object
            if (DepositPositionObj == null)
            {
                DepositPositionObj = new DepositPosition();
                DepositPositionObj.AtmId = atmid;
                DepositPositionObj.LastBnaDepositAt = trxnDatetime;
            }
            //if (DepositPositionObj != null)
            {
                DepositPositionObj.Cassette1Deposit = 0;
                DepositPositionObj.Cassette2Deposit = 0;
                DepositPositionObj.Cassette3Deposit = 0;
                DepositPositionObj.Cassette4Deposit = 0;
                //DepositPositionObj.LastBnaDepositAt = DateTime.Now;
                //DepositPositionObj.LastBnaDepositAt = trxnDatetime;
            }
            DepositPositionObj.Save(trxn.Connection, trxn);
            //trxn.Commit();
        }

        public static void ClearCPMCounter(DateTime trxnDatetime, int atmid, SqlTransaction trxn)
        {
            //      DepositPosition DepositPositionObj = DepositPosition.LoadDepositPosition("atm_id =" + atmid + " and ((last_bna_deposit_at >=convert(datetime,'" + trxnDatetime.ToString("dd/MM/yyyy") + "',103) " +
            //    " and last_bna_deposit_at <=convert(datetime,'" + trxnDatetime.ToString("dd/MM/yyyy") + " 23:59:59',103)) Or (last_cpm_deposit_at >=convert(datetime,'" + trxnDatetime.ToString("dd/MM/yyyy") + "',103) " +
            //" and last_cpm_deposit_at <=convert(datetime,'" + trxnDatetime.ToString("dd/MM/yyyy") + " 23:59:59',103)))");
            DepositPosition DepositPositionObj = DepositPosition.LoadDepositPosition("atm_id =" + atmid);

            //Edited by Ali Shah on 29th June, 2016
            //This was throwing error "Object reference not set to an instance of an object
            if (DepositPositionObj == null)
            {
                DepositPositionObj = new DepositPosition();
                DepositPositionObj.AtmId = atmid;
                DepositPositionObj.LastCpmDepositAt = trxnDatetime;
            }
            //if (DepositPositionObj != null)
            {
                DepositPositionObj.Bin1 = 0;
                DepositPositionObj.Bin2 = 0;
                DepositPositionObj.Bin3 = 0;
                DepositPositionObj.Bin4 = 0;

                //DepositPositionObj.LastCpmDepositAt = DateTime.Now;
                //DepositPositionObj.LastCpmDepositAt = trxnDatetime;
            }
            DepositPositionObj.Save(trxn.Connection, trxn);
            //trxn.Commit();
        }
    }
}
