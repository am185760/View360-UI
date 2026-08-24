using ServicesDAL;
using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading;

namespace View360BusinessRulesProcessor.PurgingManager
{
    static class PurgeManager
    {
        public static void DoPurge()
        {
            DateTime scheduleTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            TimeSpan timeSpan = DateTime.Now - scheduleTime;
            bool isPurgeExecuted = false;
            while (true)
            {
                try
                {
                    timeSpan = DateTime.Now - scheduleTime;

                    if (timeSpan.TotalSeconds > 0 || !isPurgeExecuted)
                    {
                        LogableTask.LogMonoActivityTask("", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "time to purge arrived");
                        using (SqlCommand cmd = ConnectionFactory.GetNewCommand(true, DatabaseName.Cash))
                        {
                            cmd.CommandText = "purgePostProcessingTask";
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.ExecuteNonQuery();
                        }
                        scheduleTime = scheduleTime.AddDays(1);
                        LogableTask.LogMonoActivityTask("", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "table purged successfully");
                        isPurgeExecuted = true;
                    }

                }
                catch (Exception ex)
                {
                    LogableTask.LogMonoActivityTask("", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Error, ex);

                }
                LogableTask.LogMonoActivityTask("", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "going to sleep for " +timeSpan.TotalSeconds + " seconds");
                Thread.Sleep((int)Math.Abs(timeSpan.TotalSeconds) * 1000);
            }
        }
    }
}
