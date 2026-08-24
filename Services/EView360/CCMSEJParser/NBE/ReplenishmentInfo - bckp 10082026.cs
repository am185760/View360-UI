using ServicesDAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;


namespace Avanza.CCMS.Parser
{
    public class ReplenishmentExtractor
    {
        string[] TimeFormat = { "MM/dd/yyyyHH:mm", "dd/MM/yyyyHH:mm" };
        Regex regexPrintCounters = new Regex(@"((DATE-TIME[ ]+=(?<PrintCountersDateTime>\d{2}/\d{2}/\d{2}[ ]\d{2}:\d{2}))?(\r[ ]+TYPE[ ]\d[ ]+TYPE[ ]\d[ ]*\r[ ]CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)\r\+REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)\r=REMAINING[ |]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)\r\+DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)\r=TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)\r)*[ ]LAST[ ]CLEARED[ ]+(?<LastClearedDateTime>\d+/\d+/\d+[ ]\d+:\d+)\r{3}[ ]CARDS[ ]CAPTURED[ ]+(?<CardsCapturedCount>\d+))");
        private Regex regex = new Regex(@"((?<CashAddedTime>\d+/\d+/\d+\*\d+:\d+)\*[ ]*\r?\n?(C(?<Type>\d+))?[ ]*CASH[ ]ADDED[ ]*\r?\n?[ ]*(TYPE[ ]\d+[ ]=[ ]+(?<Added>\d+)[ ]*\r?\n?)+)|((?<CountsClearingTime>\d+/\d+/\d+\*\d+:\d+)\*\s*CASH[ ]COUNTS[ ]CLEARED\s*CASH[ ]DISPENSED\s*(TYPE[ ]\d[ ]=[ ](?<Dispensed>\d+)\s+)+CASH[ ]REMAINING\s*(TYPE[ ]\d[ ]=[ ](?<Remaining>\d+)\s+)+)|((DATE-TIME[ ]+=(?<PrintCountersDateTime>\d{2}/\d{2}/\d{2}[ ]\d{2}:\d{2}))?(\r[ ]+TYPE[ ]\d[ ]+TYPE[ ]\d[ ]*\r[ ]CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)\r\+REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)\r=REMAINING[ |]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)\r\+DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)\r=TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)\r)*[ ]LAST[ ]CLEARED[ ]+(?<LastClearedDateTime>\d+/\d+/\d+[ ]\d+:\d+)\r{3}[ ]CARDS[ ]CAPTURED[ ]+(?<CardsCapturedCount>\d+))");
        Regex CountsClearingRegex = new Regex(@"((?<CountsClearingTime>\d+/\d+/\d+\*\d+:\d+)\*\s*CASH[ ]COUNTS[ ]CLEARED\s*CASH[ ]DISPENSED\s*(TYPE[ ]\d[ ]=[ ](?<Dispensed>\d+)\s+)+CASH[ ]REMAINING\s*(TYPE[ ]\d[ ]=[ ](?<Remaining>\d+)\s+)+)");
        Match match;

        private Replenishment AddReplenishmentInCCMS(ref ServicesDAL.Task downloadTask, ref EjParsedReplenishments cashAdded, ref bool isSwap)
        {
            Replenishment replenishment2 = new Replenishment();
            replenishment2.AtmId = downloadTask.ATMId;
            replenishment2.RepDatetime = cashAdded.RepDatetime;
            replenishment2.CashAdded1 = cashAdded.NotesAddedType1.Value;
            replenishment2.CashAdded2 = cashAdded.NotesAddedType2.Value;
            replenishment2.CashAdded3 = cashAdded.NotesAddedType3.Value;
            replenishment2.CashAdded4 = cashAdded.NotesAddedType4.Value;
            replenishment2.CashAdded5 = 0;
            replenishment2.CashAdded6 = 0;
            replenishment2.CashAdded7 = 0;
            replenishment2.RepStatus = "Normal";
            replenishment2.IsBillDispenser = cashAdded.IsBillDispenser;
            replenishment2.IsSwap = isSwap;
            if (!isSwap)
            {
                if (replenishment2.CashAdded1 > 0 && replenishment2.CashAdded2 > 0 && replenishment2.CashAdded3 > 0 && replenishment2.CashAdded4 > 0)
                {
                    isSwap = true;
                    replenishment2.IsSwap = true;
                }
            }
            replenishment2.TaskId = downloadTask.TaskId;
            replenishment2.CashOrderId = -1;
            replenishment2.GeneratedAt = DateTime.Now;
            replenishment2.GeneratedBy = 1;
            replenishment2.Reason = cashAdded.EjParsedReplenishmentsId.ToString();
            replenishment2.LastTsn = cashAdded.LastTsn;
            replenishment2.Save();
            //Added on 11/11 to retain counts cleared status when custodian select ADD CASH by mistake.


            ParserPostProcessingTask parserPostProcessingTask = new ParserPostProcessingTask();
            parserPostProcessingTask.AtmId = replenishment2.AtmId;
            parserPostProcessingTask.CreationTime = DateTime.Now;
            parserPostProcessingTask.EntityId = replenishment2.ReplenishmentId;
            parserPostProcessingTask.EventInfo = replenishment2.RepDatetime.ToString("MM/dd/yyyy HH:mm:ss")+"|Replenishment|OrderMissing|20180513132747|20180513132747|-1|1564|0|81|1183|0|0|0|2416|0|883|783|0|0|0|20|0|36|34|0|0|0|"+replenishment2.CashAdded1+"|"+replenishment2.CashAdded2+"|"+replenishment2.CashAdded3+"|"+replenishment2.CashAdded4+"|0|0|0";
            parserPostProcessingTask.EventOccuredAt = replenishment2.RepDatetime;
            parserPostProcessingTask.EventType = "Replenishment";
            parserPostProcessingTask.TaskId = replenishment2.TaskId;
            parserPostProcessingTask.Save(DatabaseName.Cash);

            //CashOrders cashOrder = CashOrders.LoadCashOrders("atm_id = "+replenishment2.AtmId + " and cash_order_datetime in (select max(cash_order_datetime) from cash_orders where atm_id = "+replenishment2.AtmId+")");
            /*
            CashOrders cashOrder = CashOrders.LoadCashOrders("atm_id=" + replenishment2.AtmId +
                         " and replenishment_datetime>=convert(datetime,'" + replenishment2.RepDatetime.ToString("dd/MM/yyyy") + "',103) " +
                         " and replenishment_datetime<=convert(datetime,'" + replenishment2.RepDatetime.ToString("dd/MM/yyyy") + " 23:59:59',103) ");


            if (cashOrder != null)
            {
                //if (replenishment2.CashAdded1 != cashOrder.Cassette1SuggestedNotes ||
                //    replenishment2.CashAdded2 != cashOrder.Cassette2SuggestedNotes ||
                //    replenishment2.CashAdded3 != cashOrder.Cassette3SuggestedNotes ||
                //    replenishment2.CashAdded4 != cashOrder.Cassette4SuggestedNotes ||
                //    replenishment2.CashAdded5 != cashOrder.Cassette5SuggestedNotes ||
                //    replenishment2.CashAdded6 != cashOrder.Cassette6SuggestedNotes ||
                //    replenishment2.CashAdded7 != cashOrder.Cassette7SuggestedNotes)
                //{
                //    //GenerateTerminalAlert(ATM.ATMId, (int)EnumAlertType.SuspiciousReplenishment, replenishment.CashAdded1 +
                //    //    "|" + replenishment.CashAdded2 + "|" + replenishment.CashAdded3 + "|" + replenishment.CashAdded4 + "|" +
                //    //    replenishment.CashAdded5 + "|" + replenishment.CashAdded6 + "|" + replenishment.CashAdded7 + "|" +
                //    //    cashOrder.Cassette1SuggestedNotes + "|" + cashOrder.Cassette2SuggestedNotes + "|" +
                //    //    cashOrder.Cassette3SuggestedNotes + "|" + cashOrder.Cassette4SuggestedNotes + "|" +
                //    //    cashOrder.Cassette5SuggestedNotes + "|" + cashOrder.Cassette6SuggestedNotes + "|" +
                //    //    cashOrder.Cassette7SuggestedNotes

                //}
                replenishment2.CashOrderId = cashOrder.CashOrderId;
                replenishment2.Save(trxn.Connection, trxn);

                //            , trxn, Event_Type.Information, taskID, replenishment.ReplenishmentId, "Replenishment");
                //        //GenerateCCMSEvent(EventType.SuspiciousReplenishment.ToString(),
                //        //    EventType.SuspiciousReplenishment.ToString(), Event_Type.Warning.ToString(), cashOrder.OrderNumber, EntityType.Order.ToString(), Actors.ATM.ToString(), Actors.CCMS.ToString(), trxn, null);
                //    }
                //    // GenerateTerminalAlert(ATMID, (int)EnumAlertType.ATMCounterMismatch, "ATM Counter Mismatched", trxn);
                int remainingNotesInCassette1 = cashOrder.Cassette1SuggestedNotes.Value - replenishment2.CashAdded1;
                int remainingNotesInCassette2 = cashOrder.Cassette2SuggestedNotes.Value - replenishment2.CashAdded2;
                int remainingNotesInCassette3 = cashOrder.Cassette3SuggestedNotes.Value - replenishment2.CashAdded3;
                int remainingNotesInCassette4 = cashOrder.Cassette4SuggestedNotes.Value - replenishment2.CashAdded4;
                int remainingNotesInCassette5 = cashOrder.Cassette5SuggestedNotes.Value - replenishment2.CashAdded5;
                int remainingNotesInCassette6 = cashOrder.Cassette6SuggestedNotes.Value - replenishment2.CashAdded6;
                int remainingNotesInCassette7 = cashOrder.Cassette7SuggestedNotes.Value - replenishment2.CashAdded7;

                cashOrder.Cassette1RemainingNotes = (remainingNotesInCassette1 != cashOrder.Cassette1RemainingNotes ? remainingNotesInCassette1 : cashOrder.Cassette1RemainingNotes);
                cashOrder.Cassette2RemainingNotes = (remainingNotesInCassette2 != cashOrder.Cassette2RemainingNotes ? remainingNotesInCassette2 : cashOrder.Cassette2RemainingNotes);
                cashOrder.Cassette3RemainingNotes = (remainingNotesInCassette3 != cashOrder.Cassette3RemainingNotes ? remainingNotesInCassette3 : cashOrder.Cassette3RemainingNotes);
                cashOrder.Cassette4RemainingNotes = (remainingNotesInCassette4 != cashOrder.Cassette4RemainingNotes ? remainingNotesInCassette4 : cashOrder.Cassette4RemainingNotes);
                cashOrder.Cassette5RemainingNotes = (remainingNotesInCassette5 != cashOrder.Cassette5RemainingNotes ? remainingNotesInCassette5 : cashOrder.Cassette5RemainingNotes);
                cashOrder.Cassette6RemainingNotes = (remainingNotesInCassette6 != cashOrder.Cassette6RemainingNotes ? remainingNotesInCassette6 : cashOrder.Cassette6RemainingNotes);
                cashOrder.Cassette7RemainingNotes = (remainingNotesInCassette7 != cashOrder.Cassette7RemainingNotes ? remainingNotesInCassette7 : cashOrder.Cassette7RemainingNotes);
                cashOrder.LastReplenishmentAt = replenishment2.RepDatetime;
                cashOrder.Save(trxn.Connection, trxn);

                //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "cash order updated for atm : " + replenishment.AtmId);


                //CashOrderMonitoring cashOrderMonitoring = CashOrderMonitoring.LoadCashOrderMonitoring("current_order_id=" + cashOrder.CashOrderId);
                CashOrderMonitoring cashOrderMonitoring = (cashOrder.CashOrderId > 0 ?
                    CashOrderMonitoring.LoadCashOrderMonitoring("current_order_id=" + cashOrder.CashOrderId)
                    : CashOrderMonitoring.LoadCashOrderMonitoring("atm_id=" + replenishment2.AtmId +
                    " and replenishment_datetime>=convert(datetime,'" + replenishment2.RepDatetime.ToString("dd/MM/yyyy") + "',103) " +
                    " and replenishment_datetime<=convert(datetime,'" + replenishment2.RepDatetime.ToString("dd/MM/yyyy") + " 23:59:59',103)) "));

                //    if (cashOrderMonitoring == null)
                //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "cash order monitoring not found for atm : " + replenishment.AtmId
                //             + " for the date " + replenishment.RepDatetime.ToString());

                if (cashOrderMonitoring != null)
                {
                    NoteSetType noteSetType = NoteSetType.LoadNoteSetTypeByPk(Atm.LoadAtmByPk(replenishment2.AtmId).NoteSetTypeId);
                    cashOrderMonitoring.CurrentOrderRemainingAmount = (decimal)(cashOrder.Cassette1RemainingNotes * noteSetType.DenominationType1 +
                        cashOrder.Cassette2RemainingNotes * noteSetType.DenominationType2 + cashOrder.Cassette3RemainingNotes * noteSetType.DenominationType3 +
                        cashOrder.Cassette4RemainingNotes * noteSetType.DenominationType4 + cashOrder.Cassette5RemainingNotes * noteSetType.DenominationType5 +
                        cashOrder.Cassette6RemainingNotes * noteSetType.DenominationType6 + cashOrder.Cassette7RemainingNotes * noteSetType.DenominationType7);
                    cashOrderMonitoring.CurrentOrderExecutedAt = replenishment2.RepDatetime;
                    cashOrderMonitoring.Save(trxn.Connection, trxn);
     //               task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "cash order monitoring updated for atm : " + replenishment.AtmId);
                }


            }
            */

            return replenishment2;
        }

        EjParsedReplenishments ExtractCashAdd()
        {
            EjParsedReplenishments cashadded = new EjParsedReplenishments();
            DateTime date;
            DateTime.TryParseExact(match.Groups["CashAddedTime"].Captures[0].Value.Replace("*", ""), TimeFormat, null, DateTimeStyles.None, out date);
            cashadded.RepDatetime = date;
            cashadded.NotesAddedType1 = int.Parse(match.Groups["Added"].Captures[0].Value);
            cashadded.NotesAddedType2 = int.Parse(match.Groups["Added"].Captures[1].Value);
            cashadded.NotesAddedType3 = int.Parse(match.Groups["Added"].Captures[2].Value);
            
            if (match.Groups["Added"].Captures.Count > 3)
                cashadded.NotesAddedType4 = int.Parse(match.Groups["Added"].Captures[3].Value);
            else
                cashadded.NotesAddedType4 = 0;

            cashadded.IsBillDispenser = false;
            if (match.Groups["Type"].Success)
            {
                if (match.Groups["Type"].Value == "1")
                    cashadded.IsBillDispenser = true;
                else
                    cashadded.IsBillDispenser = false;
            }
            cashadded.StartIndex = match.Index;
            cashadded.EndIndex = match.Index + match.Length;
            cashadded.ProcessingDatetime = DateTime.Now;
            return cashadded;
        }

        EjNotesDispensed ExtractCashCountsClearing()
        {
            EjNotesDispensed cashcountsclear = new EjNotesDispensed();
            DateTime date;
            DateTime.TryParseExact(match.Groups["CountsClearingTime"].Captures[0].Value.Replace("*", ""), TimeFormat, null, DateTimeStyles.None, out date);
            cashcountsclear.ClearingDatetime = date;
            cashcountsclear.NotesDispensedType1 = int.Parse(match.Groups["Dispensed"].Captures[0].Value);
            cashcountsclear.NotesDispensedType2 = int.Parse(match.Groups["Dispensed"].Captures[1].Value);
            cashcountsclear.NotesDispensedType3 = int.Parse(match.Groups["Dispensed"].Captures[2].Value);
            cashcountsclear.NotesDispensedType4 = int.Parse(match.Groups["Dispensed"].Captures[3].Value);
            cashcountsclear.NotesRemainingType1 = int.Parse(match.Groups["Remaining"].Captures[0].Value);
            cashcountsclear.NotesRemainingType2 = int.Parse(match.Groups["Remaining"].Captures[1].Value);
            cashcountsclear.NotesRemainingType3 = int.Parse(match.Groups["Remaining"].Captures[2].Value);
            cashcountsclear.NotesRemainingType4 = int.Parse(match.Groups["Remaining"].Captures[3].Value);
            return cashcountsclear;
        }

     
        public void ParseAndSaveReplenishment(ref string ejData, ServicesDAL.Task downloadTask, LogableTask task)
        {
            SqlCommand cmd = null;
            try
            {
                bool isSwap = false;
                cmd = ConnectionFactory.GetNewCommand(true,DatabaseName.Tx);
                cmd.CommandTimeout = 30 * 5;
                match = regex.Match(ejData);
                EjParsedReplenishments cashAdded;
                Replenishment lastSavedReplenishment = null;
                while (match.Success)
                {
                    if (this.match.Groups["CountsClearingTime"].Success)
                    {
                        isSwap = true;
                    }
                    else if (match.Groups["PrintCountersDateTime"].Success)
                    {
                        DateTime printCounterDateTime = DateTime.ParseExact(match.Groups["PrintCountersDateTime"].Value, "MM/dd/yy HH:mm", null);
                        int[] cassette = new int[4];
                        int[] rejected = new int[4];
                        int[] remaining = new int[4];
                        int[] dispensed = new int[4];
                        int[] total = new int[4];
                        int idx = 0;
                        if (match.Groups["Cassette1"].Success) // Captures 1 & 3
                        {
                            for (int i = 0; i < 2; i++)
                                cassette[i] = int.Parse(match.Groups["Cassette1"].Captures[i].Value);
                        }
                        if (match.Groups["Cassette2"].Success) //Captured 2 & 4
                        {
                            for (int i = 2; i < 4; i++)
                                cassette[i] = int.Parse(match.Groups["Cassette2"].Captures[idx++].Value);
                        }
                        if (match.Groups["Rejected1"].Success) // Captures 1 & 3
                        {
                            for (int i = 0; i < 2; i++)
                                rejected[i] = int.Parse(match.Groups["Rejected1"].Captures[i].Value);
                        }
                        idx = 0;
                        if (match.Groups["Rejected2"].Success) //Captured 2 & 4
                        {
                            for (int i = 2; i < 4; i++)
                                rejected[i] = int.Parse(match.Groups["Rejected2"].Captures[idx++].Value);
                        }
                        if (match.Groups["Remaining1"].Success) // Captures 1 & 3
                        {
                            for (int i = 0; i < 2; i++)
                                remaining[i] = int.Parse(match.Groups["Remaining1"].Captures[i].Value);
                        }
                        idx = 0;
                        if (match.Groups["Remaining2"].Success) //Captured 2 & 4
                        {
                            for (int i = 2; i < 4; i++)
                                remaining[i] = int.Parse(match.Groups["Remaining2"].Captures[idx++].Value);
                        }
                        if (match.Groups["Dispensed1"].Success) // Captures 1 & 3
                        {
                            for (int i = 0; i < 2; i++)
                                dispensed[i] = int.Parse(match.Groups["Dispensed1"].Captures[i].Value);
                        }
                        idx = 0;
                        if (match.Groups["Dispensed1"].Success) //Captured 2 & 4
                        {
                            for (int i = 2; i < 4; i++)
                                dispensed[i] = int.Parse(match.Groups["Dispensed1"].Captures[idx++].Value);
                        }
                        if (match.Groups["Total1"].Success) // Captures 1 & 3
                        {
                            for (int i = 0; i < 2; i++)
                                total[i] = int.Parse(match.Groups["Total1"].Captures[i].Value);
                        }
                        idx = 0;
                        if (match.Groups["Total2"].Success) //Captured 2 & 4
                        {
                            for (int i = 2; i < 4; i++)
                                total[i] = int.Parse(match.Groups["Total2"].Captures[idx++].Value);
                        }
                        if (lastSavedReplenishment != null)
                        {

                        }
                    }
                    else
                    {
                        if (this.match.Groups["CashAddedTime"].Success)
                        {
                            cashAdded = ExtractCashAdd();
                            cashAdded.TaskId = downloadTask.TaskId;
                            cashAdded.AtmId = downloadTask.ATMId;

                            cmd.CommandText = "isRepCountersExists";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("RepDate", SqlDbType.DateTime));
                            cmd.Parameters[0].Value = cashAdded.RepDatetime;
                            cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
                            cmd.Parameters[1].Value = downloadTask.ATMId;
                            cmd.Parameters.Add(new SqlParameter("notes1", SqlDbType.Int));
                            cmd.Parameters[2].Value = cashAdded.NotesAddedType1;
                            cmd.Parameters.Add(new SqlParameter("notes2", SqlDbType.Int));
                            cmd.Parameters[3].Value = cashAdded.NotesAddedType2;
                            cmd.Parameters.Add(new SqlParameter("notes3", SqlDbType.Int));
                            cmd.Parameters[4].Value = cashAdded.NotesAddedType3;
                            cmd.Parameters.Add(new SqlParameter("notes4", SqlDbType.Int));
                            cmd.Parameters[5].Value = cashAdded.NotesAddedType4;
                            cmd.Parameters.Add(new SqlParameter("isBillDispenser", SqlDbType.Bit));
                            cmd.Parameters[6].Value = cashAdded.IsBillDispenser.HasValue
                                ? (object)cashAdded.IsBillDispenser.Value
                                : DBNull.Value;

                            if ((int)cmd.ExecuteScalar() > 0)
                            {
                                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Transaction  " + ejData.Substring(match.Index, match.Length) + ".because this already exists in ej_parsed_replenishment table.");
                                match = match.NextMatch();
                                isSwap = false;
                                continue;
                            }

                            if (cashAdded.NotesAddedType1 == 0 && cashAdded.NotesAddedType2 == 0 && cashAdded.NotesAddedType3 == 0 && cashAdded.NotesAddedType4 == 0)
                            {
                                cmd.CommandType = CommandType.Text;

                                string isBillDispenserCondition = cashAdded.IsBillDispenser.HasValue
                                    ? "is_bill_dispenser = " + (cashAdded.IsBillDispenser.Value ? "1" : "0")
                                    : "is_bill_dispenser is null";

                                cmd.CommandText = "delete ej_parsed_replenishments where atm_id =  " + cashAdded.AtmId
                                    + " and rep_Datetime<='" + cashAdded.RepDatetime.ToString("yyyy-MM-dd HH:mm:ss") +
                                    "' and rep_datetime>='" + cashAdded.RepDatetime.AddHours(-2).ToString("yyyy-MM-dd HH:mm:ss") + "' and " + isBillDispenserCondition;
                                                                
                                cmd.ExecuteNonQuery();
                                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Transaction  " + ejData.Substring(match.Index, match.Length) + ".because all counters are 0.");
                                match = match.NextMatch();
                                continue;
                            }
                            cashAdded.LastTsn = null;// Last_TSN_Extraction(ref cashAdded);
//                            cashAdded.Save(trxn.Connection, trxn);
                            cashAdded.Save();

                            //Replenishment replenishment = Replenishment.LoadReplenishment("atm_id = " + downloadTask.ATMId + " and rep_datetime>=convert(datetime,'" + cashAdded.RepDatetime.ToString("dd/MM/yyyy HH:mm:ss") + "',103)  and rep_datetime<=convert(datetime,'" + cashAdded.RepDatetime.AddMinutes(20).ToString("dd/MM/yyyy HH:mm:ss") + "',103)");

                            string _isBillDispenserCondition = cashAdded.IsBillDispenser.HasValue? " and isBillDispenser = " + (cashAdded.IsBillDispenser.Value ? "1" : "0"): " and isBillDispenser is null";

                            Replenishment replenishment = Replenishment.LoadReplenishment(
                                "atm_id = " + downloadTask.ATMId
                                + " and rep_datetime>=convert(datetime,'" + cashAdded.RepDatetime.ToString("dd/MM/yyyy HH:mm:ss") + "',103)"
                                + " and rep_datetime<=convert(datetime,'" + cashAdded.RepDatetime.AddMinutes(20).ToString("dd/MM/yyyy HH:mm:ss") + "',103)"
                                + _isBillDispenserCondition);

                            if (replenishment == null) // This means Replenishment not inserted by EJ & Counters also so insert it
                            {
                                lastSavedReplenishment = this.AddReplenishmentInCCMS(ref downloadTask, ref cashAdded,ref isSwap);
                                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "extracting replenishment " + this.match.ToString());
                                isSwap = false;
                            }
                            else
                            {
                                if (replenishment.Reason != null)
                                {
                                    //If it's extracted from EJ then update it.
                                    if (isSwap)
                                    {
                                        replenishment.CashAdded1 = cashAdded.NotesAddedType1.Value;
                                        replenishment.CashAdded2 = cashAdded.NotesAddedType2.Value;
                                        replenishment.CashAdded3 = cashAdded.NotesAddedType3.Value;
                                        replenishment.CashAdded4 = cashAdded.NotesAddedType4.Value;
                                    }
                                    else
                                    {
                                        replenishment.CashAdded1 += cashAdded.NotesAddedType1.Value;
                                        replenishment.CashAdded2 += cashAdded.NotesAddedType2.Value;
                                        replenishment.CashAdded3 += cashAdded.NotesAddedType3.Value;
                                        replenishment.CashAdded4 += cashAdded.NotesAddedType4.Value;
                                    }
                                    replenishment.IsSwap = isSwap;
//                                    replenishment.Save(trxn.Connection, trxn);
                                    replenishment.Save();

                                    lastSavedReplenishment = replenishment;
                                    isSwap = false;
                                }
                                else
                                {
                                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Replenishment already extracted from counters so ignoring it for atm " + replenishment.AtmId + " for the date " + replenishment.RepDatetime);
                                }
                            }
                        }
                    }
                    match = match.NextMatch();
                }
                match = CountsClearingRegex.Match(ejData);
                EjNotesDispensed cashCountClear;

                while (match.Success)
                {
                    cashCountClear = ExtractCashCountsClearing();
                    cmd.CommandText = "isEjClearingCounterExists";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("DisDate", SqlDbType.DateTime));
                    cmd.Parameters[0].Value = cashCountClear.ClearingDatetime;
                    cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
                    cmd.Parameters[1].Value = downloadTask.ATMId;
                    if ((int)cmd.ExecuteScalar() > 0)
                    {
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Transaction  " + ejData.Substring(match.Index, match.Length) + ".because this already exists in dispensed table.");
                        match = match.NextMatch();
                        continue;
                    }

                    cashCountClear.TaskId = downloadTask.TaskId;
                    cashCountClear.AtmId = downloadTask.ATMId;
                    //    cashCountClear.Save(trxn.Connection, trxn);
                    cashCountClear.Save();

                    match = match.NextMatch();
                }
                DepositClearingInfo depositClearingInfo = new DepositClearingInfo();
                depositClearingInfo.ExtractClearingCounters(ref ejData, downloadTask, task);
            }
            finally
            {
                if (cmd != null)
                    if (cmd.Connection != null)
                        cmd.Connection.Close();
            }
        }
    }
}