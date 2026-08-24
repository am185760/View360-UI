using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Avanza.CCMS.DAL;
using System.Data;
using Avanza.iSuite.DAL;
using System.Data.SqlClient;
using System.Reflection;
using System.Collections;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Linq;

namespace NCR.CCMS.Parser
{
    public class BNACountsClearExtractor
    {
        string[] TimeFormat = { "dd/MM/yyyy HH:mm", "dd/MM/yyyyHH:mm","dd/MM/yy HH:mm", "dd/MM/yyHH:mm" };
        string[] TimeFormat1 = { "MM/dd/yyyy HH:mm", "MM/dd/yyyyHH:mm" , "MM/dd/yy HH:mm", "MM/dd/yyHH:mm" };

        Regex BNAClearRegex = new Regex(@"BNA CNTRS[\r\n]*[ ]*LAST[ ]*CLEARED[ \:]*(?<BNA_CLEAR_DTIME>\d+\/\d+\/\d+[ ]*\d+\:\d+)");
        Match BNAClearMatch;

        BnaCountsCleared ExtractBNACountsClear(Task downloadTask)
        {
            BnaCountsCleared BNAClear = new BnaCountsCleared();
            DateTime date;
            DateTime.TryParseExact(BNAClearMatch.Groups["BNA_CLEAR_DTIME"].Captures[0].Value.Replace("*", ""), TimeFormat, null, DateTimeStyles.None, out date);
            if (DateTime.Now < date || downloadTask.CreationTime.Month != date.Month)
                DateTime.TryParseExact(BNAClearMatch.Groups["BNA_CLEAR_DTIME"].Captures[0].Value.Replace("*", ""), TimeFormat1, null, DateTimeStyles.None, out date);

            BNAClear.CountsClearedAt = date;
            BNAClear.AtmId = downloadTask.ATMId;
            BNAClear.TaskId = downloadTask.TaskId;
            BNAClear.RecordedAt = DateTime.Now;

            return BNAClear;
        }
        public void ParseAndSaveBNACountsClear(ref string ejData, Task downloadTask, LogableTask task, SqlTransaction trxn)
        {
            SqlCommand cmd = null;
            try
            {
                BnaCountsCleared BNAClearObj = new BnaCountsCleared();
                cmd = ConnectionFactory.GetNewCommand(true);
                BNAClearMatch = BNAClearRegex.Match(ejData);
                while (BNAClearMatch.Success)
                {
                    LogableTask.LogMonoActivityTask("ParseAndSaveBNACountsClear ", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Match found in Task ID: " + downloadTask.TaskId + " and ATM ID: " + downloadTask.ATMId);

                    if (BNAClearMatch.Groups["BNA_CLEAR_DTIME"].Success)
                    {
                        BNAClearObj = ExtractBNACountsClear(downloadTask);

                        if (BNAClearObj != null && BNAClearObj.CountsClearedAt != DateTime.MinValue)
                        {
                            cmd.CommandText = "isBNACountsClearExists";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("BNAClearDateTime", SqlDbType.DateTime));
                            cmd.Parameters[0].Value = BNAClearObj.CountsClearedAt;
                            cmd.Parameters.Add(new SqlParameter("atmID", SqlDbType.Int));
                            cmd.Parameters[1].Value = downloadTask.ATMId;
                            if ((int)cmd.ExecuteScalar() > 0)
                            {
                                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Ignoring BNA Counts Clear:  " + ejData.Substring(BNAClearMatch.Index, BNAClearMatch.Length) + ".because this already exists in BNA counts cleared table.");
                                BNAClearMatch = BNAClearMatch.NextMatch();
                                continue;
                            }
                            BNAClearObj.Save(trxn.Connection, trxn);
                            LogableTask.LogMonoActivityTask("ParseAndSaveBNACountsClear ", MethodBase.GetCurrentMethod(), TraceLevel.Info,"BNA counts clear saved for task ID: "+downloadTask.TaskId +" and ATM ID: "+downloadTask.ATMId);
                        }
                    }
                    BNAClearMatch = BNAClearMatch.NextMatch();
                }
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.ToString());
                LogableTask.LogMonoActivityTask("ParseAndSaveBNACountsClear ", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.ToString());
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
