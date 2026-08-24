using ServicesDAL;
using System;
using System.Data;

namespace View360BusinessRulesProcessor
{
    public static class Utility
    {
        public static ParserPostProcessingTask CreateParserPostProcessingTaskObjectFromDataRow(DataRow dr)
        {
            ParserPostProcessingTask _parserPostProcessingTask = new ParserPostProcessingTask();
            _parserPostProcessingTask.ParserPostProcessingTaskId = int.Parse(dr["parser_post_processing_task_id"].ToString());
            _parserPostProcessingTask.EntityId   = int.Parse(dr["entity_id"].ToString());
            _parserPostProcessingTask.EventInfo= dr["event_info"].ToString();
            _parserPostProcessingTask.EventOccuredAt = DateTime.Parse(dr["event_occured_at"].ToString());
            _parserPostProcessingTask.EventType = dr["event_type"].ToString();
            _parserPostProcessingTask.TaskId = int.Parse(dr["task_id"].ToString());
            _parserPostProcessingTask.AtmId = int.Parse(dr["atm_id"].ToString());
            _parserPostProcessingTask.CreationTime = DateTime.Parse(dr["creation_time"].ToString());
            return _parserPostProcessingTask;
        }
    }
}
