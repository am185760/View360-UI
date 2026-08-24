using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using ServicesDAL;


namespace Avanza.CCMS.Parser
{
    public class BNAParser
    {
        //public static string[] disputeTrxnToken = System.Configuration.ConfigurationManager.AppSettings["disputeTrxnToken"].Split(',');
        public static string[] failedTrxnToken = System.Configuration.ConfigurationManager.AppSettings["failedTrxnToken"].Split(',');
        public static string chequeDepositToAccountToken = System.Configuration.ConfigurationManager.AppSettings["ChequeDeposittoAccount"];
        public static string creditCardPaymentByChequeToken = System.Configuration.ConfigurationManager.AppSettings["CreditCardPaymentbyCheque"];
        public static string cashDepositToAccountToken = System.Configuration.ConfigurationManager.AppSettings["CashDeposittoAccount"];
        public static string creditCardPaymentByCashToken = System.Configuration.ConfigurationManager.AppSettings["CreditCardPaymentbyCash"];

        public static string loanAccountPaymentByCashToken = System.Configuration.ConfigurationManager.AppSettings["LoanAccountDeposit"];
        string[] dateFormats = { "yy/MM/dd HH:mm:ss", "dd/MM/yy HH:mm:ss", "MM/dd/yy HH:mm:ss", "dd/MM/yyyy HH:mm:ss" };
        string[] dateFormats_1 = { "MM/dd/yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss", "yy/MM/dd HH:mm:ss", "dd/MM/yy HH:mm:ss", };


        class DepositTransaction
        {
            public DateTime TransactionStartTime;
            public string TransactionEndTime;
            public DateTime? TrxnDatetime;
            public int StartIndex;
            public long TaskId;
            public long AtmId;
            public DateTime GeneratedAt;
            public string Status;
            public string TerminalId;
            public string CardTakenTime;
            public string seq;
            public string Pan;
            public decimal amount;
            public string TransactionType;
            public int startIndexLength;
            public bool isDisputedTrxn;
            public string accountNo;
            public string hostTSN;
            public string micr;
            public int? CustomerId;
            public string Currency;
        }
        public static Regex mStateRegex = new Regex(@"\*(?<TSN>\d+)\*\d+\*+(?<Device>\w)\*(?<DeviceCode>\w+),[ ]*(?<mState>M-\d\d+),");
        public static Regex DPTransactionRegex = new Regex(@"((VAL|VAULTED):[ ]\d+\r?\n?(?<DepositDetail>\w{3}[ ]+(?<Denomination>\d+)[ ]X[ ]+(?<Notes>\d+)[ ]=[ ]+\d+\r?\n?)+)|(DENOM[ ]+CASS1[ ]+CASS2[ ]+CASS3[ ]+CASS4[ ]+\r?\n?(?<TotalDepositDetails>(EGP(?<Denomination>\d+)([ ]+(?<Notes>\d+))+[ ]*\r?\n?)+))|(DENOM[ ]+\w+[ ]*\w+[ ]*\w+[ ]*\r?\n?(?<TotalRejectDetails>(EGP(?<Denomination>\d+)([ ]+(?<Notes>\d+))+[ ]*\r?\n?)+))|((?<Date>\d{2}/\d{2}/\d{2})[ ](?<Time>\d+:\d+:\d+)[ ]+(?<TSN>\d+)[ ]CASH([ ]\w+)*\r?\n?[ ](?<PAN>[\d\*]+)[ ]+(?<Amount>[\d\.,]+)[ ]+\d+\r?\n?[ ]\d*[ ]+(RESP[ ]:[ ](?<ResponseCode>\d+)\r?\n?[ ]CASH[ ]DEP)?)");

        public string ParseAndSaveEJ(ref string EJData, Task downloadTask, LogableTask task)
        {
            string response = "success";
            bool isTrxnExtracted = false;
            string bankName = null;
            List<EjParsedBnaTransactionDetail> list = new List<EjParsedBnaTransactionDetail>();
            List<EjParsedBnaTransactionDetail> listTotalDeposited = new List<EjParsedBnaTransactionDetail>();
            bool depositDetailExtracted = false;
            bool switchResponseReceived = false;

            Match match = DPTransactionRegex.Match(EJData);
            EjParsedBnaTransaction ejParsedBnaTransaction = null;
            EjParsedBnaTransactionDetail ejParsedBnaTransactionDetail = null;
            DepositTransaction depositTrxn = null;
            SqlCommand cmd = null;
            try
            {
                cmd = ConnectionFactory.GetNewCommand(true, DatabaseName.Tx);
                cmd.CommandTimeout = 30 * 5;

                while (match.Success)
                {
                    if (match.Groups["Date"].Success && match.Groups["Time"].Success)
                    {
                        depositTrxn = new DepositTransaction();
                        depositTrxn.StartIndex = match.Index;
                        depositTrxn.startIndexLength = match.Length;
                        depositTrxn.TaskId = downloadTask.TaskId;
                        depositTrxn.AtmId = downloadTask.ATMId;
                        depositTrxn.GeneratedAt = DateTime.Now;
                        depositTrxn.Status = "Successful";
                        depositTrxn.TransactionType = "Deposit";
                        depositTrxn.TrxnDatetime = DateTime.ParseExact(match.Groups["Date"].Value + " " + match.Groups["Time"].Value, dateFormats, null, DateTimeStyles.None);
                        depositTrxn.TransactionStartTime = depositTrxn.TrxnDatetime.Value;
                        switchResponseReceived = true;

                        if (depositTrxn.TrxnDatetime.Value.Hour == 12 && depositTrxn.TrxnDatetime.Value.Minute == 15
                               && depositTrxn.TrxnDatetime.Value.Second == 22)
                        {
                            int b = 0;
                        }

                    }
                    if (match.Groups["TSN"].Success)
                        depositTrxn.seq = match.Groups["TSN"].Value;

                    if (match.Groups["PAN"].Success)
                        depositTrxn.Pan = match.Groups["PAN"].Value;

                    if (match.Groups["Amount"].Success)
                        depositTrxn.amount = decimal.Parse(match.Groups["Amount"].Value);

                    if (match.Groups["ResponseCode"].Success)
                        depositTrxn.Status = match.Groups["ResponseCode"].Value == "000" ? "Successful" : "Failed";

                    if (match.Groups["DepositDetail"].Success)
                    {
                        depositDetailExtracted = true;
                        switchResponseReceived = false;
                        list = new List<EjParsedBnaTransactionDetail>();
                        listTotalDeposited = new List<EjParsedBnaTransactionDetail>();

                        for (int i = 0; i < match.Groups["Denomination"].Captures.Count; i++)
                        {
                            ejParsedBnaTransactionDetail = new EjParsedBnaTransactionDetail();

                            if (match.Groups["Denomination"].Success)
                                ejParsedBnaTransactionDetail.NoteType = int.Parse(match.Groups["Denomination"].Captures[i].Value);

                            if (match.Groups["Notes"].Success)
                                ejParsedBnaTransactionDetail.NotesCount = int.Parse(match.Groups["Notes"].Captures[i].Value);

                            list.Add(ejParsedBnaTransactionDetail);
                        }
                    }
                    if (match.Groups["TotalDepositDetails"].Success)
                    {
                        isTrxnExtracted = true;

                        //listTotalDeposited = new List<EjParsedBnaTransactionDetail>();

                        for (int i = 0; i < match.Groups["Denomination"].Captures.Count; i++)
                        {
                            EjParsedBnaTransactionDetail ejParsedTotalBnaTransactionDetail = new EjParsedBnaTransactionDetail();

                            if (match.Groups["Denomination"].Success)
                                ejParsedTotalBnaTransactionDetail.NoteType = int.Parse(match.Groups["Denomination"].Captures[i].Value);

                            //if (match.Groups["Notes"].Captures.Count % 3 == 0)
                            //{
                            //    //Handling of rejects and retracts
                            //    for (int j = 0; j < 3; j++)
                            //        ejParsedTotalBnaTransactionDetail.NotesCount += int.Parse(match.Groups["Notes"].Captures[j + (i * 3)].Value);

                            //    ejParsedTotalBnaTransactionDetail.NotesCount *= -1;
                            //}
                            //else
                            //{
                            for (int j = 0; j < 4; j++)
                                ejParsedTotalBnaTransactionDetail.NotesCount += int.Parse(match.Groups["Notes"].Captures[j + (i * 4)].Value);
                            //}
                            //case when only notes went to reject/retract bin
                            if (listTotalDeposited == null)
                                listTotalDeposited = new List<EjParsedBnaTransactionDetail>();
                            listTotalDeposited.Add(ejParsedTotalBnaTransactionDetail);
                        }

                    }

                    if (match.Groups["TotalRejectDetails"].Success)
                    {
                        isTrxnExtracted = true;

                        //listTotalDeposited = new List<EjParsedBnaTransactionDetail>();

                        for (int i = 0; i < match.Groups["Denomination"].Captures.Count; i++)
                        {
                            EjParsedBnaTransactionDetail ejParsedTotalBnaTransactionDetail = new EjParsedBnaTransactionDetail();

                            if (match.Groups["Denomination"].Success)
                                ejParsedTotalBnaTransactionDetail.NoteType = int.Parse(match.Groups["Denomination"].Captures[i].Value);

                            //if (match.Groups["Notes"].Captures.Count % 3 == 0)
                            //{
                            //    //Handling of rejects and retracts
                            //    for (int j = 0; j < 3; j++)
                            //        ejParsedTotalBnaTransactionDetail.NotesCount += int.Parse(match.Groups["Notes"].Captures[j + (i * 3)].Value);

                            //    ejParsedTotalBnaTransactionDetail.NotesCount *= -1;
                            //}
                            //else
                            //{
                            for (int j = 0; j < 3; j++)
                                ejParsedTotalBnaTransactionDetail.NotesCount += int.Parse(match.Groups["Notes"].Captures[j + (i * 3)].Value);
                            ejParsedTotalBnaTransactionDetail.NotesCount *= -1;
                            //}
                            //case when only notes went to reject/retract bin
                            if (listTotalDeposited == null)
                                listTotalDeposited = new List<EjParsedBnaTransactionDetail>();
                            listTotalDeposited.Add(ejParsedTotalBnaTransactionDetail);
                        }

                    }


                    if (isTrxnExtracted && depositDetailExtracted && switchResponseReceived)
                    {
                        ejParsedBnaTransaction = new EjParsedBnaTransaction();
                        ejParsedBnaTransaction.TransactionStartTime = depositTrxn.TransactionStartTime;
                        ejParsedBnaTransaction.TrxnDatetime = depositTrxn.TrxnDatetime.Value;
                        ejParsedBnaTransaction.StartIndex = depositTrxn.StartIndex;
                        ejParsedBnaTransaction.TaskId = depositTrxn.TaskId;
                        ejParsedBnaTransaction.AtmId = depositTrxn.AtmId;
                        ejParsedBnaTransaction.GeneratedAt = DateTime.Now;
                        ejParsedBnaTransaction.IsEligible = true;
                        ejParsedBnaTransaction.Status = depositTrxn.Status;
                        ejParsedBnaTransaction.TerminalId = depositTrxn.TerminalId;
                        ejParsedBnaTransaction.CardTakenTime = depositTrxn.CardTakenTime;
                        ejParsedBnaTransaction.Seq = depositTrxn.seq;
                        ejParsedBnaTransaction.BankName = bankName;
                        ejParsedBnaTransaction.Currency = depositTrxn.Currency;

                        ejParsedBnaTransaction.Pan = depositTrxn.Pan;
                        ejParsedBnaTransaction.AmountAuthorized = depositTrxn.amount;
                        ejParsedBnaTransaction.IsDisputedTransaction = depositTrxn.isDisputedTrxn;

                        ejParsedBnaTransaction.AccountNo = depositTrxn.accountNo;
                        ejParsedBnaTransaction.HostTsn = depositTrxn.hostTSN;



                        ejParsedBnaTransaction.TransactionEndTime = depositTrxn.TransactionEndTime;
                        ejParsedBnaTransaction.EndIndex = match.Index + match.Length;

                        if (isBNATrxnExists(cmd, ejParsedBnaTransaction, downloadTask))
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Transaction  " + EJData.Substring(match.Index, match.Length) + ".because this already exists in ej_parsed_bna_transaction table.");
                        else
                        {

                            //if (ejParsedBnaTransaction.TransactionTypeId == null)
                            //{
                            //    if (ejParsedBnaTransaction.AccountNo != null)
                            //        ejParsedBnaTransaction.TransactionTypeId = CommentSaver.GetTransactionTypeId(cashDepositToAccountToken);

                            //    else
                            //        ejParsedBnaTransaction.TransactionTypeId = CommentSaver.GetTransactionTypeId(creditCardPaymentByCashToken);

                            //}

                            if (list.Count > 0)
                            {
                                ejParsedBnaTransaction.Save();
                                if (ejParsedBnaTransaction.TrxnDatetime.ToString("HHmmss") == "132016")
                                {
                                    int b = 0;
                                }
                                EJToCounterMapper.EJToCounterMapper.EjParsedBNAMigrator(ejParsedBnaTransaction, list, listTotalDeposited);
                                //Write migration logic here.

                                if (list != null)
                                {
                                    for (int i = 0; i < list.Count; i++)
                                    {
                                        list[i].EjParsedBnaTransactionId = ejParsedBnaTransaction.EjParsedBnaTransactionId;
                                        EjParsedBnaTransactionDetail objRejected = listTotalDeposited.Where(k => k.NoteType == list[i].NoteType && k.NotesCount < 0).SingleOrDefault();
                                        if (objRejected != null)
                                            list[i].TotalRejected = objRejected.NotesCount * -1;
                                        else
                                            list[i].TotalRejected = 0;
                                        EjParsedBnaTransactionDetail objRemaining = listTotalDeposited.Where(k => k.NoteType == list[i].NoteType && k.NotesCount > 0).SingleOrDefault();
                                        list[i].TotalRemaining = objRemaining.NotesCount;
                                        list[i].Save();
                                    }
                                }

                            }

                        }
                        isTrxnExtracted = false;
                        depositDetailExtracted = false;
                        switchResponseReceived = false;
                        listTotalDeposited.Clear();
                        list.Clear();
                    }
                    match = match.NextMatch();

                }
            }
            catch (Exception ex)
            {
                if (match != null)
                    downloadTask.FailureReason = EJData.Substring(match.Index, match.Length);
                task.Log(MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Error, ex.Message + ex.StackTrace);
                response = ex.Message;
                throw new Exception("Error while saving/extracting transactions", ex);
            }
            finally
            {
                if (cmd != null)
                    if (cmd.Connection != null)
                        cmd.Connection.Close();
            }
            return response;
        }



        private bool isBNATrxnExists(SqlCommand cmd, EjParsedBnaTransaction trx, Task downloadTask)
        {
            cmd.CommandText = "isBNATrxnExists";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("FromDate", SqlDbType.DateTime));
            cmd.Parameters[0].Value = trx.TrxnDatetime;
            cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
            cmd.Parameters[1].Value = downloadTask.ATMId;
            cmd.Parameters.Add(new SqlParameter("tsn", SqlDbType.VarChar));
            if (trx.Seq == null)
                trx.Seq = "-1";
            cmd.Parameters[2].Value = trx.Seq;
            //cmd.Parameters.Add(new SqlParameter("TrxnStartDTime", SqlDbType.DateTime));
            //cmd.Parameters[3].Value = trx.TransactionStartTime;

            if ((int)cmd.ExecuteScalar() > 0)
                return true;
            else
                return false;
        }

        //public void ExtractClearCountEvents(ref string ejData, Task downloadTask, LogableTask task)
        //{
        //    ClearCounterEventExtractor clearCounterEventExtractor = new ClearCounterEventExtractor();
        //    clearCounterEventExtractor.ParseAndSaveBnaCountClearing(ref ejData, downloadTask, task, trxn);
        //}
    }
}
