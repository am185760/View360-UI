using Common.RequestModel;
using Common.ViewModel;
using EView360Models.Core;
using EView360Models.Repository;
using EView360Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReportScheduleService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly CoreContext _context;

        public ReportScheduleService(UnitOfWork unitOfWork, CoreContext context = null)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public async Task<BaseModel> GetAll()
        {
            IQueryable<ReportSchedule>? queryable = _unitOfWork.ReportScheduleRepository.Get().
                  Include(x => x.Region);

            var scheduleReports = queryable.ToList().ConvertAll(x => (ScheduleReportsViewModel)x);

            return new BaseModel
            {
                IsSuccess = true,
                Message = $"Successfully retrieved all records.",
                Data = scheduleReports == null ? new List<ScheduleReportsViewModel>() : scheduleReports,
            };
        }

        public async Task<BaseModel> GetAllScheduleReportGeneration(long scheduleReportID)
        {
            IQueryable<ReportGenerationSchedule>? queryable = _unitOfWork.ReportScheduleGenerationRepository.Get().Where(x => x.ReportScheduleId == scheduleReportID);

            var scheduleReportGeneration = queryable.ToList().ConvertAll(x => (ReportGenerationViewModel)x);

            return new BaseModel
            {
                IsSuccess = true,
                Message = $"Successfully retrieved all records.",
                Data = scheduleReportGeneration == null ? new List<ReportGenerationViewModel>() : scheduleReportGeneration,
            };
        }

        public async Task<BaseModel> UpdateScheduleReportGeneration(UpdateScheduleReportRequestModel updateScheduleReportRequest)
        {
            var response = InsertReportGeneration(updateScheduleReportRequest.ScheduleReportTime, updateScheduleReportRequest.ScheduleReportId, updateScheduleReportRequest.ScheduleType);

            if (response.IsSuccess)
            {
                var response2 = UpdateScheduleReport(updateScheduleReportRequest);
                if (response2.IsSuccess)
                {
                    return new BaseModel { IsSuccess = true, Message = "Report is succesfully updated" };

                }
            }
            return new BaseModel { IsSuccess = false, Message = "Error accured" };

        }

        public BaseModel InsertReportGeneration(List<string> ScheduleTime, long ScheduleReportId, bool scheduleType)
        {
            try
            {
                List<ReportGenerationSchedule> oldReportGenerationList = _unitOfWork.ReportScheduleGenerationRepository.Get().Where(x => x.ReportScheduleId == ScheduleReportId).ToList();
                //_unitOfWork.ReportScheduleGenerationRepository.Delete(oldReportGenerationList);
                //_unitOfWork.Save();
                _context.ReportGenerationSchedules.RemoveRange(oldReportGenerationList);
                _context.SaveChanges();
                //foreach (var item in oldReportGenerationList)
                //{
                //    _unitOfWork.ReportScheduleGenerationRepository.Delete(item.ReportScheduleId);
                //}
                if (scheduleType)
                {
                    var updatedReportGenerationList = ScheduleTime;
                    List<ReportGenerationSchedule> reportGeneration = new List<ReportGenerationSchedule>();
                    foreach (var item in updatedReportGenerationList)
                    {
                        string[] parts = item.Split(':');
                        DateTime nextReportGenerationAt = DateTime.Today.AddHours(double.Parse(parts[0])).AddMinutes(double.Parse(parts[1]));
                        var reportGenerationModel = new ReportGenerationSchedule { ReportScheduleId = ScheduleReportId, NextGenerationAt = nextReportGenerationAt };
                        _unitOfWork.ReportScheduleGenerationRepository.Insert(reportGenerationModel);
                    }
                }
                return new BaseModel { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new BaseModel { IsSuccess = false };
            }
        }

        public BaseModel UpdateScheduleReport(UpdateScheduleReportRequestModel updateScheduleReportRequest)
        {
            try
            {
                if (updateScheduleReportRequest.ExportPDFChecked)
                {
                    updateScheduleReportRequest.ExportType = 1;
                }
                if (updateScheduleReportRequest.ExportExcelChecked)
                {
                    updateScheduleReportRequest.ExportType = 2;
                }
                if (updateScheduleReportRequest.ExportPDFChecked && updateScheduleReportRequest.ExportExcelChecked)
                {
                    updateScheduleReportRequest.ExportType = 3;
                }

                var scheduleReport = _unitOfWork.ReportScheduleRepository.Get().Where(x => x.ReportScheduleId == updateScheduleReportRequest.ScheduleReportId).FirstOrDefault();

                scheduleReport.ReportTempPath = updateScheduleReportRequest.ReportstTempPath;
                scheduleReport.ReportPhysicalPath = updateScheduleReportRequest.ReportsPhysicalPath;
                scheduleReport.ReportExportType = updateScheduleReportRequest.ExportType;
                scheduleReport.RetryCount = updateScheduleReportRequest.RetryCount;
                scheduleReport.ReportReceipients = updateScheduleReportRequest.Recipitents;
                scheduleReport.MinutesToScheduleAgain = updateScheduleReportRequest.MinutesToScheduleAgain;
                scheduleReport.ReportNextGeneratedAt = DateTime.Today;
                scheduleReport.ReportDataAge = updateScheduleReportRequest.ExportDataOlderThan;
                scheduleReport.ReportFriendlyName = updateScheduleReportRequest.ReportFriendlyName;
                scheduleReport.ScheduleType = updateScheduleReportRequest.ScheduleType;
                _unitOfWork.ReportScheduleRepository.Update(scheduleReport);
                _unitOfWork.Save();

                return new BaseModel { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new BaseModel { IsSuccess = false };
            }
        }

        public BaseModel DeleteScheduleReport(DeleteScheduleReportRequestModel deleteScheduleReportRequestModel)
        {
            var reportTask = _unitOfWork.ReportTaskRepository.Get().Where(x => x.ReportScheduleId == deleteScheduleReportRequestModel.ScheduleReportId);
            _context.ReportTasks.RemoveRange(reportTask);
            _unitOfWork.ReportScheduleRepository.Delete(deleteScheduleReportRequestModel.ScheduleReportId);
            _unitOfWork.Save();
            return new BaseModel { IsSuccess = true };
        }
    }

}

