using EView360Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class ScheduleReportsViewModel
    {
        public string Organizations { get; set; }
        
        public string ReportName  { get; set; }
        
        public string ReportFriendlyName  { get; set; }
        
        public long ReportScheduleId  { get; set; }
        
        public string ReportsPhysicalPath  { get; set; }
        
        public string ReportstTempPath  { get; set; }
        
        public bool ScheduleType  { get; set; }

        public int RetryCount  { get; set; }

        public short? ExportType  { get; set; }

        public int? ExportDataOlderThan  { get; set; }


        public int? MinutesToScheduleAgain  { get; set; }

        public string? Recipitents  { get; set; }

        public string? CitName  { get; set; }

        public bool ExportPDFChecked { get; set; }
        public bool ExportExcelChecked { get; set; }

        //public static explicit operator ReportSchedule(ScheduleReportsViewModel model)
        //{
        //    if (model == null)
        //    {
        //        return null;
        //    }

        //    ReportSchedule result = new();
        //    result.Organizati = model.Organizations;
        //    result.UserId = auditLog.UserId;
        //    result.ActivityTime = auditLog.ActivityTime;
        //    result.Message = auditLog.Message;
        //    return result;
        //}

        public static explicit operator ScheduleReportsViewModel(ReportSchedule model)
        {
            if (model == null)
            {
                return null;
            }

            ScheduleReportsViewModel result = new ScheduleReportsViewModel();
            result.Organizations = model.Region?.RegionName;
            result.ReportFriendlyName = model.ReportFriendlyName;
            result.ReportsPhysicalPath = model.ReportPhysicalPath;
            result.ReportstTempPath = model.ReportTempPath;
            result.ExportDataOlderThan = model.ReportDataAge;
            result.ExportType = model.ReportExportType;
            result.MinutesToScheduleAgain = model.MinutesToScheduleAgain;
            result.ScheduleType = model.ScheduleType;
            result.RetryCount = model.RetryCount;
            result.Recipitents = model.ReportReceipients;
            result.ReportName = model.ReportName;
            result.ReportScheduleId = model.ReportScheduleId;
            return result;
        }
    }
}
