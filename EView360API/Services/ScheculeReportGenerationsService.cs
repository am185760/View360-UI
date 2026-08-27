using Common.RequestModel;
using Common.ViewModel;
using DataRequestor;
using EView360Models.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace Services
{
    public class ScheculeReportGenerationsService
    {
        //private Executor _executor { get; set; }

        //public ScheculeReportGenerationsService(Executor executor)
        //{
        //    _executor = executor;
        //}

        public BaseModel GetScheduleReports(ScheduleReportsRequestModel reportsRequestModel)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter();

            var response = new BaseModel();


            List<ScheduleReportsViewModel> scheduleReports = new();
            param1 = new SqlParameter();
            param1.ParameterName = "@RegionId";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Value = string.Join(",", reportsRequestModel.RegionIds);

            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetScheduleReportGeneration", new SqlParameter[] { param1 }, reportsRequestModel.AtmIds);
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = scheduleReports = ConvertDataTableToList(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }


            return new BaseModel { IsSuccess = true, Data = scheduleReports };
        }

        public BaseModel GetReportGeneration(ReportGenerationRequestModel reportGenerationViewModel)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter();

            var response = new BaseModel();


            List<ReportGenerationViewModel> reportGenerations = new();
            param1 = new SqlParameter();
            param1.ParameterName = "@ReportScheduleId";
            param1.SqlDbType = SqlDbType.Int;
            param1.Value = reportGenerationViewModel.ScheduleReportId;

            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetReportScheduleGenerationByReportScheduleId", new SqlParameter[] { param1 }, reportGenerationViewModel.selectedAtms);
            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = reportGenerations = ConvertReportGenerationDataTableToList(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }


            return new BaseModel { IsSuccess = true, Data = reportGenerations };
        }

        public BaseModel InsertScheduleTimeItems(List<string> scheduleTimeItems, long scheduleReportId, List<string> SelectedAtms)
        {
            string filter = "";
            SqlParameter param1 = new SqlParameter();
            SqlParameter param2 = new SqlParameter();

            var response = new BaseModel();


            param1 = new SqlParameter();
            param1.ParameterName = "@ScheduleReportId";
            param1.SqlDbType = SqlDbType.Int;
            param1.Value = scheduleReportId;

            Executor _executor = new Executor();
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("DeleteScheduleReportGeneration", new SqlParameter[] { param1 }, SelectedAtms);
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }
            foreach (var item in scheduleTimeItems)
            {
                string[] parts = item.Split(':');
                DateTime nextReportGenerationAt = DateTime.Today.AddHours(double.Parse(parts[0])).AddMinutes(double.Parse(parts[1]));

                param1 = new SqlParameter();
                param1.ParameterName = "@ScheduleReportId";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = scheduleReportId;

                param2 = new SqlParameter();
                param2.ParameterName = "@NextGenerationAt";
                param2.SqlDbType = SqlDbType.DateTime;
                param2.Value = nextReportGenerationAt;

               // Executor _executor = new Executor();
                DataTableResult result2 = _executor.ExecuteDSRequest<DataTableResult>("PostScheduleReportGeneration", new SqlParameter[] { param1, param2 }, SelectedAtms);
                if (!string.IsNullOrEmpty(result2.ExceptionMessage))
                {
                    response.Message = result2.ExceptionMessage;
                    return response;
                }
            }


            return new BaseModel { IsSuccess = true };
        }
    //public BaseModel DeleteScheduleReport(DeleteScheduleReportRequestModel deleteScheduleReportRequest)
    //    {
    //        string filter = "";
    //        SqlParameter param1 = new SqlParameter();
    //        SqlParameter param2 = new SqlParameter();

    //        var response = new BaseModel();


    //        param1 = new SqlParameter();
    //        param1.ParameterName = "@ScheduleReportId";
    //        param1.SqlDbType = SqlDbType.Int;
    //        param1.Value = deleteScheduleReportRequest.ScheduleReportId;


    //        DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("DeleteSheduleReport", new SqlParameter[] { param1 }, deleteScheduleReportRequest.SelectedAtms);
    //        if (!string.IsNullOrEmpty(result.ExceptionMessage))
    //        {
    //            response.Message = result.ExceptionMessage;
    //            return response;
    //        }         

    //        return new BaseModel { IsSuccess = true };
    //    }

        //public BaseModel UpdateScheduleAndGenerationReport(UpdateScheduleReportRequestModel updateScheduleReportRequestModel)
        //{
        //    var ResportGenerationRepoonse = InsertScheduleTimeItems(updateScheduleReportRequestModel.ScheduleReportTime, updateScheduleReportRequestModel.ScheduleReportId, updateScheduleReportRequestModel.SelectedAtms);
        //    if (ResportGenerationRepoonse.IsSuccess)
        //    {
        //        var scheduleReponse = UpdateScheduleReport(updateScheduleReportRequestModel);
        //        if (scheduleReponse.IsSuccess)
        //        {
        //            return new BaseModel {IsSuccess=true,Message="Report is succesfully updated" };
        //        }
        //    }

        //    return new BaseModel { IsSuccess = false, Message = "Error accured" };

        //}
        //public BaseModel UpdateScheduleReport(UpdateScheduleReportRequestModel updateScheduleReportRequestModel)
        //{
        //    string filter = "";
        //    SqlParameter param1 = new SqlParameter();
        //    SqlParameter param3 = new SqlParameter();
        //    SqlParameter param4 = new SqlParameter();
        //    SqlParameter param5 = new SqlParameter();
        //    SqlParameter param6 = new SqlParameter();
        //    SqlParameter param7 = new SqlParameter();
        //    SqlParameter param8 = new SqlParameter();
        //    SqlParameter param9 = new SqlParameter();
        //    SqlParameter param10 = new SqlParameter();
        //    SqlParameter param11 = new SqlParameter();
        //    SqlParameter param12 = new SqlParameter();

        //    var response = new BaseModel();

        //    if (updateScheduleReportRequestModel.ExportPDFChecked)
        //    {
        //        updateScheduleReportRequestModel.ExportType = 1;
        //    }
        //    if (updateScheduleReportRequestModel.ExportExcelChecked)
        //    {
        //        updateScheduleReportRequestModel.ExportType = 2;
        //    }
        //    if (updateScheduleReportRequestModel.ExportPDFChecked && updateScheduleReportRequestModel.ExportExcelChecked)
        //    {
        //        updateScheduleReportRequestModel.ExportType = 3;
        //    }

        //    param1 = new SqlParameter();
        //    param1.ParameterName = "@ScheduleReportId";
        //    param1.SqlDbType = SqlDbType.BigInt;
        //    param1.Value = updateScheduleReportRequestModel.ScheduleReportId;


        //    param3 = new SqlParameter();
        //    param3.ParameterName = "@ReportPhysicalPath";
        //    param3.SqlDbType = SqlDbType.VarChar;
        //    param3.Value = updateScheduleReportRequestModel.ReportsPhysicalPath;

        //    param4 = new SqlParameter();
        //    param4.ParameterName = "@ReportReceipients";
        //    param4.SqlDbType = SqlDbType.VarChar;
        //    param4.Value = updateScheduleReportRequestModel.Recipitents;

        //    param5 = new SqlParameter();
        //    param5.ParameterName = "@ReportTempPath";
        //    param5.SqlDbType = SqlDbType.VarChar;
        //    param5.Value = updateScheduleReportRequestModel.ReportstTempPath;

        //    param6 = new SqlParameter();
        //    param6.ParameterName = "@RetryCount";
        //    param6.SqlDbType = SqlDbType.Int;
        //    param6.Value = updateScheduleReportRequestModel.RetryCount;

        //    param7 = new SqlParameter();
        //    param7.ParameterName = "@ReportNextGeneratedAt";
        //    param7.SqlDbType = SqlDbType.DateTime;
        //    param7.Value = DateTime.Today;

        //    param8 = new SqlParameter();
        //    param8.ParameterName = "@ReportFriendlyName";
        //    param8.SqlDbType = SqlDbType.VarChar;
        //    param8.Value = updateScheduleReportRequestModel.ReportFriendlyName;

        //    param9 = new SqlParameter();
        //    param9.ParameterName = "@MininutesToScheduleAgain";
        //    param9.SqlDbType = SqlDbType.Int;
        //    param9.Value = updateScheduleReportRequestModel.MinutesToScheduleAgain;

        //    param10 = new SqlParameter();
        //    param10.ParameterName = "@ReportExportType";
        //    param10.SqlDbType = SqlDbType.SmallInt;
        //    param10.Value = updateScheduleReportRequestModel.ExportType;

        //    param11 = new SqlParameter();
        //    param11.ParameterName = "@ReportDataAge";
        //    param11.SqlDbType = SqlDbType.Int;
        //    param11.Value = updateScheduleReportRequestModel.ExportDataOlderThan;

        //    param12 = new SqlParameter();
        //    param12.ParameterName = "@ScheduleType";
        //    param12.SqlDbType = SqlDbType.Bit;
        //    param12.Value = updateScheduleReportRequestModel.ScheduleType;

        //    DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("UpdateSheduleReport", new SqlParameter[] { param1, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12 }, updateScheduleReportRequestModel.SelectedAtms);

        //    if (!string.IsNullOrEmpty(result.ExceptionMessage))
        //    {
        //        response.Message = result.ExceptionMessage;
        //        return response;
        //    }


        //    return new BaseModel { IsSuccess = true };
        //}



        public List<ScheduleReportsViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<ScheduleReportsViewModel> scheduleReports = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    ScheduleReportsViewModel scheduleReport = new()
                    {
                        Organizations = !DBNull.Value.Equals(row["region_name"]) ? row["region_name"].ToString() : string.Empty,
                        CitName = !DBNull.Value.Equals(row["cit_name"]) ? row["cit_name"].ToString() : string.Empty,
                        ReportName = !DBNull.Value.Equals(row["report_name"]) ? row["report_name"].ToString() : string.Empty,
                        ReportFriendlyName = !DBNull.Value.Equals(row["report_friendly_name"]) ? row["report_friendly_name"].ToString() : string.Empty,
                        ReportsPhysicalPath = !DBNull.Value.Equals(row["report_physical_path"]) ? row["report_physical_path"].ToString() : string.Empty,
                        ReportstTempPath = !DBNull.Value.Equals(row["report_temp_path"]) ? row["report_temp_path"].ToString() : string.Empty,
                        Recipitents = !DBNull.Value.Equals(row["report_receipients"]) ? row["report_receipients"].ToString() : string.Empty,
                        ReportScheduleId = !DBNull.Value.Equals(row["report_Schedule_id"]) ? Convert.ToInt32(row["report_Schedule_id"].ToString()) : 0,
                        RetryCount = !DBNull.Value.Equals(row["retry_count"]) ? Convert.ToInt32(row["retry_count"].ToString()) : 0,
                        //ExportType = !DBNull.Value.Equals(row["report_export_type"]) ? Convert.ToInt32(row["report_export_type"].ToString()) : 0,
                        ExportDataOlderThan = !DBNull.Value.Equals(row["report_data_age"]) ? Convert.ToInt32(row["report_data_age"].ToString()) : 0,
                        MinutesToScheduleAgain = !DBNull.Value.Equals(row["minutes_to_schedule_again"]) ? Convert.ToInt32(row["minutes_to_schedule_again"].ToString()) : 0,
                        ScheduleType = !DBNull.Value.Equals(row["schedule_type"]) ? Convert.ToBoolean(row["schedule_type"].ToString()) : false,
                    };

                    scheduleReports.Add(scheduleReport);
                }
            }
            return scheduleReports;

        }

        public List<ReportGenerationViewModel> ConvertReportGenerationDataTableToList(DataTable dataTable)
        {
            List<ReportGenerationViewModel> reportGenerations = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    ReportGenerationViewModel reportGeneration = new()
                    {
                        ScheduleReportGenerationId = !DBNull.Value.Equals(row["report_generation_schedule_id"]) ? Convert.ToInt32(row["report_generation_schedule_id"].ToString()) : 0,
                        ScheduleReportId = !DBNull.Value.Equals(row["report_schedule_id"]) ? Convert.ToInt32(row["report_schedule_id"].ToString()) : 0,
                        NextGenerationAt = !DBNull.Value.Equals(row["next_generation_at"]) ? Convert.ToDateTime(row["next_generation_at"].ToString()) : null,
                    };

                    reportGenerations.Add(reportGeneration);
                }
            }
            return reportGenerations;

        }
    }
}
