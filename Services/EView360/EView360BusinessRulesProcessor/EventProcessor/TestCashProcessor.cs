using ServicesDAL;
using System;
using System.Data;
using System.Reflection;

namespace View360BusinessRulesProcessor.EventProcessor
{
    class TestCashProcessor
    {
        public void Run(DataTable dtTestCash)
        {
            bool a = false, b = false, c = false, d = false;

            for (int i = 0; i < dtTestCash.Rows.Count; i++)
            {
                try
                {
                    LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "processing taskid:" + dtTestCash.Rows[i]["Parser_Post_Processing_Task_Id"] + " type:" + dtTestCash.Rows[i]["Event_Type"]);

                    int taskID = int.Parse(dtTestCash.Rows[i]["task_id"].ToString());
                    Atm atm = Atm.LoadAtm("atm_id = "+int.Parse(dtTestCash.Rows[i]["atm_id"].ToString()));

                    TestCashPurgedNotes testCashPurgedNotes = TestCashPurgedNotes.LoadTestCashPurgedNotes("test_cash_purged_notes_id = "+int.Parse(dtTestCash.Rows[i]["entity_id"].ToString()));
                    if (testCashPurgedNotes != null)
                    {
                        NoteSetType noteSetType = NoteSetType.LoadNoteSetType("note_set_type_id="+atm.NoteSetTypeId);
                        EV360BusinessRulesProcessor.UpdateCashPosition(dtTestCash.Rows[i]["event_info"].ToString(), atm, noteSetType, null, taskID, null, ref a, ref b, ref c, ref d);
                        EV360BusinessRulesProcessor.ExecuteStoredProcedure("UpdatePostProcessingTasksById", dtTestCash.Rows[i]["parser_post_processing_task_id"].ToString(), null);
                    }
                    else
                    {
                        ConnectionFactory.ExecuteQuery("delete parser_post_processing_task where Parser_Post_Processing_Task_Id = " + dtTestCash.Rows[i]["Parser_Post_Processing_Task_Id"], DatabaseName.Cash);
                        LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "entry removed as parent entity does not exists:" + dtTestCash.Rows[i]["Parser_Post_Processing_Task_Id"]);
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
