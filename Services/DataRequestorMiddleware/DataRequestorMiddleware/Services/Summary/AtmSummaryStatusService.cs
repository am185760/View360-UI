using Encryption;
using EView360Models.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRequestor;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DataRequestorMiddleware.Services.Summary
{
    public class AtmSummaryStatusService
    {
        private ILogger _logger { get; set; }
        public AtmSummaryStatusService(ILogger<AtmSummaryStatusService> logger)
        {
            _logger = logger;
        }
        public List<AtmStatusViewModel> GetAtmsStatus(List<string> atmIds, string filter, string spName, ref string error)
        {
            List<AtmStatusViewModel> atms = new();
            List<TaskStatusViewModel> taskStatusView = new();

            try
            {
                _logger.LogWarning($"AtmSummaryStatusService: GetAtmsStatus enter  : {DateTime.Now.ToString()}");

                SqlParameter param3 = new SqlParameter()
                {
                    ParameterName = "@Filter",
                    SqlDbType = SqlDbType.VarChar,
                    Value = filter
                };

                _logger.LogWarning($"AtmSummaryStatusService: GetAtmsStatus going in ExecuteDSRequestForDataSet  : {DateTime.Now.ToString()}");

                Executor _executor = new Executor();
                DataSetResult result = _executor.ExecuteDSRequestForDataSet<DataSetResult>(spName, new SqlParameter[] { param3 }, atmIds, string.Join(",", atmIds));

                _logger.LogWarning($"AtmSummaryStatusService: GetAtmsStatus return from ExecuteDSRequestForDataSet  : {DateTime.Now.ToString()}");

                

                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                {
                    error = result.ExceptionMessage;
                }

                if (result?.DataSet?.Tables?.Count > 0)
                {
                    foreach (DataRow row in result.DataSet.Tables[0].Rows)
                    {
                        AtmStatusViewModel atmStatusView = new()
                        {
                            AtmId = !DBNull.Value.Equals(row["atm_id"]) ? Convert.ToInt32(row["atm_id"]) : 0,
                            Title = !DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty,
                            LastTransaction = !DBNull.Value.Equals(row["last_trxn_at"]) ? Convert.ToDateTime(row["last_trxn_at"]) : null
                        };
                        atms.Add(atmStatusView);
                    }
                }
                if (atms?.Count > 0)
                {
                    if (result?.DataSet.Tables[1]?.Rows?.Count > 0)
                    {
                        foreach (DataRow row in result.DataSet.Tables[1].Rows)
                        {
                            TaskStatusViewModel taskStatus = new()
                            {
                                AtmId = !DBNull.Value.Equals(row["atm_id"]) ? Convert.ToInt32(row["atm_id"]) : 0,
                                Status = !DBNull.Value.Equals(row["status"]) ? row["status"].ToString() : string.Empty,
                                LastInvoked = !DBNull.Value.Equals(row["last_invoked"]) ? Convert.ToDateTime(row["last_invoked"]) : null
                            };
                            taskStatusView.Add(taskStatus);
                        }
                    }

                    Parallel.ForEach(atms, atm =>
                    {
                        if (taskStatusView.Any(x => x.AtmId == atm.AtmId))
                        {
                            TaskStatusViewModel taskStatus = taskStatusView.FirstOrDefault(x => x.AtmId == atm.AtmId)!;

                            atm.LastTaskStatus = taskStatus.Status;
                            atm.LastInvoked = taskStatus.LastInvoked;
                        }
                    });
                }                
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            _logger.LogWarning($"AtmSummaryStatusService: GetAtmsStatus exit  : {DateTime.Now.ToString()}");
            return atms;
        }

        public AtmSummaryStatusModel GetTransactingATMTitle(List<string> atmIds, string filter, ref string errorMsg)
        {
            AtmSummaryStatusModel model = new();
            
            if (atmIds?.Count > 0)
            {

                SqlParameter param3 = new SqlParameter()
                {
                    ParameterName = "@Filter",
                    SqlDbType = SqlDbType.VarChar,
                    Value = filter
                };
                Executor _executor = new Executor();
                DataSetResult result = _executor.ExecuteDSRequestForDataSet<DataSetResult>("GetTransactingATMTitle", new SqlParameter[] { param3 }, atmIds, string.Join(",", atmIds));
                if (!string.IsNullOrEmpty(result.ExceptionMessage))
                {
                    errorMsg = result.ExceptionMessage;
                }
                if (result?.DataSet?.Tables?.Count > 0) 
                {
                    model.atmTiles = new();

                    if (result.DataSet.Tables[0]?.Rows?.Count > 0)
                    {
                        foreach (DataRow row in result.DataSet.Tables[0].Rows)
                        {
                            model.atmTiles.Add(!DBNull.Value.Equals(row["title"]) ? row["title"].ToString() : string.Empty);
                        }
                    }
                    if (result.DataSet.Tables[1]?.Rows?.Count > 0)
                    {
                        foreach (DataRow row in result.DataSet.Tables[1].Rows)
                        {
                            model.trnx_count_today += !DBNull.Value.Equals(row["trnx_count"]) ? Convert.ToInt32(row["trnx_count"]) : 0;
                        }
                        
                    }
                    if (result.DataSet.Tables[2]?.Rows?.Count > 0)
                    {
                        foreach (DataRow row in result.DataSet.Tables[1].Rows)
                        {
                            model.trnx_count_yesterday += !DBNull.Value.Equals(row["trnx_count"]) ? Convert.ToInt32(row["trnx_count"]) : 0;
                        }                   
                    }
                }
            }

            return model;
        }
    }
}
