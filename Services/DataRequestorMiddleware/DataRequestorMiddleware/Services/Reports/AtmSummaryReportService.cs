using Common.RequestModel;
using DataRequestor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRequestorMiddleware.Services.Operations;
using Microsoft.Extensions.Logging;

namespace DataRequestorMiddleware.Services.Reports
{
    public class AtmSummaryReportService
    {
        ILogger<AtmSummaryReportService> logger;
        public AtmSummaryReportService(ILogger<AtmSummaryReportService> logger)
        {
            this.logger = logger;
        }

        public DataTableResult GetAtmSummaryReport(AtmSummaryReportViewModel filter)
        {
            Executor _executor = new();

            string queryFilter = "";
            
            if (filter.FromDate.HasValue)
                queryFilter += " and atm.creation_time >= convert(datetime,'" + filter.FromDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";

            if (filter.ToDate.HasValue)
                queryFilter += " and atm.creation_time <= convert(datetime, '" + filter.ToDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ";

            if (!filter.CreatedBy.Equals("*"))
                queryFilter += " and atm.created_by = '" + filter.CreatedBy;
            
            if(!filter.AtmType.Equals("*"))
                queryFilter += " and atm.atm_type = '" + filter.AtmType + "'";
            
            if(filter.NoteSetTypes.Count > 0)
                queryFilter += " and atm.note_set_type_id in ( " + string.Join(",", filter.NoteSetTypes) + " ) ";

            

            if (filter.Status.Equals("Inactive"))
            {
                if (filter.SelectedRegionIds != null || filter.SelectedRegionIds?.Count > 0)
                    queryFilter += " and user_ATMs.user_id = " +filter.UserId +" and atm.is_active = 0 and atm.region_id in (" + string.Join(",", filter.SelectedRegionIds) + ")";
                else
                    queryFilter += " and atm.is_active = 0 and atm.atm_id in (" + string.Join(",", filter.SelectedAtmIds) + ")";
            }

            else if(filter.Status.Equals("Active"))
            {
                if (filter.SelectedRegionIds != null || filter.SelectedRegionIds?.Count > 0)
                    queryFilter += "  and user_ATMs.user_id = " +filter.UserId +" and atm.is_active = 1 and atm.region_id in (" + string.Join(",", filter.SelectedRegionIds) + ")";
                else
                    queryFilter += " and atm.is_active = 1 and atm.atm_id in (" + string.Join(",", filter.SelectedAtmIds) + ")";
            }
            else
            {
                if (filter.SelectedRegionIds != null || filter.SelectedRegionIds?.Count > 0)
                    queryFilter += "  and user_ATMs.user_id = " +filter.UserId  +" and atm.region_id in (" + string.Join(",", filter.SelectedRegionIds) + ")";
                else
                    queryFilter += " and atm.atm_id in (" + string.Join(",", filter.SelectedAtmIds) + ")";
            }

            SqlParameter[] sqlParameters = new SqlParameter[]
                {
                            new SqlParameter() { ParameterName = "@Filter", SqlDbType = SqlDbType.VarChar, Value = queryFilter },
                };
            logger.LogWarning("[AtmSummaryReportService:GetAtmSummaryReport] executing GetAtmSummaryReport sp");
            DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetAtmSummaryReport", sqlParameters, filter.SelectedAtmIds, string.Join(",", filter.SelectedAtmIds));
            logger.LogWarning("[AtmSummaryReportService:GetAtmSummaryReport] returning from GetAtmSummaryReport sp");
            return result;
        }
    }
}
