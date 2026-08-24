using ServicesDAL;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace View360BusinessRulesProcessor.EventProcessor
{
    class WithdrawalProcessor
    {
        public void Run(Queue<ParserPostProcessingTask> queue)
        {
            
            bool a = false, b = false, c = false, d = false;
            Atm atm = null;
            NoteSetType noteSetType = null;
            long lastProcessedATMId = -1;
            LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "Withdrawal queue count:"+queue.Count);

            while (queue.Count > 0)
            //for (int i = 0; i < dtWithdrawal.Rows.Count; i++)
            {
                try
                {
                    ParserPostProcessingTask _parserPostProcessingTask = queue.Dequeue();

                    LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "processing taskid:" + _parserPostProcessingTask.ParserPostProcessingTaskId + " type:" + _parserPostProcessingTask.EventType);

                    ParsedTransaction parsedTrxn = ParsedTransaction.LoadParsedTransaction("parsed_transaction_id = "+_parserPostProcessingTask.EntityId);
                    if (parsedTrxn != null)
                    {
                        long taskID = _parserPostProcessingTask.TaskId;

                        if (lastProcessedATMId != _parserPostProcessingTask.AtmId)
                        {
                            atm = Atm.LoadAtm("atm_id ="+_parserPostProcessingTask.AtmId);
                            noteSetType = NoteSetType.LoadNoteSetType("note_set_type_id="+atm.NoteSetTypeId);
                        }

                        EV360BusinessRulesProcessor.UpdateCashPosition(_parserPostProcessingTask.EventInfo, atm, noteSetType, null, taskID, null, ref a, ref b, ref c, ref d);

                        EV360BusinessRulesProcessor.MinThresholdProcessing(atm, _parserPostProcessingTask.EventInfo.Split('|'), parsedTrxn, noteSetType, taskID);

                        EV360BusinessRulesProcessor.ExecuteStoredProcedure("UpdatePostProcessingTasksById", _parserPostProcessingTask.ParserPostProcessingTaskId.ToString(), null);

                        lastProcessedATMId = atm.ATMId;
                    }
                    else
                    {
                        ConnectionFactory.ExecuteQuery("delete parser_post_processing_task where Parser_Post_Processing_Task_Id = " + _parserPostProcessingTask.ParserPostProcessingTaskId, DatabaseName.Cash);
                        LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "entry removed as parent entity does not exists:" + _parserPostProcessingTask.ParserPostProcessingTaskId);
                    }
                }
                catch (Exception ex )
                {
                    LogableTask.LogMonoActivityTask("p", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Error, ex);

                }


            }

        }
    }
}
