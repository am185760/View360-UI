using ServicesDAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;


namespace Avanza.CCMS.Parser
{
    public class Parser
    {

        private int allowableTimeDiff = 2;

        public void SetAllowableTimeDiff(int diff)
        {
            allowableTimeDiff = diff;
        }
        private string[] allowableMonths = null;
        public void SetAllowableMonths(string months)
        {
            allowableMonths = months.Split(',');
        }

        int replenishmentID = 0;
        int[] notesRemaining = new int[4];
        public static bool CardCaptureExtracted = false;
        public static string CardCaptureDateTimeFormat
        {
            get { return "dd/MM/yyyy HH:mm"; }
        }
        //to be check
        public static Regex mStateRegex = new Regex(@"\*(?<TSN>\d+)\*\d+\*+(?<Device>\w)\*(?<DeviceCode>\d)\d*,[ ]*(?<mState>M-\d\d+),");

        //Regex ncrWDTransactionRegex = new Regex(@"([ ]*(?<CARD_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*CARD TAKEN[ \r\n]*)?([ ]*(?<NOTES_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*NOTES TAKEN[ \r\n]*)?((?<DATE>\d{2}\/\d{2}\/\d{2})[ ]*(?<TIME>\d{2}\:\d{2}\:\d{2}))([ ]*(?<TSN>\d+)[ ]+(?<TRXN_TYPE>WITHDRA\w*))[\r\n]*[ ]*((?<PAN>[\d\*]+)[ ]*(?<AMOUNT>[\d\,\.]+)[ ]*[\d]+)[\r\n]*([ \d]*UNABLE DISP|[ \w]+|[ \d]+RESP[ \:]+(?<RESPONSE_CODE>\d+))[\r\n]*([ \w]+\d{2}\/\d{2}\/\d{2})[\r\n]*(\-ATM[\: ]+(?<ATM_ID>\d+)\-+)[\r\n ]*([ ]*(?<NOTES_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*NOTES TAKEN[ \r\n]*)?([ \d\:]+[\r\n]*NOTES PRESENTED)?[\r\n]*([ ]*POSITION[\d\,\- ]+)?[\r\n]*(COUNT[ ]+((?<NOTES_DISPENSED>\d+)\,?)+)?[\r\n]*([ ]*(?<NOTES_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*NOTES TAKEN[ \r\n]*)?((CASH TOTAL[ ]*(CDM[ ]*(?<CDM>\d))?[ ]*(TYPE\d[ ]?)+)[\r\n]*(DENOMINATION[\d ]+)[\r\n]*(DISPENSED[\d ]+)[ \r\n]*(REJECTED[ ]+((?<REJECTED>\d+)[ ]?)+)[ \r\n]*(REMAINING[ ]*((?<REMAINING>\d+)[ ]?)+)[ \r\n]*)?([ \r\n]*(?<NOTES_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*NOTES TAKEN[ \r\n]*)?(([ HGMRSE\d\,\-\,\*\]+[\r\n]*)([ ]*(?<CARD_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*CARD TAKEN[\r\n]*))?(([ HGMRSE\d\,\-\,\*\]+[\r\n]*){2}([ ]*(?<CARD_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*CARD TAKEN[\r\n]*))?(([ HGMRSE\d\,\-\,\*\]+[\r\n]*)([ \r\n]*(?<TRXN_END>\d{2}\:\d{2}\:\d{2})[ ]*TRANSACTION END[\r\n]*))?(([ HGMRSE\d\,\-\,\*\]+[\r\n]*){4}([ ]*(?<TRXN_END>\d{2}\:\d{2}\:\d{2})[ ]*TRANSACTION END[\r\n]*))?([ ]*(?<CARD_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*CARD TAKEN[\r\n]*)?([ ]*(?<TRXN_END>\d{2}\:\d{2}\:\d{2})[ ]*TRANSACTION END[\r\n]*)?");

        //29-07-26 - antiG - to handle CDM1 in withdrawal issue fixed.
        Regex ncrWDTransactionRegex = new Regex(@"([ ]*(?<CARD_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*CARD TAKEN[ \r\n]*)?([ ]*(?<NOTES_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*NOTES TAKEN[ \r\n]*)?((?<DATE>\d{2}\/\d{2}\/\d{2})[ ]*(?<TIME>\d{2}\:\d{2}\:\d{2}))([ ]*(?<TSN>\d+)[ ]+(?<TRXN_TYPE>WITHDRA\w*))[\r\n]*[ ]*((?<PAN>[\d\*]+)[ ]*(?<AMOUNT>[\d\,\.]+)[ ]*[\d]+)[\r\n]*([ \d]*UNABLE DISP|[ \w]+|[ \d]+RESP[ \:]+(?<RESPONSE_CODE>\d+))[\r\n]*([ \w]+\d{2}\/\d{2}\/\d{2})[\r\n]*(\-ATM[\: ]+(?<ATM_ID>\d+)\-+)[\r\n ]*([ ]*(?<NOTES_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*NOTES TAKEN[ \r\n]*)?((?<NOTES_PRESENTED>[ \d\:]+)[\r\n]*NOTES PRESENTED[ \d\,]*)?[\r\n]*([ ]*POSITION[\d\,\- ]+)?[\r\n]*(COUNT[ ]+((?<NOTES_DISPENSED>\d+)\,?)+)?[\r\n]*([ ]*(?<NOTES_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*NOTES TAKEN[ \r\n]*)?((CASH TOTAL[ ]*(CDM[ ]*(?<CDM>\d))?[ ]*(TYPE\d[ ]?)+)[\r\n]*(DENOMINATION[\d ]+)[\r\n]*(DISPENSED[\d ]+)[ \r\n]*(REJECTED[ ]+((?<REJECTED>\d+)[ ]?)+)[ \r\n]*(REMAINING[ ]*((?<REMAINING>\d+)[ ]?)+)[ \r\n]*)?([ \r\n]*(?<NOTES_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*NOTES TAKEN[ \r\n]*)?(([ HGMRSE\d\,\-\,\*\]+[\r\n]*)([ ]*(?<CARD_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*CARD TAKEN[\r\n]*))?(([ HGMRSE\d\,\-\,\*\]+[\r\n]*){2}([ ]*(?<CARD_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*CARD TAKEN[\r\n]*))?(([ HGMRSE\d\,\-\,\*\]+[\r\n]*)([ \r\n]*(?<TRXN_END>\d{2}\:\d{2}\:\d{2})[ ]*TRANSACTION END[\r\n]*))?(([ HGMRSE\d\,\-\,\*\]+[\r\n]*){4}([ ]*(?<TRXN_END>\d{2}\:\d{2}\:\d{2})[ ]*TRANSACTION END[\r\n]*))?([ ]*(?<CARD_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*CARD TAKEN[\r\n]*)?([ ]*(?<TRXN_END>\d{2}\:\d{2}\:\d{2})[ ]*TRANSACTION END[\r\n]*)?");

        //old -bckp
        //Regex ncrWDTransactionRegex = new Regex(@"([ ]*(?<CARD_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*CARD TAKEN[ \r\n]*)?([ ]*(?<NOTES_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*NOTES TAKEN[ \r\n]*)?((?<DATE>\d{2}\/\d{2}\/\d{2})[ ]*(?<TIME>\d{2}\:\d{2}\:\d{2}))([ ]*(?<TSN>\d+)[ ]+(?<TRXN_TYPE>WITHDRA\w*))[\r\n]*[ ]*((?<PAN>[\d\*]+)[ ]*(?<AMOUNT>[\d\,\.]+)[ ]*[\d]+)[\r\n]*([ \d]*UNABLE DISP|[ \w]+|[ \d]+RESP[ \:]+(?<RESPONSE_CODE>\d+))[\r\n]*([ \w]+\d{2}\/\d{2}\/\d{2})[\r\n]*(\-ATM[\: ]+(?<ATM_ID>\d+)\-+)[\r\n ]*([ ]*(?<NOTES_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*NOTES TAKEN[ \r\n]*)?((?<NOTES_PRESENTED>[ \d\:]+)[\r\n]*NOTES PRESENTED)?[\r\n]*([ ]*POSITION[\d\,\- ]+)?[\r\n]*(COUNT[ ]+((?<NOTES_DISPENSED>\d+)\,?)+)?[\r\n]*([ ]*(?<NOTES_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*NOTES TAKEN[ \r\n]*)?((CASH TOTAL[ ]*(CDM[ ]*(?<CDM>\d))?[ ]*(TYPE\d[ ]?)+)[\r\n]*(DENOMINATION[\d ]+)[\r\n]*(DISPENSED[\d ]+)[ \r\n]*(REJECTED[ ]+((?<REJECTED>\d+)[ ]?)+)[ \r\n]*(REMAINING[ ]*((?<REMAINING>\d+)[ ]?)+)[ \r\n]*)?([ \r\n]*(?<NOTES_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*NOTES TAKEN[ \r\n]*)?(([ HGMRSEw\d\,\-\,\*\]+[\r\n]*)([ ]*(?<CARD_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*CARD TAKEN[\r\n]*))?(([ HGMRSEw\d\,\-\,\*\]+[\r\n]*){2}([ ]*(?<CARD_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*CARD TAKEN[\r\n]*))?(([ HGMRSEw\d\,\-\,\*\]+[\r\n]*)([ \r\n]*(?<TRXN_END>\d{2}\:\d{2}\:\d{2})[ ]*TRANSACTION END[\r\n]*))?(([ HGMRSEw\d\,\-\,\*\]+[\r\n]*){4}([ ]*(?<TRXN_END>\d{2}\:\d{2}\:\d{2})[ ]*TRANSACTION END[\r\n]*))?([ ]*(?<CARD_TAKEN>\d{2}\:\d{2}\:\d{2})[ ]*CARD TAKEN[\r\n]*)?([ ]*(?<TRXN_END>\d{2}\:\d{2}\:\d{2})[ ]*TRANSACTION END[\r\n]*)?");

        static Regex captureCardRegEx = new Regex(@"(\d{2}/\d{2}/\d{2}[ ]+(?<Time>\d{2}:\d{2}:\d{2})\r[\n]?PAN: (?<PAN>[\d]*)\r?[\n]?\r(\n)?\*[\d]+\*(?<Date>\d{2}/\d{2}/\d{4})\*\d{2}:\d{2}\*\r(\n)?[ ]*\*\r[\n]?[ ]*\*\r[\n]?[ ]*\*(?<Reason>CARD CAPTURED A/C))|(DATE: (?<Date>\d{2}/\d{2}/\d{4})[ ]+TIME: (?<Time>\d{2}:\d{2}:\d{2})\r[\n]?PAN: (?<PAN>[\d]+)[ ]+\r[\n]?TXN: (?<TXN>[\w ]*)[ ]+SEQ: (?<Seq>[\d]+)\r[\n]?STAN:[ ]+(?<Stan>[\d]+)\r[\n]?([ ]*AMOUNT: (?<CurrencyCode>[\w]+)[ ]+(?<Amount>[\d.]*)[ *]*\r[\n]?)?STATUS: (?<Reason>(CARD CAPTURED)|(HOT[ ]CARD)|(CARD[ ]EXPIRED[ ]OR[ ]HAS[ ]BAD[ ]DATE[ ]*)|(PIN EXHAUSTED: CARD DEACTIVATED\r(\n)?\r?[\n]?\r(\n)?\*[\d]+\*(?<Date>\d{2}/\d{2}/\d{4})\*\d{2}:\d{2}\*\r(\n)?[ ]*\*\r[\n]?[ ]*\*\r[\n]?[ ]*\*CARD CAPTURED A/C)))");

        string[] dateFormats = { "yy/MM/dd HH:mm:ss", "dd/MM/yy HH:mm:ss", "MM/dd/yy HH:mm:ss" };

        private void CheckMStatus(EjParsedTransactions trx, Match match, ref string comment, ref string ejData)
        {
            int mstateSearchStartIndex = trx.StartIndex.Value - 50;
            int mstateSearchEndIndex = match.Index + 1050;
            if (mstateSearchStartIndex < 0)
                mstateSearchStartIndex = 0;

            if (mstateSearchEndIndex >= ejData.Length)
                mstateSearchEndIndex = ejData.Length - 1;

            if (ejData.IndexOf("M-", mstateSearchStartIndex, mstateSearchEndIndex - mstateSearchStartIndex) > -1)
            {
                Match mStates = mStateRegex.Match(ejData.Substring(mstateSearchStartIndex, mstateSearchEndIndex - mstateSearchStartIndex));
                while (mStates.Success)
                {
                    if (trx.Tsn != null)
                    {
                        if (trx.Tsn.ToString().Substring(2) == mStates.Groups["TSN"].Captures[0].Value)
                        {

                            MState mStateRow = MState.LoadMState("device_id = '" + mStates.Groups["Device"].Captures[0].Value + "' and mstate_Code = '" + mStates.Groups["mState"].Captures[0].Value + "'");

                            if (mStateRow == null)
                            {
                                trx.Status = 2;
                                trx.MstateId = 0;// not found
                            }
                            else
                            {
                                if (mStateRow.MstateStatus != 0)
                                {
                                    trx.Status = (byte)mStateRow.MstateStatus;
                                    trx.MstateId = mStateRow.MstateId;
                                    if (trx.Status == 1)
                                        break;
                                }
                            }
                            if ((mStates.Groups["Device"].Success) && (mStates.Groups["DeviceCode"].Success))
                            {
                                if ((mStates.Groups["Device"].Captures[0].Value.Equals("E")) && (mStates.Groups["DeviceCode"].Captures[0].Value.Equals("5")))
                                {
                                    comment += " Bills Retracted";
                                    if (trx.Status != 1)
                                        trx.Status = 2;
                                }
                                else if ((mStates.Groups["Device"].Captures[0].Value.Equals("D")) && (mStates.Groups["DeviceCode"].Captures[0].Value.Equals("1")))
                                {
                                    comment += " Card Captured or Jammed";
                                    if (trx.Status != 1)
                                        trx.Status = 2;
                                }
                            }


                        }
                    }
                    mStates = mStates.NextMatch();
                }
            }

        }
        private bool isTrxnExists(SqlCommand cmd, EjParsedTransactions trx, ServicesDAL.Task downloadTask)
        {
            cmd.CommandText = "isTrxnExists";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("FromDate", SqlDbType.DateTime));
            cmd.Parameters[0].Value = trx.TrxnDatetime;
            cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
            cmd.Parameters[1].Value = downloadTask.ATMId;
            cmd.Parameters.Add(new SqlParameter("tsn", SqlDbType.VarChar));
            cmd.Parameters[2].Value = trx.Tsn;
            cmd.Parameters.Add(new SqlParameter("ttype", SqlDbType.Int));
            cmd.Parameters[3].Value = trx.TransactionTypeId;

            if ((int)cmd.ExecuteScalar() > 0)
                return true;
            else
                return false;
        }

        
     
      
        public string ParseAndSaveEJ(ref string ejData, ServicesDAL.Task downloadTask, LogableTask task)
        {
            string response = "success";
            bool isOutOfCashAlertResolved = false;
            bool isLowBalanceAlertResolved = false;
            bool isOutOfCashAlertGenerated = false;
            bool isLowBalanceAlertGenerated = false;
            SqlCommand cmd = null;
            EjParsedTransactions trx = null;
            EjParsedTransactions tempTrx = null;
            Match match = null;
            string TransactionType = "";
            string comment = null;
            try
            {
                cmd = ConnectionFactory.GetNewCommand(true,DatabaseName.Tx);
                Atm atm = Atm.LoadAtmByPk(downloadTask.ATMId);
                NoteSetType noteSetType = NoteSetType.LoadNoteSetTypeByPk(atm.NoteSetTypeId);
                task.Log(MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Verbose, "ej formatted");

                
                match = ncrWDTransactionRegex.Match(ejData);

                DateTime temp = DateTime.MinValue;
                DateTime Dtime;
                while (match.Success)
                {
                    if (match.Groups["DATE"].Success)
                    {
                        trx = new EjParsedTransactions();
                        trx.AtmId = atm.ATMId;
                        trx.TaskId = downloadTask.TaskId;
                        trx.Status = 0;
                        trx.Tsn = "-1";
                        trx.IsDispensedFromRecycler = false;

                        if (match.Groups["DATE"].Success && match.Groups["TIME"].Success)
                        {
                            DateTime.TryParseExact(match.Groups["DATE"].Captures[0].Value + " " + match.Groups["TIME"].Captures[0].Value, dateFormats, null, System.Globalization.DateTimeStyles.None, out temp);
                            trx.TrxnDatetime = temp;
                            trx.TransactionStartTime = temp;
                        }

                        if (match.Groups["NOTES_PRESENTED"].Success && atm.AtmType.ToLower().Contains("ncr"))
                        {
                            string noteTime = match.Groups["NOTES_PRESENTED"].Captures[0].Value.Trim();
                            DateTime.TryParseExact(match.Groups["DATE"].Captures[0].Value + " " + noteTime, dateFormats, null, System.Globalization.DateTimeStyles.None, out Dtime);
                            trx.TrxnDatetime = Dtime;
                            if (temp != DateTime.MinValue && temp.Hour != Dtime.Hour && Dtime.Hour == 23 && Math.Abs(temp.Minute - Dtime.Minute) > 5)
                            {
                                trx.TrxnDatetime = Dtime.AddDays(-1);
                            }
                        }

                        if (match.Groups["NOTES_TAKEN"].Success && !atm.AtmType.ToLower().Contains("ncr"))
                        {
                            DateTime.TryParseExact(match.Groups["DATE"].Captures[0].Value + " " + match.Groups["NOTES_TAKEN"].Captures[0].Value, dateFormats, null, System.Globalization.DateTimeStyles.None, out temp);
                            trx.TrxnDatetime = temp;
                        }

                        if (match.Groups["TSN"].Success)
                            trx.Tsn = match.Groups["TSN"].Captures[0].Value;

                        if (match.Groups["PAN"].Success)
                            trx.Pan = match.Groups["PAN"].Captures[0].Value;

                        
                        if (match.Groups["AMOUNT"].Success)
                            trx.Amount = decimal.Parse(match.Groups["AMOUNT"].Captures[0].Value);


                        TransactionType = "WITHDRAWAL";
                        trx.TransactionTypeId = 1;// CommentSaver.GetTransactionTypeId(TransactionType);

                        if (match.Groups["CARD_TAKEN"].Success)
                            trx.CardTakenTime = match.Groups["CARD_TAKEN"].Captures[0].Value;

                        if (match.Groups["TRXN_END"].Success)
                            trx.TransactionEndTime = match.Groups["TRXN_END"].Captures[0].Value;

                        //if (match.Groups["CURRENCY"].Success)
                        //    trx.Currency = match.Groups["CURRENCY"].Captures[0].Value;
                        trx.Currency = "EGP";

                        //if (match.Groups["ACCOUNT_NO"].Success)
                        //{
                        //    if (!String.IsNullOrEmpty(match.Groups["ACCOUNT_NO"].Captures[0].Value) && match.Groups["ACCOUNT_NO"].Captures[0].Value.Count(c => c == '-') == match.Groups["ACCOUNT_NO"].Captures[0].Value.Count())
                        //        trx.AccountNo = String.Empty;
                        //    else
                        //        trx.AccountNo = match.Groups["ACCOUNT_NO"].Captures[0].Value;

                        //}


                        trx.EndIndex = match.Index + match.Length;
                        trx.StartIndex = match.Index;

                        if (match.Groups["CDM"].Success && match.Groups["CDM"].Captures[0].Value == "1")
                        {
                            trx.IsDispensedFromRecycler = true;
                        }

                        if (atm.AtmType.ToLower().Contains("brm"))
                            trx.IsDispensedFromRecycler = true;

                        if (isTrxnExists(cmd, trx, downloadTask))
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Transaction  " + ejData.Substring(match.Index, match.Length) + ".because this already exists in ej_parsed_transactions table.");
                            match = match.NextMatch();
                            comment = null;
                            trx = null;
                            continue;
                        }

                        CheckMStatus(trx, match, ref comment, ref ejData);

                        if (match.Groups["RESPONSE_CODE"].Success)
                        {
                            if (match.Groups["RESPONSE_CODE"].Captures[0].Value == "000")
                            {
                                trx.Result = "SUCCESS";
                                trx.Status = 0;
                            }
                            else
                            {
                                trx.Result = "FAIL";
                                trx.Status = 1;
                            }

                        }
                        else
                        {
                            trx.Result = "FAIL";
                            trx.Status = 1;
                        }

                        try
                        {
                            if (TransactionType.Contains("WITHDRAWAL") && trx.Amount > 0)
                            {

                                if (match.Value.Contains("NOTES PRESENTED") && match.Value.Contains("COUNT") && match.Groups["NOTES_DISPENSED"].Success)
                                {
                                    trx.NotesDispensedType1 = !String.IsNullOrEmpty(match.Groups["NOTES_DISPENSED"].Captures[0].Value) ? int.Parse(match.Groups["NOTES_DISPENSED"].Captures[0].Value) : 0;
                                    trx.NotesDispensedType2 = !String.IsNullOrEmpty(match.Groups["NOTES_DISPENSED"].Captures[1].Value) ? int.Parse(match.Groups["NOTES_DISPENSED"].Captures[1].Value) : 0;
                                    trx.NotesDispensedType3 = !String.IsNullOrEmpty(match.Groups["NOTES_DISPENSED"].Captures[2].Value) ? int.Parse(match.Groups["NOTES_DISPENSED"].Captures[2].Value) : 0;
                                    trx.NotesDispensedType4 = !String.IsNullOrEmpty(match.Groups["NOTES_DISPENSED"].Captures[3].Value) ? int.Parse(match.Groups["NOTES_DISPENSED"].Captures[3].Value) : 0;

                                }
                                if (match.Value.Contains("REMAINING") && match.Groups["REMAINING"].Success)
                                {
                                    for (int cap = 0; cap < match.Groups["REMAINING"].Captures.Count; cap++)
                                    {
                                        if (cap == 0)
                                            trx.NotesRemainingType1 = !String.IsNullOrEmpty(match.Groups["REMAINING"].Captures[0].Value) ? int.Parse(match.Groups["REMAINING"].Captures[0].Value) : 0;
                                        else if (cap == 1)
                                            trx.NotesRemainingType2 = !String.IsNullOrEmpty(match.Groups["REMAINING"].Captures[1].Value) ? int.Parse(match.Groups["REMAINING"].Captures[1].Value) : 0;
                                        else if (cap == 2)
                                            trx.NotesRemainingType3 = !String.IsNullOrEmpty(match.Groups["REMAINING"].Captures[2].Value) ? int.Parse(match.Groups["REMAINING"].Captures[2].Value) : 0;
                                        else if (cap == 3)
                                            trx.NotesRemainingType4 = !String.IsNullOrEmpty(match.Groups["REMAINING"].Captures[3].Value) ? int.Parse(match.Groups["REMAINING"].Captures[3].Value) : 0;

                                    }
                                    trx.NotesRemainingType1 = (String.IsNullOrEmpty(trx.NotesRemainingType1.ToString()) || trx.NotesRemainingType1 == null) ? 0 : trx.NotesRemainingType1;
                                    trx.NotesRemainingType2 = (String.IsNullOrEmpty(trx.NotesRemainingType2.ToString()) || trx.NotesRemainingType2 == null) ? 0 : trx.NotesRemainingType2;
                                    trx.NotesRemainingType3 = (String.IsNullOrEmpty(trx.NotesRemainingType3.ToString()) || trx.NotesRemainingType3 == null) ? 0 : trx.NotesRemainingType3;
                                    trx.NotesRemainingType4 = (String.IsNullOrEmpty(trx.NotesRemainingType4.ToString()) || trx.NotesRemainingType4 == null) ? 0 : trx.NotesRemainingType4;
                                    //UpdateCashPosition(atm, trx, noteSetType, dbTrx, ref isOutOfCashAlertResolved, ref isLowBalanceAlertResolved, ref isOutOfCashAlertGenerated, ref isLowBalanceAlertGenerated);                                  
                                }
                                if (match.Value.Contains("REJECTED") && match.Groups["REJECTED"].Success)
                                {
                                    for (int cap = 0; cap < match.Groups["REJECTED"].Captures.Count; cap++)
                                    {
                                        if (cap == 0)
                                            trx.NotesRejectedType1 = !String.IsNullOrEmpty(match.Groups["REJECTED"].Captures[0].Value) ? int.Parse(match.Groups["REJECTED"].Captures[0].Value) : 0;
                                        else if (cap == 1)
                                            trx.NotesRejectedType2 = !String.IsNullOrEmpty(match.Groups["REJECTED"].Captures[1].Value) ? int.Parse(match.Groups["REJECTED"].Captures[1].Value) : 0;
                                        else if (cap == 2)
                                            trx.NotesRejectedType3 = !String.IsNullOrEmpty(match.Groups["REJECTED"].Captures[2].Value) ? int.Parse(match.Groups["REJECTED"].Captures[2].Value) : 0;
                                        else if (cap == 3)
                                            trx.NotesRejectedType4 = !String.IsNullOrEmpty(match.Groups["REJECTED"].Captures[3].Value) ? int.Parse(match.Groups["REJECTED"].Captures[3].Value) : 0;

                                    }                                 
                                    trx.NotesRejectedType1 = (String.IsNullOrEmpty(trx.NotesRejectedType1.ToString()) || trx.NotesRejectedType1 == null) ? 0 : trx.NotesRejectedType1;
                                    trx.NotesRejectedType2 = (String.IsNullOrEmpty(trx.NotesRejectedType2.ToString()) || trx.NotesRejectedType2 == null) ? 0 : trx.NotesRejectedType2;
                                    trx.NotesRejectedType3 = (String.IsNullOrEmpty(trx.NotesRejectedType3.ToString()) || trx.NotesRejectedType3 == null) ? 0 : trx.NotesRejectedType3;
                                    trx.NotesRejectedType4 = (String.IsNullOrEmpty(trx.NotesRejectedType4.ToString()) || trx.NotesRejectedType4 == null) ? 0 : trx.NotesRejectedType4;
                                }
                                //GetRemainingNotes(trx);

                            }
                        }
                        catch (Exception ex)
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.Message);
                            LogableTask.LogMonoActivityTask("Ej Parse and save transactions___ ", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                            response = ex.Message;
                        }

                        trx.ProcessingDatetime = DateTime.Now;
                        trx.Save();
                        if (TransactionType.Contains("WITHDRAWAL") && trx.Status == 0)
                        {
                            EJToCounterMapper.EJToCounterMapper.EjParsedTransactionMigrator(trx);
                        }
                        comment = null;
                        trx = null;

                    }

                    match = match.NextMatch();
                }
                downloadTask.Parsed = true;
                downloadTask.Status = DownloadStates.completed.ToString();
            }
            catch (Exception ex)
            {
                if (match != null)
                    downloadTask.FailureReason = ejData.Substring(match.Index, match.Length);
                downloadTask.Status = DownloadStates.parsingFailed.ToString();
                downloadTask.RetryRemaining--;
                task.Log(MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Error, ex.Message + ex.StackTrace);
                LogableTask.LogMonoActivityTask("Ej Parse and save transactions -- ", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
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

  
       


    }
}
