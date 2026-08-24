using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Avanza.CCMS.DAL;
using Avanza.iSuite.DAL;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Diagnostics;
using System.Globalization;
using System.Configuration;

namespace NCR.CCMS.Parser
{
    public class WincorClearCounterEventsExtractor
    {
        private Regex regex = new Regex(@"(\d{1,2}:\d{1,2}:\d{1,2}[ ]+CASH[ ]*IN[ ]*COUNTERS[ ]*BEFORE[ ]*SOP[ ]*[\r\n ]+\d+[ ]*:[ ]*(\d+)[ ]*\w+[\r\n ]+\d+[ ]*:[ ]*\d+[ ]*\w+[\r\n ]+)?(?<ClearCashAndChequeCounterTime>\d{1,2}:\d{1,2}:\d{1,2})[ ]+CASH[ ]*IN[ ]*COUNTERS[ ]*AFTER[ ]*SOP[\r\n ]+\d+[ ]*:[ ]*(?<DepositCounter1AfterSOP>\d+)[ ]*\w+([\r\n ]+\d+:[ ]*(?<DepositCounter2AfterSOP>\d+)[ ]*\w+)?(\d{1,2}:\d{1,2}:\d{1,2}[ ]+CASH[ ]*IN[ ]*COUNTERS[ ]*BEFORE[ ]*SOP[ ]*[\r\n ]+\d+[ ]*:[ ]*(\d+)[ ]*\w+[\r\n ]+\d+[ ]*:[ ]*\d+[ ]*\w+[\r\n ]+)?");
        Regex CounterRegex = new Regex(@"((?<ClearCounterDate>\d{1,2}/\d{1,2}/\d{2,4})[ ]+\d{1,2}:\d{1,2}[ ](MACHINE NO\.:[ ]*.+[ ]*[ \r\n]*TYPE[ ]*\d[ ]+TYPE[ ]*\d[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette1>\d+)[ ]+(?<Cassette2>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected1>\d+)[ ]+(?<Rejected2>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining1>\d+)[ ]+(?<Remaining2>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed1>\d+)[ ]+(?<Dispensed2>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total1>\d+)[ ]+(?<Total2>\d+)[ \r\n]*TYPE[ ]*3[ ]+TYPE[ ]*4[ ]*\r?\n?[ ]*CASSETTE[ ]+(?<Cassette3>\d+)[ ]+(?<Cassette4>\d+)[ ]*\r?\n?[ ]*\+?REJECTED[ ]+(?<Rejected3>\d+)[ ]+(?<Rejected4>\d+)[ ]*\r?\n?[ ]*=?REMAINING[ ]+(?<Remaining3>\d+)[ ]+(?<Remaining4>\d+)[ ]*\r?\n?[ ]*\+?DISPENSED[ ]+(?<Dispensed3>\d+)[ ]+(?<Dispensed4>\d+)[ ]*\r?\n?[ ]*=?TOTAL[ ]+(?<Total3>\d+)[ ]+(?<Total4>\d+)[ \r\n]*)|((ACTUAL RETRACTS[ ]*:[ ]*\d+[ ]*[ \r\n]*)?LAST CLEARED[ ]*:[ ]*(?<LastClearedDateTime>\d{1,2}/\d{1,2}/\d{2,4}[ ]+\d{1,2}:\d{1,2})[ ]*\r?\n?[ ]*CARDS CAPTURED[ ]+(?<CardCapturedCount>\d+)))");
        
        
        Match match;
        Match matchCounters;

        BnaCountsCleared bnaCountsCleared = null;
        CpmCountsCleared cpmCountsCleared = null;

        string[] TimeFormat = { "MM/dd/yy HH:mm:ss", "MM/dd/yyHH:mm:ss", "dd/MM/yy HH:mm", "dd/MM/yyHH:mm:ss" };   //Barwa

        int OffsetClearDepositChunkinMin = int.Parse(ConfigurationManager.AppSettings["OffsetToCheckClearDepositCountEventInMin"] != null ? ConfigurationManager.AppSettings["OffsetToCheckClearDepositCountEventInMin"] : "5");

        public void ParseAndExtractClearCounterEvents(ref string ejData, Task downloadTask, LogableTask task, SqlTransaction trxn)
        {
            SqlCommand cmd = null;

            string clearCounterTime = "";
            string clearCounterDate = "";
            
            try
            {
                cmd = ConnectionFactory.GetNewCommand(true);
                match = regex.Match(ejData);

                DateTime temp;

                while (match.Success)
                {
                    clearCounterTime = "";
                    clearCounterDate = "";

                    bnaCountsCleared = null;
                    cpmCountsCleared = null;

                    string piece = ejData.Substring(0, match.Index);
                    int machineKeywordIndex = piece.LastIndexOf("CASH COUNTERS\r\n");

                    if (machineKeywordIndex < 0)
                    {
                        LogableTask.LogMonoActivityTask("Extract Clear Counter Events", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Clear counters not found to extract clear counter events for taskID:" + downloadTask.TaskId);
                        match = match.NextMatch();
                        continue;
                    }
                    
                    matchCounters = CounterRegex.Match(piece.Substring(machineKeywordIndex));

                    if (!matchCounters.Success || !matchCounters.Groups["ClearCounterDate"].Success)
                    {
                        LogableTask.LogMonoActivityTask("Extract Clear Counter Events", MethodBase.GetCurrentMethod(), TraceLevel.Warning, "DATE Not Found to extract clear counter events for taskID:" + downloadTask.TaskId);
                        match = match.NextMatch();
                        continue;
                    }

                    if (!match.Groups["ClearCashAndChequeCounterTime"].Success)
                    {
                        LogableTask.LogMonoActivityTask("Extract Clear Counter Events", MethodBase.GetCurrentMethod(), TraceLevel.Warning, "TIME Not Found to extract clear counter events for taskID:" + downloadTask.TaskId);
                        match = match.NextMatch();
                        continue;
                    }

                    if ((match.Groups["DepositCounter1AfterSOP"].Success && int.Parse(match.Groups["DepositCounter1AfterSOP"].Value) != 0) || (match.Groups["DepositCounter2AfterSOP"].Success && int.Parse(match.Groups["DepositCounter2AfterSOP"].Value) != 0))
                    {
                        LogableTask.LogMonoActivityTask("Extract Clear Counter Events", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Deposits are not cleared for taskID:" + downloadTask.TaskId);
                        match = match.NextMatch();
                        continue;
                    }

                    clearCounterDate = matchCounters.Groups["ClearCounterDate"].Value;
                    clearCounterTime = match.Groups["ClearCashAndChequeCounterTime"].Value;

                    DateTime.TryParseExact(clearCounterDate + " " + clearCounterTime, TimeFormat, null, DateTimeStyles.None, out temp);

                    bnaCountsCleared = BnaCountsCleared.LoadBnaCountsCleared("atm_id =" + downloadTask.ATMId + " and counts_cleared_at >= Convert(datetime,'" + temp.AddMinutes(-OffsetClearDepositChunkinMin).ToString("dd/MM/yyyy HH:mm:ss") + "',103) and counts_cleared_at <= Convert(datetime,'" + temp.AddMinutes(OffsetClearDepositChunkinMin).ToString("dd/MM/yyyy HH:mm:ss") + "',103)");
                    cpmCountsCleared = CpmCountsCleared.LoadCpmCountsCleared("atm_id =" + downloadTask.ATMId + " and counts_cleared_at >= Convert(datetime,'" + temp.AddMinutes(-OffsetClearDepositChunkinMin).ToString("dd/MM/yyyy HH:mm:ss") + "',103) and counts_cleared_at <= Convert(datetime,'" + temp.AddMinutes(OffsetClearDepositChunkinMin).ToString("dd/MM/yyyy HH:mm:ss") + "',103)");

                    if (bnaCountsCleared == null)
                        bnaCountsCleared = new BnaCountsCleared();
                    if (cpmCountsCleared == null)
                        cpmCountsCleared = new CpmCountsCleared();

                    bnaCountsCleared.AtmId = downloadTask.ATMId;
                    cpmCountsCleared.AtmId = downloadTask.ATMId;

                    bnaCountsCleared.CountsClearedAt = temp;
                    cpmCountsCleared.CountsClearedAt = temp;

                    bnaCountsCleared.RecordedAt = DateTime.Now;
                    cpmCountsCleared.RecordedAt = DateTime.Now;

                    bnaCountsCleared.Save(trxn.Connection, trxn);
                    EJToCounterMapper.EJToCounterMapper.ClearBNACounter(bnaCountsCleared.CountsClearedAt, downloadTask.ATMId, trxn);

                    cpmCountsCleared.Save(trxn.Connection, trxn);
                    EJToCounterMapper.EJToCounterMapper.ClearCPMCounter(cpmCountsCleared.CountsClearedAt, downloadTask.ATMId, trxn);

                    match = match.NextMatch();
                }
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
