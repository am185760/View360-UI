using Common.RequestModel;
using Common.ViewModel;
using DataRequestor;
using EView360Models.ViewModels;
using System.Data.SqlClient;
using System.Data;
using DataRequestorMiddleware.Services.Operations;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Analytics
{
    public class DenominationUtilizationAnalysisServiceMW
    {
        private Executor _executor { get; set; }
        ILogger<DenominationUtilizationAnalysisServiceMW> logger;
        public DenominationUtilizationAnalysisServiceMW(Executor executor, ILogger<DenominationUtilizationAnalysisServiceMW> logger)
        {
            _executor = executor;
            this.logger = logger;
        }

        public BaseModel GetDenominationUtilizationAnalysis(DenominationUtilizationAnalysisRequestModel filter)
        {
            string queryFilter = "";
            var response = new BaseModel();

            if (filter.fromDate.HasValue)
                queryFilter += "trxn_datetime >= convert(datetime, '" + filter.fromDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) and ";

            if (filter.toDate.HasValue)
                queryFilter += "trxn_datetime <= convert(datetime, '" + filter.toDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) and ";

            if (filter.notesetTypeId != null)
                queryFilter += " atm.note_set_type_id = " + filter.notesetTypeId + " and ";

            if (filter.SelectedRegionIds != null || filter.SelectedRegionIds?.Count > 0)
                queryFilter += " atm.region_id in (" + string.Join(",", filter.SelectedRegionIds) + ") and user_ATMs.user_id = " +filter.UserId + " and atm.is_active=1 ";
                
            else
                queryFilter += " atm.atm_id in (" + string.Join(",", filter.SelectedAtmIds) + ")";

            List<DenominationUtilizationAnalysisViewModel> denominationUtilizations = new();
            SqlParameter[] paramArray = new SqlParameter[]
            {
                    new SqlParameter() {ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = queryFilter},
                    new SqlParameter() {ParameterName = "@Orderby", SqlDbType = SqlDbType.VarChar, Value = "trxn_datetime"}
            };

            logger.LogWarning("[DenominationUtilizationAnalysisServiceMW:GetDenominationUtilizationAnalysis] executing GetDenominationUtilization sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetDenominationUtilization", paramArray, filter.SelectedAtmIds, string.Join(",", filter.SelectedAtmIds));
            logger.LogWarning("[DenominationUtilizationAnalysisServiceMW:GetDenominationUtilizationAnalysis] returning from GetDenominationUtilization sp");

            if (result?.Table?.Rows?.Count > 0)
            {
                response.Data = denominationUtilizations = ConvertDataTableToList(result.Table);
            }
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
            {
                response.Message = result.ExceptionMessage;
                return response;
            }

            return new BaseModel { IsSuccess = true, Data = denominationUtilizations };
        }

        public List<DenominationUtilizationAnalysisViewModel> ConvertDataTableToList(DataTable dataTable)
        {
            List<DenominationUtilizationAnalysisViewModel> denominationUtilizations = new();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    DenominationUtilizationAnalysisViewModel denominationUtilization = new()
                    {
                        //DispensedDate = !DBNull.Value.Equals(row["trxn_datetime"]) ? Convert.ToDateTime(row["trxn_datetime"]) : null,
                        DispensedDate = !DBNull.Value.Equals(row["trxn_datetime"]) ? DateTime.ParseExact((string)row["trxn_datetime"], "dd/MM/yyyy", null) : null,
                        NotesDispensed1 = !DBNull.Value.Equals(row["notesDispensed1"]) ? Convert.ToInt32(row["notesDispensed1"]) : 0,
                        NotesDispensed2 = !DBNull.Value.Equals(row["notesDispensed2"]) ? Convert.ToInt32(row["notesDispensed2"]) : 0,
                        NotesDispensed3 = !DBNull.Value.Equals(row["notesDispensed3"]) ? Convert.ToInt32(row["notesDispensed3"]) : 0,
                        NotesDispensed4 = !DBNull.Value.Equals(row["notesDispensed4"]) ? Convert.ToInt32(row["notesDispensed4"]) : 0
                    };
                    denominationUtilizations.Add(denominationUtilization);
                }
            }
            return denominationUtilizations;
        }

        //public BaseModel GetNotesetTypesByAtmIds(List<long> atmIds)
        //{
        //    var response = new BaseModel();

        //    List<NotesetTypeAnalyticsViewModel> atmNotesetTypes = new();
        //    SqlParameter[] paramArray = new SqlParameter[]
        //    {
        //            new SqlParameter() {ParameterName = "@AtmIds", SqlDbType = SqlDbType.VarChar, Value = string.Join(",", atmIds)},
        //    };

        //    List<string> atmIdsString = atmIds.ConvertAll<string>(x => x.ToString());

        //    DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetNotesetTypesByAtmIds", paramArray, atmIdsString);
        //    if (result?.Table?.Rows?.Count > 0)
        //    {
        //        response.Data = atmNotesetTypes = ConvertNotesetTypeDataTableToList(result.Table);
        //    }
        //    if (!string.IsNullOrEmpty(result.ExceptionMessage))
        //    {
        //        response.Message = result.ExceptionMessage;
        //        return response;
        //    }

        //    return new BaseModel { IsSuccess = true, Data = atmNotesetTypes };
        //}

        //public List<NotesetTypeAnalyticsViewModel> ConvertNotesetTypeDataTableToList(DataTable dataTable)
        //{
        //    List<NotesetTypeAnalyticsViewModel> atmNotesetTypes = new();

        //    if (dataTable != null)
        //    {
        //        foreach (DataRow row in dataTable.Rows)
        //        {
        //            NotesetTypeAnalyticsViewModel atmNotesetType = new()
        //            {
        //                NoteSetTypeId = !DBNull.Value.Equals(row["note_set_type_id"]) ? Convert.ToInt64(row["note_set_type_id"]) : 0,
        //                NoteSetTypeName = !DBNull.Value.Equals(row["note_set_type_name"]) ? row["note_set_type_name"].ToString() : string.Empty,
        //                DenominationType1Title = !DBNull.Value.Equals(row["denomination_type_1_title"]) ? row["denomination_type_1_title"].ToString() : "Undefined1",
        //                DenominationType1 = !DBNull.Value.Equals(row["denomination_type_1"]) ? Convert.ToInt32(row["denomination_type_1"]) : 0,
        //                DenominationType2Title = !DBNull.Value.Equals(row["denomination_type_2_title"]) ? row["denomination_type_2_title"].ToString() : "Undefined2",
        //                DenominationType2 = !DBNull.Value.Equals(row["denomination_type_2"]) ? Convert.ToInt32(row["denomination_type_2"]) : 0,
        //                DenominationType3Title = !DBNull.Value.Equals(row["denomination_type_3_title"]) ? row["denomination_type_3_title"].ToString() : "Undefined3",
        //                DenominationType3 = !DBNull.Value.Equals(row["denomination_type_3"]) ? Convert.ToInt32(row["denomination_type_3"]) : 0,
        //                DenominationType4Title = !DBNull.Value.Equals(row["denomination_type_4_title"]) ? row["denomination_type_4_title"].ToString() : "Undefined4",
        //                DenominationType4 = !DBNull.Value.Equals(row["denomination_type_4"]) ? Convert.ToInt32(row["denomination_type_4"]) : 0,
        //            };
        //            atmNotesetTypes.Add(atmNotesetType);
        //        }
        //    }
        //    return atmNotesetTypes;
        //}
    }
}
