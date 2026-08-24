using ServicesDAL;
using System;
using System.Data;
using System.Reflection;

namespace View360BusinessRulesProcessor.EventProcessor
{
    class BNACountsClearedProcessor
    {
        public void Run(DataTable dtBNACountsCleared)
        {
            for (int i = 0; i < dtBNACountsCleared.Rows.Count; i++)
            {
                try
                {
                    LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "processing taskid:" + dtBNACountsCleared.Rows[i]["Parser_Post_Processing_Task_Id"] + " type:" + dtBNACountsCleared.Rows[i]["Event_Type"]);

                    BnaCountsCleared bnaCountsCleared = BnaCountsCleared.LoadBnaCountsClearedByPk(int.Parse(dtBNACountsCleared.Rows[i]["entity_id"].ToString()));
                    if (bnaCountsCleared != null)
                    {
                        EV360BusinessRulesProcessor.ExecuteStoredProcedure("UpdateAlert", "alert_type_id=18 and atm_id=" + dtBNACountsCleared.Rows[i]["atm_id"] + " and resolve_at is null", -1, null);
                        EV360BusinessRulesProcessor.ExecuteStoredProcedure("UpdatePostProcessingTasksById", dtBNACountsCleared.Rows[i]["parser_post_processing_task_id"].ToString(), null);
                    }
                    else
                    {
                        ConnectionFactory.ExecuteQuery("delete parser_post_processing_task where entity_id = " + dtBNACountsCleared.Rows[i]["Parser_Post_Processing_Task_Id"], DatabaseName.Cash);
                        LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "entry removed as parent entity does not exists:" + dtBNACountsCleared.Rows[i]["Parser_Post_Processing_Task_Id"]);

                    }
                }
                catch (Exception ex)
                {
                    LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Error, ex);

                }
            }
        }
    }
}
