using System;
using System.Data;
using System.Reflection;

namespace View360BusinessRulesProcessor.EventProcessor
{
    class CPMCountsClearedProcessor
    {
        public void Run(DataTable dtCPMCountsCleared)
        {
            //for (int i = 0; i < dtCPMCountsCleared.Rows.Count; i++)
            //{
            //    try
            //    {
            //        LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "processing taskid:" + dtCPMCountsCleared.Rows[i]["Parser_Post_Processing_Task_Id"] + " type:" + dtCPMCountsCleared.Rows[i]["Event_Type"]);

            //        CpmCountsCleared cpmCountsCleared = CpmCountsCleared.LoadCpmCountsClearedByPk(int.Parse(dtCPMCountsCleared.Rows[i]["entity_id"].ToString()));
            //        if (cpmCountsCleared != null)
            //        {
            //            EV360BusinessRulesProcessor.ExecuteStoredProcedure("UpdateAlert", "alert_type_id=17 and atm_id=" + dtCPMCountsCleared.Rows[i]["atm_id"] + " and resolve_at is null", -1, null);
            //            EV360BusinessRulesProcessor.ExecuteStoredProcedure("UpdatePostProcessingTasksById", dtCPMCountsCleared.Rows[i]["parser_post_processing_task_id"].ToString(), null);
            //        }
            //        else
            //        {
            //            ConnectionFactory.ExecuteQuery("delete parser_post_processing_task where Parser_Post_Processing_Task_Id = " + dtCPMCountsCleared.Rows[i]["Parser_Post_Processing_Task_Id"]);
            //            LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "entry removed as parent entity does not exists:" + dtCPMCountsCleared.Rows[i]["Parser_Post_Processing_Task_Id"]);
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Error, ex);

            //    }

            //}
        }
    }
}
