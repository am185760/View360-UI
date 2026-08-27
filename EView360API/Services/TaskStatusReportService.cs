using Common.RequestModel;
using Common.ViewModel;
using DataRequestor;
using EView360Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TaskStatusReportService
    {
        //private Executor _executor { get; set; }

        //public TaskStatusReportService(Executor executor)
        //{
        //    _executor = executor;
        //}

        public BaseModel GetTaskStatusReport(TaskStatusReportRequestModel taskStatusReportRequest)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter();
            SqlParameter param2 = new SqlParameter();
            SqlParameter param3 = new SqlParameter();
            SqlParameter param4 = new SqlParameter();
            SqlParameter param5 = new SqlParameter();

            var response = new BaseModel();
            //if (taskStatusReportRequest.FromDate != DateTime.MinValue)
            //    filter += " and creation_time >= convert(datetime,'" + taskStatusReportRequest.FromDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";
            //else
            //    filter += " and creation_time >= getdate() - 3";

            //if (taskStatusReportRequest.FromDate != DateTime.MinValue)
            //    filter += " and creation_time <= convert(datetime,'" + taskStatusReportRequest.ToDate.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            if (taskStatusReportRequest.EndTimeFrom != null && taskStatusReportRequest.EndTimeFrom != DateTime.MinValue)
                filter += " and end_time >= convert(datetime,'" + taskStatusReportRequest.EndTimeFrom.Value.ToString("dd/MM/yyyy HH:mm:ss") + " ',103)";

            if (taskStatusReportRequest.EndTimeFrom != null && taskStatusReportRequest.EndTimeTo != DateTime.MinValue)
                filter += " and end_time <= convert(datetime,'" + taskStatusReportRequest.EndTimeTo.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103)";

            //if (groupbuilder.Length > 0)
            //    filter += " and note_set_type_id in ( " + groupbuilder.ToString() + " ) ";
            if (taskStatusReportRequest.NoteSetTypeId > 0)
            {
                filter += " and note_set_type_id = " + taskStatusReportRequest.NoteSetTypeId;
            }
            if (taskStatusReportRequest.TaskType != null && taskStatusReportRequest.TaskType != string.Empty)
                filter += " and task_type.task_type_id  = " + taskStatusReportRequest.TaskType;

            if (taskStatusReportRequest.UserId > 0)
                filter += " and created_by = " + taskStatusReportRequest.UserId;

            if (taskStatusReportRequest.Status != null && taskStatusReportRequest.Status != string.Empty)
                filter += " and status = '" + taskStatusReportRequest.Status + "'";

            if (taskStatusReportRequest.AtmType != null && taskStatusReportRequest.AtmType != string.Empty)
                filter += " and atm_type = '" + taskStatusReportRequest.AtmType + "'";

            List<TaskStatusReportViewModel> taskStatusReports = new();
            param1 = new SqlParameter();
            param1.ParameterName = "@AtmId";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = string.Join(",", taskStatusReportRequest.SelectedAtms);

            //param2 = new SqlParameter();
            //param2.ParameterName = "@OrderBy";
            //param2.SqlDbType = SqlDbType.VarChar;
            //param2.Value = "title asc"; 


            param2 = new SqlParameter();
            param2.ParameterName = "@FromDate";
            param2.SqlDbType = SqlDbType.DateTime;
            param2.Value = taskStatusReportRequest.FromDate;


            param3 = new SqlParameter();
            param3.ParameterName = "@ToDate";
            param3.SqlDbType = SqlDbType.DateTime;
            param3.Value = taskStatusReportRequest.ToDate;


            param4.ParameterName = "@ArchiveYear";
            param4.SqlDbType = SqlDbType.VarChar;
            param4.Value = taskStatusReportRequest?.ArchiveYear != string.Empty ? $"_{taskStatusReportRequest.ArchiveYear}" : "";


            param5.ParameterName = "@Filter";
            param5.SqlDbType = SqlDbType.VarChar;
            param5.Value = filter;
            //SqlParameter param6 = new SqlParameter()
            //{
            //    ParameterName = "@offset",
            //    SqlDbType = SqlDbType.Int,
            //    Value = 1
            //};

            //SqlParameter param7 = new SqlParameter()
            //{
            //    ParameterName = "@RowCount",
            //    SqlDbType = SqlDbType.Int,
            //    Value = 10000
            //};
            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetReportTaskStatus", new SqlParameter[] { param1, param2, param3, param4, param5 }, taskStatusReportRequest.SelectedAtms);
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = JsonConvert.SerializeObject(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = JsonConvert.SerializeObject(result.Table) };
        }


        public List<TaskStatusReportViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<TaskStatusReportViewModel> taskStatusReports = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    TaskStatusReportViewModel taskStatus = new()
                    {
                        AtmTittle = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                        AtmLocation = !DBNull.Value.Equals(row["location"]) ? row["location"].ToString() : string.Empty,
                        CreationTime = !DBNull.Value.Equals(row["creation_time"]) ? row["creation_time"].ToString() : string.Empty,
                        EndTime = !DBNull.Value.Equals(row["end_time"]) ? row["end_time"].ToString() : string.Empty,
                        FailureReason = !DBNull.Value.Equals(row["reason"]) ? row["reason"].ToString() : string.Empty,
                        LastInvoked = !DBNull.Value.Equals(row["last_invoked"]) ? row["last_invoked"].ToString() : string.Empty,
                        Status = !DBNull.Value.Equals(row["status"]) ? row["status"].ToString() : string.Empty,
                        TaskType = !DBNull.Value.Equals(row["task_type_name"]) ? row["task_type_name"].ToString() : string.Empty,
                    };

                    taskStatusReports.Add(taskStatus);
                }
            }
            return taskStatusReports;

        }
    }
}
