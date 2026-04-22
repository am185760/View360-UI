using DataRequestor;
using EView360Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DataRequestorMiddleware.Services.Summary;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace DataRequestorMiddleware.Services.Operations
{
    public class AtmPendingFileService
    {
        private ILogger _logger { get; set; }

        public AtmPendingFileService(ILogger<AtmSummaryStatusService> logger)
        {
            _logger = logger;
        }

        public List<AtmPendingFileViewModel> GetAtmPendingFiles(List<string> atmIds, List<AtmViewModel> AtmList, ref string errorMsg)
        {
            List<AtmPendingFileViewModel> atmPendingFiles = new();
            ConcurrentBag<AtmPendingFileViewModel> _atmPendingFiles = new();
            try
            {
                if (atmIds?.Count > 0)
                {
                    Executor _executor = new Executor();

                    _logger.LogWarning($"AtmPendingFileService: GetAtmPendingFiles enter  : {DateTime.Now.ToString()}");
                    DataTableResult result = _executor.ExecuteDSRequest<DataTableResult>("GetAtmPendingFiles", new SqlParameter[] { }, atmIds, string.Join(",", atmIds));
                    _logger.LogWarning($"AtmPendingFileService: GetAtmPendingFiles exit  : {DateTime.Now.ToString()}");

                    if (!string.IsNullOrEmpty(result.ExceptionMessage))
                    {
                        _logger.LogError($"AtmPendingFileService: error from Executor as:  {result.ExceptionMessage}  : {DateTime.Now.ToString()}");
                        errorMsg = result.ExceptionMessage;
                    }
                    if (result?.Table?.Rows?.Count > 0)
                    {
                        _logger.LogWarning($"AtmPendingFileService: Result Table rows count = {result?.Table?.Rows?.Count}  : {DateTime.Now.ToString()}");

                        List<AllValueViewModel> allValues = new List<AllValueViewModel>();

                        foreach (DataRow row in result.Table.Rows)
                        {
                            AllValueViewModel allValue = new()
                            {
                                AtmIP = !DBNull.Value.Equals(row["IP"]) ? row["IP"].ToString() : string.Empty,
                                LastInvoked = !DBNull.Value.Equals(row["last_invoked"]) ? Convert.ToDateTime(row["last_invoked"]) : null,
                                FileName = !DBNull.Value.Equals(row["file_name"]) ? row["file_name"].ToString() : string.Empty,
                                FileCreationDateTime = !DBNull.Value.Equals(row["file_creation_time"]) ? Convert.ToDateTime(row["file_creation_time"]) : null,
                                FileSize = !DBNull.Value.Equals(row["file_size"]) ? Convert.ToInt64(row["file_size"]) : 0,
                            };
                            allValues.Add(allValue);
                        }
                        if (allValues?.Count > 0)
                        {
                            List<string> distinctIPs = allValues.Select(x => x.AtmIP).Distinct().ToList();

                            Parallel.ForEach(distinctIPs, ip =>
                            {
                                AtmPendingFileViewModel atmPendingFileView = new();
                                List<AllValueViewModel> filterAtms = allValues.Where(x => x.AtmIP == ip).ToList();

                                atmPendingFileView.PendingFilesCount = filterAtms.Count;

                                AtmViewModel singleAtm = AtmList.FirstOrDefault(x => x.Ip == ip);
                                if (singleAtm != null) 
                                {
                                    atmPendingFileView.AtmId = singleAtm.AtmId;
                                    atmPendingFileView.AtmTitle = singleAtm.Title;
                                    atmPendingFileView.IsAtm = singleAtm.IsAtm;
                                    atmPendingFileView.IsCdm = singleAtm.IsCdm;
                                    atmPendingFileView.IsRecycler = singleAtm.IsRecycler;
                                    atmPendingFileView.Location = singleAtm.Location;
                                    atmPendingFileView.AtmType = singleAtm.AtmType;
                                }                                
                                atmPendingFileView.AtmIP = ip;
                                atmPendingFileView.LastInvoked = DateTime.Now;
                                atmPendingFileView.fileDetails = new();

                                foreach (AllValueViewModel viewModel in filterAtms)
                                {
                                    FileDetailViewModel fileDetail = new()
                                    {
                                        FileCreationDateTime = viewModel.FileCreationDateTime,
                                        FileName = viewModel.FileName,
                                        FileSize = viewModel.FileSize
                                    };
                                    atmPendingFileView.fileDetails.Add(fileDetail);
                                }
                                _atmPendingFiles.Add(atmPendingFileView);
                            });
                            atmPendingFiles = _atmPendingFiles.ToList();
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError($"AtmPendingFileService: exception as:  {ex.Message}  : {DateTime.Now.ToString()}");
            }           

            return atmPendingFiles;
        }
    }
}
