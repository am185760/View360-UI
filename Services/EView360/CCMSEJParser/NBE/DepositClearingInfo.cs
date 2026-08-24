using ServicesDAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;


namespace Avanza.CCMS.Parser
{
    public class DepositClearingInfo
    {
        Regex regexCountsClearing = new Regex(@"(\*(?<CurrentClearingDateTime>\d+/\d+/\d+\*\d+:\d+)\*[\r?\n?]+[ ]+BNA[ ]CNTRS\r?\n?[ ]+LAST[ ]CLEARED[ ]:[ ]\d+/\d+/\d+[ ]\d+:\d+)");
        //Regex regexCountsClearing = new Regex(@"DATE[ ]&[ ]TIME:[ ](?<CurrentDateTime>\d+-\d+-\d+[ ]\d+:\d+:\d+)[ ]+\r?\n?LAST[ ]CLEARED:[ ](?<LastCleared>\d+-\d+-\d+ \d+:\d+:\d+)([ ]+\r?\n?){2}DEPOSIT[ ]COUNTS:[ ]+\r?\n?(\w+[ ]+(?<Denomination>\d+)[ ]X[ ]+(?<Notes>\d+)[ ]=[ ]+\d+[ ]+\r?\n?)+");
        string[] dateFormats = { "MM/dd/yy HH:mm", "MM/dd/yy HH:mm:ss", "yy/MM/dd HH:mm", "yy/MM/dd HH:mm:ss", "MM/dd/yyyy HH:mm", "MM/dd/yyyy HH:mm:ss", "yyyy/MM/dd HH:mm", "yyyy/MM/dd HH:mm:ss" };

        Match match;



        public void ExtractClearingCounters(ref string ejData, ServicesDAL.Task downloadTask, LogableTask task)

        {
            SqlCommand cmd = null;
            try
            {
                //cmd = ConnectionFactory.GetNewCommand(true);
                //cmd.CommandTimeout = 30 * 5;
                //
                match = regexCountsClearing.Match(ejData);

                while (match.Success)
                {
                    DateTime ejClearingDatetime = DateTime.ParseExact(match.Groups["CurrentClearingDateTime"].Value.Replace("*", " "), dateFormats, null, DateTimeStyles.None);
                    if ((int)ConnectionFactory.ExecuteScalar("select count(*) from bna_counts_cleared where atm_id = " + downloadTask.ATMId
                                                   + " and counts_cleared_at>=convert(datetime, '" + ejClearingDatetime.AddMinutes(-5).ToString("dd/MM/yyyy HH:mm:ss") + "',103)"
                                                   + " and counts_cleared_at<=convert(datetime, '" + ejClearingDatetime.AddMinutes(5).ToString("dd/MM/yyyy HH:mm:ss") + "',103)"
                                                   ,DatabaseName.Cash) == 0)
                    {
                        BnaCountsCleared bnaCountsCleared = new BnaCountsCleared();
                        bnaCountsCleared.TaskId = downloadTask.TaskId;
                        bnaCountsCleared.AtmId = downloadTask.ATMId;
                        bnaCountsCleared.CountsClearedAt = ejClearingDatetime;
                        bnaCountsCleared.RecordedAt = DateTime.Now;
                        bnaCountsCleared.Save();
                    }
                    match = match.NextMatch();
                }
            }
            finally
            {
            //    if (cmd != null)
            //        if (cmd.Connection != null)
            //            cmd.Connection.Close();
            }
        }

    }
}

