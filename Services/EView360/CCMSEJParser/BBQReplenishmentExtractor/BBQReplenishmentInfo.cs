using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Globalization;
using System.Diagnostics;
using System.Threading.Tasks;
using EView360CashDAL;

namespace NCR.CCMS.Parser
{
    public class ReplenishmentExtractor
    {
        System.Threading.Tasks.Task globalTask;
        string[] TimeFormat1 = {"dd/MM/yyyyHH:mm", "MM/dd/yyyyHH:mm" };    //qiib
        string[] TimeFormat = { "MM/dd/yyyyHH:mm", "dd/MM/yyyyHH:mm" };     //Barwa
        Regex regexPrintCounters = new Regex(@"((DATE-TIME[ ]+=(?<PrintCountersDateTime>\d{2}/\d{2}/\d{2}[ ]\d{2}:\d{2}))?(\r[ ]+TYPE[ ]\d[ ]+TYPE[ ]\d[ ]*\r[ ]CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)\r\+REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)\r=REMAINING[ |]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)\r\+DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)\r=TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)\r)*[ ]LAST[ ]CLEARED[ ]+(?<LastClearedDateTime>\d+/\d+/\d+[ ]\d+:\d+)\r{3}[ ]CARDS[ ]CAPTURED[ ]+(?<CardsCapturedCount>\d+))");
        //private Regex regex = new Regex(@"((?<CashAddedTime>\d+/\d+/\d+\*\d+:\d+)\*[ ]*\r?\n?[ ]*(C\d+[ ]*)?CASH[ ]ADDED[ ]*\r?\n?[ ]*(TYPE[ ]\d+[ ]=[ ]+(?<Added>\d+)\s+)+)|((?<CountsClearingTime>\d+/\d+/\d+\*\d+:\d+)\*\s*CASH[ ]COUNTS[ ]CLEARED\s*CASH[ ]DISPENSED\s*(TYPE[ ]\d[ ]=[ ](?<Dispensed>\d+)\s+)+CASH[ ]REMAINING\s*(TYPE[ ]\d[ ]=[ ](?<Remaining>\d+)\s+)+)|((DATE-TIME[ ]+=(?<PrintCountersDateTime>\d{2}/\d{2}/\d{2}[ ]\d{2}:\d{2}))?(\r[ ]+TYPE[ ]\d[ ]+TYPE[ ]\d[ ]*\r[ ]CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)\r\+REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)\r=REMAINING[ |]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)\r\+DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)\r=TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)\r)*[ ]LAST[ ]CLEARED[ ]+(?<LastClearedDateTime>\d+/\d+/\d+[ ]\d+:\d+)\r{3}[ ]CARDS[ ]CAPTURED[ ]+(?<CardsCapturedCount>\d+))");
        //private Regex regex = new Regex(@"((?<CashAddedTime>\d+/\d+/\d+\*\d+:\d+)\*[ ]*\r?\n?[ ]*(C\d+[ ]*)?CASH[ ]ADDED[ ]*\r?\n?[ ]*(TYPE[ ]\d+[ ]=[ ]+(?<Added>\d+)\s+)+)|((?<CountsClearingTime>\d+/\d+/\d+\*\d+:\d+)\*\s*CASH[ ]COUNTS[ ]CLEARED\s*CASH[ ]DISPENSED\s*(TYPE[ ]\d[ ]=[ ](?<Dispensed>\d+)\s+)+CASH[ ]REMAINING\s*(TYPE[ ]\d[ ]=[ ](?<Remaining>\d+)\s+)+)|((DATE-TIME[ ]+=(?<PrintCountersDateTime>\d{2}/\d{2}/\d{2}[ ]\d{2}:\d{2}))?(\r[ ]+TYPE[ ]\d[ ]+TYPE[ ]\d[ ]*\r[ ]CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)\r\+REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)\r=REMAINING[ |]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)\r\+DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)\r=TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)\r)*[ ]LAST[ ]CLEARED[ ]+(?<LastClearedDateTime>\d+/\d+/\d+[ ]\d+:\d+)\r{3}[ ]CARDS[ ]CAPTURED[ ]+(?<CardsCapturedCount>\d+)|(?<PrintCountersDateTime>\d{1,2}/\d{1,2}/\d{2,4}[ ]+\d{1,2}:\d{1,2})[ ]*[ \r\n]*TYPE[ ]*\d[ ]+TYPE[ ]*\d[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)[ \r\n]*TYPE[ ]*3[ ]+TYPE[ ]*4[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette3>\d+)[ ]+(?<Cassette4>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected3>\d+)[ ]+(?<Rejected4>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining3>\d+)[ ]+(?<Remaining4>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed3>\d+)[ ]+(?<Dispensed4>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total3>\d+)[ ]+(?<Total4>\d+)[ \r\n]*[ \r\n]*[ ]*LAST CLEARED[ ]*[ ]*(?<LastClearedDateTime>\d{1,2}/\d{1,2}/\d{2,4}[ ]+\d{1,2}:\d{1,2}))");
        //private Regex regex = new Regex(@"((?<CashAddedTime>\d+/\d+/\d+\*\d+:\d+)\*[ ]*\r?\n?[ ]*(C\d+[ ]*)?CASH[ ]*ADDED[ ]*\r?\n?[ ]*(TYPE[ ]*\d+[ ]*=[ ]*(?<Added1>\d+))([ ]*TYPE[ ]*\d+[ ]*=[ ]*(?<Added2>\d+))[\r\n]*([ ]*TYPE[ ]*\d+[ ]*=[ ]*(?<Added3>\d+))([ ]*TYPE[ ]*\d+[ ]*=[ ]*(?<Added4>\d+)))|((?<CountsClearingTime>\d+/\d+/\d+\*\d+:\d+)\*\s*CASH[ ]COUNTS[ ]CLEARED\s*CASH[ ]DISPENSED[ ]*(CDM 2)?[\r\n]*(TYPE[ ]\d[ ]=[ ](?<Dispensed>\d+)\s+)+CASH[ ]REMAINING\s*(TYPE[ ]\d[ ]=[ ](?<Remaining>\d+)\s+)+)|((DATE-TIME[ ]+=(?<PrintCountersDateTime>\d{2}/\d{2}/\d{2}[ ]\d{2}:\d{2}))?(\r[ ]+TYPE[ ]\d[ ]+TYPE[ ]\d[ ]*\r[ ]CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)\r\+REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)\r=REMAINING[ |]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)\r\+DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)\r=TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)\r)*[ ]LAST[ ]CLEARED[ ]+(?<LastClearedDateTime>\d+/\d+/\d+[ ]\d+:\d+)\r{3}[ ]CARDS[ ]CAPTURED[ ]+(?<CardsCapturedCount>\d+)|(?<PrintCountersDateTime>\d{1,2}/\d{1,2}/\d{2,4}[ ]+\d{1,2}:\d{1,2})[ ]*[ \r\n]*TYPE[ ]*\d[ ]+TYPE[ ]*\d[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)[ \r\n]*TYPE[ ]*3[ ]+TYPE[ ]*4[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette3>\d+)[ ]+(?<Cassette4>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected3>\d+)[ ]+(?<Rejected4>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining3>\d+)[ ]+(?<Remaining4>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed3>\d+)[ ]+(?<Dispensed4>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total3>\d+)[ ]+(?<Total4>\d+)[ \r\n]*[ \r\n]*[ ]*LAST CLEARED[ ]*[ ]*(?<LastClearedDateTime>\d{1,2}/\d{1,2}/\d{2,4}[ ]+\d{1,2}:\d{1,2}))");
        private Regex regex = new Regex(@"((?<CashAddedTime>\d+/\d+/\d+\*\d+:\d+)\*[ ]*\r?\n?[ ]*(C2[ ]*)?CASH[ ]*ADDED[ ]*\r?\n?[ ]*(TYPE[ ]*\d+[ ]*=[ ]*(?<Added1>\d+))([ ]*TYPE[ ]*\d+[ ]*=[ ]*(?<Added2>\d+))[\r\n]*([ ]*TYPE[ ]*\d+[ ]*=[ ]*(?<Added3>\d+))([ ]*TYPE[ ]*\d+[ ]*=[ ]*(?<Added4>\d+)))|((?<CountsClearingTime>\d+/\d+/\d+\*\d+:\d+)\*\s*CASH[ ]COUNTS[ ]CLEARED\s*CASH[ ]DISPENSED[ ]*(CDM 2)?[\r\n]*(TYPE[ ]\d[ ]=[ ](?<Dispensed>\d+)\s+)+CASH[ ]REMAINING\s*(TYPE[ ]\d[ ]=[ ](?<Remaining>\d+)\s+)+)|((DATE-TIME[ ]+=(?<PrintCountersDateTime>\d{2}/\d{2}/\d{2}[ ]\d{2}:\d{2}))?(\r[ ]+TYPE[ ]\d[ ]+TYPE[ ]\d[ ]*\r[ ]CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)\r\+REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)\r=REMAINING[ |]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)\r\+DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)\r=TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)\r)*[ ]LAST[ ]CLEARED[ ]+(?<LastClearedDateTime>\d+/\d+/\d+[ ]\d+:\d+)\r{3}[ ]CARDS[ ]CAPTURED[ ]+(?<CardsCapturedCount>\d+)|(?<PrintCountersDateTime>\d{1,2}/\d{1,2}/\d{2,4}[ ]+\d{1,2}:\d{1,2})[ ]*[ \r\n]*TYPE[ ]*\d[ ]+TYPE[ ]*\d[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)[ \r\n]*TYPE[ ]*3[ ]+TYPE[ ]*4[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette3>\d+)[ ]+(?<Cassette4>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected3>\d+)[ ]+(?<Rejected4>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining3>\d+)[ ]+(?<Remaining4>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed3>\d+)[ ]+(?<Dispensed4>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total3>\d+)[ ]+(?<Total4>\d+)[ \r\n]*[ \r\n]*[ ]*LAST CLEARED[ ]*[ ]*(?<LastClearedDateTime>\d{1,2}/\d{1,2}/\d{2,4}[ ]+\d{1,2}:\d{1,2}))");
        Regex CountsClearingRegex = new Regex(@"((?<CountsClearingTime>\d+/\d+/\d+\*\d+:\d+)\*\s*CASH[ ]COUNTS[ ]CLEARED\s*CASH[ ]DISPENSED\s*(TYPE[ ]\d[ ]=[ ](?<Dispensed>\d+)\s+)+CASH[ ]REMAINING\s*(TYPE[ ]\d[ ]=[ ](?<Remaining>\d+)\s+)+)");
        Regex CheckSwap = new Regex(@"(?<PrintCountersDateTime>\d{1,2}/\d{1,2}/\d{2,4}[ ]+\d{1,2}:\d{1,2})[ ]*[ \r\n]*TYPE[ ]*\d[ ]+TYPE[ ]*\d[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)[ \r\n]*TYPE[ ]*3[ ]+TYPE[ ]*4[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette3>\d+)[ ]+(?<Cassette4>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected3>\d+)[ ]+(?<Rejected4>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining3>\d+)[ ]+(?<Remaining4>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed3>\d+)[ ]+(?<Dispensed4>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total3>\d+)[ ]+(?<Total4>\d+)[ \r\n]*[ \r\n]*[ ]*LAST CLEARED[ ]*[ ]*(?<LastClearedDateTime>\d{1,2}/\d{1,2}/\d{2,4}[ ]+\d{1,2}:\d{1,2})");
        Match match;
        Match swapMatch;
        Regex AllCashCountsClearing = new Regex(@"((?<CountsClearingTime>\d+/\d+/\d+\*\d+:\d+)\*\s*CASH[ ]COUNTS[ ]CLEARED\s*CASH[ ]DISPENSED[ ]*(CDM 2)?[\r\n]*(TYPE[ ]\d[ ]=[ ](?<Dispensed>\d+)\s+)+CASH[ ]REMAINING\s*(TYPE[ ]\d[ ]=[ ](?<Remaining>\d+)\s+)+)");

        //Variable added by Ali Shah on 29th July, 2016
        //To fix datetime format issue of EJ Data in QIIB for NCR Machine
        string[] printCounterTimeFormat = { "dd/MM/yy HH:mm", "MM/dd/yy HH:mm" };

        private Replenishment AddReplenishmentInCCMS(ref Task downloadTask, ref EjParsedReplenishments cashAdded, ref SqlTransaction trxn, ref bool isSwap)
        {
            Replenishment replenishment2 = new Replenishment();
            replenishment2.AtmId = downloadTask.ATMId;
            replenishment2.RepDatetime = cashAdded.RepDatetime.Value;
            replenishment2.CashAdded1 = cashAdded.NotesAddedType1.Value;
            replenishment2.CashAdded2 = cashAdded.NotesAddedType2.Value;
            replenishment2.CashAdded3 = cashAdded.NotesAddedType3.Value;
            replenishment2.CashAdded4 = cashAdded.NotesAddedType4.Value;
            replenishment2.CashAdded5 = 0;
            replenishment2.CashAdded6 = 0;
            replenishment2.CashAdded7 = 0;
            replenishment2.RepStatus = "Normal";
            replenishment2.IsSwap = isSwap;

            //if (!isSwap)
            //{
            //    if (replenishment2.CashAdded1 > 0 && replenishment2.CashAdded2 > 0 && replenishment2.CashAdded3 > 0 && replenishment2.CashAdded4 > 0)
            //    {
            //        isSwap = true;
            //        replenishment2.IsSwap = true;
            //    }
            //}

            replenishment2.TaskId = downloadTask.TaskId;
            replenishment2.CashOrderId = -1;
            replenishment2.GeneratedAt = DateTime.Now;
            replenishment2.GeneratedBy = 1;
            replenishment2.Reason = cashAdded.EjParsedReplenishmentsId.ToString();
            replenishment2.Save(trxn.Connection, trxn);
            //Added on 11/11 to retain counts cleared status when custodian select ADD CASH by mistake.
            //Change done on 05/02/2015
            //Change done on 05/02/2015
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //else
            //   isSwap = false;
            ParserPostProcessingTask parserPostProcessingTask = new ParserPostProcessingTask();
            parserPostProcessingTask.AtmId = replenishment2.AtmId;
            parserPostProcessingTask.CreationTime = DateTime.Now;
            parserPostProcessingTask.EntityId = replenishment2.ReplenishmentId;
            parserPostProcessingTask.EventInfo = replenishment2.RepDatetime.ToString("MM/dd/yyyy HH:mm:ss") + "|Replenishment|OrderMissing|20180513132747|20180513132747|-1|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|" + replenishment2.CashAdded1 + "|" + replenishment2.CashAdded2 + "|" + replenishment2.CashAdded3 + "|" + replenishment2.CashAdded4 + "|0|0|0";
            parserPostProcessingTask.EventOccuredAt = replenishment2.RepDatetime;
            parserPostProcessingTask.EventType = "Replenishment";
            parserPostProcessingTask.TaskId = replenishment2.TaskId;
            LogableTask.LogMonoActivityTask("ExtractRep", MethodBase.GetCurrentMethod(), TraceLevel.Info, " before add to post processing: " + downloadTask.TaskId);
            parserPostProcessingTask.Save();
            LogableTask.LogMonoActivityTask("ExtractRep", MethodBase.GetCurrentMethod(), TraceLevel.Info, " after add to post processing: " + downloadTask.TaskId);

            return replenishment2;
        }


        EjParsedReplenishments ExtractCashAdd()
        {
            EjParsedReplenishments cashadded = new EjParsedReplenishments();
            DateTime date;
            DateTime.TryParseExact(match.Groups["CashAddedTime"].Captures[0].Value.Replace("*", ""), TimeFormat, null, DateTimeStyles.None, out date);
            if (DateTime.Now < date || globalTask.CreationTime.Month != date.Month)
                DateTime.TryParseExact(match.Groups["CashAddedTime"].Captures[0].Value.Replace("*", ""), TimeFormat1, null, DateTimeStyles.None, out date);

            cashadded.RepDatetime = date;
            LogableTask.LogMonoActivityTask("ExtractCashAdd", MethodBase.GetCurrentMethod(), TraceLevel.Info, "===Task===" + globalTask.TaskId);
            LogableTask.LogMonoActivityTask("ExtractCashAdd", MethodBase.GetCurrentMethod(), TraceLevel.Info, "===Match=== " + match.Value + "==");
            cashadded.NotesAddedType1 = int.Parse(match.Groups["Added1"].Value);
            cashadded.NotesAddedType2 = int.Parse(match.Groups["Added2"].Value);
            cashadded.NotesAddedType3 = int.Parse(match.Groups["Added3"].Value);
            cashadded.NotesAddedType4 = int.Parse(match.Groups["Added4"].Value);
            cashadded.NotesAddedType5 = 0;
            cashadded.NotesAddedType6 = 0;
            cashadded.NotesAddedType7 = 0;
            cashadded.StartIndex = match.Index;
            cashadded.EndIndex = match.Index + match.Length;
            cashadded.ProcessingDatetime = DateTime.Now;

            return cashadded;
        }

        EjNotesDispensed ExtractCashCounts()
        {
            EjNotesDispensed cashcountsclear = new EjNotesDispensed();
            //Edited by Ali Shah on 25th May, 2016 for QIB
            DateTime date = DateTime.MinValue;
            string tempDateTime = match.Groups["CountsClearingTime"].Captures[0].Value;
            if (!String.IsNullOrEmpty(tempDateTime))
                tempDateTime = tempDateTime.Replace("*", "");

            DateTime.TryParseExact(tempDateTime, TimeFormat, null, DateTimeStyles.None, out date);
            if (DateTime.Now < date || globalTask.CreationTime.Month != date.Month)
                DateTime.TryParseExact(tempDateTime, TimeFormat1, null, DateTimeStyles.None, out date);

            cashcountsclear.ClearingDatetime = date;

            LogableTask.LogMonoActivityTask("Just to test", MethodBase.GetCurrentMethod(), TraceLevel.Info, "cashAddedDate: " + date);

            cashcountsclear.NotesDispensedType1 = int.Parse(match.Groups["Dispensed"].Captures[0].Value);
            cashcountsclear.NotesDispensedType2 = int.Parse(match.Groups["Dispensed"].Captures[1].Value);
            cashcountsclear.NotesDispensedType3 = int.Parse(match.Groups["Dispensed"].Captures[2].Value);
            cashcountsclear.NotesDispensedType4 = int.Parse(match.Groups["Dispensed"].Captures[3].Value);

            cashcountsclear.NotesRemainingType1 = int.Parse(match.Groups["Remaining"].Captures[0].Value);
            cashcountsclear.NotesRemainingType2 = int.Parse(match.Groups["Remaining"].Captures[1].Value);
            cashcountsclear.NotesRemainingType3 = int.Parse(match.Groups["Remaining"].Captures[2].Value);
            cashcountsclear.NotesRemainingType4 = int.Parse(match.Groups["Remaining"].Captures[3].Value);

            //cashcountsclear.NotesRemainingType1 = remainingCount.Type1;
            //cashcountsclear.NotesRemainingType2 = remainingCount.Type2;
            //cashcountsclear.NotesRemainingType3 = remainingCount.Type3;
            //cashcountsclear.NotesRemainingType4 = remainingCount.Type4;

            //cashcountsclear.StartIndex = match.Index;
            //cashcountsclear.EndIndex = match.Index + match.Length;
            return cashcountsclear;
        }

        Dispensed ExtractCashCountsClearing()
        {
            Dispensed cashcountsclear = new Dispensed();
            DateTime date;
            DateTime.TryParseExact(match.Groups["CountsClearingTime"].Captures[0].Value.Replace("*", ""), TimeFormat, null, DateTimeStyles.None, out date);
            cashcountsclear.ClearingDatetime = date;

            cashcountsclear.CashDispensed1 = int.Parse(match.Groups["Dispensed"].Captures[0].Value);
            cashcountsclear.CashDispensed2 = int.Parse(match.Groups["Dispensed"].Captures[1].Value);
            cashcountsclear.CashDispensed3 = int.Parse(match.Groups["Dispensed"].Captures[2].Value);
            cashcountsclear.CashDispensed4 = int.Parse(match.Groups["Dispensed"].Captures[3].Value);

            cashcountsclear.CashRemaining1 = int.Parse(match.Groups["Remaining"].Captures[0].Value);
            cashcountsclear.CashRemaining2 = int.Parse(match.Groups["Remaining"].Captures[1].Value);
            cashcountsclear.CashRemaining3 = int.Parse(match.Groups["Remaining"].Captures[2].Value);
            cashcountsclear.CashRemaining4 = int.Parse(match.Groups["Remaining"].Captures[3].Value);

            //cashcountsclear.StartIndex = match.Index;
            //cashcountsclear.EndIndex = match.Index + match.Length;
            return cashcountsclear;
        }

        bool IsDispAndRemZeros(EjNotesDispensed CountClear)
        {
            if (CountClear.NotesDispensedType1 == 0 && CountClear.NotesDispensedType2 == 0 && CountClear.NotesDispensedType3 == 0 && CountClear.NotesDispensedType4 == 0
                && CountClear.NotesRemainingType1 == 0 && CountClear.NotesRemainingType2 == 0 && CountClear.NotesRemainingType3 == 0 && CountClear.NotesRemainingType4 == 0)
                return true;
            else
                return false;
        }
        public void ParseAndSaveReplenishment(ref string ejData, EView360CashDAL.Task downloadTask, LogableTask task, SqlTransaction trxn)
        //ref string ejData, int  atm_id, int FileDownloadInfoId)
        {
            SqlCommand cmd = null;
            try
            {
                globalTask = downloadTask;
                bool isSwap = false;
                bool RepFound = false;
                cmd = ConnectionFactory.GetNewCommand(true);
                match = regex.Match(ejData);
                swapMatch = CheckSwap.Match(ejData);
                EjParsedReplenishments cashAdded;
                Replenishment lastSavedReplenishment = null;
                //MatchCollection matchAllClearCounts = AllCashCountsClearing.Matches(ejData);
                //List<string> AllClearCountsList = matchAllClearCounts.Cast<Match>().Select(match => match.Groups["CountsClearingTime"].Value).ToList();

                DateTime temp;
                while (match.Success)
                {
                    LogableTask.LogMonoActivityTask("Just to test", MethodBase.GetCurrentMethod(), TraceLevel.Info, "==Match==" + match.Value);
                    //if (this.match.Groups["CountsClearingTime"].Success)
                    //{
                    //    //match = match.NextMatch();

                    //    isSwap = true;
                    //    //swapMatch = swapMatch.NextMatch();
                    //    // this.match = this.match.NextMatch();
                    //}
                    if (match.Groups["CountsClearingTime"].Success)
                    {
                        try
                        {
                            EjNotesDispensed cashCountClear;
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, " Before enter Extract Cash count method ");
                            LogableTask.LogMonoActivityTask("ExtractCashCount", MethodBase.GetCurrentMethod(), TraceLevel.Info, " Before enter Extract Cash count method ");
                            cashCountClear = ExtractCashCounts();
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, " after entered Extract Cash count method ");
                            LogableTask.LogMonoActivityTask("ExtractCashCount", MethodBase.GetCurrentMethod(), TraceLevel.Info, " after entered Extract Cash count method ");
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, " Cash count clear Rem values: " + cashCountClear.NotesRemainingType1 + " " + cashCountClear.NotesRemainingType2 + " " + cashCountClear.NotesRemainingType3 + " "
                                + cashCountClear.NotesRemainingType4 + " disp values: " + cashCountClear.NotesDispensedType1 + " " + cashCountClear.NotesDispensedType2 + " " + cashCountClear.NotesDispensedType3 + " " + cashCountClear.NotesDispensedType4);
                            LogableTask.LogMonoActivityTask("ExtractCashCount", MethodBase.GetCurrentMethod(), TraceLevel.Info, " Cash count clear Rem values: " + cashCountClear.NotesRemainingType1 + " " + cashCountClear.NotesRemainingType2 + " " + cashCountClear.NotesRemainingType3 + " "
                                + cashCountClear.NotesRemainingType4 + " disp values: " + cashCountClear.NotesDispensedType1 + " " + cashCountClear.NotesDispensedType2 + " " + cashCountClear.NotesDispensedType3 + " " + cashCountClear.NotesDispensedType4);

                            if(IsDispAndRemZeros(cashCountClear))
                            {
                                match = match.NextMatch();
                                continue;
                            }
                            cmd.CommandText = "isEjClearingCounterExists";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("DisDate", SqlDbType.DateTime));
                            cmd.Parameters[0].Value = cashCountClear.ClearingDatetime;
                            cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
                            cmd.Parameters[1].Value = downloadTask.ATMId;
                            if ((int)cmd.ExecuteScalar() > 0)
                            {
                                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Dispension:  " + ejData.Substring(match.Index, match.Length) + ".because this already exists in dispensed table.");
                                match = match.NextMatch();
                                continue;
                            }

                            cashCountClear.TaskId = downloadTask.TaskId;
                            cashCountClear.AtmId = downloadTask.ATMId;
                            cashCountClear.Save(trxn.Connection, trxn);

                            //match = match.NextMatch();
                            isSwap = true;
                        }
                        catch (Exception ex)
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.ToString());
                            LogableTask.LogMonoActivityTask("ExtractCashCount", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.ToString());
                            throw;
                        }
                    }
                    if (this.match.Groups["CashAddedTime"].Success)
                    {

                        cashAdded = ExtractCashAdd();

                        cashAdded.TaskId = downloadTask.TaskId;
                        cashAdded.AtmId = downloadTask.ATMId;

                        RepFound = true;

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



                        if ((int)cmd.ExecuteScalar() > 0)
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Transaction  " + ejData.Substring(match.Index, match.Length) + ".because this already exists in ej_parsed_replenishment table.");
                            match = match.NextMatch();
                            isSwap = false;
                            RepFound = false;
                            continue;
                        }

                        if (cashAdded.NotesAddedType1 == 0 && cashAdded.NotesAddedType2 == 0 && cashAdded.NotesAddedType3 == 0 && cashAdded.NotesAddedType4 == 0)
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring Transaction  " + ejData.Substring(match.Index, match.Length) + ".becauseall counters are 0.");
                            match = match.NextMatch();
                            //isSwap = false;
                            RepFound = false;
                            continue;
                        }
                        cmd.CommandText = "isEjCounterClearedBeforeRep";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("RepDate", SqlDbType.DateTime));
                        cmd.Parameters[0].Value = cashAdded.RepDatetime;
                        cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
                        cmd.Parameters[1].Value = downloadTask.ATMId;
                        if ((int)cmd.ExecuteScalar() > 0)
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Rep type is Swap");
                            isSwap = true;
                        }
                        else
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Rep type is AddCash");
                            isSwap = false;
                        }

                        cashAdded.Save(trxn.Connection, trxn);
                        Replenishment replenishment = Replenishment.LoadReplenishment(string.Concat(new object[] { "atm_id = ", downloadTask.ATMId, " and rep_datetime>=convert(datetime,'", cashAdded.RepDatetime.Value.ToString("dd/MM/yyyy"), "',103)  and rep_datetime<=convert(datetime,'", cashAdded.RepDatetime.Value.ToString("dd/MM/yyyy"), " 23:59:59',103) " }));
                        //Replenishment replenishment = Replenishment.LoadReplenishment(string.Concat(new object[] { " atm_id = ", downloadTask.ATMId, " and rep_datetime=convert(datetime,'", cashAdded.RepDatetime.Value.ToString("dd/MM/yyyy HH:mm:ss"), "',103)" }));
                        //if (replenishment != null)
                        //{
                        //    //int? nullable2;
                        //    //int num = replenishment.get_CashAdded1();
                        //    //if (num == cashAdded.get_NotesAddedType1())
                        //    //{
                        //    //    num = replenishment.get_CashAdded2();
                        //    //    if (num == cashAdded.get_NotesAddedType2())
                        //    //    {
                        //    //        num = replenishment.get_CashAdded3();
                        //    //        nullable2 = cashAdded.get_NotesAddedType3();
                        //    //    }
                        //    //}
                        //    if (replenishment.CashAdded1!=cashAdded.NotesAddedType1 ||
                        //        replenishment.CashAdded2 != cashAdded.NotesAddedType2 ||
                        //        replenishment.CashAdded3 != cashAdded.NotesAddedType3 ||
                        //        replenishment.CashAdded4 != cashAdded.NotesAddedType4)
                        //    {
                        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "extracting replenishment because counters are different from the counters in ej " + this.match.ToString());
                        //        this.AddReplenishmentInCCMS(ref downloadTask, ref cashAdded, ref trxn, ref isSwap);
                        //    }
                        //    else
                        //    {
                        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring replenishment because it already exist " + this.match.ToString());
                        //    }
                        //}
                        //else
                        //{
                        //if (replenishment == null) // This means Replenishment not inserted by EJ & Counters also so insert it
                        //{
                        lastSavedReplenishment = this.AddReplenishmentInCCMS(ref downloadTask, ref cashAdded, ref trxn, ref isSwap);
                        if (lastSavedReplenishment != null)
                        {
                            isSwap = false;
                        }
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "extracting replenishment " + this.match.ToString());
                        //Added on 05/02/2015

                        //}
                        //else
                        //{

                        //    if (replenishment.Reason != null)
                        //    {
                        //        //If it's extracted from EJ then update it.
                        //        if (isSwap)
                        //        {
                        //            replenishment.CashAdded1 = cashAdded.NotesAddedType1.Value;
                        //            replenishment.CashAdded2 = cashAdded.NotesAddedType2.Value;
                        //            replenishment.CashAdded3 = cashAdded.NotesAddedType3.Value;
                        //            replenishment.CashAdded4 = cashAdded.NotesAddedType4.Value;

                        //        }
                        //        else
                        //        {
                        //            replenishment.CashAdded1 += cashAdded.NotesAddedType1.Value;
                        //            replenishment.CashAdded2 += cashAdded.NotesAddedType2.Value;
                        //            replenishment.CashAdded3 += cashAdded.NotesAddedType3.Value;
                        //            replenishment.CashAdded4 += cashAdded.NotesAddedType4.Value;

                        //        }
                        //        replenishment.IsSwap = isSwap;
                        //        replenishment.Save(trxn.Connection, trxn);
                        //        lastSavedReplenishment = replenishment;
                        //        isSwap = false;
                        //    }
                        //    else
                        //    {
                        //        //If Replenishment is extracted from counter file do not update it
                        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Replenishment already extracted from counters so ignoring it for atm " + replenishment.AtmId + " for the date " + replenishment.RepDatetime);

                        //    }
                        //}
                        //}

                    }
                    
                    match = match.NextMatch();
                }
                BNACountsClearExtractor BnaCountClearObj = new BNACountsClearExtractor();
                BnaCountClearObj.ParseAndSaveBNACountsClear(ref ejData, downloadTask, task, trxn);
                LogableTask.LogMonoActivityTask("ParseAndSaveBNACountsClear ", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Finished extraction all BNA counts clear");
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.ToString());
                LogableTask.LogMonoActivityTask("ExtractCashCount", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.ToString());
                throw;
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
