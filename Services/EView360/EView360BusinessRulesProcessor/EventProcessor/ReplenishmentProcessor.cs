using ServicesDAL;
using System;
using System.Data;
using System.Reflection;

namespace View360BusinessRulesProcessor.EventProcessor
{
    class ReplenishmentProcessor
    {
        public void Run(DataTable dtReplenishment)
        {
            bool a = false, b = false, c = false, d = false;
            NoteSetType noteSetType = null;
            long lastProcessedATMId = -1;
            Atm atm = null;

            for (int i = 0; i < dtReplenishment.Rows.Count; i++)
            {
                try
                {
                    LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "processing taskid:" + dtReplenishment.Rows[i]["Parser_Post_Processing_Task_Id"] + " type:" + dtReplenishment.Rows[i]["Event_Type"]);

                    Replenishment replenishment = Replenishment.LoadReplenishment("replenishment_id = "+int.Parse(dtReplenishment.Rows[i]["entity_id"].ToString()));
                    if (replenishment != null)
                    {
                        int taskID = int.Parse(dtReplenishment.Rows[i]["task_id"].ToString());
                        if (lastProcessedATMId != replenishment.AtmId)
                        {
                            atm = Atm.LoadAtm("atm_id = "+int.Parse(dtReplenishment.Rows[i]["atm_id"].ToString()));
                            noteSetType = NoteSetType.LoadNoteSetTypeByPk(atm.NoteSetTypeId);
                        }
                        EV360BusinessRulesProcessor.UpdateCashPosition(dtReplenishment.Rows[i]["event_info"].ToString(), atm, noteSetType, null, taskID, null, ref a, ref b, ref c, ref d);
                        EV360BusinessRulesProcessor.ExecuteStoredProcedure("UpdatePostProcessingTasksById", dtReplenishment.Rows[i]["parser_post_processing_task_id"].ToString(), null);

                        EV360BusinessRulesProcessor.HandleReplenishment(replenishment, atm, null, noteSetType, taskID);
                        //EV360BusinessRulesProcessor.HandleLedger(atm, dtReplenishment.Rows[i]["event_info"].ToString().Split('|'), null, replenishment);
                        lastProcessedATMId = atm.ATMId;

                    }
                    else
                    {
                        ConnectionFactory.ExecuteQuery("delete parser_post_processing_task where Parser_Post_Processing_Task_Id = " + dtReplenishment.Rows[i]["Parser_Post_Processing_Task_Id"], DatabaseName.Cash);
                        LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "entry removed as parent entity does not exists:"+ dtReplenishment.Rows[i]["Parser_Post_Processing_Task_Id"]);

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
