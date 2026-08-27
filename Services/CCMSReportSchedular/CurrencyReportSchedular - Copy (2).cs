using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using Microsoft.Win32;
using Avanza.iSuite.DAL;
using Avanza.CCMS.DAL;
using System.Threading;
using System.Reflection;
using System.Net.Mail;
using System.Data.SqlClient;
using Avanza.CCMS;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using CurrencyReportSchedular.ReportDataset;
using System.Configuration;
using System.Net;
using Encryption;

namespace CCMSReportSchedular
{
    public partial class CurrencyReportSchedular : ServiceBase
    {
        Timer timerReportSchedule;
        Timer timerReportTaskExecutor;
        Timer timerEmailSender;
        static AppSetting appSettings;
        static DateTime appSettingLastLoadedAt;
        static string[] supportedTypes = ConfigurationManager.AppSettings["supportedTypes"].Split(',');
        static readonly bool isDeadATMExcluded = ConfigurationManager.AppSettings["isDeadATMExcluded"] == "1" ? true : false;

        string HTML2PDFFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "\\wkhtmltopdf.exe";
        DateTime gScheduleDate;
        DateTime gFrom;
        DateTime gTo;
        DateTime fromDate;
        DateTime toDate;
        int totalDeposits = 0;
        int totalRejects = 0;


        bool isWeeklyAnalysis = false;
        ReportSchedule reportSchedule = null;
        public CurrencyReportSchedular()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string connectionStr = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\CCMS").GetValue("ConnectionString", "");
            connectionStr = Encryption.Cryptic.DecryptString(connectionStr);
            ConnectionFactory.Initialize(connectionStr, true);
            appSettings = AppSetting.LoadAppSetting("1=1");
            appSettingLastLoadedAt = DateTime.Now;
            XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\CCMSReportSchedular_{1:yyMMMdd}.txt", appSettings.LogFilePath, DateTime.Now));
            //maxLicensedATMId = LicenseManager.MaxLicensedATMID();
            LogableTask.LogMonoActivityTask("DisplayVersion", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : Currency Report Schedular 1.0.0.6, Modified Date 23-Nov-2014");
            LogableTask.LogMonoActivityTask("Schedular", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Worker Threads begin execution after 15 seconds.");
            timerReportSchedule = new Timer(ReportSchedular, null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));
            timerReportTaskExecutor = new Timer(ReportTaskExecutor, null, new TimeSpan(0, 0, 25), new TimeSpan(0, 0, 0, 0, -1));
            timerEmailSender = new Timer(EmailSender, null, new TimeSpan(0, 0, 25), new TimeSpan(0, 0, 0, 0, -1));
        }

        protected override void OnStop()
        {
            timerReportSchedule.Dispose();
        }
        void EmailSender(object state)
        {
            timerEmailSender.Change(-1, -1);
            LogableTask task = LogableTask.NewTask("EmailSender");

            try
            {
                EmailReport();
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                try
                {
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to sleep");
                    task.EndTask();
                }
                catch (Exception ex)
                {
                }
                if (appSettings != null)
                    timerEmailSender.Change(new TimeSpan(0, appSettings.RefreshInterval, 0), new TimeSpan(0, 0, 0, 0, -1));
                else
                    timerEmailSender.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));

            }
        }


        void ReportSchedular(object state)
        {

            timerReportSchedule.Change(-1, -1);
            LogableTask task = LogableTask.NewTask("ReportSchedular");
            ReportSchedule.ReportScheduleReader reader = null;
            List<int> reportGenerationScheduleIds = null;
            try
            {
                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\CCMSReportSchedular_{1:yyMMMdd}.txt", appSettings.LogFilePath, DateTime.Now));
                if (appSettingLastLoadedAt.AddHours(1) < DateTime.Now)
                {
                    appSettings = AppSetting.LoadAppSetting("1=1");
                    appSettingLastLoadedAt = DateTime.Now;
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "App Settings reloaded after an hour.");
                }

                reader = ReportSchedule.ExecuteReader("1=1 order by report_schedule_id");
                int counter = 0;
                while (reader.Read())
                {
                    if (reader.CurrentReportSchedule.ScheduleType)
                    {//absolute flow.
                        reportGenerationScheduleIds = new List<int>();
                        ReportGenerationSchedule reportGenSchedule = null;
                        ReportGenerationSchedule.ReportGenerationScheduleReader reportGenerationScheduleReader = ReportGenerationSchedule.ExecuteReader("report_schedule_id = " + reader.CurrentReportSchedule.ReportScheduleId);
                        while (reportGenerationScheduleReader.Read())
                        {
                            if (reportGenerationScheduleReader.CurrentReportGenerationSchedule.NextGenerationAt <= DateTime.Now)
                            {
                                reportGenSchedule = reportGenerationScheduleReader.CurrentReportGenerationSchedule;
                                reportGenerationScheduleIds.Add(reportGenerationScheduleReader.CurrentReportGenerationSchedule.ReportGenerationScheduleId);
                                reportGenerationScheduleReader.CurrentReportGenerationSchedule.NextGenerationAt =
                                   DateTime.Today.AddDays(1).AddHours(reportGenerationScheduleReader.CurrentReportGenerationSchedule.NextGenerationAt.Hour).AddMinutes(
                                   reportGenerationScheduleReader.CurrentReportGenerationSchedule.NextGenerationAt.Minute);
                                reportGenerationScheduleReader.CurrentReportGenerationSchedule.Save();

                            }
                            //Generate task for only last schedule...
                        }
                        reportGenerationScheduleReader.Close();
                        if (reportGenerationScheduleIds.Count > 0)
                        {
                            GenerateReportingTask(reader.CurrentReportSchedule, reportGenSchedule);
                            counter++;
                        }

                    }
                    else
                    { //Relative flow.
                        if (reader.CurrentReportSchedule.ReportNextGeneratedAt <= DateTime.Now)
                        {

                            try
                            {
                                GenerateReportingTask(reader.CurrentReportSchedule, null);
                                //if (reader.CurrentReportSchedule.IsMonthly.HasValue)
                                //{
                                //    if (reader.CurrentReportSchedule.IsMonthly.Value)
                                //        reader.CurrentReportSchedule.ReportNextGeneratedAt = reader.CurrentReportSchedule.ReportNextGeneratedAt.AddMonths(1);
                                //}
                                //else if (reader.CurrentReportSchedule.IsWeekly.HasValue)
                                //{
                                //    if (reader.CurrentReportSchedule.IsWeekly.Value)
                                //    {
                                //        int day = reader.CurrentReportSchedule.ReportNextGeneratedAt.Day;
                                //        if (day <= 7)//first week 
                                //        {
                                //            //Change the schedule time to day 1
                                //            DateTime newScheduleTime = new DateTime(reader.CurrentReportSchedule.ReportNextGeneratedAt.Year,
                                //                reader.CurrentReportSchedule.ReportNextGeneratedAt.Month, 1, reader.CurrentReportSchedule.ReportNextGeneratedAt.Hour,
                                //                reader.CurrentReportSchedule.ReportNextGeneratedAt.Minute, reader.CurrentReportSchedule.ReportNextGeneratedAt.Second);

                                //            reader.CurrentReportSchedule.ReportNextGeneratedAt = newScheduleTime.AddDays(7);
                                //        }
                                //        else if (day >= 8 && day <= 14)
                                //        {
                                //            //Change the schedule time to day 8
                                //            DateTime newScheduleTime = new DateTime(reader.CurrentReportSchedule.ReportNextGeneratedAt.Year,
                                //                reader.CurrentReportSchedule.ReportNextGeneratedAt.Month, 8, reader.CurrentReportSchedule.ReportNextGeneratedAt.Hour,
                                //                reader.CurrentReportSchedule.ReportNextGeneratedAt.Minute, reader.CurrentReportSchedule.ReportNextGeneratedAt.Second);

                                //            reader.CurrentReportSchedule.ReportNextGeneratedAt = newScheduleTime.AddDays(7);
                                //        }
                                //        else if (day >= 15 && day <= 21)
                                //        {
                                //            //Change the schedule time to day 15
                                //            DateTime newScheduleTime = new DateTime(reader.CurrentReportSchedule.ReportNextGeneratedAt.Year,
                                //                reader.CurrentReportSchedule.ReportNextGeneratedAt.Month, 15, reader.CurrentReportSchedule.ReportNextGeneratedAt.Hour,
                                //                reader.CurrentReportSchedule.ReportNextGeneratedAt.Minute, reader.CurrentReportSchedule.ReportNextGeneratedAt.Second);

                                //            reader.CurrentReportSchedule.ReportNextGeneratedAt = newScheduleTime.AddDays(7);
                                //        }
                                //        else
                                //        {
                                //            DateTime newScheduleTime = new DateTime(reader.CurrentReportSchedule.ReportNextGeneratedAt.Year,
                                //               reader.CurrentReportSchedule.ReportNextGeneratedAt.Month, 1, reader.CurrentReportSchedule.ReportNextGeneratedAt.Hour,
                                //               reader.CurrentReportSchedule.ReportNextGeneratedAt.Minute, reader.CurrentReportSchedule.ReportNextGeneratedAt.Second);


                                //            reader.CurrentReportSchedule.ReportNextGeneratedAt = newScheduleTime.AddMonths(1);
                                //        }

                                //    }
                                //}
                                //else
                                //    reader.CurrentReportSchedule.ReportNextGeneratedAt = reader.CurrentReportSchedule.ReportNextGeneratedAt.AddMinutes(reader.CurrentReportSchedule.MinutesToScheduleAgain.Value);

                                //reader.CurrentReportSchedule.Save();
                                counter++;
                            }
                            catch (Exception ex)
                            {
                                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, string.Format("Error while creating schedule[{0}],Error[{1}]", reader.CurrentReportSchedule.ReportScheduleId, ex));
                            }
                        }
                    }
                }
                reader.Close();
                if (counter > 0)
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, counter.ToString() + " tasks scheduled successfully");
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                try
                {
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to sleep.");
                    task.EndTask();
                }
                catch (Exception ex)
                {
                }

                if (appSettings != null)
                    timerReportSchedule.Change(new TimeSpan(0, appSettings.RefreshInterval, 0), new TimeSpan(0, 0, 0, 0, -1));
                else
                    timerReportSchedule.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));
            }
        }

        void ReportTaskExecutor(object state)
        {
            timerReportTaskExecutor.Change(-1, -1);
            LogableTask task = LogableTask.NewTask("ReportTaskExecutor");
            ReportTask.ReportTaskReader reader = null;
            try
            {
                //reader = ReportTask.ExecuteReader("status='Scheduled' and retry_count>0 and report_schedule_id in (select report_schedule_id from report_schedule where  is_graphical_report=0) order by creation_time");
                reader = ReportTask.ExecuteReader("status='Scheduled' and retry_count>0 order by creation_time");

                while (reader.Read())
                {
                    try
                    {
                        GC.Collect();
                        reader.CurrentReportTask.RetryCount--;
                        reader.CurrentReportTask.LastInvokedAt = DateTime.Now;
                        reader.CurrentReportTask.Save();

                        ExecuteTask(reader.CurrentReportTask, task);

                    }
                    catch (Exception ex)
                    {
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                        string msg = null;
                        if (ex.Message.Length > 500)
                            msg = ex.Message.Substring(0, 499);
                        else
                            msg = ex.Message;
                        msg = msg.Replace("'", "''");
                        reader.CurrentReportTask.FailureReason = msg;
                        if (reader.CurrentReportTask.RetryCount == 0)
                        {

                            reader.CurrentReportTask.Status = "Retries Exhausted";

                        }
                        reader.CurrentReportTask.Save();

                    }
                }

            }
            catch (Exception ex)
            {

                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }


            finally
            {
                if (reader != null)
                    reader.Close();
                try
                {
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to sleep");
                    task.EndTask();
                }
                catch (Exception ex)
                {
                }
                if (appSettings != null)
                    timerReportTaskExecutor.Change(new TimeSpan(0, appSettings.RefreshInterval, 0), new TimeSpan(0, 0, 0, 0, -1));
                else
                    timerReportTaskExecutor.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));
            }

        }
        public static string GetOrganization(int region_id)
        {
            Region region = Region.LoadRegionByPk(region_id);
            if (region.IsOrganization)
            {
                return region.RegionName;
            }
            else
                return GetOrganization(region.ParentRegionId.Value);
        }
        private void ProcessDataTable(string columnName, DataSet ds, DataTable dt, List<int> atmIDs)
        {
            DataRow[] dr = null;
            foreach (int atmID in atmIDs)
            {
                object result = ds.Tables["DataTable1"].Compute("sum(" + columnName + ")", "atm_id=" + atmID);
                if (result != null)
                {
                    int val = int.Parse(result.ToString());
                    if (val == 0)
                    {
                        dr = ds.Tables["DataTable1"].Select(columnName + "=0 and atm_id=" + atmID);
                        int atmTotalRecords = ds.Tables["DataTable1"].Select("atm_id=" + atmID).Length;
                        if (atmTotalRecords == dr.Length)
                            AddToDataTable(dr, dt);
                    }
                }
            }
        }
        private DataSet GetReportDataSet(string reportName, int orgID, bool isEjEnabled, int reportDataAge, ReportTask reportTask)
        {
            LogableTask task = LogableTask.NewTask("GetReportDataSet");
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                DateTime scheduleDate = reportTask.ScheduleDate;
                gScheduleDate = scheduleDate;
                isWeeklyAnalysis = false;
                conn = ConnectionFactory.GetNewConnection();
                cmd = conn.CreateCommand();
                cmd.CommandTimeout = 0;//60 * 20;
                DataSet ds = null;

                if (reportName == "ReplenishmentRemainingNotesReport")
                {
                    cmd.CommandText = "GetReplenishmentRemainingNotes";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AtmId", SqlDbType.VarChar));
                    cmd.Parameters[0].Value = "";
                    cmd.Parameters.Add(new SqlParameter("@NoteSetTypeId", SqlDbType.Int));
                    cmd.Parameters[1].Value = 0;

                    ds = new dsReplenishmentRemainingNotes();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables[0]);
                }

                else if (reportName == "CassetteFaultySummaryReport")
                {
                    cmd.CommandText = "GetCassetteFaultyMessages";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("FromDate", SqlDbType.DateTime));
                    cmd.Parameters[0].Value = scheduleDate;
                    cmd.Parameters.Add(new SqlParameter("ToDate", SqlDbType.DateTime));
                    cmd.Parameters[1].Value = scheduleDate;
                    cmd.Parameters.Add(new SqlParameter("orgID", SqlDbType.Int));
                    cmd.Parameters[2].Value = orgID;
                    cmd.Parameters.Add(new SqlParameter("isDeadATMExcluded", SqlDbType.Int));
                    cmd.Parameters[3].Value = isDeadATMExcluded ? 1 : 0;


                    ds = new dsCassetteFaultySummary();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables[0]);
                }

                else if (reportName == "ReplenishmentReturnedReport")
                {
                    if (isEjEnabled)
                    {
                        cmd.CommandText = @"select ej_summary.atm_id,region.region_name,region.region_id, parent_region_id, title,trxn_datetime,
cash_added1,cash_added2,cash_added3,cash_added4,return_type1,return_type2,return_type3,return_type4 ,replenishment_amount total_cashAdded,return_amount total_returned,atm.location 
                      from atm, ej_summary, region  where atm.atm_id = ej_summary.atm_id and atm.region_id = region.region_id and replenishment_amount>0 " +
                                          " and trxn_datetime >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                         " trxn_datetime <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) and ej_summary.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    }
                    else
                    {
                        cmd.CommandText = @"select summary.atm_id,region.region_name,region.region_id, parent_region_id, title,trxn_datetime,
cash_added1,cash_added2,cash_added3,cash_added4,return_type1,return_type2,return_type3,return_type4 ,replenishment_amount total_cashAdded,return_amount total_returned,atm.location 
                      from atm, summary, region  where atm.atm_id = summary.atm_id and atm.region_id = region.region_id and replenishment_amount>0 " +
                                           " and trxn_datetime >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                          " trxn_datetime <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) and summary.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    }
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new dsReplenishmentReturned();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables[0]);
                    PopulateDataTable(ds.Tables[0]);

                }



                else if (reportName == "DeadATMsReport")
                {
                    cmd.CommandText = @"select outerATM.location,( isnull((select region_name + '-' from region where region_id = r.parent_region_id and is_organization=0),'') + r.region_name) region_name,r.region_id,r.parent_region_id,(select max(heart_beat_received_at) from heart_beat where atm_id = outerATM.atm_id) heart_beat_received_at ,outerATM.last_ping_executed_at,outerATM.last_ping_status,outerATM.last_telnet_executed_at,last_telnet_status,outerATM.title
                                        from atm outerATM inner join region r on outerATM.region_id = r.region_id
                                        where outerATM.is_active = 1 and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")"
                                              + " and ATM_id not in (select ATM_id from heart_beat where heart_beat_received_at >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                            "heart_beat_received_at <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)) ";
                    //" and atm_id in (" + Session[SessionVars.SelectedATMs.ToString()] + ")" + " ) " + filter;

                    //                    cmd.CommandText = @"select outerATM.title,region.region_name,(select max(heart_beat_received_at) from heart_beat where atm_id = outerATM.atm_id) heart_beat_received_at ,outerATM.location
                    //                                    from atm outerATM inner join region on outerATM.region_id = region.region_id
                    //                                    where outerATM.is_active = 1 and ATM_id not in (select ATM_id from heart_beat where heart_beat_received_at >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                    //                                        "heart_beat_received_at <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)) and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DataSetDeadAtm();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["dtDeadATMs"]);
                    PopulateDataTableForDeadATMsReport(ds.Tables["dtDeadATMs"]);
                    //    return ds;

                }
                else if (reportName == "SwitchDispensingReport")
                {
                    if (isEjEnabled)
                        cmd.CommandText = @"select title,location,amount denomination,count(ej_parsed_transactions_id) count
                                    from atm inner join ej_parsed_transactions
                                    on ej_parsed_transactions.atm_id = atm.ATM_id
                                    and atm.is_active = 1 and atm.is_ej_enabled=1 
                                    and amount > 0 and 
                                        trxn_datetime >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                          " trxn_datetime <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" +
                                          "  group by title,location,amount";
                    else
                        cmd.CommandText = @"select title,location,amount denomination,count(parsed_transaction_id) count
                                    from atm inner join parsed_transaction
                                    on parsed_transaction.atm_id = atm.ATM_id
                                    and atm.is_active = 1
                                    and amount > 0 and 
                                        trxn_datetime >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                          " trxn_datetime <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" +
                                          "  group by title,location,amount";

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DsDispensing();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);

                    if (isEjEnabled)
                        cmd.CommandText = @"select title,
                                        isnull(notes_dispensed_type1,0) cash_dispensed1, isnull(notes_dispensed_type2,0) cash_dispensed2, isnull(notes_dispensed_type3,0) cash_dispensed3,
                                        isnull(notes_dispensed_type4,0) cash_dispensed4, isnull(notes_dispensed_type5,0) cash_dispensed5,isnull(notes_dispensed_type6,0) cash_dispensed6,
                                        isnull(notes_dispensed_type7,0) cash_dispensed7,amount,
                                        notes_remaining_type1 cash_remaining1, notes_remaining_type2 cash_remaining2, notes_remaining_type3 cash_remaining3,
                                        notes_remaining_type4 cash_remaining4
                                        from atm, ej_parsed_transactions, region  where atm.atm_id = ej_parsed_transactions.atm_id 
                                        and atm.region_id = region.region_id and atm.is_active = 1 and atm.is_ej_enabled=1 and amount>0 and 
                                        trxn_datetime >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                            " trxn_datetime <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    else
                        cmd.CommandText = @"select title,
                                        cash_dispensed1, cash_dispensed2,cash_dispensed3,cash_dispensed4,cash_dispensed5,cash_dispensed6,cash_dispensed7,amount,
                                        cash_remaining1,cash_remaining2,cash_remaining3,cash_remaining4
                                        from atm, parsed_transaction, region  where atm.atm_id = parsed_transaction.atm_id 
                                        and atm.region_id = region.region_id and atm.is_active = 1 and 
                                        trxn_datetime >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                        " trxn_datetime <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    DataTable dt = new DataTable();
                    //DSCashUtilization Ds = new DSCashUtilization();
                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    DataTable dtDistinct = dt.DefaultView.ToTable(true, "amount");
                    foreach (DataRow dr in dtDistinct.Rows)
                    {
                        string amount = dr[0].ToString();
                        DataRow[] drArray = dt.Select("amount=" + amount);
                        foreach (DataRow obj in drArray)
                        {
                            DataRow[] result = ds.Tables["DataTable2"].Select("cash_dispensed1=" + obj[1] + " and cash_dispensed2=" + obj[2] + " and cash_dispensed3=" + obj[3] +
                                " and cash_dispensed4=" + obj[4]);
                            if (result.Length == 0)
                            {
                                DataRow newRow = ds.Tables["DataTable2"].NewRow();
                                newRow["title"] = obj[0];
                                newRow["denomination"] = amount.Split('.')[0];
                                newRow["cash_dispensed1"] = obj[1];
                                newRow["cash_dispensed2"] = obj[2];
                                newRow["cash_dispensed3"] = obj[3];
                                newRow["cash_dispensed4"] = obj[4];
                                newRow["remaining1"] = obj[9];
                                newRow["remaining2"] = obj[10];
                                newRow["remaining3"] = obj[11];
                                newRow["remaining4"] = obj[12];
                                ds.Tables["DataTable2"].Rows.Add(newRow);
                            }
                        }
                    }

                    //PopulateDataTable(ds.Tables[0]);
                    //    return ds;

                }
                else if (reportName == "CPMCounterDetailReport")
                {
                    if (reportDataAge == 0)
                    {
                        cmd.CommandText = @"select region_name,region.region_id, parent_region_id, title, bank_logo,atm.location,                    
                                        bin1 cpm_pkt_1,bin2 cpm_pkt_2,bin3 cpm_pkt_3,bin4 cpm_pkt_4,deposit_at last_cpm_deposit_at from parsed_cpm_counter outerCPM
                                        inner join atm on  outerCPM.atm_id = atm.atm_id inner join region on atm.region_id = region.region_id 
                                        where atm.is_active = 1 and deposit_at in (select max(deposit_at) from parsed_cpm_counter where atm_id = outerCPM.atm_id) and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    }
                    else
                        cmd.CommandText = @"select region_name,region.region_id, parent_region_id, title, bank_logo,atm.location,                    
                                        bin1 cpm_pkt_1,bin2 cpm_pkt_2,bin3 cpm_pkt_3,bin4 cpm_pkt_4,deposit_at last_cpm_deposit_at from parsed_cpm_counter 
                                        inner join atm on  parsed_cpm_counter.atm_id = atm.atm_id inner join region on atm.region_id = region.region_id 
                                        where atm.is_active = 1 and deposit_at >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                          " deposit_at <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DsCPMCounter();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["CPMCounter"]);
                    PopulateDataTable(ds.Tables["CPMCounter"]);
                    //    return ds;

                }
                else if (reportName == "CPMCounterSummaryReport")
                {
                    if (reportDataAge == 0)
                    {
                        cmd.CommandText = @"select convert(datetime,convert(varchar,deposit_at,103),103) last_cpm_deposit_at,region_name,region.region_id, parent_region_id, title,atm.location,                   
                                        sum(bin1) cpm_pkt_1,sum(bin2) cpm_pkt_2,sum(bin3) cpm_pkt_3,sum(bin4) cpm_pkt_4 from parsed_cpm_counter outerCPM
                                        inner join atm on  outerCPM.atm_id = atm.atm_id inner join region on atm.region_id = region.region_id 
                                        where atm.is_active = 1 and deposit_at in (select max(deposit_at) from parsed_cpm_counter where atm_id = outerCPM.atm_id) and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")"
                                      + " group by convert(varchar,deposit_at,103),region_name,region.region_id, parent_region_id, title,atm.location";

                    }
                    else
                        cmd.CommandText = @"select convert(datetime,convert(varchar,deposit_at,103),103) last_cpm_deposit_at,region_name,region.region_id, parent_region_id, title,atm.location,                   
                                        sum(bin1) cpm_pkt_1,sum(bin2) cpm_pkt_2,sum(bin3) cpm_pkt_3,sum(bin4) cpm_pkt_4 from parsed_cpm_counter
                                        inner join atm on  parsed_cpm_counter.atm_id = atm.atm_id inner join region on atm.region_id = region.region_id 
                                        where atm.is_active = 1 and deposit_at >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                      " deposit_at <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")"
                                      + " group by convert(varchar,deposit_at,103),region_name,region.region_id, parent_region_id, title,atm.location";

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DsCPMCounter();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["CPMCounter"]);
                    PopulateDataTable(ds.Tables["CPMCounter"]);
                    dsCPMCountsClearedReport dsCPMCounterCleared = new dsCPMCountsClearedReport();
                    if (reportDataAge == 0)
                        cmd.CommandText = @"select title,counts_cleared_at 
                                           from cpm_counts_cleared outerCPM,atm where outerCPM.atm_id = atm.atm_id and atm.is_active = 1
                                           and outerCPM.counts_cleared_at in (select max(counts_cleared_at) from cpm_counts_cleared where atm_id =outerCPM.atm_id ) and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    else
                        cmd.CommandText = @"select title,counts_cleared_at 
                                        from cpm_counts_cleared,atm where cpm_counts_cleared.atm_id = atm.atm_id and atm.is_active = 1
                                        and counts_cleared_at >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                      " and counts_cleared_at <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsCPMCounterCleared.Tables[0]);
                    ds.Tables.Add(dsCPMCounterCleared.Tables[0].Copy());
                    return ds;

                }
                else if (reportName == "BNACounterDetailReport")
                {

                    if (reportDataAge == 0)
                        cmd.CommandText = @"select region_name,region_id, parent_region_id, title, bank_logo,
                                        bna_cassette1,bna_cassette2,bna_cassette3,bna_cassette4,bna_cassette5,last_bna_deposit_at,location
                                         from vDepositPosition as deposited_notes
                                        where last_bna_deposit_at in (select max(last_bna_deposit_at) from vDepositPosition where atm_id = deposited_notes.atm_id) " +
                                          " and atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "atm_id") : "");
                    else
                        cmd.CommandText = @"select region_name,region_id, parent_region_id, title, bank_logo,
                                        bna_cassette1,bna_cassette2,bna_cassette3,bna_cassette4,bna_cassette5,last_bna_deposit_at,location
                                         from vDepositPosition 
                                        where last_bna_deposit_at >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                          " last_bna_deposit_at <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) " +
                                          " and atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "atm_id") : "");


                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DsBNACounter();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["BNACounter"]);
                    PopulateDataTable(ds.Tables["BNACounter"]);
                    //    return ds;

                }
                else if (reportName == "BNACounterSummaryReport")
                {
                    if (reportDataAge == 0)
                        cmd.CommandText = @"select convert(datetime,convert(varchar,last_bna_deposit_at,103),103) last_bna_deposit_at,region_name,region_id, parent_region_id, title,location,
                                        sum(bna_cassette1) bna_cassette1,sum(bna_cassette2) bna_cassette2,sum(bna_cassette3) bna_cassette3,sum(bna_cassette4) bna_cassette4,sum(bna_cassette5) bna_cassette5,count(atm_id) total_trxn 
                                        from vDepositPosition as deposited_notes
                                        where last_bna_deposit_at in (select max(last_bna_deposit_at) from vDepositPosition where atm_id = deposited_notes.atm_id) and atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "atm_id") : "") + " group by convert(varchar,last_bna_deposit_at,103),region_name,region_id,parent_region_id,title,location";

                    else
                        cmd.CommandText = @"select convert(datetime,convert(varchar,last_bna_deposit_at,103),103) last_bna_deposit_at,region_name,region_id, parent_region_id, title,location,
                                        sum(bna_cassette1) bna_cassette1,sum(bna_cassette2) bna_cassette2,sum(bna_cassette3) bna_cassette3,sum(bna_cassette4) bna_cassette4,sum(bna_cassette5) bna_cassette5,count(atm_id) total_trxn 
                                        from vDepositPosition
                                        where last_bna_deposit_at >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                          " last_bna_deposit_at <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) and atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "atm_id") : "") + " group by convert(varchar,last_bna_deposit_at,103),region_name,region_id,parent_region_id,title,location";

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DsBNACounter();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["BNACounter"]);
                    PopulateDataTable(ds.Tables["BNACounter"]);
                    dsBNACountsClearedReport dsBNACounterCleared = new dsBNACountsClearedReport();
                    //*******************************************************************************************************************************************************************************
                    //Change done on 23/11/2014
                    //Desc : There is no need for 'counts_cleared_at_date_only' column
                    //*******************************************************************************************************************************************************************************
                    //                    cmd.CommandText = @"select title,counts_cleared_at , convert(varchar,counts_cleared_at,103) counts_cleared_at_date_only
                    //                                        from bna_counts_cleared,atm where bna_counts_cleared.atm_id = atm.atm_id and atm.is_active = 1
                    //                                        and counts_cleared_at >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                    //                                      " and counts_cleared_at <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) " +
                    //                                        " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    if (reportDataAge == 0)
                        cmd.CommandText = @"select title,counts_cleared_at 
                                           from bna_counts_cleared outerBNA,atm where outerBNA.atm_id = atm.atm_id and atm.is_active = 1
                                           and outerBNA.counts_cleared_at in (select max(counts_cleared_at) from bna_counts_cleared where atm_id =outerBNA.atm_id ) and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "atm_id") : "");

                    else
                        cmd.CommandText = @"select title,counts_cleared_at 
                                        from bna_counts_cleared,atm where bna_counts_cleared.atm_id = atm.atm_id and atm.is_active = 1
                                        and counts_cleared_at >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                 " and counts_cleared_at <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) " +
                                   " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "atm_id") : "");

                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsBNACounterCleared.Tables[0]);
                    ds.Tables.Add(dsBNACounterCleared.Tables[0].Copy());
                    return ds;

                }


                else if (reportName == "OrderCancelledEnoughCashOnATM")
                {
                    cmd.CommandText = @"select * from vTaskStatusReport where is_active=1
                                        and creation_time >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                      " creation_time <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) " +
                                         " and task_type_id  = 4 and status = 'cancelledEnoughCashOnATM'" +
                                         " and atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DsTaskStatusRpt();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["TaskStatus"]);
                    PopulateDataTableForTaskStatus(ds.Tables["TaskStatus"]);
                    //    return ds;

                }

                else if (reportName == "TaskStatusReport")
                {
                    cmd.CommandText = @"select * from vTaskStatusReport where is_active=1
                                        and creation_time >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                      " creation_time <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)" +
                                      " and atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DsTaskStatusRpt();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["TaskStatus"]);
                    PopulateDataTableForTaskStatus(ds.Tables["TaskStatus"]);
                    //    return ds;

                }
                else if (reportName == "TerminalDowntimeReport")
                {
                    cmd.CommandText = @"select * from vTerminalDowntimeReport where is_active=1
                                        and generated_at >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                      " generated_at <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)" +
                                        " and atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DsTerminalDowntimeRpt();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables[0]);
                    PopulateDataTable(ds.Tables[0]);
                    //    return ds;

                }
                else if (reportName == "CashOrderReport")
                {
                    cmd.CommandText = @"select * from vCashOrderReport
                                        where cash_order_datetime >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                      " cash_order_datetime <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)" +
                                      " and atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DsCashOrderRpt();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables[0]);
                    PopulateDataTable(ds.Tables[0]);
                    //    return ds;

                }
                else if (reportName == "ScheduleTrackingReport")
                {
                    cmd.CommandText = @"select * from vScheduleTrackingReport 
                                        where creation_time >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                      " creation_time <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)" +
                                        " and atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DsScheduleTrackingRpt();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables[0]);
                    PopulateDataTable(ds.Tables[0]);
                    //    return ds;

                }
                else if (reportName == "ATMSummaryReport")
                {

                    cmd.CommandText = @"
select atm.title, atm.ip,atm.location,atm.is_active status,( isnull((select region_name + '-' from region where region_id = r.parent_region_id and is_organization=0),'') + r.region_name) region_name,r.region_id, r.parent_region_id, bank_logo,atm.min_operating_balance,note_set_type_name
from atm,region r ,note_set_type
where  atm.region_id = r.region_id and atm.note_set_type_id = note_set_type.note_set_type_id  and atm.is_active=1
                                        and atm.creation_time >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                      " atm.creation_time <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)" +
                                      " and atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";



                    //                    cmd.CommandText = @"select atm.title, atm.ip,atm.location,atm.is_active status,region_name,region.region_id, parent_region_id, bank_logo,atm.min_operating_balance
                    //                                        from atm,region
                    //                                        where  atm.region_id = region.region_id and atm.is_active=1
                    //                                        and atm.creation_time >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                    //                                      " atm.creation_time <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)" +
                    //                                      " and atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new dsATMSummary();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);
                    PopulateDataTable(ds.Tables[0]);
                    //    return ds;

                }
                else if (reportName == "CurrentCashPositionsReport" || (reportName == "CashPositionsReport" && reportDataAge == 0))
                {
                    if (isEjEnabled)
                        cmd.CommandText = @"select outerATM.location,outerATM.title title, note_set_type.denomination_type_1, note_set_type.denomination_type_2, note_set_type.denomination_type_3,
                                    note_set_type.denomination_type_4, note_set_type.denomination_type_5, 
                                    note_set_type.denomination_type_6, note_set_type.denomination_type_7, 
                                    p.last_trxn_at, p.cassette1_notes, p.cassette2_notes,
                                    p.cassette3_notes, p.cassette4_notes, p.cassette5_notes, p.cassette6_notes,
                                    p.cassette7_notes, (select max(trxn_datetime) from parsed_transaction where atm_id = outerATM.atm_id and amount>0 )last_invoked  ,description,
note_set_type.denomination_type_1 * p.cassette1_notes + 
note_set_type.denomination_type_2 * p.cassette2_notes + 
note_set_type.denomination_type_3 * p.cassette3_notes + 
note_set_type.denomination_type_4 * p.cassette4_notes + 
note_set_type.denomination_type_5 * p.cassette5_notes + 
note_set_type.denomination_type_6 * p.cassette6_notes + 
note_set_type.denomination_type_7 * p.cassette7_notes total ,
( select max(rep_datetime) from ej_parsed_replenishments where atm_id = outerATM.atm_id)last_replenishment_at,( isnull((select region_name + '-' from region where region_id = r.parent_region_id and is_organization=0),'') + r.region_name) region_name,r.region_id,parent_region_id,bank_logo
,

( select min(cash_order_datetime) from cash_order_monitoring where  atm_id = outerATM.atm_id    
and cash_order_datetime>=convert(datetime,'" + DateTime.Today.ToString("dd/MM/yyyy") + "',103))next_replenishment_at, " +

    " ( select min(current_order_suggested_amount) from cash_order_monitoring where  atm_id = outerATM.atm_id  " +
    " and cash_order_datetime>=convert(datetime,'" + DateTime.Today.ToString("dd/MM/yyyy") + "',103))amount" +

    " from atm outerATM , ej_cash_position p ,note_set_type,region r" +
    " where outerATM.atm_id = p.atm_id  and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ") and outerATM.is_active = 1 and outerATM.exclude_dff= 0  and outerATM.is_atm = 1" +
    " and p.last_trxn_at in (select MAX(last_trxn_at) from ej_cash_position where atm_id =outerATM.atm_id) " +
    " and outerATM.note_set_type_id = note_set_type.note_set_type_id and outerATM.region_id = r.region_id " + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "outerATM.atm_id") : "");
                    else
                        cmd.CommandText = @"select outerATM.location,outerATM.title title, note_set_type.denomination_type_1, note_set_type.denomination_type_2, note_set_type.denomination_type_3,
                                    note_set_type.denomination_type_4, note_set_type.denomination_type_5, 
                                    note_set_type.denomination_type_6, note_set_type.denomination_type_7, 
                                    p.last_trxn_at, p.cassette1_notes, p.cassette2_notes,
                                    p.cassette3_notes, p.cassette4_notes, p.cassette5_notes, p.cassette6_notes,
                                    p.cassette7_notes, (select max(trxn_datetime) from parsed_transaction where atm_id = outerATM.atm_id and amount>0 )last_invoked  ,description,
note_set_type.denomination_type_1 * p.cassette1_notes + 
note_set_type.denomination_type_2 * p.cassette2_notes + 
note_set_type.denomination_type_3 * p.cassette3_notes + 
note_set_type.denomination_type_4 * p.cassette4_notes + 
note_set_type.denomination_type_5 * p.cassette5_notes + 
note_set_type.denomination_type_6 * p.cassette6_notes + 
note_set_type.denomination_type_7 * p.cassette7_notes total ,
( select max(rep_datetime) from replenishment where atm_id = outerATM.atm_id)last_replenishment_at,( isnull((select region_name + '-' from region where region_id = r.parent_region_id and is_organization=0),'') + r.region_name) region_name,r.region_id,parent_region_id,bank_logo
,

( select min(cash_order_datetime) from cash_order_monitoring where  atm_id = outerATM.atm_id    
and cash_order_datetime>=convert(datetime,'" + DateTime.Today.ToString("dd/MM/yyyy") + "',103))next_replenishment_at, " +

    " ( select min(current_order_suggested_amount) from cash_order_monitoring where  atm_id = outerATM.atm_id  " +
    " and cash_order_datetime>=convert(datetime,'" + DateTime.Today.ToString("dd/MM/yyyy") + "',103))amount" +

    " from atm outerATM , cash_position p ,note_set_type,region r" +
    " where outerATM.atm_id = p.atm_id  and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ") and outerATM.is_active = 1 and outerATM.exclude_dff= 0  and outerATM.is_atm = 1" +
    " and p.last_trxn_at in (select MAX(last_trxn_at) from cash_position where atm_id =outerATM.atm_id) " +
    " and outerATM.note_set_type_id = note_set_type.note_set_type_id and outerATM.region_id = r.region_id " + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "outerATM.atm_id") : "");

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new dsCashPositions();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables[0]);
                    PopulateDataTable(ds.Tables[0]);
                    //    return ds;

                }
                else if (reportName == "CashPositionsReport")
                {
                    if (isEjEnabled)
                        cmd.CommandText = @"select outerATM.location,outerATM.title title, note_set_type.denomination_type_1, note_set_type.denomination_type_2, note_set_type.denomination_type_3,
                                    note_set_type.denomination_type_4, note_set_type.denomination_type_5, 
                                    note_set_type.denomination_type_6, note_set_type.denomination_type_7, 
                                    p.last_trxn_at, p.cassette1_notes, p.cassette2_notes,
                                    p.cassette3_notes, p.cassette4_notes, p.cassette5_notes, p.cassette6_notes,
                                    p.cassette7_notes, (select max(trxn_datetime) from ej_parsed_transactions where atm_id = outerATM.atm_id and amount>0 )last_invoked ,
note_set_type.denomination_type_1 * p.cassette1_notes + 
note_set_type.denomination_type_2 * p.cassette2_notes + 
note_set_type.denomination_type_3 * p.cassette3_notes + 
note_set_type.denomination_type_4 * p.cassette4_notes + 
note_set_type.denomination_type_5 * p.cassette5_notes + 
note_set_type.denomination_type_6 * p.cassette6_notes + 
note_set_type.denomination_type_7 * p.cassette7_notes total ,description,
( select max(rep_datetime) from ej_parsed_replenishments where atm_id = outerATM.atm_id)last_replenishment_at,( isnull((select region_name + '-' from region where region_id = r.parent_region_id and is_organization=0),'') + r.region_name) region_name,r.region_id,parent_region_id,bank_logo
,

( select min(cash_order_datetime) from cash_order_monitoring where  atm_id = outerATM.atm_id    
and cash_order_datetime>=convert(datetime,'" + DateTime.Today.ToString("dd/MM/yyyy") + "',103))next_replenishment_at, " +

    " ( select min(current_order_suggested_amount) from cash_order_monitoring where  atm_id = outerATM.atm_id  " +
    " and cash_order_datetime>=convert(datetime,'" + DateTime.Today.ToString("dd/MM/yyyy") + "',103))amount" +

    " from atm outerATM , ej_cash_position p ,note_set_type,region r" +
    " where outerATM.atm_id = p.atm_id and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ") and outerATM.is_active = 1 and outerATM.exclude_dff= 0  and outerATM.is_atm = 1 " +
    " and p.last_trxn_at >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                                " p.last_trxn_at <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)" +
    " and outerATM.note_set_type_id = note_set_type.note_set_type_id and outerATM.region_id = r.region_id" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "outerATM.atm_id") : "");
                    else
                        cmd.CommandText = @"select outerATM.location,outerATM.title title, note_set_type.denomination_type_1, note_set_type.denomination_type_2, note_set_type.denomination_type_3,
                                    note_set_type.denomination_type_4, note_set_type.denomination_type_5, 
                                    note_set_type.denomination_type_6, note_set_type.denomination_type_7, 
                                    p.last_trxn_at, p.cassette1_notes, p.cassette2_notes,
                                    p.cassette3_notes, p.cassette4_notes, p.cassette5_notes, p.cassette6_notes,
                                    p.cassette7_notes, (select max(trxn_datetime) from parsed_transaction where atm_id = outerATM.atm_id and amount>0 )last_invoked ,
note_set_type.denomination_type_1 * p.cassette1_notes + 
note_set_type.denomination_type_2 * p.cassette2_notes + 
note_set_type.denomination_type_3 * p.cassette3_notes + 
note_set_type.denomination_type_4 * p.cassette4_notes + 
note_set_type.denomination_type_5 * p.cassette5_notes + 
note_set_type.denomination_type_6 * p.cassette6_notes + 
note_set_type.denomination_type_7 * p.cassette7_notes total ,description,
( select max(rep_datetime) from replenishment where atm_id = outerATM.atm_id)last_replenishment_at,( isnull((select region_name + '-' from region where region_id = r.parent_region_id and is_organization=0),'') + r.region_name) region_name,r.region_id,parent_region_id,bank_logo
,

( select min(cash_order_datetime) from cash_order_monitoring where  atm_id = outerATM.atm_id    
and cash_order_datetime>=convert(datetime,'" + DateTime.Today.ToString("dd/MM/yyyy") + "',103))next_replenishment_at, " +

    " ( select min(current_order_suggested_amount) from cash_order_monitoring where  atm_id = outerATM.atm_id  " +
    " and cash_order_datetime>=convert(datetime,'" + DateTime.Today.ToString("dd/MM/yyyy") + "',103))amount" +

    " from atm outerATM , cash_position p ,note_set_type,region r" +
    " where outerATM.atm_id = p.atm_id and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ") and outerATM.is_active = 1 and outerATM.exclude_dff= 0  and outerATM.is_atm = 1 " +
    " and p.last_trxn_at >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                                " p.last_trxn_at <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)" +
    " and outerATM.note_set_type_id = note_set_type.note_set_type_id and outerATM.region_id = r.region_id" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "outerATM.atm_id") : "");

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new dsCashPositions();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables[0]);
                    PopulateDataTable(ds.Tables[0]);
                    //    return ds;

                }
                else if (reportName == "ATMWithoutTrxn24Hour")
                {
                    StringBuilder builder = new StringBuilder();
                    if (isEjEnabled)
                        cmd.CommandText = "select atm_id from atm where atm.is_active=1 and  atm_id not in (select ATM_id from ej_parsed_transactions where trxn_datetime >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                                " trxn_datetime <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103))" +
                                                " and atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ") ";
                    else
                        cmd.CommandText = "select atm_id from atm where atm.is_active=1 and  atm_id not in (select ATM_id from parsed_transaction where trxn_datetime >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                            " trxn_datetime <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103))" +
                                            " and atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ") " + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "atm_id") : "");
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        builder.Append(reader.GetInt32(0) + ",");
                    }
                    builder.Append("-1");

                    reader.Close();
                    string atmWithoutTrxnToday = builder.ToString();
                    string[] parts = atmWithoutTrxnToday.Split(',');


                    if (isEjEnabled)
                        cmd.CommandText = @"select outerATM.atm_id,outerATM.title,region.region_name,trxn_datetime last_trxn_at,amount,outerATM.location,outerATM.allowed_inactivity_period
                                    from atm outerATM left join ej_parsed_transactions on outerATM.atm_id =ej_parsed_transactions.atm_id 
                                    inner join region on  outerATM.region_id = region.region_id 
                                    where outerATM.is_active = 1 and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")  and outerATM.atm_id in (" + atmWithoutTrxnToday + ")" +
                                        " and trxn_datetime in (select max(trxn_datetime) from ej_parsed_transactions " +
                                                                                     " where ej_parsed_transactions.atm_id= outerATM.atm_id)";
                    else
                        cmd.CommandText = @"select outerATM.atm_id,outerATM.title,region.region_name,trxn_datetime last_trxn_at,amount,outerATM.location,outerATM.allowed_inactivity_period
                                    from atm outerATM left join parsed_transaction on outerATM.atm_id =parsed_transaction.atm_id 
                                    inner join region on  outerATM.region_id = region.region_id 
                                    where outerATM.is_active = 1 and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")  and outerATM.atm_id in (" + atmWithoutTrxnToday + ")" +
                                    " and trxn_datetime in (select max(trxn_datetime) from parsed_transaction " +
                                                                                 " where parsed_transaction.atm_id= outerATM.atm_id)";

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new dsNoCashWithdrawals();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);
                    builder = new StringBuilder();

                    for (int i = 0; i < parts.Length; i++)
                    {
                        DataRow[] dr = ds.Tables["DataTable1"].Select("atm_id=" + parts[i]);
                        if (dr.Length == 0)
                        {
                            builder.Append(parts[i] + ",");
                        }
                    }
                    builder.Append("-1");
                    cmd.CommandText = "select title,region_name,atm.location from atm inner join region on atm.region_id =region.region_id   " +
                                        " where atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")  and atm.is_active=1 and atm_id in (" + builder.ToString() + ")";
                    DataTable temp = new DataTable();
                    adapter.Fill(temp);
                    ds.Tables["DataTable1"].Merge(temp);
                    ds.Tables["DataTable1"].DefaultView.Sort = "title asc";

                }
                else if (reportName == "ReplenishmentWithoutTestCash")
                {
                    cmd.CommandText = @"select cash_added1,cash_added2,cash_added3,cash_added4,cash_added5,cash_added6,cash_added7,is_swap,cash_order_id,
                                    atm.atm_id,title,region.region_id,region.region_name,parent_region_id,ip,
                                    rep_datetime,rep_status reason,
                                    cash_added1*note_set_type.denomination_type_1+cash_added2*denomination_type_2+cash_added3*denomination_type_3+cash_added4*denomination_type_4+cash_added5*denomination_type_5
                                    +cash_added6*denomination_type_6+cash_added7*denomination_type_7 total_rep,atm.location
                                    from replenishment 
                                    inner join atm on replenishment.atm_id = atm.atm_id 
                                    inner join note_set_type on atm.note_set_type_id = note_set_type.note_set_type_id 
                                    inner join region on atm.region_id = region.region_id 
                                    where rep_datetime >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                        "and rep_datetime <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                        " and atm.IS_ACTIVE =1 and rep_status ='ReplenishmentWithoutTestCash'" +
                                        " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DsSuspiciousReplenishmentRpt();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["SuspiciousReplenishment"]);
                    //PopulateDataTableForReplenishment(ds.Tables["SuspiciousReplenishment"]);
                }
                //Added on 30/12/2014
                ///////
                else if (reportName == "DepositPositionReport")
                {

                    cmd.CommandText = @"select * , (select max(counts_cleared_at) from bna_counts_cleared where atm_id = outerATM.atm_id) last_bna_cleared_at, 
                                    (select max(counts_cleared_at) from cpm_counts_cleared where atm_id = outerATM.atm_id)last_cpm_cleared_at  from deposit_position, atm outerATM, region 
                                    where outerATM.region_id = region.region_id 
                                    and outerATM.atm_id = deposit_position.atm_id 
                                    and outerATM.is_active =1 " +
                                   " and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" +
                                   " order by title ";

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new dsDepositPositionReport();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables[0]);
                    //PopulateDataTableForReplenishment(ds.Tables["SuspiciousReplenishment"]);
                }
                ///////

                else if (reportName == "ReplenishmentSummaryReport")
                {
                    if (isEjEnabled)
                        cmd.CommandText = @"select notes_added_type1 cash_added1,notes_added_type2 cash_added2,notes_added_type3 cash_added3,
                                        notes_added_type4 cash_added4, 0 cash_added5,0 cash_added6,0 cash_added7,1 is_swap, -1 cash_order_id,
                                    atm.atm_id,title,region.region_id,region.region_name,parent_region_id,ip,
                                    rep_datetime,'Normal' reason,
                                    notes_added_type1*note_set_type.denomination_type_1+notes_added_type2*denomination_type_2+notes_added_type3*denomination_type_3+notes_added_type4*denomination_type_4
                                     total_rep,atm.location
                                    from ej_parsed_replenishments
                                    inner join atm on ej_parsed_replenishments.atm_id = atm.atm_id 
                                    inner join note_set_type on atm.note_set_type_id = note_set_type.note_set_type_id 
                                    inner join region on atm.region_id = region.region_id 
                                    where rep_datetime >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                        "and rep_datetime <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                        " and atm.IS_ACTIVE =1" +
                        " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    else
                        cmd.CommandText = @"select cash_added1,cash_added2,cash_added3,cash_added4,cash_added5,cash_added6,cash_added7,is_swap,cash_order_id,
                                    atm.atm_id,title,region.region_id,region.region_name,parent_region_id,ip,
                                    rep_datetime,rep_status reason,
                                    cash_added1*note_set_type.denomination_type_1+cash_added2*denomination_type_2+cash_added3*denomination_type_3+cash_added4*denomination_type_4+cash_added5*denomination_type_5
                                    +cash_added6*denomination_type_6+cash_added7*denomination_type_7 total_rep,atm.location
                                    from replenishment 
                                    inner join atm on replenishment.atm_id = atm.atm_id 
                                    inner join note_set_type on atm.note_set_type_id = note_set_type.note_set_type_id 
                                    inner join region on atm.region_id = region.region_id 
                                    where rep_datetime >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                            "and rep_datetime <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                            " and atm.IS_ACTIVE =1" +
                                            " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DsSuspiciousReplenishmentRpt();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["SuspiciousReplenishment"]);
                    //PopulateDataTableForReplenishment(ds.Tables["SuspiciousReplenishment"]);
                }
                else if (reportName == "LowBalanceReport")
                {
                    if (reportDataAge == 0)
                        if (isEjEnabled)
                            cmd.CommandText = @"
                                 select ( isnull((select region_name + '-' from region where region_id = r.parent_region_id and is_organization=0),'') + r.region_name) region_name,r.region_id, r.parent_region_id, outerATM.title, bank_logo,alert_type_name,atm_alert.generated_at,alert_msg,
                                notes_added_type1 cash_added1,notes_added_type2 cash_added2,notes_added_type3 cash_added3,notes_added_type4 cash_added4,rep_datetime,outerATM.location,(select note_set_type.denomination_type_1 * cassette1_notes +
                                note_set_type.denomination_type_2 * cassette2_notes +
                                note_set_type.denomination_type_3 * cassette3_notes +
                                note_set_type.denomination_type_4 * cassette4_notes from ej_cash_position,atm , note_set_type
                                where ej_cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and ej_cash_position.atm_id = outerATM.atm_id
                                and last_trxn_at = (select max(last_trxn_at) from ej_cash_position where atm_id = outerATM.atm_id)) currentBalance
                                from atm_alert inner join atm outerATM on outerATM.atm_id = atm_alert.atm_id
                                inner join alert_type on atm_alert.alert_type_id = alert_type.alert_type_id
                                inner join region r on outerATM.region_id = r.region_id
                                left join ej_parsed_replenishments on ej_parsed_replenishments.atm_id = outerATM.ATM_id 
                                and rep_datetime in (select max(rep_datetime) from ej_parsed_replenishments
                                where rep_datetime <=atm_alert.generated_at and atm_id =atm_alert.atm_id )													
                                where outerATM.is_active=1

                                and atm_alert.generated_at in (select max(generated_at) from atm_alert where atm_id = outerATM.atm_id and alert_type_id = 20 and resolve_at is null) " +
                                " and alert_type.alert_type_id = 20 and resolve_at is null " +
                                " and (select note_set_type.denomination_type_1 * cassette1_notes + " +
                                " note_set_type.denomination_type_2 * cassette2_notes + " +
                                " note_set_type.denomination_type_3 * cassette3_notes + " +
                                " note_set_type.denomination_type_4 * cassette4_notes from ej_cash_position,atm , note_set_type " +
                                " where ej_cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and ej_cash_position.atm_id = outerATM.atm_id " +
                                " and last_trxn_at = (select max(last_trxn_at) from ej_cash_position where atm_id = outerATM.atm_id)) <= outerATM.min_operating_balance" +
                                " and (select note_set_type.denomination_type_1 * cassette1_notes + " +
                                " note_set_type.denomination_type_2 * cassette2_notes + " +
                                " note_set_type.denomination_type_3 * cassette3_notes + " +
                                " note_set_type.denomination_type_4 * cassette4_notes from ej_cash_position,atm , note_set_type " +
                                " where ej_cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and ej_cash_position.atm_id = outerATM.atm_id " +
                                " and last_trxn_at = (select max(last_trxn_at) from ej_cash_position where atm_id = outerATM.atm_id)) > outerATM.out_of_cash_threshold" +
                                " and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "outerATM.atm_id") : "");

                    else
                        cmd.CommandText = @"
                                
                                select ( isnull((select region_name + '-' from region where region_id = r.parent_region_id and is_organization=0),'') + r.region_name) region_name,r.region_id, r.parent_region_id, outerATM.title, bank_logo,alert_type_name,atm_alert.generated_at,alert_msg,
                                cash_added1,cash_added2,cash_added3,cash_added4,rep_datetime,outerATM.location,(select note_set_type.denomination_type_1 * cassette1_notes +
                                note_set_type.denomination_type_2 * cassette2_notes +
                                note_set_type.denomination_type_3 * cassette3_notes +
                                note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type
                                where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = outerATM.atm_id
                                and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = outerATM.atm_id)) currentBalance
                                from 
                                atm_alert,atm outerATM,alert_type,region r,replenishment
                                where outerATM.atm_id = atm_alert.atm_id
                                and outerATM.is_active=1
                                and atm_alert.alert_type_id = alert_type.alert_type_id
                                and outerATM.region_id = r.region_id
                                and replenishment.atm_id = outerATM.ATM_id 
                                and rep_datetime in (select max(rep_datetime) from replenishment
								where rep_datetime <=atm_alert.generated_at
                                and atm_id =atm_alert.atm_id )													
                                and atm_alert.generated_at in (select max(generated_at) from atm_alert where atm_id = outerATM.atm_id and alert_type_id = 20 and resolve_at is null) " +
                                " and alert_type.alert_type_id = 20 and resolve_at is null " +
                                " and (select note_set_type.denomination_type_1 * cassette1_notes + " +
                                " note_set_type.denomination_type_2 * cassette2_notes + " +
                                " note_set_type.denomination_type_3 * cassette3_notes + " +
                                " note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type " +
                                " where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = outerATM.atm_id " +
                                " and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = outerATM.atm_id)) <= outerATM.min_operating_balance" +
                                " and (select note_set_type.denomination_type_1 * cassette1_notes + " +
                                " note_set_type.denomination_type_2 * cassette2_notes + " +
                                " note_set_type.denomination_type_3 * cassette3_notes + " +
                                " note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type " +
                                " where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = outerATM.atm_id " +
                                " and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = outerATM.atm_id)) > outerATM.out_of_cash_threshold" +
                                " and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "outerATM.atm_id") : "");

//                        cmd.CommandText = @"
                    //                                
                    //select region_name,region.region_id, parent_region_id, outerATM.title, bank_logo,alert_type_name,generated_at,alert_msg,
                    //cash_added1,cash_added2,cash_added3,cash_added4,rep_datetime,outerATM.location from 
                    //                                atm_alert,atm outerATM,alert_type,region,replenishment
                    //                                where outerATM.atm_id = atm_alert.atm_id
                    //                                and outerATM.is_active=1
                    //                                and atm_alert.alert_type_id = alert_type.alert_type_id
                    //                                and outerATM.region_id = region.region_id
                    //                                and replenishment.atm_id = outerATM.ATM_id 
                    //                                and rep_datetime in (select max(rep_datetime) from replenishment
                    //													where rep_datetime <=atm_alert.generated_at
                    //                                                    and atm_id =atm_alert.atm_id )													
                    //                                and atm_alert.generated_at in (select max(generated_at) from atm_alert where atm_id = outerATM.atm_id and alert_type_id = 20) " +
                    //                                " and alert_type.alert_type_id = 20 and resolve_at is null" +
                    //                                " and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    else
                        cmd.CommandText = @"
                                
                                select ( isnull((select region_name + '-' from region where region_id = r.parent_region_id and is_organization=0),'') + r.region_name) region_name,r.region_id, r.parent_region_id, title, bank_logo,alert_type_name,atm_alert.generated_at,alert_msg,
                                cash_added1,cash_added2,cash_added3,cash_added4,rep_datetime,outerATM.location ,(select note_set_type.denomination_type_1 * cassette1_notes +
                                note_set_type.denomination_type_2 * cassette2_notes +
                                note_set_type.denomination_type_3 * cassette3_notes +
                                note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type
                                where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = outerATM.atm_id
                                and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = outerATM.atm_id)) currentBalance from 
                                atm_alert,atm outerATM,alert_type,region r,replenishment
                                where outerATM.atm_id = atm_alert.atm_id                                
                                and atm_alert.alert_type_id = alert_type.alert_type_id
                                and outerATM.region_id = r.region_id
                                and replenishment.atm_id = outerATM.ATM_id 
                                and rep_datetime in (select max(rep_datetime) from replenishment
								where rep_datetime <=atm_alert.generated_at
                                and atm_id = atm_alert.atm_id)													
                                and atm_alert.generated_at >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                               "and atm_alert.generated_at <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                              " and alert_type.alert_type_id = 20 and resolve_at is null  " +
                              " and (select note_set_type.denomination_type_1 * cassette1_notes + " +
                              " note_set_type.denomination_type_2 * cassette2_notes + " +
                              " note_set_type.denomination_type_3 * cassette3_notes + " +
                              " note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type " +
                              " where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = outerATM.atm_id " +
                              " and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = outerATM.atm_id)) <= outerATM.min_operating_balance" +
                              " and (select note_set_type.denomination_type_1 * cassette1_notes + " +
                                " note_set_type.denomination_type_2 * cassette2_notes + " +
                                " note_set_type.denomination_type_3 * cassette3_notes + " +
                                " note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type " +
                                " where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = outerATM.atm_id " +
                                " and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = outerATM.atm_id)) > outerATM.out_of_cash_threshold" +
                             " and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "outerATM.atm_id") : "");

                    //                        cmd.CommandText = @"
                    //                                
                    //select region_name,region.region_id, parent_region_id, title, bank_logo,alert_type_name,generated_at,alert_msg,
                    //cash_added1,cash_added2,cash_added3,cash_added4,rep_datetime,atm.location from 
                    //                                atm_alert,atm,alert_type,region,replenishment
                    //                                where atm.atm_id = atm_alert.atm_id
                    //                                and atm.is_active=1
                    //                                and atm_alert.alert_type_id = alert_type.alert_type_id
                    //                                and atm.region_id = region.region_id
                    //                                and replenishment.atm_id = atm.ATM_id 
                    //                                and rep_datetime in (select max(rep_datetime) from replenishment
                    //													where rep_datetime <=atm_alert.generated_at
                    //                                                    and atm_id =atm_alert.atm_id )													
                    //                                and atm_alert.generated_at >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                    //                                    "and atm_alert.generated_at <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                    //                                    " and alert_type.alert_type_id = 20 and resolve_at is null" +
                    //                                    " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    ds = new dsAlerts();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);
                    SplitAlertMessageIntoColumns(ds.Tables["DataTable1"]);

                    //PopulateDataTable(ds.Tables["DataTable1"]);
                }

                else if (reportName == "MinNotesThresholdReport")
                {
                    //                    if (reportDataAge == 0)
                    //                        cmd.CommandText = @"
                    //                                
                    //                                select ( isnull((select region_name + '-' from region where region_id = r.parent_region_id and is_organization=0),'') + r.region_name) region_name,r.region_id, r.parent_region_id, outerATM.title, bank_logo,alert_type_name,atm_alert.generated_at,alert_msg,
                    //                                cash_added1,cash_added2,cash_added3,cash_added4,rep_datetime,outerATM.location,(select note_set_type.denomination_type_1 * cassette1_notes +
                    //                                note_set_type.denomination_type_2 * cassette2_notes +
                    //                                note_set_type.denomination_type_3 * cassette3_notes +
                    //                                note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type
                    //                                where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = outerATM.atm_id
                    //                                and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = outerATM.atm_id)) currentBalance
                    //                                from 
                    //                                atm_alert,atm outerATM,alert_type,region r,replenishment
                    //                                where outerATM.atm_id = atm_alert.atm_id
                    //                                and outerATM.is_active=1
                    //                                and atm_alert.alert_type_id = alert_type.alert_type_id
                    //                                and outerATM.region_id = r.region_id
                    //                                and replenishment.atm_id = outerATM.ATM_id 
                    //                                and rep_datetime in (select max(rep_datetime) from replenishment
                    //								where rep_datetime <=atm_alert.generated_at
                    //                                and atm_id =atm_alert.atm_id )													
                    //                                and atm_alert.generated_at in (select max(generated_at) from atm_alert where atm_id = outerATM.atm_id and alert_type_id = 20 and resolve_at is null) " +
                    //                                " and alert_type.alert_type_id = 20 and resolve_at is null " +
                    //                                " and (select note_set_type.denomination_type_1 * cassette1_notes + " +
                    //                                " note_set_type.denomination_type_2 * cassette2_notes + " +
                    //                                " note_set_type.denomination_type_3 * cassette3_notes + " +
                    //                                " note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type " +
                    //                                " where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = outerATM.atm_id " +
                    //                                " and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = outerATM.atm_id)) <= outerATM.min_operating_balance" +
                    //                                " and (select note_set_type.denomination_type_1 * cassette1_notes + " +
                    //                                " note_set_type.denomination_type_2 * cassette2_notes + " +
                    //                                " note_set_type.denomination_type_3 * cassette3_notes + " +
                    //                                " note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type " +
                    //                                " where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = outerATM.atm_id " +
                    //                                " and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = outerATM.atm_id)) > outerATM.out_of_cash_threshold" +
                    //                                " and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    //                        cmd.CommandText = @"
                    //                                
                    //select region_name,region.region_id, parent_region_id, outerATM.title, bank_logo,alert_type_name,generated_at,alert_msg,
                    //cash_added1,cash_added2,cash_added3,cash_added4,rep_datetime,outerATM.location from 
                    //                                atm_alert,atm outerATM,alert_type,region,replenishment
                    //                                where outerATM.atm_id = atm_alert.atm_id
                    //                                and outerATM.is_active=1
                    //                                and atm_alert.alert_type_id = alert_type.alert_type_id
                    //                                and outerATM.region_id = region.region_id
                    //                                and replenishment.atm_id = outerATM.ATM_id 
                    //                                and rep_datetime in (select max(rep_datetime) from replenishment
                    //													where rep_datetime <=atm_alert.generated_at
                    //                                                    and atm_id =atm_alert.atm_id )													
                    //                                and atm_alert.generated_at in (select max(generated_at) from atm_alert where atm_id = outerATM.atm_id and alert_type_id = 20) " +
                    //                                " and alert_type.alert_type_id = 20 and resolve_at is null" +
                    //                                " and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    // else
                    cmd.CommandText = @"
                                
                                select ( isnull((select region_name + '-' from region where region_id = r.parent_region_id and is_organization=0),'') + r.region_name) region_name,r.region_id, r.parent_region_id, title, bank_logo,alert_type_name,atm_alert.generated_at,alert_msg,
                                outerATM.location  from 
                                atm_alert,atm outerATM,alert_type,region r
                                where outerATM.atm_id = atm_alert.atm_id                                
                                and atm_alert.alert_type_id = alert_type.alert_type_id
                                and outerATM.region_id = r.region_id
                                
                                
                                and atm_alert.generated_at >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                           "and atm_alert.generated_at <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                          " and alert_type.alert_type_id in (46,47,48,49)  and resolve_at is null  " +

                         " and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    //                        cmd.CommandText = @"
                    //                                
                    //select region_name,region.region_id, parent_region_id, title, bank_logo,alert_type_name,generated_at,alert_msg,
                    //cash_added1,cash_added2,cash_added3,cash_added4,rep_datetime,atm.location from 
                    //                                atm_alert,atm,alert_type,region,replenishment
                    //                                where atm.atm_id = atm_alert.atm_id
                    //                                and atm.is_active=1
                    //                                and atm_alert.alert_type_id = alert_type.alert_type_id
                    //                                and atm.region_id = region.region_id
                    //                                and replenishment.atm_id = atm.ATM_id 
                    //                                and rep_datetime in (select max(rep_datetime) from replenishment
                    //													where rep_datetime <=atm_alert.generated_at
                    //                                                    and atm_id =atm_alert.atm_id )													
                    //                                and atm_alert.generated_at >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                    //                                    "and atm_alert.generated_at <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                    //                                    " and alert_type.alert_type_id = 20 and resolve_at is null" +
                    //                                    " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    ds = new dsAlerts();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);
                    SplitMinNotesMessageIntoParts(ds.Tables["DataTable1"]);

                    PopulateDataTable(ds.Tables["DataTable1"]);
                }

                else if (reportName == "CurrentLowBalanceReport")
                {
                    cmd.CommandText = @"
                                
                                select ( isnull((select region_name + '-' from region where region_id = r.parent_region_id and is_organization=0),'') + r.region_name) region_name,r.region_id, parent_region_id, outerATM.title, bank_logo,alert_type_name,atm_alert.generated_at,alert_msg,
                                cash_added1,cash_added2,cash_added3,cash_added4,rep_datetime,outerATM.location from 
                                atm_alert,atm outerATM,alert_type,region r,replenishment
                                where outerATM.atm_id = atm_alert.atm_id
                                and outerATM.is_active=1
                                and atm_alert.alert_type_id = alert_type.alert_type_id
                                and outerATM.region_id = r.region_id
                                and replenishment.atm_id = outerATM.ATM_id 
                                and rep_datetime in (select max(rep_datetime) from replenishment
								where rep_datetime <=atm_alert.generated_at
                                and atm_id =atm_alert.atm_id )													
                                and atm_alert.generated_at in (select max(generated_at) from atm_alert where atm_id = outerATM.atm_id and alert_type_id = 20 and resolve_at is null) " +
                                " and alert_type.alert_type_id = 20 and resolve_at is null" +
                                " and (select note_set_type.denomination_type_1 * cassette1_notes + " +
                                " note_set_type.denomination_type_2 * cassette2_notes + " +
                                " note_set_type.denomination_type_3 * cassette3_notes + " +
                                " note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type " +
                                " where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = outerATM.atm_id " +
                                " and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = outerATM.atm_id)) <= outerATM.min_operating_balance" +
                                " and (select note_set_type.denomination_type_1 * cassette1_notes + " +
                                " note_set_type.denomination_type_2 * cassette2_notes + " +
                                " note_set_type.denomination_type_3 * cassette3_notes + " +
                                " note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type " +
                                " where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = outerATM.atm_id " +
                                " and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = outerATM.atm_id)) > outerATM.out_of_cash_threshold" +
                                " and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    ds = new dsAlerts();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);
                    SplitAlertMessageIntoColumns(ds.Tables["DataTable1"]);

                    //PopulateDataTable(ds.Tables["DataTable1"]);
                }


                else if (reportName == "CurrentOutOfCashReport")
                {

                    cmd.CommandText = @"
                                select ( isnull((select region_name + '-' from region where region_id = r.parent_region_id and is_organization=0),'') + r.region_name) region_name,r.region_id, r.parent_region_id, outerATM.title, bank_logo,alert_type_name,atm_alert.generated_at,alert_msg,outerATM.location,
                                cash_added1,cash_added2,cash_added3,cash_added4,rep_datetime,(select note_set_type.denomination_type_1 * cassette1_notes +
                                note_set_type.denomination_type_2 * cassette2_notes +
                                note_set_type.denomination_type_3 * cassette3_notes +
                                note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type
                                where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = outerATM.atm_id
                                and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = outerATM.atm_id)) currentBalance
                                from    
                                atm_alert,atm outerATM,alert_type,region r ,replenishment
                                where outerATM.atm_id = atm_alert.atm_id 
                                and outerATM.is_active=1
                                and atm_alert.alert_type_id = alert_type.alert_type_id
                                and outerATM.region_id = r.region_id
                                and replenishment.atm_id = outerATM.ATM_id 
                                and rep_datetime in (select max(rep_datetime) from replenishment
								where rep_datetime <=atm_alert.generated_at
                                and atm_id =atm_alert.atm_id )													                                
                                and atm_alert.generated_at in (select max(generated_at) from atm_alert where atm_id = outerATM.atm_id and alert_type_id = 21 and resolve_at is null) " +
                                " and alert_type.alert_type_id = 21 and resolve_at is null " +
                                " and (select note_set_type.denomination_type_1 * cassette1_notes + " +
                                " note_set_type.denomination_type_2 * cassette2_notes + " +
                                " note_set_type.denomination_type_3 * cassette3_notes + " +
                                " note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type " +
                                " where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = outerATM.atm_id " +
                                " and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = outerATM.atm_id)) <= outerATM.out_of_cash_threshold" +
                                " and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "outerATM.atm_id") : "");


                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    //                    cmd.CommandText = @"
                    //                                select region_name,region.region_id, parent_region_id, outerATM.title, bank_logo,alert_type_name,generated_at,alert_msg,outerATM.location,
                    //cash_added1,cash_added2,cash_added3,cash_added4,rep_datetime
                    //
                    //                                from    
                    //                                atm_alert,atm outerATM,alert_type,region,replenishment
                    //                                where outerATM.atm_id = atm_alert.atm_id 
                    //                                and outerATM.is_active=1
                    //                                and atm_alert.alert_type_id = alert_type.alert_type_id
                    //                                and outerATM.region_id = region.region_id
                    //and replenishment.atm_id = outerATM.ATM_id 
                    //                                and rep_datetime in (select max(rep_datetime) from replenishment
                    //													where rep_datetime <=atm_alert.generated_at
                    //                                                    and atm_id =atm_alert.atm_id )													                                
                    //and atm_alert.generated_at in (select max(generated_at) from atm_alert where atm_id = outerATM.atm_id and alert_type_id = 21) " +
                    //                                " and alert_type.alert_type_id = 21 and resolve_at is null" +
                    //                    " and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    ds = new dsAlerts();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);
                    SplitAlertMessageIntoColumns(ds.Tables["DataTable1"]);
                    //PopulateDataTable(ds.Tables["DataTable1"]);
                }


                else if (reportName == "OutOfCashReport")
                {
                    if (reportDataAge == 0)
                        cmd.CommandText = @"
                                select region_name,region.region_id, parent_region_id, outerATM.title, bank_logo,alert_type_name,atm_alert.generated_at,alert_msg,outerATM.location,
                                cash_added1,cash_added2,cash_added3,cash_added4,rep_datetime
                                from    
                                atm_alert,atm outerATM,alert_type,region,replenishment
                                where outerATM.atm_id = atm_alert.atm_id 
                                and outerATM.is_active=1
                                and atm_alert.alert_type_id = alert_type.alert_type_id
                                and outerATM.region_id = region.region_id
                                and replenishment.atm_id = outerATM.ATM_id 
                                and rep_datetime in (select max(rep_datetime) from replenishment
								where rep_datetime <=atm_alert.generated_at
                                and atm_id =atm_alert.atm_id )													                                
                                and atm_alert.generated_at in (select max(generated_at) from atm_alert where atm_id = outerATM.atm_id and alert_type_id = 21) " +
                                " and alert_type.alert_type_id = 21 and resolve_at is null" +
                                " and (select note_set_type.denomination_type_1 * cassette1_notes + " +
                                " note_set_type.denomination_type_2 * cassette2_notes + " +
                                " note_set_type.denomination_type_3 * cassette3_notes + " +
                                " note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type " +
                                " where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = outerATM.atm_id " +
                                " and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = outerATM.atm_id)) <= outerATM.out_of_cash_threshold" +
                                " and outerATM.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "outerATM.atm_id") : "");

                    else
                        cmd.CommandText = @"
                                select region_name,region.region_id, parent_region_id, title, bank_logo,alert_type_name,atm_alert.generated_at,alert_msg,atm.location,
                                cash_added1,cash_added2,cash_added3,cash_added4,rep_datetime
                                from    
                                atm_alert,atm,alert_type,region,replenishment
                                where atm.atm_id = atm_alert.atm_id 
                                and atm.is_active=1
                                and atm_alert.alert_type_id = alert_type.alert_type_id
                                and atm.region_id = region.region_id
                                and replenishment.atm_id = atm.ATM_id 
                                and rep_datetime in (select max(rep_datetime) from replenishment
								where rep_datetime <=atm_alert.generated_at
                                and atm_id =atm_alert.atm_id )													                                
                                and atm_alert.generated_at >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                "and atm_alert.generated_at <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                " and alert_type.alert_type_id = 21 and resolve_at is null" +
                                " and (select note_set_type.denomination_type_1 * cassette1_notes + " +
                                " note_set_type.denomination_type_2 * cassette2_notes + " +
                                " note_set_type.denomination_type_3 * cassette3_notes + " +
                                " note_set_type.denomination_type_4 * cassette4_notes from cash_position,atm , note_set_type " +
                                " where cash_position.atm_id = atm.atm_id and atm.note_set_type_id = note_set_type.note_set_type_id and cash_position.atm_id = atm.atm_id " +
                                " and last_trxn_at = (select max(last_trxn_at) from cash_position where atm_id = atm_alert.atm_id)) <= atm.out_of_cash_threshold" +
                                " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "atm.atm_id") : "");

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new dsAlerts();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);
                    SplitAlertMessageIntoColumns(ds.Tables["DataTable1"]);
                    //PopulateDataTable(ds.Tables["DataTable1"]);
                }
                else if (reportName == "PurgeBinAlertsReport")
                {
                    cmd.CommandText = @"
                                select region_name,region.region_id, parent_region_id, title, bank_logo,alert_type_name,generated_at,alert_msg,atm.location from 
                                atm_alert,atm,alert_type,region
                                where atm.atm_id = atm_alert.atm_id 
                                and atm.is_active=1                                
                                and atm_alert.alert_type_id = alert_type.alert_type_id
                                and atm.region_id = region.region_id
                                and atm_alert.generated_at >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                "and atm_alert.generated_at <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                " and alert_type.alert_type_id = 22 and resolve_at is null" +
                                " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    ds = new dsAlerts();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);
                    //1,72,12, 2,47,12, 3,0,12, 4,17,14
                    SplitAlertMessageIntoColumnsForPurgeThreshold(ds.Tables["DataTable1"]);
                    //PopulateDataTable(ds.Tables["DataTable1"]);
                }
                else if (reportName == "DateTimeSyncReport")
                {
                    cmd.CommandText = @"SELECT * from vTaskStatusReport where " +
                     " IS_ACTIVE =1 and creation_time >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                     " and creation_time <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                    " and task_type_id  = 6" +
                    " and atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DsTaskStatusRpt();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["TaskStatus"]);
                    PopulateDataTableForTaskStatus(ds.Tables["TaskStatus"]);

                }

                else if (reportName == "CashUtilizationReport")
                {
                    if (isEjEnabled)
                        cmd.CommandText = @"select atm.location,region.region_name,region.region_id, parent_region_id, title, trxn_datetime rep_datetime, replenishment_amount,return_amount 
                        from atm, ej_summary, region  where atm.is_active=1 and atm.atm_id = ej_summary.atm_id and atm.region_id = region.region_id and replenishment_amount > 0 and " +
                                           " trxn_datetime >= convert(datetime,'" + scheduleDate.AddDays(-double.Parse(System.Configuration.ConfigurationManager.AppSettings["cashUtilizationInterval"])).ToString("dd/MM/yyyy") + "',103) " +
                                            " and trxn_datetime <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                            " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    else
                        cmd.CommandText = @"select atm.location,region.region_name,region.region_id, parent_region_id, title, trxn_datetime rep_datetime, replenishment_amount,return_amount 
                        from atm, summary, region  where atm.is_active=1 and atm.atm_id = summary.atm_id and atm.region_id = region.region_id and replenishment_amount > 0 and " +
                                           " trxn_datetime >= convert(datetime,'" + scheduleDate.AddDays(-double.Parse(System.Configuration.ConfigurationManager.AppSettings["cashUtilizationInterval"])).ToString("dd/MM/yyyy") + "',103) " +
                                            " and trxn_datetime <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                            " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, cmd.CommandText);
                    ds = new DSCashUtilization();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables[0]);
                    PopulateDataTable(ds.Tables[0]);
                }

                else if (reportName == "AlertsReport")
                {
                    cmd.CommandText = @"select region_name,region.region_id, title,parent_region_id,  bank_logo,alert_type_name,generated_at,resolve_at,generate_at_retry_remaining,atm.location,
                                        resolve_at_retry_remaining,generate_notification_sent,resolve_notification_sent,failure_reason from 
                                        atm_alert,atm,alert_type,region
                                        where atm.atm_id = atm_alert.atm_id 
                                        and atm_alert.alert_type_id = alert_type.alert_type_id
                                        and atm.region_id = region.region_id" +
                                        " and atm.is_active = 1 and " +
                                       " generated_at >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                        " and generated_at <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                        " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    ds = new dsAlerts();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);
                    PopulateDataTable(ds.Tables["DataTable1"]);
                }


                else if (reportName == "NoActivityAlertReport" || reportName == "BNANoActivityAlertReport" || reportName == "CDMNoActivityAlertReport")
                {
                    ds = new dsNoCashWithdrawals();
                    int inactivityPeriod = 0;
                    conn.Open();
                    if (reportName == "NoActivityAlertReport")
                    {
                        if (isEjEnabled)

                            cmd.CommandText = @"
                                        select atm.atm_id, max(trxn_datetime) trxn_datetime
                                        from atm  left join ej_parsed_transactions
                                        on ej_parsed_transactions.atm_id = atm.atm_id and status = 0
                                        left join transaction_type on transaction_type.transaction_type_id = ej_parsed_transactions.transaction_type_id
                                        where is_active = 1 and allowed_inactivity_period is not null and is_atm=1 and is_ej_enabled=1  " +
                                        " and (transaction_type_name like '%WITH%' or transaction_type_name is null) "+
                                      
                                        " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" +
                                        " group by atm.atm_id";


                        else
                            cmd.CommandText = @"
                                        select atm.atm_id, max(trxn_datetime) trxn_datetime
                                        from atm  left join parsed_transaction
                                        on parsed_transaction.atm_id = atm.atm_id 
                                        where is_active = 1 and allowed_inactivity_period is not null and is_atm=1  " +
                                            " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" +
                                            " group by atm.atm_id";

                    }

                    else if (reportName == "BNANoActivityAlertReport")
                    {
                        cmd.CommandText = @"
                                        select atm.atm_id, max(last_bna_deposit_at) trxn_datetime
                                        from atm  left join deposit_position
                                        on deposit_position.atm_id = atm.atm_id 
                                        where is_active = 1 and bna_allowed_inactivity_period is not null and is_cdm =1 " +
                                        " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" +
                                        " group by atm.atm_id";
                    }

                    else if (reportName == "CDMNoActivityAlertReport")
                    {
                        cmd.CommandText = @"
                                        select atm.atm_id, max(last_cpm_deposit_at) trxn_datetime
                                        from atm  left join deposit_position
                                        on deposit_position.atm_id = atm.atm_id 
                                        where is_active = 1 and cheque_allowed_inactivity_period is not null and is_ccdm=1" +
                                        " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" +
                                        " group by atm.atm_id";

                    }


                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Atm atm = Atm.LoadAtmByPk(reader.GetInt32(0));
                        if (reportName == "NoActivityAlertReport")
                        {
                            inactivityPeriod = atm.AllowedInactivityPeriod.Value;
                        }
                        else if (reportName == "BNANoActivityAlertReport")
                        {
                            inactivityPeriod = atm.BnaAllowedInactivityPeriod.Value;
                        }
                        else if (reportName == "CDMNoActivityAlertReport")
                        {
                            inactivityPeriod = atm.ChequeAllowedInactivityPeriod.Value;
                        }

                        if (reader[1] != DBNull.Value)
                        {
                            DateTime maxDateTime = reader.GetDateTime(1);

                            if (maxDateTime.AddSeconds(
                                 inactivityPeriod) < DateTime.Now)
                            {


                                DataRow dr = ds.Tables[0].NewRow();
                                dr["title"] = atm.Title;
                                dr["last_trxn_at"] = maxDateTime;

                                if (reportName == "NoActivityAlertReport")
                                {
                                    if (isEjEnabled)
                                    {
                                        EjParsedTransactions parsedTransaction = EjParsedTransactions.LoadEjParsedTransactions(
                                            "trxn_datetime=convert(datetime,'" + maxDateTime.ToString("dd/MM/yyyy HH:mm:ss") + "',103) and atm_id = " + atm.ATMId);
                                        
                                        if (parsedTransaction.Amount != null)
                                            dr["amount"] = parsedTransaction.Amount;
                                        else
                                            dr["amount"] = 0;

                                        if (parsedTransaction.NotesRemainingType1.HasValue)
                                            dr["remaining_type_1"] = parsedTransaction.NotesRemainingType1.Value;
                                        else
                                            dr["remaining_type_1"] = 0;

                                        if (parsedTransaction.NotesRemainingType2.HasValue)
                                            dr["remaining_type_2"] = parsedTransaction.NotesRemainingType2.Value;
                                        else
                                            dr["remaining_type_2"] = 0;

                                        if (parsedTransaction.NotesRemainingType3.HasValue)
                                            dr["remaining_type_3"] = parsedTransaction.NotesRemainingType3.Value;
                                        else
                                            dr["remaining_type_3"] = 0;

                                        if (parsedTransaction.NotesRemainingType4.HasValue)
                                            dr["remaining_type_4"] = parsedTransaction.NotesRemainingType4.Value;
                                        else
                                            dr["remaining_type_4"] = 0;




                                    }
                                    else
                                    {
                                        ParsedTransaction parsedTransaction = ParsedTransaction.LoadParsedTransaction(
                                            "trxn_datetime=convert(datetime,'" + maxDateTime.ToString("dd/MM/yyyy HH:mm:ss") + "',103) and atm_id = " + atm.ATMId);
                                        dr["amount"] = parsedTransaction.Amount;
                                        dr["remaining_type_1"] = parsedTransaction.CashRemaining1;
                                        dr["remaining_type_2"] = parsedTransaction.CashRemaining2;
                                        dr["remaining_type_3"] = parsedTransaction.CashRemaining3;
                                        dr["remaining_type_4"] = parsedTransaction.CashRemaining4;

                                    }
                                }
                                else
                                    dr["amount"] = 0;

                                dr["description"] = atm.Description;
                                dr["location"] = atm.Location;
                                dr["region_id"] = atm.RegionId;
                                dr["allowed_inactivity_period"] = inactivityPeriod;
                                Region region = Region.LoadRegionByPk(atm.RegionId);
                                dr["region_name"] = region.RegionName;
                                dr["parent_region_id"] = region.ParentRegionId;
                                dr["organization"] = GetOrganization(region.RegionId);
                                ds.Tables[0].Rows.Add(dr);
                            }

                        }
                        else
                        {
                            DataRow dr = ds.Tables[0].NewRow();
                            dr["description"] = atm.Description;
                            dr["title"] = atm.Title;
                            //dr["last_trxn_at"] = maxDateTime;
                            //dr["amount"] = parsedTransaction.Amount;
                            dr["location"] = atm.Location;
                            dr["region_id"] = atm.RegionId;
                            dr["allowed_inactivity_period"] = inactivityPeriod;
                            Region region = Region.LoadRegionByPk(atm.RegionId);
                            dr["region_name"] = region.RegionName;
                            dr["parent_region_id"] = region.ParentRegionId;
                            dr["organization"] = GetOrganization(region.RegionId);
                            ds.Tables[0].Rows.Add(dr);
                        }
                    }
                    reader.Close();
                }




                    //                    cmd.CommandText = @"select region_name,region.region_id, title,parent_region_id,  bank_logo,alert_type_name,generated_at,resolve_at,generate_at_retry_remaining,
                //                                        resolve_at_retry_remaining,generate_notification_sent,resolve_notification_sent,failure_reason from 
                //                                        atm_alert,atm,alert_type,region
                //                                        where atm.atm_id = atm_alert.atm_id 
                //                                        and atm_alert.alert_type_id = alert_type.alert_type_id
                //                                        and atm.region_id = region.region_id" +
                //                                        "and atm.is_active = 1 and alert_type.alert_type_id = 31 and " +
                //                                        "generated_at >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                //                                        "and generated_at <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  ";



                    //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //adapter.Fill(ds.Tables["DataTable1"]);
                //                    PopulateDataTable(ds.Tables["DataTable1"]);



                else if (reportName == "MemberBankTransactionReport")
                {
                    cmd.CommandText = @"select case when status =0 then 'Successful' when status =1 then 'Failed' when status = 2 then 'Suspicious' end status ,  title,transaction_type_name, bank_name, pan,tsn,amount,donation_amount,transferred_amount,trxn_datetime, " +
                                " region.region_name,region.region_id, parent_region_id,atm.location,notes_dispensed_type1,notes_dispensed_type2,notes_dispensed_type3,notes_dispensed_type4 " +
                                " from atm inner join ej_parsed_transactions " +
                                " on atm.atm_id = ej_parsed_transactions.atm_id " +
                                " inner join transaction_type " +
                                " on transaction_type.transaction_type_id =ej_parsed_transactions.transaction_type_id " +
                                " inner join FITMapping " +
                                " on substring(ej_parsed_transactions.PAN,1,6) = FITMapping.PAN_prefix " +
                                " inner join region on atm.region_id = region.region_id " +
                                " where atm.is_active = 1 and " +
                                       " trxn_datetime >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                        " and trxn_datetime <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                        " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    ds = new dsMemberBankTransaction();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);
                    //PopulateDataTable(ds.Tables["DataTable1"]);
                }
                else if (reportName == "CardCaptureReport")
                {
                    cmd.CommandText = @"select title,pan,tsn,capture_time captured_at,atm.location,region.region_id,parent_region_id,region_name,reason
                                    from ej_captured_card inner join atm 
                                    on ej_captured_card.atm_id = atm.atm_id 
                                    inner join region on atm.region_id = region.region_id where atm.is_active=1 and 
                                        capture_time >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                        " and capture_time <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                        " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";

                    ds = new dsCardCaptured();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);
                    //PopulateDataTable(ds.Tables["DataTable1"]);
                }
                else if (reportName == "CashWithdrawalsSummaryReport")
                {
                    if (isEjEnabled)
                        cmd.CommandText = @"select ej_summary.atm_id,region.region_name,region.region_id, parent_region_id, title,trxn_datetime,
withdrawals, closing_balance, replenishment_amount,return_amount ,atm.location,(select count(parsed_transaction_id) from 
ej_parsed_transactions where trxn_datetime>=ej_summary.trxn_datetime and trxn_datetime<=convert(datetime,convert(varchar,ej_summary.trxn_datetime,103)+ ' 23:59:59',103)
and atm_id = ej_summary.atm_id ) transaction_count
                        from atm, ej_summary, region  where atm.is_active=1 and atm.atm_id = ej_summary.atm_id and atm.region_id = region.region_id and
                                        trxn_datetime >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                            " and trxn_datetime <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                            " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    else
                        cmd.CommandText = @"select summary.atm_id,region.region_name,region.region_id, parent_region_id, title,trxn_datetime,
withdrawals, closing_balance, replenishment_amount,return_amount ,atm.location,(select count(parsed_transaction_id) from 
parsed_transaction where trxn_datetime>=summary.trxn_datetime and trxn_datetime<=convert(datetime,convert(varchar,summary.trxn_datetime,103)+ ' 23:59:59',103)
and atm_id = summary.atm_id ) transaction_count
                        from atm, summary, region  where atm.is_active=1 and atm.atm_id = summary.atm_id and atm.region_id = region.region_id and
                                        trxn_datetime >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                            " and trxn_datetime <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                            " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "atm.atm_id") : "");
                    ds = new dsCashWithdrawals();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);
                    PopulateDataTable(ds.Tables["DataTable1"]);
                }
                else if (reportName == "CashWithdrawalsReport")
                {
                    if (isEjEnabled)
                        cmd.CommandText = @"select region.region_name,region.region_id, parent_region_id, title,trxn_datetime,
                                                notes_dispensed_type1 cash_dispensed1, notes_dispensed_type2 cash_dispensed2,notes_dispensed_type3 cash_dispensed3,
                                        notes_dispensed_type4 cash_dispensed4, 0 cash_dispensed5,0 cash_dispensed6,0 cash_dispensed7,amount,ej_parsed_transactions_id,
notes_remaining_type1 cash_remaining1,notes_remaining_type2 cash_remaining2,notes_remaining_type3 cash_remaining3,notes_remaining_type4 cash_remaining4,atm.location
                                        from atm, ej_parsed_transactions, region  where atm.is_active=1 and  atm.atm_id = ej_parsed_transactions.atm_id and atm.region_id = region.region_id
                                        and trxn_datetime >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                            " and trxn_datetime <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                            " and amount > 0 and status =0 and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    else
                        cmd.CommandText = @"select region.region_name,region.region_id, parent_region_id, title,trxn_datetime,
                                                cash_dispensed1, cash_dispensed2,cash_dispensed3,cash_dispensed4,cash_dispensed5,cash_dispensed6,cash_dispensed7,amount,parsed_transaction_id,
cash_remaining1,cash_remaining2,cash_remaining3,cash_remaining4,atm.location
                                        from atm, parsed_transaction, region  where atm.is_active=1 and  atm.atm_id = parsed_transaction.atm_id and atm.region_id = region.region_id
                                        and trxn_datetime >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                            " and trxn_datetime <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                            " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")" + (isDeadATMExcluded ? GetExcludeDeadATMFilter(scheduleDate, "atm.atm_id") : "");

                    ds = new dsCashWithdrawals();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);
                    //PopulateDataTable(ds.Tables["DataTable1"]);
                }
                else if (reportName == "CassetteDispensingReport")
                {
                    if (isEjEnabled)
                        cmd.CommandText = @"select region.region_name,region.region_id, parent_region_id, title,trxn_datetime,
                                                notes_dispensed_type1 cash_dispensed1, notes_dispensed_type2 cash_dispensed2, notes_dispensed_type3 cash_dispensed3,
notes_dispensed_type4 cash_dispensed4,0 cash_dispensed5,0 cash_dispensed6,0 cash_dispensed7,amount,ej_parsed_transactions_id parsed_transaction_id,atm.atm_id,
notes_remaining_type1 cash_remaining1,notes_remaining_type2 cash_remaining2,notes_remaining_type3 cash_remaining3,notes_remaining_type4 cash_remaining4,atm.location
                                        from atm, ej_parsed_transactions, region  where atm.is_active=1 and atm.atm_id = ej_parsed_transactions.atm_id and atm.region_id = region.region_id
                                        and trxn_datetime >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                            " and trxn_datetime <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                            " and amount > 0 and status =0 and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    else
                        cmd.CommandText = @"select region.region_name,region.region_id, parent_region_id, title,trxn_datetime,
                                                cash_dispensed1, cash_dispensed2,cash_dispensed3,cash_dispensed4,cash_dispensed5,cash_dispensed6,cash_dispensed7,amount,parsed_transaction_id,atm.atm_id,
cash_remaining1,cash_remaining2,cash_remaining3,cash_remaining4,atm.location
                                        from atm, parsed_transaction, region  where atm.is_active=1 and atm.atm_id = parsed_transaction.atm_id and atm.region_id = region.region_id
                                        and trxn_datetime >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                            " and trxn_datetime <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103)  " +
                                            " and atm.atm_id in (select atm_id from mcn_atms where region_id = " + orgID + ")";
                    ds = new dsCashWithdrawals();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["DataTable1"]);
                    //DataColumn dc = new DataColumn();
                    //dc.ColumnName = "parsed_transaction_id";
                    //dc.DataType = typeof(int);
                    //DataColumn[] dcArray = new DataColumn[1];
                    //dcArray[0] = dc;
                    //ds.Tables["DataTable1"].PrimaryKey = dcArray;
                    if (ds.Tables["DataTable1"].Rows.Count > 0)
                    {

                        List<int> atmIDs = new List<int>();
                        foreach (DataRow dr in ds.Tables["DataTable1"].Rows)
                        {
                            int atmID = int.Parse(dr["atm_id"].ToString());
                            if (!atmIDs.Contains(atmID))
                                atmIDs.Add(atmID);
                        }

                        DataSet temp = new DataSet();
                        DataTable dt = new DataTable();
                        dt = ds.Tables["DataTable1"].Clone();
                        dt.PrimaryKey = new DataColumn[] { dt.Columns["parsed_transaction_id"] };

                        if (supportedTypes[0] == "1")
                            ProcessDataTable("cash_dispensed1", ds, dt, atmIDs);
                        if (supportedTypes[1] == "1")
                            ProcessDataTable("cash_dispensed2", ds, dt, atmIDs);
                        if (supportedTypes[2] == "1")
                            ProcessDataTable("cash_dispensed3", ds, dt, atmIDs);
                        if (supportedTypes[3] == "1")
                            ProcessDataTable("cash_dispensed4", ds, dt, atmIDs);


                        temp.Tables.Add(dt);
                        ds.Tables["DataTable1"].Rows.Clear();
                        ds = temp;
                        //if (dt.Rows.Count > 0)
                        //{
                        //    PopulateDataTable(ds.Tables["DataTable1"]);
                        //}
                    }
                }
                else if (reportName == "PNCDepositSummaryForBNA" || reportName == "PNCDepositSummaryForSDMBNA")
                {
                    DataTable dtGrid = new DataTable();
                    dtGrid.Columns.Add("title");
                    dtGrid.Columns.Add("trxn_datetime", typeof(DateTime));
                    dtGrid.Columns.Add("notes_accepted", typeof(int));
                    dtGrid.Columns.Add("notes_rejected1", typeof(int));
                    dtGrid.Columns.Add("notes_rejected2", typeof(int));
                    dtGrid.Columns.Add("total_rejected", typeof(int));
                    dtGrid.Columns.Add("acc_perc", typeof(decimal));
                    dtGrid.Columns.Add("rej_perc", typeof(decimal));

                    //SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
                    cmd.CommandTimeout = 0;// 500;


                    string SQL = @"select atm.atm_id,title,convert(varchar,trxn_datetime,103) trxn_datetime,seq,account_type,pan,amount_authorized,dispute_status,status,comment,note_type,notes_count,ej_parsed_bna_transaction.ej_parsed_bna_transaction_Id
                                    from ej_parsed_bna_transaction inner join atm on ej_parsed_bna_transaction.atm_id = atm.atm_id
                                    inner join ej_parsed_bna_transaction_detail on  ej_parsed_bna_transaction_detail.ej_parsed_bna_transaction_id = 
                                    ej_parsed_bna_transaction.ej_parsed_bna_transaction_id
                                     where atm.is_active=1 " + GetFilter();


                    //string SQL = "select atm.atm_id,title,convert(varchar,trxn_datetime,103) trxn_datetime,dispute_status,status from ej_parsed_cpm_transaction left join ej_parsed_cpm_transaction_detail on ej_parsed_cpm_transaction.ej_parsed_cpm_transaction_id = ej_parsed_cpm_transaction_detail.ej_parsed_cpm_transaction_id " +
                    //             " inner join atm on ej_parsed_cpm_transaction.atm_id = atm.atm_id  where atm.is_active=1 and trxn_datetime>=convert(datetime,'" + fromDate + "',103)  " +
                    //             " and trxn_datetime<=convert(datetime,'" + toDate + " 23:59:59',103) ";

                    DataTable dt = GetDataTable(SQL);

                    DataTable dtATMs = dt.DefaultView.ToTable(true, new string[] { "atm_id", "title" });
                    DataTable dtATMsTrxnDatetime = dt.DefaultView.ToTable(true, new string[] { "atm_id", "trxn_datetime" });
                    int depositCount = 0;
                    int rej1 = 0;
                    int rej2 = 0;
                    int total = 0;
                    foreach (DataRow dr in dtATMs.Rows)
                    {
                        DataRow[] drTrxnDates = dtATMsTrxnDatetime.Select("atm_id = " + dr["atm_id"]);

                        foreach (DataRow drInner in drTrxnDates)
                        {
                            rej1 = 0;
                            rej2 = 0;
                            total = 0;
                            depositCount = 0;

                            DataRow[] drAllTrxnForTheDay = dt.Select("atm_id = " + dr["atm_id"] + " and trxn_datetime='" + drInner["trxn_datetime"] + "' and status = 'Successful'");
                            if (drAllTrxnForTheDay.Length > 0)
                            {

                                DataTable dtBNATrxnIds = drAllTrxnForTheDay.CopyToDataTable().DefaultView.ToTable(true, new string[] { "ej_parsed_bna_transaction_id" });

                                foreach (DataRow drRow in dtBNATrxnIds.Rows)
                                {

                                    StringBuilder builder = new StringBuilder();
                                    DataRow[] dr1 = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"]);
                                    if (dr1.Length > 0)
                                    {
                                        DataTable dtUniqueNoteType = dr1.CopyToDataTable().DefaultView.ToTable(true, new string[] { "note_type" });
                                        foreach (DataRow drUniqueNoteType in dtUniqueNoteType.Rows)
                                        {
                                            DataRow[] temp = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"] + " and note_type=" + drUniqueNoteType["note_type"], "notes_count");
                                            builder.Append(drUniqueNoteType["note_type"].ToString() + "*" + int.Parse(temp[temp.Length - 1]["notes_count"].ToString()) + "=" + int.Parse(drUniqueNoteType["note_type"].ToString()) * int.Parse(temp[temp.Length - 1]["notes_count"].ToString()) + "<br/>");
                                            depositCount += int.Parse(temp[temp.Length - 1]["notes_count"].ToString());
                                        }

                                    }
                                }
                            }

                            DataRow newRow = dtGrid.NewRow();
                            newRow["title"] = dr["title"];
                            newRow["trxn_datetime"] = DateTime.ParseExact(drInner["trxn_datetime"].ToString(), "dd/MM/yyyy", null);
                            newRow["notes_accepted"] = depositCount;



                            drAllTrxnForTheDay = dt.Select("atm_id = " + dr["atm_id"] + " and trxn_datetime='" + drInner["trxn_datetime"] + "' and status = 'Failed' and dispute_status is not null");
                            if (drAllTrxnForTheDay.Length > 0)
                            {
                                DataTable dtBNATrxnIds = drAllTrxnForTheDay.CopyToDataTable().DefaultView.ToTable(true, new string[] { "ej_parsed_bna_transaction_id" });

                                foreach (DataRow drRow in dtBNATrxnIds.Rows)
                                {

                                    StringBuilder builder = new StringBuilder();
                                    DataRow[] dr1 = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"]);
                                    if (dr1.Length > 0)
                                    {
                                        DataTable dtUniqueNoteType = dr1.CopyToDataTable().DefaultView.ToTable(true, new string[] { "note_type" });
                                        foreach (DataRow drUniqueNoteType in dtUniqueNoteType.Rows)
                                        {
                                            DataRow[] temp = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"] + " and note_type=" + drUniqueNoteType["note_type"], "notes_count");
                                            builder.Append(drUniqueNoteType["note_type"].ToString() + "*" + int.Parse(temp[temp.Length - 1]["notes_count"].ToString()) + "=" + int.Parse(drUniqueNoteType["note_type"].ToString()) * int.Parse(temp[temp.Length - 1]["notes_count"].ToString()) + "<br/>");
                                            rej1 += int.Parse(temp[temp.Length - 1]["notes_count"].ToString());
                                        }

                                    }
                                }
                            }



                            newRow["notes_rejected1"] = rej1;

                            drAllTrxnForTheDay = dt.Select("atm_id = " + dr["atm_id"] + " and trxn_datetime='" + drInner["trxn_datetime"] + "' and status = 'Failed' and dispute_status is null");
                            if (drAllTrxnForTheDay.Length > 0)
                            {
                                DataTable dtBNATrxnIds = drAllTrxnForTheDay.CopyToDataTable().DefaultView.ToTable(true, new string[] { "ej_parsed_bna_transaction_id" });

                                foreach (DataRow drRow in dtBNATrxnIds.Rows)
                                {

                                    StringBuilder builder = new StringBuilder();
                                    DataRow[] dr1 = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"]);
                                    if (dr1.Length > 0)
                                    {
                                        DataTable dtUniqueNoteType = dr1.CopyToDataTable().DefaultView.ToTable(true, new string[] { "note_type" });
                                        foreach (DataRow drUniqueNoteType in dtUniqueNoteType.Rows)
                                        {
                                            DataRow[] temp = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"] + " and note_type=" + drUniqueNoteType["note_type"], "notes_count");
                                            builder.Append(drUniqueNoteType["note_type"].ToString() + "*" + int.Parse(temp[temp.Length - 1]["notes_count"].ToString()) + "=" + int.Parse(drUniqueNoteType["note_type"].ToString()) * int.Parse(temp[temp.Length - 1]["notes_count"].ToString()) + "<br/>");
                                            rej2 += int.Parse(temp[temp.Length - 1]["notes_count"].ToString());
                                        }

                                    }
                                }


                            }
                            newRow["notes_rejected2"] = rej2;
                            newRow["total_rejected"] = rej1 + rej2;
                            total = rej1 + rej2 + depositCount;
                            if (total != 0)
                            {
                                newRow["acc_perc"] = Math.Round(((decimal)depositCount / total) * 100, 2);
                                newRow["rej_perc"] = Math.Round((((decimal)rej1 + rej2) / total) * 100, 2);
                            }
                            else
                            {
                                newRow["acc_perc"] = 0;
                                newRow["rej_perc"] = 0;
                            }
                            dtGrid.Rows.Add(newRow);

                        }


                    }
                    ds = new DsPNCNoteDepSummary();
                    ds.Tables[0].Merge(dtGrid);

                }
                else if (reportName == "PNCDepositSummaryForSDMCPM")
                {
                    int reportType = 0;
                    switch (reportName)
                    {
                        case "PNCDepositSummaryForSCPMAndSDM":
                            reportType = 0;
                            break;
                        case "PNCDepositSummaryForSCPM":
                            reportType = 1;
                            break;
                        case "PNCDepositSummaryForSDM":
                            reportType = 2;
                            break;
                    }
                    DataTable dtGrid = new DataTable();
                    dtGrid.Columns.Add("title");
                    dtGrid.Columns.Add("trxn_datetime", typeof(DateTime));
                    dtGrid.Columns.Add("cheques_accepted", typeof(int));
                    dtGrid.Columns.Add("cheques_rejected1", typeof(int));
                    dtGrid.Columns.Add("cheques_rejected2", typeof(int));
                    dtGrid.Columns.Add("total_rejected", typeof(int));
                    dtGrid.Columns.Add("acc_perc", typeof(decimal));
                    dtGrid.Columns.Add("rej_perc", typeof(decimal));

                    //                    SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
                    cmd.CommandTimeout = 0;//500;

                    string SQL = "select atm.atm_id,title,convert(varchar,trxn_datetime,103) trxn_datetime,dispute_status,status from ej_parsed_cpm_transaction left join ej_parsed_cpm_transaction_detail on ej_parsed_cpm_transaction.ej_parsed_cpm_transaction_id = ej_parsed_cpm_transaction_detail.ej_parsed_cpm_transaction_id " +
                                 " inner join atm on ej_parsed_cpm_transaction.atm_id = atm.atm_id  where atm.is_active=1 " + GetFilter();

                    DataTable dt = GetDataTable(SQL);

                    DataTable dtATMs = dt.DefaultView.ToTable(true, new string[] { "atm_id", "title" });
                    DataTable dtATMsTrxnDatetime = dt.DefaultView.ToTable(true, new string[] { "atm_id", "trxn_datetime" });

                    foreach (DataRow dr in dtATMs.Rows)
                    {
                        DataRow[] drTrxnDates = dtATMsTrxnDatetime.Select("atm_id = " + dr["atm_id"]);

                        foreach (DataRow drInner in drTrxnDates)
                        {
                            DataRow[] drBusinessRuleReject = dt.Select("trxn_datetime='" + drInner["trxn_datetime"] + "' and  atm_id = " + dr["atm_id"] + " and dispute_status <>'000' and dispute_status is not null and status = 'Failed'");
                            DataRow[] drNonBusinessRuleReject = dt.Select("trxn_datetime='" + drInner["trxn_datetime"] + "' and atm_id = " + dr["atm_id"] + " and dispute_status is null and status = 'Failed'");
                            DataRow[] drAccepted = dt.Select("trxn_datetime='" + drInner["trxn_datetime"] + "' and atm_id = " + dr["atm_id"] + " and dispute_status ='000' and status = 'Successful'");

                            int totalChecks = drBusinessRuleReject.Length + drNonBusinessRuleReject.Length + drAccepted.Length;
                            DataRow newRow = dtGrid.NewRow();
                            newRow["title"] = dr["title"];
                            newRow["trxn_datetime"] = DateTime.ParseExact(drInner["trxn_datetime"].ToString(), "dd/MM/yyyy", null);
                            newRow["cheques_accepted"] = drAccepted.Length;
                            newRow["cheques_rejected1"] = drBusinessRuleReject.Length;
                            newRow["cheques_rejected2"] = drNonBusinessRuleReject.Length;
                            newRow["total_rejected"] = drBusinessRuleReject.Length + drNonBusinessRuleReject.Length;
                            if (totalChecks != 0)
                            {
                                newRow["acc_perc"] = Math.Round(((decimal)drAccepted.Length / totalChecks) * 100, 2);
                                newRow["rej_perc"] = Math.Round((((decimal)drBusinessRuleReject.Length + drNonBusinessRuleReject.Length) / totalChecks) * 100, 2);
                            }
                            else
                            {
                                newRow["acc_perc"] = 0;
                                newRow["rej_perc"] = 0;
                            }

                            dtGrid.Rows.Add(newRow);

                        }
                        //if (totalChecks > 0)
                        //    Label_AccPerc.Text = Math.Round((decimal)drAccepted.Length / totalChecks * 100).ToString();
                        //else
                        //    Label_AccPerc.Text = "0";


                    }
                    ds = new DsPNCChequeDepSummary();
                    ds.Tables[0].Merge(dtGrid);

                }
                //
                else if (reportName == "PNCTop5IncidentsAnalysisForBNA" || reportName == "PNCTop5IncidentsAnalysisForSDMBNA")
                {
                    ds = new dsPNCIncidentsAnalysis();
                    ds.Tables[0].Merge(GetCashAcceptorDataTable());

                }
                else if (reportName == "PNCTop5IncidentsAnalysisForSDMCPM")
                {

                    int reportType = 0;
                    switch (reportName)
                    {
                        case "PNCTop5IncidentsAnalysisForSCPMAndSDM":
                            reportType = 0;
                            break;
                        case "PNCTop5IncidentsAnalysisForSCPM":
                            reportType = 1;
                            break;
                        case "PNCTop5IncidentsAnalysisForSDM":
                            reportType = 2;
                            break;
                    }

                    ds = new dsPNCIncidentsAnalysis();
                    ds.Tables[0].Merge(GetCheckAcceptorGraph(reportType));
                }

                else if (reportName == "PNCRejectReasonsForBNA" || reportName == "PNCRejectReasonsForSDMBNA")
                {
                    ds = new dsPNCIncidentsAnalysis();
                    ds.Tables[0].Merge(GetNoteRejectReasonsDataTable());

                }
                else if (reportName == "PNCRejectReasonsForCPM")
                {
                    ds = new dsPNCIncidentsAnalysis();
                    ds.Tables[0].Merge(GetCPMRejectCausesDataTable(0));

                }
                else if (reportName == "PNCRejectReasonsForSDM")
                {
                    ds = new dsPNCIncidentsAnalysis();
                    ds.Tables[0].Merge(GetSDMRejectCausesDataTable(0));

                }

                else if (reportName == "PNCRejectReasonsForSDMCPM")
                {


                    int reportType = 0;
                    switch (reportName)
                    {
                        case "PNCRejectReasonsForCPMAndSDM":
                            reportType = 0;
                            break;
                        case "PNCRejectReasonsForSCPM":
                            reportType = 1;
                            break;
                        case "PNCRejectReasonsForSDM":
                            reportType = 2;
                            break;
                    }

                    ds = new dsPNCIncidentsAnalysis();
                    ds.Tables[0].Merge(GetCPMRejectCausesDataTable(reportType));

                }
                else if (reportName == "PNCWeeklyAnalysisForSDM")
                {
                    isWeeklyAnalysis = true;
                    //int yr =  scheduleDate.Year;
                    //int month = scheduleDate.Month;

                    int yr = reportTask.FromDate.Value.Year;
                    int month = reportTask.FromDate.Value.Month;


                    DateTime from = new DateTime(yr, month, 1);
                    //TextBox_FromDate.Text = from.ToString("dd/MM/yyyy");
                    //TextBox_ToDate.Text = from.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy");


                    DateTime fromByUser = from;
                    DateTime toByUser = from.AddMonths(1).AddDays(-1);
                    DateTime temp = new DateTime(toByUser.Year, toByUser.Month, 1);
                    temp = temp.AddMonths(1).AddDays(-1);

                    gFrom = from;
                    gTo = toByUser;

                    if (fromByUser.Day != 1 || toByUser != temp)
                        throw new Exception("Invalid date entered for weekly analysis.From Date should be start date of month and end data should be end data of the same/other month");

                    DataTable dtGrid = new DataTable();
                    dtGrid.Columns.Add("title");
                    dtGrid.Columns.Add("month_year");
                    dtGrid.Columns.Add("acc_perc_week1", typeof(decimal));
                    dtGrid.Columns.Add("acc_perc_week2", typeof(decimal));
                    dtGrid.Columns.Add("acc_perc_week3", typeof(decimal));
                    dtGrid.Columns.Add("acc_perc_week4", typeof(decimal));
                    dtGrid.Columns.Add("rej_perc_week1", typeof(decimal));
                    dtGrid.Columns.Add("rej_perc_week2", typeof(decimal));
                    dtGrid.Columns.Add("rej_perc_week3", typeof(decimal));
                    dtGrid.Columns.Add("rej_perc_week4", typeof(decimal));

                    dtGrid.Columns.Add("items_accepted_week1", typeof(decimal));
                    dtGrid.Columns.Add("items_rejected_week1", typeof(decimal));
                    dtGrid.Columns.Add("items_processed_week1", typeof(decimal));
                    dtGrid.Columns.Add("items_accepted_week2", typeof(decimal));
                    dtGrid.Columns.Add("items_rejected_week2", typeof(decimal));
                    dtGrid.Columns.Add("items_processed_week2", typeof(decimal));
                    dtGrid.Columns.Add("items_accepted_week3", typeof(decimal));
                    dtGrid.Columns.Add("items_rejected_week3", typeof(decimal));
                    dtGrid.Columns.Add("items_processed_week3", typeof(decimal));
                    dtGrid.Columns.Add("items_accepted_week4", typeof(decimal));
                    dtGrid.Columns.Add("items_rejected_week4", typeof(decimal));
                    dtGrid.Columns.Add("items_processed_week4", typeof(decimal));


                    cmd = ConnectionFactory.GetNewCommand(false);
                    List<string> listDateTime = new List<string>();
                    DateTime dtFromDate = from;
                    DateTime dtToDate = from.AddMonths(1).AddDays(-1);
                    DateTime dtTemp = dtFromDate;
                    //listDateTime.Add(dtFromDate);
                    dtFromDate = dtFromDate.AddDays(-1);
                    TimeSpan diff = dtToDate - dtFromDate;
                    //   int weeks = (int)Math.Round(((diff.TotalDays-6) / 7));
                    int weeks = (int)Math.Round((diff.TotalDays / 31 * 4));
                    while (weeks % 4 != 0)
                        weeks++;

                    for (int i = 0; i < weeks; i++)
                    {
                        dtFromDate = dtFromDate.AddDays(1);
                        listDateTime.Add(dtFromDate.ToString("MM/dd/yyyy"));

                        if ((i + 1) % 4 == 0)
                        {
                            dtFromDate = dtFromDate.AddDays(6);//Days till End of month
                            dtTemp = dtTemp.AddMonths(1);
                            dtFromDate = dtTemp.AddDays(-1);
                        }
                        else
                            dtFromDate = dtFromDate.AddDays(6);
                        listDateTime.Add(dtFromDate.ToString("MM/dd/yyyy"));
                    }

                    DataRow newRow = null;
                    cmd.CommandTimeout = 0;// 500;
                    int depositCount = 0;
                    int rej1 = 0;
                    int rej2 = 0;
                    int total = 0;

                    string SQL = @"select atm.atm_id,title, trxn_datetime,seq,account_type,pan,amount_authorized,dispute_status,status,comment,note_type,notes_count,ej_parsed_bna_transaction.ej_parsed_bna_transaction_Id
                                    from ej_parsed_bna_transaction inner join atm on ej_parsed_bna_transaction.atm_id = atm.atm_id
                                    inner join ej_parsed_bna_transaction_detail on  ej_parsed_bna_transaction_detail.ej_parsed_bna_transaction_id = 
                                    ej_parsed_bna_transaction.ej_parsed_bna_transaction_id
                                     where atm.is_active=1 " + GetFilter();


                    //string SQL = "select atm.atm_id,title,convert(varchar,trxn_datetime,103) trxn_datetime,dispute_status,status from ej_parsed_cpm_transaction left join ej_parsed_cpm_transaction_detail on ej_parsed_cpm_transaction.ej_parsed_cpm_transaction_id = ej_parsed_cpm_transaction_detail.ej_parsed_cpm_transaction_id " +
                    //             " inner join atm on ej_parsed_cpm_transaction.atm_id = atm.atm_id  where atm.is_active=1 and trxn_datetime>=convert(datetime,'" + fromDate + "',103)  " +
                    //             " and trxn_datetime<=convert(datetime,'" + toDate + " 23:59:59',103) ";

                    DataTable dt = GetDataTable(SQL);


                    SQL = "select atm.atm_id,title, trxn_datetime,dispute_status,status from ej_parsed_cpm_transaction left join ej_parsed_cpm_transaction_detail on ej_parsed_cpm_transaction.ej_parsed_cpm_transaction_id = ej_parsed_cpm_transaction_detail.ej_parsed_cpm_transaction_id " +
                       " inner join atm on ej_parsed_cpm_transaction.atm_id = atm.atm_id  where atm.is_active=1 " + GetFilter();

                    DataTable dtCPM = GetDataTable(SQL);



                    DataTable dtATMs = dt.DefaultView.ToTable(true, new string[] { "atm_id", "title" });
                    foreach (DataRow dr in dtCPM.Rows)
                    {
                        if (dtATMs.Select("atm_id = " + dr["atm_id"]).Length == 0)
                        {
                            DataRow atmNewRow = dtATMs.NewRow();
                            atmNewRow["atm_id"] = dr["atm_id"];
                            atmNewRow["title"] = dr["title"];
                            dtATMs.Rows.Add(atmNewRow);
                        }
                    }


                    //      DataTable dtATMsTrxnDatetime = dt.DefaultView.ToTable(true, new string[] { "atm_id", "trxn_datetime" });
                    int counter = 0;
                    int counter1 = 0;
                    foreach (DataRow dr in dtATMs.Rows)
                    {
                        counter = 0;
                        for (int j = 0; j < listDateTime.Count; j = j + 2)
                        {

                            if (counter % 4 == 0)
                            {
                                if (newRow != null)
                                    dtGrid.Rows.Add(newRow);
                                newRow = dtGrid.NewRow();
                                newRow["title"] = dr["title"];
                                newRow["month_year"] = DateTime.ParseExact(listDateTime[j], "MM/dd/yyyy", null).ToString("MM-yyyy");
                                counter1 = 0;

                            }
                            depositCount = 0;
                            rej1 = 0;
                            rej2 = 0;
                            counter++;
                            counter1++;
                            string criteria = "trxn_datetime>=#" + listDateTime[j] + "# and trxn_datetime<=#" + listDateTime[j + 1] + " 23:59:59#  and atm_id = " + dr["atm_id"] + " and dispute_status ='000' and status = 'Successful'";

                            //DataRow[] drTrxnDates = dtATMsTrxnDatetime.Select("atm_id = " + dr["atm_id"]);

                            //foreach (DataRow drInner in drTrxnDates)
                            //{
                            //    rej1 = 0;
                            //    rej2 = 0;
                            //    total = 0;
                            //    depositCount = 0;

                            DataRow[] drAllTrxnForTheDay = dt.Select(criteria);
                            //"atm_id = " + dr["atm_id"] + " and trxn_datetime='" + drInner["trxn_datetime"] + "' and status = 'Successful'");
                            if (drAllTrxnForTheDay.Length > 0)
                            {

                                DataTable dtBNATrxnIds = drAllTrxnForTheDay.CopyToDataTable().DefaultView.ToTable(true, new string[] { "ej_parsed_bna_transaction_id" });

                                foreach (DataRow drRow in dtBNATrxnIds.Rows)
                                {

                                    StringBuilder builder = new StringBuilder();
                                    DataRow[] dr1 = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"]);
                                    if (dr1.Length > 0)
                                    {
                                        DataTable dtUniqueNoteType = dr1.CopyToDataTable().DefaultView.ToTable(true, new string[] { "note_type" });
                                        foreach (DataRow drUniqueNoteType in dtUniqueNoteType.Rows)
                                        {
                                            DataRow[] innerTemp = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"] + " and note_type=" + drUniqueNoteType["note_type"], "notes_count");
                                            builder.Append(drUniqueNoteType["note_type"].ToString() + "*" + int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString()) + "=" + int.Parse(drUniqueNoteType["note_type"].ToString()) * int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString()) + "<br/>");
                                            depositCount += int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString());
                                        }

                                    }
                                }
                            }

                            //DataRow newRow = dtGrid.NewRow();
                            //newRow["title"] = dr["title"];
                            //newRow["month_year"] = DateTime.ParseExact(drInner["trxn_datetime"].ToString(), "MM/dd/yyyy", null).ToString("MM-yyyy");
                            ////newRow["notes_accepted"] = depositCount;



                            drAllTrxnForTheDay = dt.Select("atm_id = " + dr["atm_id"] + " and trxn_datetime>=#" + listDateTime[j] + "# and trxn_datetime<=#" + listDateTime[j + 1] + " 23:59:59# and status = 'Failed' and dispute_status is not null");
                            if (drAllTrxnForTheDay.Length > 0)
                            {
                                DataTable dtBNATrxnIds = drAllTrxnForTheDay.CopyToDataTable().DefaultView.ToTable(true, new string[] { "ej_parsed_bna_transaction_id" });

                                foreach (DataRow drRow in dtBNATrxnIds.Rows)
                                {

                                    StringBuilder builder = new StringBuilder();
                                    DataRow[] dr1 = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"]);
                                    if (dr1.Length > 0)
                                    {
                                        DataTable dtUniqueNoteType = dr1.CopyToDataTable().DefaultView.ToTable(true, new string[] { "note_type" });
                                        foreach (DataRow drUniqueNoteType in dtUniqueNoteType.Rows)
                                        {
                                            DataRow[] innerTemp = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"] + " and note_type=" + drUniqueNoteType["note_type"], "notes_count");
                                            builder.Append(drUniqueNoteType["note_type"].ToString() + "*" + int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString()) + "=" + int.Parse(drUniqueNoteType["note_type"].ToString()) * int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString()) + "<br/>");
                                            rej1 += int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString());
                                        }

                                    }
                                }
                            }



                            //newRow["notes_rejected1"] = rej1;

                            drAllTrxnForTheDay = dt.Select("atm_id = " + dr["atm_id"] + " and trxn_datetime>=#" + listDateTime[j] + "# and trxn_datetime<=#" + listDateTime[j + 1] + " 23:59:59# and status = 'Failed' and dispute_status is null");
                            if (drAllTrxnForTheDay.Length > 0)
                            {
                                DataTable dtBNATrxnIds = drAllTrxnForTheDay.CopyToDataTable().DefaultView.ToTable(true, new string[] { "ej_parsed_bna_transaction_id" });

                                foreach (DataRow drRow in dtBNATrxnIds.Rows)
                                {

                                    StringBuilder builder = new StringBuilder();
                                    DataRow[] dr1 = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"]);
                                    if (dr1.Length > 0)
                                    {
                                        DataTable dtUniqueNoteType = dr1.CopyToDataTable().DefaultView.ToTable(true, new string[] { "note_type" });
                                        foreach (DataRow drUniqueNoteType in dtUniqueNoteType.Rows)
                                        {
                                            DataRow[] innerTemp = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"] + " and note_type=" + drUniqueNoteType["note_type"], "notes_count");
                                            builder.Append(drUniqueNoteType["note_type"].ToString() + "*" + int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString()) + "=" + int.Parse(drUniqueNoteType["note_type"].ToString()) * int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString()) + "<br/>");
                                            rej2 += int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString());
                                        }

                                    }
                                }


                            }


                            ////
                            criteria = "trxn_datetime>=#" + listDateTime[j] + "# and trxn_datetime<=#" + listDateTime[j + 1] + " 23:59:59#  and atm_id = " + dr["atm_id"] + " and dispute_status ='000' and status = 'Successful'";

                            DataRow[] drAccepted = dtCPM.Select(criteria);
                            DataRow[] drRejected = dtCPM.Select("trxn_datetime>=#" + listDateTime[j] + "# and trxn_datetime<=#" + listDateTime[j + 1] + " 23:59:59#  and atm_id = " + dr["atm_id"] + " and status = 'Failed'");


                            //int totalChecks = drRejected.Length + drAccepted.Length;

                            //if (totalChecks != 0)
                            //{
                            //    newRow["acc_perc_week" + counter1] = Math.Round(((decimal)drAccepted.Length / totalChecks) * 100, 2);
                            //    newRow["rej_perc_week" + counter1] = Math.Round((((decimal)drRejected.Length) / totalChecks) * 100, 2);
                            //}
                            //else
                            //{
                            //    newRow["acc_perc_week" + counter1] = 0;
                            //    newRow["rej_perc_week" + counter1] = 0;
                            //}


                            total = rej1 + rej2 + depositCount + drRejected.Length + drAccepted.Length;

                            if (total != 0)
                            {
                                newRow["acc_perc_week" + counter1] = Math.Round((((decimal)depositCount + drAccepted.Length) / total) * 100, 2);
                                newRow["rej_perc_week" + counter1] = Math.Round(((((decimal)rej1 + rej2 + drRejected.Length)) / total) * 100, 2);

                                newRow["items_accepted_week" + counter1] = depositCount + drAccepted.Length;
                                newRow["items_rejected_week" + counter1] = rej1 + rej2 + drRejected.Length;
                                newRow["items_processed_week" + counter1] = total;

                                totalDeposits += depositCount + drAccepted.Length;
                                totalRejects += rej1 + rej2 + drRejected.Length;

                            }
                            else
                            {
                                newRow["acc_perc_week" + counter1] = 0;
                                newRow["rej_perc_week" + counter1] = 0;
                                newRow["items_accepted_week" + counter1] = 0;
                                newRow["items_rejected_week" + counter1] = 0;
                                newRow["items_processed_week" + counter1] = 0;

                            }




                            //}

                        }
                        dtGrid.Rows.Add(newRow);
                        newRow = null;
                        counter1 = 0;
                        depositCount = 0;
                        rej1 = 0;
                        rej2 = 0;

                    }
                    ds = new DsPNCNoteDepSummary();
                    ds.Tables[0].Merge(dtGrid);

                }

                else if (reportName == "PNCWeeklyAnalysisForBNA" || reportName == "PNCWeeklyAnalysisForSDMBNA")
                {
                    isWeeklyAnalysis = true;
                    //int yr = scheduleDate.Year;
                    //int month = scheduleDate.Month;
                    //
                    int yr = reportTask.FromDate.Value.Year;
                    int month = reportTask.FromDate.Value.Month;

                    DateTime from = new DateTime(yr, month, 1);
                    //TextBox_FromDate.Text = from.ToString("dd/MM/yyyy");
                    //TextBox_ToDate.Text = from.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy");


                    DateTime fromByUser = from;
                    DateTime toByUser = from.AddMonths(1).AddDays(-1);
                    DateTime temp = new DateTime(toByUser.Year, toByUser.Month, 1);
                    temp = temp.AddMonths(1).AddDays(-1);

                    gFrom = from;
                    gTo = toByUser;

                    if (fromByUser.Day != 1 || toByUser != temp)
                        throw new Exception("Invalid date entered for weekly analysis.From Date should be start date of month and end data should be end data of the same/other month");

                    DataTable dtGrid = new DataTable();
                    dtGrid.Columns.Add("title");
                    dtGrid.Columns.Add("month_year");
                    dtGrid.Columns.Add("acc_perc_week1", typeof(decimal));
                    dtGrid.Columns.Add("acc_perc_week2", typeof(decimal));
                    dtGrid.Columns.Add("acc_perc_week3", typeof(decimal));
                    dtGrid.Columns.Add("acc_perc_week4", typeof(decimal));
                    dtGrid.Columns.Add("rej_perc_week1", typeof(decimal));
                    dtGrid.Columns.Add("rej_perc_week2", typeof(decimal));
                    dtGrid.Columns.Add("rej_perc_week3", typeof(decimal));
                    dtGrid.Columns.Add("rej_perc_week4", typeof(decimal));
                    dtGrid.Columns.Add("items_accepted_week1", typeof(decimal));
                    dtGrid.Columns.Add("items_rejected_week1", typeof(decimal));
                    dtGrid.Columns.Add("items_processed_week1", typeof(decimal));
                    dtGrid.Columns.Add("items_accepted_week2", typeof(decimal));
                    dtGrid.Columns.Add("items_rejected_week2", typeof(decimal));
                    dtGrid.Columns.Add("items_processed_week2", typeof(decimal));
                    dtGrid.Columns.Add("items_accepted_week3", typeof(decimal));
                    dtGrid.Columns.Add("items_rejected_week3", typeof(decimal));
                    dtGrid.Columns.Add("items_processed_week3", typeof(decimal));
                    dtGrid.Columns.Add("items_accepted_week4", typeof(decimal));
                    dtGrid.Columns.Add("items_rejected_week4", typeof(decimal));
                    dtGrid.Columns.Add("items_processed_week4", typeof(decimal));


                    cmd = ConnectionFactory.GetNewCommand(false);
                    List<string> listDateTime = new List<string>();
                    DateTime dtFromDate = from;
                    DateTime dtToDate = from.AddMonths(1).AddDays(-1);
                    DateTime dtTemp = dtFromDate;
                    //listDateTime.Add(dtFromDate);
                    dtFromDate = dtFromDate.AddDays(-1);
                    TimeSpan diff = dtToDate - dtFromDate;
                    //   int weeks = (int)Math.Round(((diff.TotalDays-6) / 7));
                    int weeks = (int)Math.Round((diff.TotalDays / 31 * 4));
                    while (weeks % 4 != 0)
                        weeks++;

                    for (int i = 0; i < weeks; i++)
                    {
                        dtFromDate = dtFromDate.AddDays(1);
                        listDateTime.Add(dtFromDate.ToString("MM/dd/yyyy"));

                        if ((i + 1) % 4 == 0)
                        {
                            dtFromDate = dtFromDate.AddDays(6);//Days till End of month
                            dtTemp = dtTemp.AddMonths(1);
                            dtFromDate = dtTemp.AddDays(-1);
                        }
                        else
                            dtFromDate = dtFromDate.AddDays(6);
                        listDateTime.Add(dtFromDate.ToString("MM/dd/yyyy"));
                    }

                    DataRow newRow = null;
                    cmd.CommandTimeout = 0;// 500;
                    int depositCount = 0;
                    int rej1 = 0;
                    int rej2 = 0;
                    int total = 0;

                    string SQL = @"select atm.atm_id,title, trxn_datetime,seq,account_type,pan,amount_authorized,dispute_status,status,comment,note_type,notes_count,ej_parsed_bna_transaction.ej_parsed_bna_transaction_Id
                                    from ej_parsed_bna_transaction inner join atm on ej_parsed_bna_transaction.atm_id = atm.atm_id
                                    inner join ej_parsed_bna_transaction_detail on  ej_parsed_bna_transaction_detail.ej_parsed_bna_transaction_id = 
                                    ej_parsed_bna_transaction.ej_parsed_bna_transaction_id
                                     where atm.is_active=1 " + GetFilter();


                    //string SQL = "select atm.atm_id,title,convert(varchar,trxn_datetime,103) trxn_datetime,dispute_status,status from ej_parsed_cpm_transaction left join ej_parsed_cpm_transaction_detail on ej_parsed_cpm_transaction.ej_parsed_cpm_transaction_id = ej_parsed_cpm_transaction_detail.ej_parsed_cpm_transaction_id " +
                    //             " inner join atm on ej_parsed_cpm_transaction.atm_id = atm.atm_id  where atm.is_active=1 and trxn_datetime>=convert(datetime,'" + fromDate + "',103)  " +
                    //             " and trxn_datetime<=convert(datetime,'" + toDate + " 23:59:59',103) ";

                    DataTable dt = GetDataTable(SQL);

                    DataTable dtATMs = dt.DefaultView.ToTable(true, new string[] { "atm_id", "title" });
                    //      DataTable dtATMsTrxnDatetime = dt.DefaultView.ToTable(true, new string[] { "atm_id", "trxn_datetime" });
                    int counter = 0;
                    int counter1 = 0;
                    foreach (DataRow dr in dtATMs.Rows)
                    {
                        counter = 0;
                        for (int j = 0; j < listDateTime.Count; j = j + 2)
                        {

                            if (counter % 4 == 0)
                            {
                                if (newRow != null)
                                    dtGrid.Rows.Add(newRow);
                                newRow = dtGrid.NewRow();
                                newRow["title"] = dr["title"];
                                newRow["month_year"] = DateTime.ParseExact(listDateTime[j], "MM/dd/yyyy", null).ToString("MM-yyyy");
                                counter1 = 0;

                            }
                            depositCount = 0;
                            rej1 = 0;
                            rej2 = 0;
                            counter++;
                            counter1++;
                            string criteria = "trxn_datetime>=#" + listDateTime[j] + "# and trxn_datetime<=#" + listDateTime[j + 1] + " 23:59:59#  and atm_id = " + dr["atm_id"] + " and dispute_status ='000' and status = 'Successful'";

                            //DataRow[] drTrxnDates = dtATMsTrxnDatetime.Select("atm_id = " + dr["atm_id"]);

                            //foreach (DataRow drInner in drTrxnDates)
                            //{
                            //    rej1 = 0;
                            //    rej2 = 0;
                            //    total = 0;
                            //    depositCount = 0;

                            DataRow[] drAllTrxnForTheDay = dt.Select(criteria);
                            //"atm_id = " + dr["atm_id"] + " and trxn_datetime='" + drInner["trxn_datetime"] + "' and status = 'Successful'");
                            if (drAllTrxnForTheDay.Length > 0)
                            {

                                DataTable dtBNATrxnIds = drAllTrxnForTheDay.CopyToDataTable().DefaultView.ToTable(true, new string[] { "ej_parsed_bna_transaction_id" });

                                foreach (DataRow drRow in dtBNATrxnIds.Rows)
                                {

                                    StringBuilder builder = new StringBuilder();
                                    DataRow[] dr1 = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"]);
                                    if (dr1.Length > 0)
                                    {
                                        DataTable dtUniqueNoteType = dr1.CopyToDataTable().DefaultView.ToTable(true, new string[] { "note_type" });
                                        foreach (DataRow drUniqueNoteType in dtUniqueNoteType.Rows)
                                        {
                                            DataRow[] innerTemp = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"] + " and note_type=" + drUniqueNoteType["note_type"], "notes_count");
                                            builder.Append(drUniqueNoteType["note_type"].ToString() + "*" + int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString()) + "=" + int.Parse(drUniqueNoteType["note_type"].ToString()) * int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString()) + "<br/>");
                                            depositCount += int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString());
                                        }

                                    }
                                }
                            }

                            //DataRow newRow = dtGrid.NewRow();
                            //newRow["title"] = dr["title"];
                            //newRow["month_year"] = DateTime.ParseExact(drInner["trxn_datetime"].ToString(), "MM/dd/yyyy", null).ToString("MM-yyyy");
                            ////newRow["notes_accepted"] = depositCount;



                            drAllTrxnForTheDay = dt.Select("atm_id = " + dr["atm_id"] + " and trxn_datetime>=#" + listDateTime[j] + "# and trxn_datetime<=#" + listDateTime[j + 1] + " 23:59:59# and status = 'Failed' and dispute_status is not null");
                            if (drAllTrxnForTheDay.Length > 0)
                            {
                                DataTable dtBNATrxnIds = drAllTrxnForTheDay.CopyToDataTable().DefaultView.ToTable(true, new string[] { "ej_parsed_bna_transaction_id" });

                                foreach (DataRow drRow in dtBNATrxnIds.Rows)
                                {

                                    StringBuilder builder = new StringBuilder();
                                    DataRow[] dr1 = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"]);
                                    if (dr1.Length > 0)
                                    {
                                        DataTable dtUniqueNoteType = dr1.CopyToDataTable().DefaultView.ToTable(true, new string[] { "note_type" });
                                        foreach (DataRow drUniqueNoteType in dtUniqueNoteType.Rows)
                                        {
                                            DataRow[] innerTemp = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"] + " and note_type=" + drUniqueNoteType["note_type"], "notes_count");
                                            builder.Append(drUniqueNoteType["note_type"].ToString() + "*" + int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString()) + "=" + int.Parse(drUniqueNoteType["note_type"].ToString()) * int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString()) + "<br/>");
                                            rej1 += int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString());
                                        }

                                    }
                                }
                            }



                            //newRow["notes_rejected1"] = rej1;

                            drAllTrxnForTheDay = dt.Select("atm_id = " + dr["atm_id"] + " and trxn_datetime>=#" + listDateTime[j] + "# and trxn_datetime<=#" + listDateTime[j + 1] + " 23:59:59# and status = 'Failed' and dispute_status is null");
                            if (drAllTrxnForTheDay.Length > 0)
                            {
                                DataTable dtBNATrxnIds = drAllTrxnForTheDay.CopyToDataTable().DefaultView.ToTable(true, new string[] { "ej_parsed_bna_transaction_id" });

                                foreach (DataRow drRow in dtBNATrxnIds.Rows)
                                {

                                    StringBuilder builder = new StringBuilder();
                                    DataRow[] dr1 = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"]);
                                    if (dr1.Length > 0)
                                    {
                                        DataTable dtUniqueNoteType = dr1.CopyToDataTable().DefaultView.ToTable(true, new string[] { "note_type" });
                                        foreach (DataRow drUniqueNoteType in dtUniqueNoteType.Rows)
                                        {
                                            DataRow[] innerTemp = dt.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"] + " and note_type=" + drUniqueNoteType["note_type"], "notes_count");
                                            builder.Append(drUniqueNoteType["note_type"].ToString() + "*" + int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString()) + "=" + int.Parse(drUniqueNoteType["note_type"].ToString()) * int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString()) + "<br/>");
                                            rej2 += int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString());
                                        }

                                    }
                                }


                            }
                            // newRow["notes_rejected2"] = rej2;
                            //newRow["total_rejected"] = rej1 + rej2;
                            total = rej1 + rej2 + depositCount;
                            if (total != 0)
                            {
                                newRow["acc_perc_week" + counter1] = Math.Round(((decimal)depositCount / total) * 100, 2);
                                newRow["rej_perc_week" + counter1] = Math.Round((((decimal)rej1 + rej2) / total) * 100, 2);
                                newRow["items_accepted_week" + counter1] = depositCount;
                                newRow["items_rejected_week" + counter1] = rej1 + rej2;
                                newRow["items_processed_week" + counter1] = total;

                                //newRow["acc_perc_week" + counter1] = ((decimal)depositCount / total) * 100;
                                //newRow["rej_perc_week" + counter1] = (((decimal)rej1 + rej2) / total) * 100;
                                totalDeposits += depositCount;
                                totalRejects += rej1 + rej2;
                            }
                            else
                            {
                                newRow["acc_perc_week" + counter1] = 0;
                                newRow["rej_perc_week" + counter1] = 0;
                                newRow["items_accepted_week" + counter1] = 0;
                                newRow["items_rejected_week" + counter1] = 0;
                                newRow["items_processed_week" + counter1] = 0;
                            }




                            //}

                        }
                        dtGrid.Rows.Add(newRow);
                        newRow = null;
                        counter1 = 0;
                        depositCount = 0;
                        rej1 = 0;
                        rej2 = 0;

                    }
                    ds = new DsPNCNoteDepSummary();
                    ds.Tables[0].Merge(dtGrid);

                }
                else if (reportName == "PNCWeeklyAnalysisForSDMCPM" || reportName == "PNCWeeklyAnalysisForCPM")
                {
                    isWeeklyAnalysis = true;
                    //int reportType = 0;
                    //switch (reportName)
                    //{
                    //    case "PNCWeeklyAnalysisForCPMAndSDM":
                    //        reportType = 0;
                    //        break;
                    //    case "PNCWeeklyAnalysisForSCPM":
                    //        reportType = 1;
                    //        break;
                    //    case "PNCWeeklyAnalysisForSDM":
                    //        reportType = 2;
                    //        break;
                    //}


                    //isWeeklyAnalysis = true;
                    //int yr = scheduleDate.Year;
                    //int month = scheduleDate.Month;
                    int yr = reportTask.FromDate.Value.Year;
                    int month = reportTask.FromDate.Value.Month;

                    DateTime from = new DateTime(yr, month, 1);
                    //TextBox_FromDate.Text = from.ToString("dd/MM/yyyy");
                    //TextBox_ToDate.Text = from.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy");


                    DateTime fromByUser = from;
                    DateTime toByUser = from.AddMonths(1).AddDays(-1);
                    DateTime temp = new DateTime(toByUser.Year, toByUser.Month, 1);
                    temp = temp.AddMonths(1).AddDays(-1);

                    gFrom = from;
                    gTo = toByUser;

                    if (fromByUser.Day != 1 || toByUser != temp)
                        throw new Exception("Invalid date entered for weekly analysis.From Date should be start date of month and end data should be end data of the same/other month");

                    DataTable dtGrid = new DataTable();
                    dtGrid.Columns.Add("title");
                    dtGrid.Columns.Add("month_year");
                    dtGrid.Columns.Add("acc_perc_week1", typeof(decimal));
                    dtGrid.Columns.Add("acc_perc_week2", typeof(decimal));
                    dtGrid.Columns.Add("acc_perc_week3", typeof(decimal));
                    dtGrid.Columns.Add("acc_perc_week4", typeof(decimal));
                    dtGrid.Columns.Add("rej_perc_week1", typeof(decimal));
                    dtGrid.Columns.Add("rej_perc_week2", typeof(decimal));
                    dtGrid.Columns.Add("rej_perc_week3", typeof(decimal));
                    dtGrid.Columns.Add("rej_perc_week4", typeof(decimal));

                    dtGrid.Columns.Add("items_accepted_week1", typeof(decimal));
                    dtGrid.Columns.Add("items_rejected_week1", typeof(decimal));
                    dtGrid.Columns.Add("items_processed_week1", typeof(decimal));
                    dtGrid.Columns.Add("items_accepted_week2", typeof(decimal));
                    dtGrid.Columns.Add("items_rejected_week2", typeof(decimal));
                    dtGrid.Columns.Add("items_processed_week2", typeof(decimal));
                    dtGrid.Columns.Add("items_accepted_week3", typeof(decimal));
                    dtGrid.Columns.Add("items_rejected_week3", typeof(decimal));
                    dtGrid.Columns.Add("items_processed_week3", typeof(decimal));
                    dtGrid.Columns.Add("items_accepted_week4", typeof(decimal));
                    dtGrid.Columns.Add("items_rejected_week4", typeof(decimal));
                    dtGrid.Columns.Add("items_processed_week4", typeof(decimal));

                    cmd = ConnectionFactory.GetNewCommand(false);
                    List<string> listDateTime = new List<string>();
                    DateTime dtFromDate = from;
                    DateTime dtToDate = from.AddMonths(1).AddDays(-1);
                    DateTime dtTemp = dtFromDate;
                    //listDateTime.Add(dtFromDate);
                    dtFromDate = dtFromDate.AddDays(-1);
                    TimeSpan diff = dtToDate - dtFromDate;
                    //   int weeks = (int)Math.Round(((diff.TotalDays-6) / 7));
                    int weeks = (int)Math.Round((diff.TotalDays / 31 * 4));
                    while (weeks % 4 != 0)
                        weeks++;

                    for (int i = 0; i < weeks; i++)
                    {
                        dtFromDate = dtFromDate.AddDays(1);
                        listDateTime.Add(dtFromDate.ToString("MM/dd/yyyy"));

                        if ((i + 1) % 4 == 0)
                        {
                            dtFromDate = dtFromDate.AddDays(6);//Days till End of month
                            dtTemp = dtTemp.AddMonths(1);
                            dtFromDate = dtTemp.AddDays(-1);
                        }
                        else
                            dtFromDate = dtFromDate.AddDays(6);
                        listDateTime.Add(dtFromDate.ToString("MM/dd/yyyy"));
                    }

                    DataRow newRow = null;
                    cmd.CommandTimeout = 0;//500;

                    string SQL = "select atm.atm_id,title, trxn_datetime,dispute_status,status from ej_parsed_cpm_transaction left join ej_parsed_cpm_transaction_detail on ej_parsed_cpm_transaction.ej_parsed_cpm_transaction_id = ej_parsed_cpm_transaction_detail.ej_parsed_cpm_transaction_id " +
                                 " inner join atm on ej_parsed_cpm_transaction.atm_id = atm.atm_id  where atm.is_active=1 " + GetFilter();

                    DataTable dt = GetDataTable(SQL);

                    DataTable dtATMs = dt.DefaultView.ToTable(true, new string[] { "atm_id", "title" });
                    int counter = 0;
                    int counter1 = 0;
                    foreach (DataRow dr in dtATMs.Rows)
                    {
                        counter = 0;
                        for (int j = 0; j < listDateTime.Count; j = j + 2)
                        {

                            if (counter % 4 == 0)
                            {
                                if (newRow != null)
                                    dtGrid.Rows.Add(newRow);
                                newRow = dtGrid.NewRow();
                                newRow["title"] = dr["title"];
                                newRow["month_year"] = DateTime.ParseExact(listDateTime[j], "MM/dd/yyyy", null).ToString("MM-yyyy");
                                counter1 = 0;

                            }
                            counter++;
                            counter1++;
                            string criteria = "trxn_datetime>=#" + listDateTime[j] + "# and trxn_datetime<=#" + listDateTime[j + 1] + " 23:59:59#  and atm_id = " + dr["atm_id"] + " and dispute_status ='000' and status = 'Successful'";

                            DataRow[] drAccepted = dt.Select(criteria);
                            DataRow[] drRejected = dt.Select("trxn_datetime>=#" + listDateTime[j] + "# and trxn_datetime<=#" + listDateTime[j + 1] + " 23:59:59#  and atm_id = " + dr["atm_id"] + " and status = 'Failed'");


                            int totalChecks = drRejected.Length + drAccepted.Length;
                            if (totalChecks != 0)
                            {
                                newRow["acc_perc_week" + counter1] = Math.Round(((decimal)drAccepted.Length / totalChecks) * 100, 2);
                                newRow["rej_perc_week" + counter1] = Math.Round((((decimal)drRejected.Length) / totalChecks) * 100, 2);

                                newRow["items_accepted_week" + counter1] = drAccepted.Length;
                                newRow["items_rejected_week" + counter1] = drRejected.Length;
                                newRow["items_processed_week" + counter1] = totalChecks;

                                totalDeposits += drAccepted.Length;
                                totalRejects += drRejected.Length;

                            }
                            else
                            {
                                newRow["acc_perc_week" + counter1] = 0;
                                newRow["rej_perc_week" + counter1] = 0;

                                newRow["items_accepted_week" + counter1] = 0;
                                newRow["items_rejected_week" + counter1] = 0;
                                newRow["items_processed_week" + counter1] = 0;

                            }

                        }
                        dtGrid.Rows.Add(newRow);
                        newRow = null;
                        counter1 = 0;

                        //if (totalChecks > 0)
                        //    Label_AccPerc.Text = Math.Round((decimal)drAccepted.Length / totalChecks * 100).ToString();
                        //else
                        //    Label_AccPerc.Text = "0";


                    }
                    ds = new dsPNCNotesDepWeeklyAnalysis();
                    ds.Tables[0].Merge(dtGrid);

                }
                //
                else if (reportName == "PNCDepositDetailForBNA" || reportName == "PNCDepositDetailForSDMBNA")
                {

                    int depositCount = 0;
                    DataTable dtGrid = new DataTable();
                    dtGrid.Columns.Add("title");
                    dtGrid.Columns.Add("trxn_datetime", typeof(DateTime));
                    dtGrid.Columns.Add("tsn");
                    dtGrid.Columns.Add("account_type");
                    dtGrid.Columns.Add("pan");
                    dtGrid.Columns.Add("amount_authorized", typeof(decimal));
                    dtGrid.Columns.Add("dispute_status");
                    dtGrid.Columns.Add("status");
                    dtGrid.Columns.Add("comment");
                    dtGrid.Columns.Add("detail");
                    dtGrid.Columns.Add("deposit_count", typeof(int));




                    cmd.CommandTimeout = 0;// 500;

                    //                cmd.CommandText = @"select title,trxn_datetime,seq,account_type,pan,amount_authorized,dispute_status,status,comment
                    //                                    from ej_parsed_bna_transaction inner join atm 
                    //                                    on ej_parsed_bna_transaction.atm_id = atm.atm_id where atm.is_active=1 
                    //                                    and  atm.atm_id in (" + Session[SessionVars.SelectedATMs.ToString()] + ") " + GetFilter()
                    //                                     + " order by " + ViewState["orderby"];


                    cmd.CommandText = @"select title,trxn_datetime,seq,account_type,pan,amount_authorized,dispute_status,status,comment,note_type,notes_count,ej_parsed_bna_transaction.ej_parsed_bna_transaction_Id
                                    from ej_parsed_bna_transaction inner join atm on ej_parsed_bna_transaction.atm_id = atm.atm_id
                                    inner join ej_parsed_bna_transaction_detail on  ej_parsed_bna_transaction_detail.ej_parsed_bna_transaction_id = 
                                    ej_parsed_bna_transaction.ej_parsed_bna_transaction_id
                                     where atm.is_active=1 " + GetFilter();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dtTrxn = new DataTable();
                    adapter.Fill(dtTrxn);

                    //Bind Comment Combo
                    //DropDownList_Comment.Items.Clear();
                    //DropDownList_Comment.Items.Add("Any");
                    //DataTable comments = dtTrxn.DefaultView.ToTable(true, new string[] { "comment" });
                    ////DataRow[] dataRow = dtTrxn.Select("comment<>''");
                    //foreach (DataRow dr in comments.Rows)
                    //{
                    //    if (dr["comment"].ToString().Length > 0)
                    //        DropDownList_Comment.Items.Add(dr["comment"].ToString());
                    //}
                    //


                    DataTable dtBNATrxnIds = dtTrxn.DefaultView.ToTable(true, new string[] { "ej_parsed_bna_transaction_id" });
                    foreach (DataRow drRow in dtBNATrxnIds.Rows)
                    {
                        depositCount = 0;
                        StringBuilder builder = new StringBuilder();
                        DataRow[] dr = dtTrxn.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"]);
                        if (dr.Length > 0)
                        {
                            DataTable dtUniqueNoteType = dr.CopyToDataTable().DefaultView.ToTable(true, new string[] { "note_type" });
                            foreach (DataRow drUniqueNoteType in dtUniqueNoteType.Rows)
                            {
                                DataRow[] temp = dtTrxn.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"] + " and note_type=" + drUniqueNoteType["note_type"], "notes_count");
                                builder.Append(drUniqueNoteType["note_type"].ToString() + "*" + int.Parse(temp[temp.Length - 1]["notes_count"].ToString()) + "=" + int.Parse(drUniqueNoteType["note_type"].ToString()) * int.Parse(temp[temp.Length - 1]["notes_count"].ToString()) + " ");
                                depositCount += int.Parse(temp[temp.Length - 1]["notes_count"].ToString());
                            }

                        }
                        DataRow drNewRow = dtGrid.NewRow();
                        drNewRow["title"] = dr[0]["title"];
                        drNewRow["trxn_datetime"] = dr[0]["trxn_datetime"];
                        drNewRow["tsn"] = dr[0]["seq"];
                        drNewRow["account_type"] = dr[0]["account_type"];
                        drNewRow["pan"] = dr[0]["pan"];
                        drNewRow["amount_authorized"] = dr[0]["amount_authorized"];
                        drNewRow["dispute_status"] = dr[0]["dispute_status"];
                        drNewRow["status"] = dr[0]["status"];
                        drNewRow["comment"] = dr[0]["comment"];
                        drNewRow["deposit_count"] = depositCount;
                        drNewRow["detail"] = builder.ToString();

                        dtGrid.Rows.Add(drNewRow);

                    }







                    ds = new dsPNCNoteDepDetail();
                    ds.Tables[0].Merge(dtGrid);


                }
                else if (reportName == "PNCDepositDetailForSDMCPM")
                {
                    int reportType = 0;
                    switch (reportName)
                    {
                        case "PNCDepositDetailForCPMAndSDM":
                            reportType = 0;
                            break;
                        case "PNCDepositDetailForSCPM":
                            reportType = 1;
                            break;
                        case "PNCDepositDetailForSDM":
                            reportType = 2;
                            break;
                    }

                    int depositCount = 0;
                    DataTable dtGrid = new DataTable();
                    dtGrid.Columns.Add("title");
                    dtGrid.Columns.Add("trxn_datetime", typeof(DateTime));
                    dtGrid.Columns.Add("tsn");
                    dtGrid.Columns.Add("account_type");
                    dtGrid.Columns.Add("pan");
                    dtGrid.Columns.Add("deposit_amount");
                    dtGrid.Columns.Add("result");
                    dtGrid.Columns.Add("dispute_status");
                    dtGrid.Columns.Add("status");
                    dtGrid.Columns.Add("comment");
                    dtGrid.Columns.Add("amount_authorized", typeof(decimal));
                    dtGrid.Columns.Add("detail");
                    dtGrid.Columns.Add("deposit_count", typeof(int));




                    cmd.CommandTimeout = 0;// 500;

                    cmd.CommandText = @"select title,trxn_datetime,seq,account_type,pan,deposit_amount,result,dispute_status,status,comment,check_amount,ej_parsed_cpm_transaction_detail.ej_parsed_cpm_transaction_id 
                                    from ej_parsed_cpm_transaction inner join atm 
                                    on ej_parsed_cpm_transaction.atm_id = atm.atm_id
                                    inner join ej_parsed_cpm_transaction_detail on ej_parsed_cpm_transaction_detail.ej_parsed_cpm_transaction_id = 
                                    ej_parsed_cpm_transaction.ej_parsed_cpm_transaction_id 
                                    where atm.is_active=1 " + GetFilter();


                    //                cmd.CommandText = @"select title,trxn_datetime,seq,account_type,pan,deposit_amount,result,dispute_status,status,comment
                    //                                    from ej_parsed_cpm_transaction inner join atm 
                    //                                    on ej_parsed_cpm_transaction.atm_id = atm.atm_id where atm.is_active=1 
                    //                                    and atm.atm_id in (" + Session[SessionVars.SelectedATMs.ToString()] + ") " + GetFilter()
                    //                + " order by " + ViewState["orderby"];

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dtTrxn = new DataTable();
                    adapter.Fill(dtTrxn);

                    //Bind Comment Combo
                    //DropDownList_Comment.Items.Clear();
                    //DropDownList_Comment.Items.Add("Any");
                    //DataTable comments = dtTrxn.DefaultView.ToTable(true, new string[] { "comment" });
                    ////DataRow[] dataRow = dtTrxn.Select("comment<>''");
                    //foreach (DataRow dr in comments.Rows)
                    //{
                    //    if (dr["comment"].ToString().Length>0)
                    //    DropDownList_Comment.Items.Add(dr["comment"].ToString());
                    //}
                    //
                    DataTable dtCPMTrxnIds = dtTrxn.DefaultView.ToTable(true, new string[] { "ej_parsed_cpm_transaction_id" });
                    foreach (DataRow drRow in dtCPMTrxnIds.Rows)
                    {
                        depositCount = 0;
                        StringBuilder builder = new StringBuilder();
                        DataRow[] dr = dtTrxn.Select("ej_parsed_cpm_transaction_id=" + drRow["ej_parsed_cpm_transaction_id"]);
                        if (dr.Length > 0)
                        {
                            //    DataTable dtUniqueNoteType = dr.CopyToDataTable().DefaultView.ToTable(true, new string[] { "note_type" });
                            foreach (DataRow drDepositedCheque in dr)
                            {
                                //DataRow[] temp = dtTrxn.Select("ej_parsed_bna_transaction_id=" + drRow["ej_parsed_bna_transaction_id"] + " and note_type=" + drUniqueNoteType["note_type"]);
                                builder.Append(drDepositedCheque["check_amount"].ToString() + "    ");
                                depositCount++;
                            }

                        }
                        DataRow drNewRow = dtGrid.NewRow();
                        drNewRow["title"] = dr[0]["title"];
                        drNewRow["trxn_datetime"] = dr[0]["trxn_datetime"];
                        drNewRow["tsn"] = dr[0]["seq"];
                        drNewRow["account_type"] = dr[0]["account_type"];
                        drNewRow["pan"] = dr[0]["pan"];
                        drNewRow["deposit_amount"] = dr[0]["deposit_amount"];
                        drNewRow["result"] = dr[0]["result"];
                        drNewRow["dispute_status"] = dr[0]["dispute_status"];
                        drNewRow["status"] = dr[0]["status"];
                        drNewRow["comment"] = dr[0]["comment"];
                        drNewRow["detail"] = builder.ToString();
                        drNewRow["amount_authorized"] = dr[0]["deposit_amount"];
                        drNewRow["deposit_count"] = depositCount;

                        dtGrid.Rows.Add(drNewRow);

                    }


                    ds = new DsPNCChequeDepSummary();
                    ds.Tables[0].Merge(dtGrid);

                }
                ///
                else if (reportName == "PNCMeanTimeToFailureAnalysisForBNA" || reportName == "PNCMeanTimeToFailureAnalysisForSDMBNA")
                {
                    DataTable dtGrid = new DataTable();
                    dtGrid.Columns.Add("title");
                    dtGrid.Columns.Add("trxn_datetime", typeof(DateTime));
                    dtGrid.Columns.Add("counter", typeof(int));
                    dtGrid.Columns.Add("type");
                    cmd = ConnectionFactory.GetNewCommand(false);

                    List<int> parsedBNATransactions = new List<int>();
                    // int count = 0;
                    int successfulChqDeposit = 0;
                    int id = 0;

                    string SQL = "select * from ej_parsed_bna_transaction left join ej_parsed_bna_transaction_detail on ej_parsed_bna_transaction.ej_parsed_bna_transaction_id = ej_parsed_bna_transaction_detail.ej_parsed_bna_transaction_id " +
                         " inner join atm on atm.atm_id = ej_parsed_bna_transaction.atm_id " +
                        " where atm.is_active=1 " + GetFilter() + "  order by trxn_datetime ";
                    DataTable dt = GetDataTable(SQL);
                    LogableTask.LogMonoActivityTask("genMeanTime", MethodBase.GetCurrentMethod(), TraceLevel.Info, "sql result retrieved.");

                    DataTable dtATMs = dt.DefaultView.ToTable(true, new string[] { "atm_id", "title" });
                    LogableTask.LogMonoActivityTask("genMeanTime", MethodBase.GetCurrentMethod(), TraceLevel.Info, "unique ATMs retrieved.");

                    DataTable dtTrxns = dt.DefaultView.ToTable(true, new string[] { "atm_id", "trxn_datetime" });
                    LogableTask.LogMonoActivityTask("genMeanTime", MethodBase.GetCurrentMethod(), TraceLevel.Info, "unique ATMs trxn retrieved.");

                    foreach (DataRow drATM in dtATMs.Rows)
                    {
                        for (int i = 0; i < dtTrxns.Rows.Count; i++)
                        {
                            //DataRow[] drArray = dt.Select(
                            //    "trxn_datetime >= #" + DateTime.Parse(dtTrxns.Rows[i]["trxn_datetime"].ToString()).ToString("MM/dd/yyyy") +
                            //    "# and trxn_datetime <= #" + DateTime.Parse(dtTrxns.Rows[i]["trxn_datetime"].ToString()).ToString("MM/dd/yyyy") + " 23:59:59# and atm_id = " + drATM["atm_id"]);

                            //Added on 19/06/2014.
                            DataRow[] drArray = dt.Select("trxn_datetime = #" + dtTrxns.Rows[i]["trxn_datetime"] + " 23:59:59# and atm_id = " + drATM["atm_id"]);
                            //DataView dv = new DataView(dt,
                            //    "trxn_datetime >= #" + DateTime.Parse(dtTrxns.Rows[i]["trxn_datetime"].ToString()).ToString("MM/dd/yyyy") +" and atm_id = " + drATM["atm_id"],
                            //    "trxn_datetime", DataViewRowState.CurrentRows);
                            ////

                            foreach (DataRow dr in drArray)
                            {
                                id = int.Parse(dr["ej_parsed_bna_transaction_id"].ToString());
                                if (parsedBNATransactions.Contains(id))
                                    continue;
                                else
                                    parsedBNATransactions.Add(id);

                                if (dr["status"].ToString() == "Successful")
                                {
                                    DataRow[] temp = dt.Select("ej_parsed_bna_transaction_id = " + dr["ej_parsed_bna_transaction_id"]);

                                    if (temp.Length > 0)
                                    {
                                        DataTable dtUniqueNoteType = temp.CopyToDataTable().DefaultView.ToTable(true, new string[] { "note_type" });
                                        foreach (DataRow drUniqueNoteType in dtUniqueNoteType.Rows)
                                        {
                                            DataRow[] innerTemp = dt.Select("ej_parsed_bna_transaction_id=" + dr["ej_parsed_bna_transaction_id"] + " and note_type=" + drUniqueNoteType["note_type"]);
                                            successfulChqDeposit += int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString());
                                        }

                                    }

                                }
                                else if (dr["status"].ToString() == "Failed" && successfulChqDeposit > 0)
                                {
                                    DataRow newRow = dtGrid.NewRow();
                                    newRow["title"] = drATM["title"];
                                    newRow["trxn_datetime"] = dr["trxn_datetime"];
                                    newRow["counter"] = successfulChqDeposit;
                                    newRow["type"] = dr["comment"];
                                    dtGrid.Rows.Add(newRow);
                                    successfulChqDeposit = 0;
                                }
                            }//

                            //foreach (DataRow dr in drArray)
                            //{
                            //    id = int.Parse(dr["ej_parsed_bna_transaction_id"].ToString());
                            //    if (parsedBNATransactions.Contains(id))
                            //        continue;
                            //    else
                            //        parsedBNATransactions.Add(id);

                            //    if (dr["status"].ToString() == "Successful")
                            //    {
                            //        DataRow[] temp = dt.Select("ej_parsed_bna_transaction_id = " + dr["ej_parsed_bna_transaction_id"]);

                            //        if (temp.Length > 0)
                            //        {
                            //            DataTable dtUniqueNoteType = temp.CopyToDataTable().DefaultView.ToTable(true, new string[] { "note_type" });
                            //            foreach (DataRow drUniqueNoteType in dtUniqueNoteType.Rows)
                            //            {
                            //                DataRow[] innerTemp = dt.Select("ej_parsed_bna_transaction_id=" + dr["ej_parsed_bna_transaction_id"] + " and note_type=" + drUniqueNoteType["note_type"]);
                            //                //builder.Append(drUniqueNoteType["note_type"].ToString() + "*" + int.Parse(temp[temp.Length - 1]["notes_count"].ToString()) + "=" + int.Parse(drUniqueNoteType["note_type"].ToString()) * int.Parse(temp[temp.Length - 1]["notes_count"].ToString()) + "<br/>");
                            //                successfulChqDeposit += int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString());
                            //            }

                            //        }

                            //        //if (temp != null)
                            //        //{
                            //        //    foreach (DataRow drTemp in temp)
                            //        //        successfulChqDeposit += int.Parse(drTemp["notes_count"].ToString()); // Successful cheque deposit count;
                            //        //}
                            //    }
                            //    else if (dr["status"].ToString() == "Failed" && successfulChqDeposit > 0)
                            //    {
                            //        DataRow newRow = dtGrid.NewRow();
                            //        newRow["title"] = drATM["title"];
                            //        newRow["trxn_datetime"] = dr["trxn_datetime"];
                            //        newRow["counter"] = successfulChqDeposit;
                            //        newRow["type"] = dr["comment"];
                            //        dtGrid.Rows.Add(newRow);
                            //        successfulChqDeposit = 0;
                            //    }
                            //}//

                        }

                        LogableTask.LogMonoActivityTask("genMeanTime", MethodBase.GetCurrentMethod(), TraceLevel.Info, drATM["title"] + " processed for mean time.");

                    }
                    ds = new dsMeanTimeToFailureAnalysis();
                    ds.Tables[0].Merge(dtGrid);

                }
                else if (reportName == "PNCMeanTimeToFailureAnalysisForSDMCPM")
                {
                    int reportType = 0;
                    switch (reportName)
                    {
                        case "PNCMeanTimeToFailureAnalysisForCPMAndSDM":
                            reportType = 0;
                            break;
                        case "PNCMeanTimeToFailureAnalysisForSCPM":
                            reportType = 1;
                            break;
                        case "PNCMeanTimeToFailureAnalysisForSDM":
                            reportType = 2;
                            break;
                    }

                    DataTable dtGrid = new DataTable();
                    dtGrid.Columns.Add("title");
                    dtGrid.Columns.Add("trxn_datetime", typeof(DateTime));
                    dtGrid.Columns.Add("counter", typeof(int));
                    dtGrid.Columns.Add("type");
                    cmd = ConnectionFactory.GetNewCommand(false);

                    List<int> parsedCPMTransactions = new List<int>();
                    //int count = 0;
                    int successfulChqDeposit = 0;
                    int id = 0;


                    string SQL = @"select atm.atm_id,* from ej_parsed_cpm_transaction 
                                  left join ej_parsed_cpm_transaction_detail 
                                  on ej_parsed_cpm_transaction.ej_parsed_cpm_transaction_id = ej_parsed_cpm_transaction_detail.ej_parsed_cpm_transaction_id " +
                                 " inner join atm on atm.atm_id = ej_parsed_cpm_transaction.atm_id " +
                        " where atm.is_active=1 " + GetFilter() + "  order by trxn_datetime ";
                    DataTable dt = GetDataTable(SQL);
                    DataTable dtATMs = dt.DefaultView.ToTable(true, new string[] { "atm_id", "title" });
                    DataTable dtTrxns = dt.DefaultView.ToTable(true, new string[] { "atm_id", "trxn_datetime" });

                    foreach (DataRow drATM in dtATMs.Rows)
                    {
                        for (int i = 0; i < dtTrxns.Rows.Count; i++)
                        {
                            //DataRow[] drArray = dt.Select(
                            //    "trxn_datetime >= #" + DateTime.Parse(dtTrxns.Rows[i]["trxn_datetime"].ToString()).ToString("MM/dd/yyyy") +
                            //    "# and trxn_datetime <= #" + DateTime.Parse(dtTrxns.Rows[i]["trxn_datetime"].ToString()).ToString("MM/dd/yyyy") + " 23:59:59# and atm_id = " + drATM["atm_id"]);

                            DataRow[] drArray = dt.Select("trxn_datetime = #" + dtTrxns.Rows[i]["trxn_datetime"] + " 23:59:59# and atm_id = " + drATM["atm_id"]);

                            foreach (DataRow dr in drArray)
                            {
                                id = int.Parse(dr["ej_parsed_cpm_transaction_id"].ToString());
                                if (parsedCPMTransactions.Contains(id))
                                    continue;
                                else
                                    parsedCPMTransactions.Add(id);

                                if (dr["status"].ToString() == "Successful")
                                {
                                    DataRow[] temp = dt.Select("ej_parsed_cpm_transaction_id = " + dr["ej_parsed_cpm_transaction_id"]);
                                    if (temp != null)
                                        successfulChqDeposit += temp.Length; // Successful cheque deposit count;
                                }
                                else if (dr["status"].ToString() == "Failed" && successfulChqDeposit > 0)
                                {
                                    DataRow newRow = dtGrid.NewRow();
                                    newRow["title"] = drATM["title"];
                                    newRow["trxn_datetime"] = dr["trxn_datetime"];
                                    newRow["counter"] = successfulChqDeposit;
                                    newRow["type"] = dr["comment"];
                                    dtGrid.Rows.Add(newRow);
                                    successfulChqDeposit = 0;
                                }
                            }
                        }

                    }


                    ds = new dsMeanTimeToFailureAnalysis();
                    ds.Tables[0].Merge(dtGrid);

                }
                //Change on 12/06/2014
                else if (reportName == "PNCMeanTimeToIncidentFailureAnalysisForBNA" || reportName == "PNCMeanTimeToIncidentFailureAnalysisForSDMBNA")
                {
                    DataTable dtGrid = new DataTable();
                    dtGrid.Columns.Add("title");
                    dtGrid.Columns.Add("trxn_datetime", typeof(DateTime));
                    dtGrid.Columns.Add("counter", typeof(int));
                    dtGrid.Columns.Add("type");
                    cmd = ConnectionFactory.GetNewCommand(false);

                    List<int> parsedBNATransactions = new List<int>();
                    // int count = 0;
                    int successfulChqDeposit = 0;
                    int id = 0;

                    string SQL = "select * from ej_parsed_bna_transaction left join ej_parsed_bna_transaction_detail on ej_parsed_bna_transaction.ej_parsed_bna_transaction_id = ej_parsed_bna_transaction_detail.ej_parsed_bna_transaction_id " +
                         " inner join atm on atm.atm_id = ej_parsed_bna_transaction.atm_id " +
                        " where atm.is_active=1 " + GetFilter() + "  order by trxn_datetime ";
                    DataTable dt = GetDataTable(SQL);
                    DataTable dtATMs = dt.DefaultView.ToTable(true, new string[] { "atm_id", "title" });
                    DataTable dtTrxns = dt.DefaultView.ToTable(true, new string[] { "atm_id", "trxn_datetime" });
                    foreach (DataRow drATM in dtATMs.Rows)
                    {
                        for (int i = 0; i < dtTrxns.Rows.Count; i++)
                        {
                            //DataRow[] drArray = dt.Select(
                            //    "trxn_datetime >= #" + DateTime.Parse(dtTrxns.Rows[i]["trxn_datetime"].ToString()).ToString("MM/dd/yyyy") +
                            //    "# and trxn_datetime <= #" + DateTime.Parse(dtTrxns.Rows[i]["trxn_datetime"].ToString()).ToString("MM/dd/yyyy") + " 23:59:59# and atm_id = " + drATM["atm_id"]);

                            DataRow[] drArray = dt.Select("trxn_datetime = #" + dtTrxns.Rows[i]["trxn_datetime"] + " 23:59:59# and atm_id = " + drATM["atm_id"]);
                            foreach (DataRow dr in drArray)
                            {
                                id = int.Parse(dr["ej_parsed_bna_transaction_id"].ToString());
                                if (parsedBNATransactions.Contains(id))
                                    continue;
                                else
                                    parsedBNATransactions.Add(id);

                                if (dr["status"].ToString() == "Successful")
                                {
                                    successfulChqDeposit++;
                                    //DataRow[] temp = dt.Select("ej_parsed_bna_transaction_id = " + dr["ej_parsed_bna_transaction_id"]);

                                    //if (temp.Length > 0)
                                    //{
                                    //    DataTable dtUniqueNoteType = temp.CopyToDataTable().DefaultView.ToTable(true, new string[] { "note_type" });
                                    //    foreach (DataRow drUniqueNoteType in dtUniqueNoteType.Rows)
                                    //    {
                                    //        DataRow[] innerTemp = dt.Select("ej_parsed_bna_transaction_id=" + dr["ej_parsed_bna_transaction_id"] + " and note_type=" + drUniqueNoteType["note_type"]);
                                    //        //builder.Append(drUniqueNoteType["note_type"].ToString() + "*" + int.Parse(temp[temp.Length - 1]["notes_count"].ToString()) + "=" + int.Parse(drUniqueNoteType["note_type"].ToString()) * int.Parse(temp[temp.Length - 1]["notes_count"].ToString()) + "<br/>");
                                    //        successfulChqDeposit += int.Parse(innerTemp[innerTemp.Length - 1]["notes_count"].ToString());
                                    //    }

                                    //}

                                    //if (temp != null)
                                    //{
                                    //    foreach (DataRow drTemp in temp)
                                    //        successfulChqDeposit += int.Parse(drTemp["notes_count"].ToString()); // Successful cheque deposit count;
                                    //}
                                }
                                else if (dr["status"].ToString() == "Failed" && successfulChqDeposit > 0)
                                {
                                    DataRow newRow = dtGrid.NewRow();
                                    newRow["title"] = drATM["title"];
                                    newRow["trxn_datetime"] = dr["trxn_datetime"];
                                    newRow["counter"] = successfulChqDeposit;
                                    newRow["type"] = dr["comment"];
                                    dtGrid.Rows.Add(newRow);
                                    successfulChqDeposit = 0;
                                }
                            }
                        }


                    }
                    ds = new dsMeanTimeToFailureAnalysis();
                    ds.Tables[0].Merge(dtGrid);

                }
                else if (reportName == "PNCMeanTimeToIncidentFailureAnalysisForSDMCPM")
                {
                    int reportType = 0;
                    switch (reportName)
                    {
                        case "PNCMeanTimeToFailureAnalysisForCPMAndSDM":
                            reportType = 0;
                            break;
                        case "PNCMeanTimeToFailureAnalysisForSCPM":
                            reportType = 1;
                            break;
                        case "PNCMeanTimeToFailureAnalysisForSDM":
                            reportType = 2;
                            break;
                    }

                    DataTable dtGrid = new DataTable();
                    dtGrid.Columns.Add("title");
                    dtGrid.Columns.Add("trxn_datetime", typeof(DateTime));
                    dtGrid.Columns.Add("counter", typeof(int));
                    dtGrid.Columns.Add("type");
                    cmd = ConnectionFactory.GetNewCommand(false);

                    List<int> parsedCPMTransactions = new List<int>();
                    //int count = 0;
                    int successfulChqDeposit = 0;
                    int id = 0;


                    string SQL = @"select atm.atm_id,* from ej_parsed_cpm_transaction 
                                  left join ej_parsed_cpm_transaction_detail 
                                  on ej_parsed_cpm_transaction.ej_parsed_cpm_transaction_id = ej_parsed_cpm_transaction_detail.ej_parsed_cpm_transaction_id " +
                                 " inner join atm on atm.atm_id = ej_parsed_cpm_transaction.atm_id " +
                        " where atm.is_active=1 " + GetFilter() + "  order by trxn_datetime ";
                    DataTable dt = GetDataTable(SQL);
                    DataTable dtATMs = dt.DefaultView.ToTable(true, new string[] { "atm_id", "title" });
                    DataTable dtTrxns = dt.DefaultView.ToTable(true, new string[] { "atm_id", "trxn_datetime" });

                    foreach (DataRow drATM in dtATMs.Rows)
                    {
                        for (int i = 0; i < dtTrxns.Rows.Count; i++)
                        {
                            //DataRow[] drArray = dt.Select(
                            //    "trxn_datetime >= #" + DateTime.Parse(dtTrxns.Rows[i]["trxn_datetime"].ToString()).ToString("MM/dd/yyyy") +
                            //    "# and trxn_datetime <= #" + DateTime.Parse(dtTrxns.Rows[i]["trxn_datetime"].ToString()).ToString("MM/dd/yyyy") + " 23:59:59# and atm_id = " + drATM["atm_id"]);
                            DataRow[] drArray = dt.Select("trxn_datetime = #" + dtTrxns.Rows[i]["trxn_datetime"] + " 23:59:59# and atm_id = " + drATM["atm_id"]);
                            foreach (DataRow dr in drArray)
                            {
                                id = int.Parse(dr["ej_parsed_cpm_transaction_id"].ToString());
                                if (parsedCPMTransactions.Contains(id))
                                    continue;
                                else
                                    parsedCPMTransactions.Add(id);

                                if (dr["status"].ToString() == "Successful")
                                {
                                    successfulChqDeposit++;
                                    //DataRow[] temp = dt.Select("ej_parsed_cpm_transaction_id = " + dr["ej_parsed_cpm_transaction_id"]);
                                    //if (temp != null)
                                    //    successfulChqDeposit += temp.Length; // Successful cheque deposit count;
                                }
                                else if (dr["status"].ToString() == "Failed" && successfulChqDeposit > 0)
                                {
                                    DataRow newRow = dtGrid.NewRow();
                                    newRow["title"] = drATM["title"];
                                    newRow["trxn_datetime"] = dr["trxn_datetime"];
                                    newRow["counter"] = successfulChqDeposit;
                                    newRow["type"] = dr["comment"];
                                    dtGrid.Rows.Add(newRow);
                                    successfulChqDeposit = 0;
                                }
                            }
                        }

                    }


                    ds = new dsMeanTimeToFailureAnalysis();
                    ds.Tables[0].Merge(dtGrid);

                }

                //

                return ds;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
                try
                {
                    task.EndTask();
                }
                catch (Exception ex)
                {
                }
            }
        }


        string GetExcludeDeadATMFilter(DateTime scheduleDate, string fieldName)
        {
            return " and " + fieldName + " in (select ATM_id from heart_beat where heart_beat_received_at >=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) and " +
                                         "heart_beat_received_at <=convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103))";

            //return " and " + fieldName + " in (select ATM_id from heart_beat where heart_beat_received_at >=convert(datetime,'" + DateTime.Today.ToString("dd/MM/yyyy") + "',103) and " +
            //                 "heart_beat_received_at <=convert(datetime,'" + DateTime.Today.ToString("dd/MM/yyyy") + " 23:59:59',103))";

        }
        string GetFilter()
        {
            string filter = "";

            if (reportSchedule.IsWeekly || reportSchedule.IsMonthly)
            {
                filter += " and trxn_datetime >= convert(datetime,'" + fromDate.ToString("dd/MM/yyyy") + "',103) " +
                            " and trxn_datetime<= convert(datetime,'" + toDate.ToString("dd/MM/yyyy") + " 23:59:59',103)";

            }
            //else if (reportSchedule.IsMonthly)
            //{
            //    DateTime newScheduleDate = new DateTime(reportSchedule.ReportNextGeneratedAt.Year, reportSchedule.ReportNextGeneratedAt.Month, 1,
            //        reportSchedule.ReportNextGeneratedAt.Hour, reportSchedule.ReportNextGeneratedAt.Minute, reportSchedule.ReportNextGeneratedAt.Second);

            //    newScheduleDate = newScheduleDate.AddMonths(-1);

            //    filter += " and trxn_datetime >= convert(datetime,'" + newScheduleDate.ToString("dd/MM/yyyy") + "',103) " +
            //              " and trxn_datetime<= convert(datetime,'" + newScheduleDate.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59',103)";

            //}
            else if (isWeeklyAnalysis)
            {
                filter += " and trxn_datetime >= convert(datetime,'" + gFrom.ToString("dd/MM/yyyy") + "',103) " +
                            " and trxn_datetime<= convert(datetime,'" + gTo.ToString("dd/MM/yyyy") + " 23:59:59',103)";

            }
            else
            {

                if (reportSchedule.MinutesToScheduleAgain.Value > 1440)
                {
                    DateTime startDate = new DateTime(gScheduleDate.Year, gScheduleDate.Month, 1);
                    DateTime endDate = startDate.AddMonths(1).AddDays(-1);

                    filter += " and trxn_datetime >= convert(datetime,'" + startDate.ToString("dd/MM/yyyy") + "',103) " +
                                " and trxn_datetime<= convert(datetime,'" + endDate.ToString("dd/MM/yyyy") + " 23:59:59',103)";
                }
                else
                    filter += " and trxn_datetime >= convert(datetime,'" + reportSchedule.ReportNextGeneratedAt.AddDays(-1).ToString("dd/MM/yyyy") + "',103) " +
                                " and trxn_datetime<= convert(datetime,'" + reportSchedule.ReportNextGeneratedAt.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59',103)";
            }
            //if (type == 0)
            //    filter += " and (is_ccdm = 1 or is_sdm = 1) ";
            //else if (type == 1)
            //    filter += " and is_ccdm = 1 ";
            //else if (type == 2)
            //    filter += " and is_sdm = 1 ";
            //else if (type == 3)
            //    filter += " and is_cdm = 1 ";

            if (reportSchedule.ReportName.ToLower().Contains("sdm"))
                filter += " and is_sdm = 1 ";
            else if (reportSchedule.ReportName.ToLower().Contains("bna"))
                filter += " and is_cdm = 1 ";
            else if (reportSchedule.ReportName.ToLower().Contains("cpm"))
                filter += " and is_ccdm = 1 ";
            //if (DropDownList_Comment.SelectedIndex>0)
            //    filter += " and comment = '"+DropDownList_Comment.SelectedItem.Text+"'";
            if (reportSchedule.CriteriaId.HasValue)
            {
                if (reportSchedule.CriteriaId == 1)
                    filter += " and dispute_status is not null ";
                else if (reportSchedule.CriteriaId == 2)
                    filter += " and (dispute_status is null or dispute_status = '000') ";
            }

            filter += " and is_eligible = 1";
            LogableTask.LogMonoActivityTask("filter", MethodBase.GetCurrentMethod(), TraceLevel.Info, filter);
            return filter;
        }
        private void SplitAlertMessageIntoColumnsForPurgeThreshold(DataTable dataTable)
        {
            string[] ConfiguredCassettes = System.Configuration.ConfigurationManager.AppSettings["supportedTypes"].Split(',');
            foreach (DataRow dr in dataTable.Rows)
            {
                //1,72,12, 2,47,12, 3,0,12, 4,17,14
                string[] parts = dr["alert_msg"].ToString().Split(',');
                if (ConfiguredCassettes[0] == "1")
                {
                    dr["type1"] = parts[1];
                    dr["threshold1"] = parts[2];
                }
                if (ConfiguredCassettes[1] == "1")
                {
                    dr["type2"] = parts[4];
                    dr["threshold2"] = parts[5];
                }
                if (ConfiguredCassettes[2] == "1")
                {
                    dr["type3"] = parts[7];
                    dr["threshold3"] = parts[8];
                }
                if (ConfiguredCassettes[3] == "1")
                {
                    dr["type4"] = parts[10];
                    dr["threshold4"] = parts[11];
                }
            }
        }
        private void SplitAlertMessageIntoColumns(DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                string[] parts = dr["alert_msg"].ToString().Split(',');
                dr["type1"] = parts[0];
                dr["type2"] = parts[1];
                dr["type3"] = parts[2];
                dr["type4"] = parts[3];
                dr["balance"] = parts[7];
            }
        }
        private void SplitMinNotesMessageIntoParts(DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                string[] parts = dr["alert_msg"].ToString().Split('|');
                dr["type1"] = parts[0];
                dr["type2"] = parts[1];
                dr["type3"] = parts[2];
                dr["type4"] = parts[3];
                dr["balance"] = parts[4];
            }
        }

        private void AddToDataTable(DataRow[] src, DataTable dest)
        {
            foreach (DataRow row in src)
            {
                if (!dest.Rows.Contains(row["parsed_transaction_id"]))
                {
                    DataRow dr = dest.NewRow();
                    for (int i = 0; i < row.ItemArray.Length; i++)
                        dr[i] = row.ItemArray[i];

                    dest.Rows.Add(dr);
                }

            }
        }
        private void PopulateDataTable(DataTable dt)
        {
            int region_id = 0;
            int id = -1;
            Region region = null;
            DataTable dtRegions = new DataTable();
            SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
            cmd.CommandText = "select region_id, parent_region_id, is_organization, bank_logo from region where parent_region_id is not null";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dtRegions);



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                region_id = int.Parse(dt.Rows[i][3].ToString()); //parent

                while (true)
                {
                    DataRow[] innerArray = dtRegions.Select("region_id=" + region_id);
                    if (bool.Parse(innerArray[0][2].ToString()))
                    {
                        id = int.Parse(innerArray[0][0].ToString());
                        break;
                    }
                    else
                        region_id = int.Parse(innerArray[0][1].ToString());

                }
                //organization id found
                if (region != null)
                {
                    if (id != region.RegionId)
                        region = Region.LoadRegionByPk(id);
                }
                else
                    region = Region.LoadRegionByPk(id);

                dt.Rows[i][1] = region.RegionName;
                //dt.Rows[i][4] = region.BankLogo;

            }

        }

        private void PopulateDataTableForDeadATMsReport(DataTable dt)
        {
            int region_id = 0;
            int id = -1;
            Region region = null;
            DataTable dtRegions = new DataTable();
            SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
            cmd.CommandText = "select region_id, parent_region_id, is_organization, bank_logo from region";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dtRegions);



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                region_id = int.Parse(dt.Rows[i][10].ToString()); //parent

                while (true)
                {
                    DataRow[] innerArray = dtRegions.Select("region_id=" + region_id);
                    if (bool.Parse(innerArray[0][2].ToString()))
                    {
                        id = int.Parse(innerArray[0][0].ToString());
                        break;
                    }
                    else
                        region_id = int.Parse(innerArray[0][1].ToString());

                }
                //organization id found
                if (region != null)
                {
                    if (id != region.RegionId)
                        region = Region.LoadRegionByPk(id);
                }
                else
                    region = Region.LoadRegionByPk(id);

                dt.Rows[i][8] = region.RegionName;
                //dt.Rows[i][8] = region.BankLogo;

            }

        }
        private void PopulateDataTableForTaskStatus(DataTable dt)
        {
            int region_id = 0;
            int id = -1;
            Region region = null;
            DataTable dtRegions = new DataTable();
            SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
            cmd.CommandText = "select region_id, parent_region_id, is_organization, bank_logo from region";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dtRegions);



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                region_id = int.Parse(dt.Rows[i][10].ToString()); //parent

                while (true)
                {
                    DataRow[] innerArray = dtRegions.Select("region_id=" + region_id);
                    if (bool.Parse(innerArray[0][2].ToString()))
                    {
                        id = int.Parse(innerArray[0][0].ToString());
                        break;
                    }
                    else
                        region_id = int.Parse(innerArray[0][1].ToString());

                }
                //organization id found
                if (region != null)
                {
                    if (id != region.RegionId)
                        region = Region.LoadRegionByPk(id);
                }
                else
                    region = Region.LoadRegionByPk(id);

                dt.Rows[i][7] = region.RegionName;
                //dt.Rows[i][8] = region.BankLogo;

            }

        }
        private void PopulateDataTableForReplenishment(DataTable dt)
        {
            int region_id = 0;
            int id = -1;
            Region region = null;
            DataTable dtRegions = new DataTable();
            SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
            cmd.CommandText = "select region_id, parent_region_id, is_organization, bank_logo from region";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dtRegions);



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                region_id = int.Parse(dt.Rows[i][19].ToString()); //parent

                while (true)
                {
                    DataRow[] innerArray = dtRegions.Select("region_id=" + region_id);
                    if (bool.Parse(innerArray[0][2].ToString()))
                    {
                        id = int.Parse(innerArray[0][0].ToString());
                        break;
                    }
                    else
                        region_id = int.Parse(innerArray[0][1].ToString());

                }
                //organization id found
                if (region != null)
                {
                    if (id != region.RegionId)
                        region = Region.LoadRegionByPk(id);
                }
                else
                    region = Region.LoadRegionByPk(id);

                dt.Rows[i][5] = region.RegionName;
                dt.Rows[i][6] = region.BankLogo;

            }

        }
        void GenerateReportingTask(ReportSchedule reportSchedule, ReportGenerationSchedule reportGenerationSchedule)
        {
            ReportTask reportTask = null;
            string filePath = null;
            string reportName = reportSchedule.ReportName;
            if (reportSchedule.CriteriaId.HasValue)
                reportName = reportSchedule.ReportName + "_" + reportSchedule.CriteriaId;
            if (reportSchedule.IsMonthly)
                reportName += "_M";
            else if (reportSchedule.IsWeekly)
                reportName += "_W_" + reportSchedule.ReportNextGeneratedAt.ToString("ddMMyyyy");

            filePath = reportSchedule.ReportTempPath + "\\" + reportName + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss");

            if (reportSchedule.ReportExportType == 1)
                filePath += ".pdf";
            else if (reportSchedule.ReportExportType == 2)
                filePath += ".xls";
            else if (reportSchedule.ReportExportType == 3)
            {
                filePath += ".pdf;";
                filePath += reportSchedule.ReportTempPath + "\\" + reportName + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xls";
            }


            reportTask = new ReportTask();
            reportTask.ReportScheduleId = reportSchedule.ReportScheduleId;
            reportTask.RetryCount = reportSchedule.RetryCount;
            reportTask.CreationTime = DateTime.Now;
            reportTask.FilePathAttachment = filePath;
            reportTask.Status = "Scheduled";

            //if (reportTask.ReportScheduleId == 27)
            //    reportTask.ScheduleDate = new DateTime(reportSchedule.ReportNextGeneratedAt.Year, reportSchedule.ReportNextGeneratedAt.Month,
            //        reportSchedule.ReportNextGeneratedAt.Day);
            //else
            if (reportGenerationSchedule != null)
            {
                //-1 bcoz schedule already updated for next day.
                reportTask.ScheduleDate = reportGenerationSchedule.NextGenerationAt.AddDays(-1 - reportSchedule.ReportDataAge.Value);
            }
            else
            {
                reportTask.ScheduleDate = reportSchedule.ReportNextGeneratedAt.AddDays(-reportSchedule.ReportDataAge.Value);


                if (reportSchedule.IsMonthly)
                {
                    reportTask.ToDate = reportSchedule.ReportNextGeneratedAt.AddDays(-1);
                    reportTask.FromDate = new DateTime(reportTask.ToDate.Value.Year, reportTask.ToDate.Value.Month, 1, reportTask.ToDate.Value.Hour, reportTask.ToDate.Value.Minute, reportTask.ToDate.Value.Second);
                    reportSchedule.ReportNextGeneratedAt = reportSchedule.ReportNextGeneratedAt.AddMonths(1);

                }
                else if (reportSchedule.IsWeekly)
                {
                    int day = reportSchedule.ReportNextGeneratedAt.Day;
                    if (day > 1 && day <= 22)//first week 
                    {
                        //Change the schedule time to day 1
                        //DateTime newScheduleTime = new DateTime(reportSchedule.ReportNextGeneratedAt.Year,
                        //    reportSchedule.ReportNextGeneratedAt.Month, 1, reportSchedule.ReportNextGeneratedAt.Hour,
                        //    reportSchedule.ReportNextGeneratedAt.Minute, reportSchedule.ReportNextGeneratedAt.Second);

                        reportTask.FromDate = reportSchedule.ReportNextGeneratedAt.AddDays(-7);
                        reportTask.ToDate = reportSchedule.ReportNextGeneratedAt.AddDays(-1);
                        if (day == 22)
                        {
                            //DateTime newScheduleTime = new DateTime(reportSchedule.ReportNextGeneratedAt.Year, reportSchedule.ReportNextGeneratedAt.Month, 22, reportSchedule.ReportNextGeneratedAt.Hour,
                            //                          reportSchedule.ReportNextGeneratedAt.Minute, reportSchedule.ReportNextGeneratedAt.Second);

                            // reportTask.FromDate = newScheduleTime;
                            DateTime newScheduleTime = new DateTime(reportSchedule.ReportNextGeneratedAt.Year, reportSchedule.ReportNextGeneratedAt.Month, 1, reportSchedule.ReportNextGeneratedAt.Hour,
                                                               reportSchedule.ReportNextGeneratedAt.Minute, reportSchedule.ReportNextGeneratedAt.Second);

                            //reportTask.ToDate = newScheduleTime.AddMonths(1).AddDays(-1);
                            reportSchedule.ReportNextGeneratedAt = newScheduleTime.AddMonths(1);




                        }
                        else
                            reportSchedule.ReportNextGeneratedAt = reportSchedule.ReportNextGeneratedAt.AddDays(7);

                        //Set Date Range for report task

                    }
                    else
                    {
                        DateTime newScheduleTime = new DateTime(reportSchedule.ReportNextGeneratedAt.Year, reportSchedule.ReportNextGeneratedAt.Month, 22, reportSchedule.ReportNextGeneratedAt.Hour,
                                                                reportSchedule.ReportNextGeneratedAt.Minute, reportSchedule.ReportNextGeneratedAt.Second);

                        reportTask.FromDate = newScheduleTime.AddMonths(-1);
                        reportTask.ToDate = reportSchedule.ReportNextGeneratedAt.AddDays(-1);


                        reportSchedule.ReportNextGeneratedAt = reportSchedule.ReportNextGeneratedAt.AddDays(7);
                        //reportSchedule.ReportNextGeneratedAt = reportSchedule.ReportNextGeneratedAt.AddDays(7);
                    }
                    //else if (day >= 8 && day <= 14)
                    //{
                    //    //Change the schedule time to day 8
                    //    DateTime newScheduleTime = new DateTime(reportSchedule.ReportNextGeneratedAt.Year,
                    //        reportSchedule.ReportNextGeneratedAt.Month, 8, reportSchedule.ReportNextGeneratedAt.Hour,
                    //        reportSchedule.ReportNextGeneratedAt.Minute, reportSchedule.ReportNextGeneratedAt.Second);

                    //    reportSchedule.ReportNextGeneratedAt = newScheduleTime.AddDays(7);
                    //}
                    //else if (day >= 15 && day <= 21)
                    //{
                    //    //Change the schedule time to day 15
                    //    DateTime newScheduleTime = new DateTime(reportSchedule.ReportNextGeneratedAt.Year,
                    //        reportSchedule.ReportNextGeneratedAt.Month, 15, reportSchedule.ReportNextGeneratedAt.Hour,
                    //        reportSchedule.ReportNextGeneratedAt.Minute, reportSchedule.ReportNextGeneratedAt.Second);

                    //    reportSchedule.ReportNextGeneratedAt = newScheduleTime.AddDays(7);
                    //}
                    //else
                    //{
                    //    DateTime newScheduleTime = new DateTime(reportSchedule.ReportNextGeneratedAt.Year,
                    //       reportSchedule.ReportNextGeneratedAt.Month, 1, reportSchedule.ReportNextGeneratedAt.Hour,
                    //       reportSchedule.ReportNextGeneratedAt.Minute, reportSchedule.ReportNextGeneratedAt.Second);


                    //    reportSchedule.ReportNextGeneratedAt = newScheduleTime.AddMonths(1);
                    //}

                }

                else
                    reportSchedule.ReportNextGeneratedAt = reportSchedule.ReportNextGeneratedAt.AddMinutes(reportSchedule.MinutesToScheduleAgain.Value);

                reportSchedule.Save();
            }
            reportTask.Save();
        }

        private void ExecuteTask(ReportTask reportTask, LogableTask task)
        {

            LogableTask.LogMonoActivityTask("ExecuteTask", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Entered");
            ReportDocument rptDoc = null;

            try
            {
                totalDeposits = 0;
                totalRejects = 0;
                if (reportTask.FromDate.HasValue)
                    fromDate = reportTask.FromDate.Value;
                if (reportTask.ToDate.HasValue)
                    toDate = reportTask.ToDate.Value;

                reportSchedule = ReportSchedule.LoadReportScheduleByPk(reportTask.ReportScheduleId);
                LogableTask.LogMonoActivityTask("ExecuteTask", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Report Schedule ID = " + reportSchedule.ReportScheduleId);
                LogableTask.LogMonoActivityTask("ExecuteTask", MethodBase.GetCurrentMethod(), TraceLevel.Info, reportSchedule.ReportPhysicalPath);

                if (reportSchedule.ReportName == "CashOrderReport" && System.Configuration.ConfigurationManager.AppSettings["isCustomized"] == "1")
                {
                    ExportCashOrder(reportTask.ScheduleDate,reportTask);
                    reportTask.Status = "Processed";
                    reportTask.RetryCount = reportSchedule.RetryCount;
                    reportTask.Save();
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Processed " + reportSchedule.ReportFriendlyName);
                }
                else if (reportSchedule.IsGraphicalReport)
                {
                    //if (reportSchedule.IsWeekly)
                    //{
                    //    int day = reportTask.ScheduleDate.Day;
                    //    if (day <= 7)//first week 
                    //    {
                    //        //Change the schedule time to day 1
                    //        DateTime newScheduleTime = new DateTime(reportTask.ScheduleDate.Year,
                    //            reportTask.ScheduleDate.Month, 1, reportTask.ScheduleDate.Hour,
                    //            reportTask.ScheduleDate.Minute, reportTask.ScheduleDate.Second);

                    //        from = newScheduleTime;
                    //        to = newScheduleTime.AddDays(7).AddDays(-1);

                    //    }
                    //    else if (day >= 8 && day <= 14)
                    //    {
                    //        //Change the schedule time to day 8
                    //        DateTime newScheduleTime = new DateTime(reportTask.ScheduleDate.Year,
                    //            reportTask.ScheduleDate.Month, 8, reportTask.ScheduleDate.Hour,
                    //            reportTask.ScheduleDate.Minute, reportTask.ScheduleDate.Second);

                    //        from = newScheduleTime;
                    //        to = newScheduleTime.AddDays(7).AddDays(-1);


                    //    }
                    //    else if (day >= 15 && day <= 21)
                    //    {
                    //        //Change the schedule time to day 15
                    //        DateTime newScheduleTime = new DateTime(reportTask.ScheduleDate.Year,
                    //            reportTask.ScheduleDate.Month, 15, reportTask.ScheduleDate.Hour,
                    //           reportTask.ScheduleDate.Minute, reportTask.ScheduleDate.Second);

                    //        from = newScheduleTime;
                    //        to = newScheduleTime.AddDays(7).AddDays(-1);

                    //    }
                    //    else
                    //    {
                    //        DateTime newScheduleTime = new DateTime(reportTask.ScheduleDate.Year,
                    //           reportTask.ScheduleDate.Month, 22, reportTask.ScheduleDate.Hour,
                    //           reportTask.ScheduleDate.Minute, reportTask.ScheduleDate.Second);

                    //        DateTime temp = new DateTime(reportTask.ScheduleDate.Year,
                    //           reportTask.ScheduleDate.Month, 1, reportTask.ScheduleDate.Hour,
                    //           reportTask.ScheduleDate.Minute, reportTask.ScheduleDate.Second);


                    //        from = newScheduleTime;
                    //        to = temp.AddMonths(1).AddDays(-1);


                    //        //                                    rptDoc.SetParameterValue("FromDate", newScheduleTime);
                    //        //                                    rptDoc.SetParameterValue("ToDate", newScheduleTime.AddMonths(1).AddDays(-1));
                    //        ////                                    reader.CurrentReportSchedule.ReportNextGeneratedAt = newScheduleTime.AddMonths(1).AddDays(-1);
                    //    }



                    //}
                    //else if (reportSchedule.IsMonthly)
                    //{
                    //    DateTime newScheduleDate = new DateTime(reportTask.ScheduleDate.Year, reportTask.ScheduleDate.Month, 1,
                    //        reportTask.ScheduleDate.Hour, reportTask.ScheduleDate.Minute, reportTask.ScheduleDate.Second);

                    //    from = newScheduleDate;
                    //    to = newScheduleDate.AddMonths(1).AddDays(-1);
                    //}


                    //                     ProcessStartInfo psInfo = new ProcessStartInfo(HTML2PDFFilePath, reportSchedule.ReportVirtualDirPath + "?tid=" + reportTask.ReportTaskId + "&id=" + reportSchedule.ReportScheduleId + "&from=" + from.ToString("dd/MM/yyyy") + "&to=" + to.ToString("dd/MM/yyyy") + " " + reportTask.FilePathAttachment);
                    //                  task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to process url  " + psInfo.Arguments);


                    String applicationName = "\"" + HTML2PDFFilePath + "\" -O \"Landscape\" \"" + reportSchedule.ReportVirtualDirPath + "?tid=" + reportTask.ReportTaskId + "&id=" + reportSchedule.ReportScheduleId + "&from=" + fromDate.ToString("dd/MM/yyyy") + "&to=" + toDate.ToString("dd/MM/yyyy") + "\" " + reportTask.FilePathAttachment;
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to execute command  " + applicationName);

                    // launch the application
                    bool result = NativeMethods.LaunchProcess(applicationName);
                    //                    ApplicationLoader.PROCESS_INFORMATION procInfo;
                    //                    bool result = ApplicationLoader.StartProcessAndBypassUAC(applicationName, out procInfo);

                    //Thread.Sleep(7 * 1000);
                    // Process process = System.Diagnostics.Process.Start(HTML2PDFFilePath, reportSchedule.ReportPhysicalPath + "?from="+date+"&to="+date+" " + reportTask.FilePathAttachment);
                    // process.WaitForExit(7*1000);



                    //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Process exit code " + process.ExitCode);
                    if (result && File.Exists(reportTask.FilePathAttachment)) //process.ExitCode == 0)
                    {
                        reportTask.Status = "Processed";
                        reportTask.RetryCount = reportSchedule.RetryCount;
                        reportTask.Save();
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Processed " + reportSchedule.ReportFriendlyName);
                    }
                    else
                        throw new Exception("An error occurred while processing url " + reportSchedule.ReportVirtualDirPath);

                }
                
                else
                {
                    //bool isReportParamAttached = false;
                    rptDoc = new ReportDocument();
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to read file from " + reportSchedule.ReportPhysicalPath);
                    rptDoc.Load(reportSchedule.ReportPhysicalPath);
                    rptDoc.SummaryInfo.ReportTitle = reportSchedule.ReportFriendlyName;
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Processing " + reportSchedule.ReportFriendlyName);

                    //if (reportSchedule.IsWeekly)
                    //{
                    //    int day = reportTask.ScheduleDate.Day;
                    //    if (day <= 7)//first week 
                    //    {
                    //        //Change the schedule time to day 1
                    //        DateTime newScheduleTime = new DateTime(reportTask.ScheduleDate.Year,
                    //            reportTask.ScheduleDate.Month, 1, reportTask.ScheduleDate.Hour,
                    //            reportTask.ScheduleDate.Minute, reportTask.ScheduleDate.Second);

                    //        weekFrom = newScheduleTime;
                    //        weekTo = newScheduleTime.AddDays(7).AddDays(-1);

                    //    }
                    //    else if (day >= 8 && day <= 14)
                    //    {
                    //        //Change the schedule time to day 8
                    //        DateTime newScheduleTime = new DateTime(reportTask.ScheduleDate.Year,
                    //            reportTask.ScheduleDate.Month, 8, reportTask.ScheduleDate.Hour,
                    //            reportTask.ScheduleDate.Minute, reportTask.ScheduleDate.Second);

                    //        weekFrom = newScheduleTime;
                    //        weekTo = newScheduleTime.AddDays(7).AddDays(-1);


                    //    }
                    //    else if (day >= 15 && day <= 21)
                    //    {
                    //        //Change the schedule time to day 15
                    //        DateTime newScheduleTime = new DateTime(reportTask.ScheduleDate.Year,
                    //            reportTask.ScheduleDate.Month, 15, reportTask.ScheduleDate.Hour,
                    //           reportTask.ScheduleDate.Minute, reportTask.ScheduleDate.Second);

                    //        weekFrom = newScheduleTime;
                    //        weekTo = newScheduleTime.AddDays(7).AddDays(-1);

                    //    }
                    //    else
                    //    {
                    //        DateTime newScheduleTime = new DateTime(reportTask.ScheduleDate.Year,
                    //           reportTask.ScheduleDate.Month, 22, reportTask.ScheduleDate.Hour,
                    //           reportTask.ScheduleDate.Minute, reportTask.ScheduleDate.Second);

                    //        DateTime temp = new DateTime(reportTask.ScheduleDate.Year,
                    //           reportTask.ScheduleDate.Month, 1, reportTask.ScheduleDate.Hour,
                    //           reportTask.ScheduleDate.Minute, reportTask.ScheduleDate.Second);


                    //        weekFrom = newScheduleTime;
                    //        weekTo = temp.AddMonths(1).AddDays(-1);


                    //        //                                    rptDoc.SetParameterValue("FromDate", newScheduleTime);
                    //        //                                    rptDoc.SetParameterValue("ToDate", newScheduleTime.AddMonths(1).AddDays(-1));
                    //        ////                                    reader.CurrentReportSchedule.ReportNextGeneratedAt = newScheduleTime.AddMonths(1).AddDays(-1);
                    //    }
                    //    //rptDoc.SetParameterValue("FromDate", weekFrom);
                    //    //rptDoc.SetParameterValue("ToDate", weekTo);
                    //    // isReportParamAttached = true;  
                    //}

                    DataSet ds = GetReportDataSet(reportSchedule.ReportName, reportSchedule.OrganizationId.Value, reportSchedule.IsEjEnabled, reportSchedule.ReportDataAge.Value, reportTask);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (reportSchedule.ReportName == "SwitchDispensingReport")
                            rptDoc.SetDataSource(ds);
                        else
                            rptDoc.SetDataSource(ds.Tables[0]);
                        if (reportSchedule.ReportName == "ATMWithoutTrxn24Hour"
                            || reportSchedule.ReportName == "NoActivityAlertReport" || reportSchedule.ReportName == "BNANoActivityAlertReport" || reportSchedule.ReportName == "CDMNoActivityAlertReport")
                            rptDoc.SetParameterValue("generatedFor", reportTask.ScheduleDate.ToString("dd/MM/yyyy"));


                        else if (
                            reportSchedule.ReportName == "PNCDepositSummaryForBNA" ||
                            reportSchedule.ReportName == "PNCDepositSummaryForSDMBNA" ||
                            reportSchedule.ReportName == "PNCDepositSummaryForSDMCPM" ||


                            reportSchedule.ReportName == "PNCTop5IncidentsAnalysisForBNA" ||
                            reportSchedule.ReportName == "PNCTop5IncidentsAnalysisForSDMBNA" ||
                            reportSchedule.ReportName == "PNCTop5IncidentsAnalysisForSDMCPM" ||


                            reportSchedule.ReportName == "PNCRejectReasonsForBNA" ||
                            reportSchedule.ReportName == "PNCRejectReasonsForCPM" ||
                            reportSchedule.ReportName == "PNCRejectReasonsForSDM" ||

                            reportSchedule.ReportName == "PNCRejectReasonsForSDMBNA" ||
                            reportSchedule.ReportName == "PNCRejectReasonsForSDMCPM" ||


                            reportSchedule.ReportName == "PNCWeeklyAnalysisForBNA" ||
                            reportSchedule.ReportName == "PNCWeeklyAnalysisForCPM" ||
                            reportSchedule.ReportName == "PNCWeeklyAnalysisForSDM" ||
                            reportSchedule.ReportName == "PNCWeeklyAnalysisForSDMBNA" ||
                            reportSchedule.ReportName == "PNCWeeklyAnalysisForSDMCPM" ||


                            reportSchedule.ReportName == "PNCDepositDetailForBNA" ||
                            reportSchedule.ReportName == "PNCDepositDetailForSDMBNA" ||
                            reportSchedule.ReportName == "PNCDepositDetailForSDMCPM" ||

                            reportSchedule.ReportName == "PNCMeanTimeToFailureAnalysisForBNA" ||
                            reportSchedule.ReportName == "PNCMeanTimeToFailureAnalysisForSDMBNA" ||
                            reportSchedule.ReportName == "PNCMeanTimeToFailureAnalysisForSDMCPM" ||

                            reportSchedule.ReportName == "PNCMeanTimeToIncidentFailureAnalysisForBNA" ||
                            reportSchedule.ReportName == "PNCMeanTimeToIncidentFailureAnalysisForSDMBNA" ||
                            reportSchedule.ReportName == "PNCMeanTimeToIncidentFailureAnalysisForSDMCPM" ||



                            reportSchedule.ReportName == "DepositPositionReport" ||
                            reportSchedule.ReportName == "DeadATMsReport" ||
                            reportSchedule.ReportName == "CassetteFaultySummaryReport" ||
                            reportSchedule.ReportName == "ReplenishmentReturnedReport" ||

                            reportSchedule.ReportName == "OrderCancelledEnoughCashOnATM" ||
                            reportSchedule.ReportName == "CPMCounterDetailReport" ||
                            reportSchedule.ReportName == "CPMCounterSummaryReport" ||
                            reportSchedule.ReportName == "BNACounterDetailReport" ||
                            reportSchedule.ReportName == "BNACounterSummaryReport" ||
                            reportSchedule.ReportName == "TaskStatusReport" ||
                            reportSchedule.ReportName == "TerminalDowntimeReport" ||
                            reportSchedule.ReportName == "ReplenishmentWithoutTestCash" ||
                            reportSchedule.ReportName == "ReplenishmentSummaryReport" ||
                            reportSchedule.ReportName == "ScheduleTrackingReport" ||
                            reportSchedule.ReportName == "CashOrderReport" ||
                            reportSchedule.ReportName == "DateTimeSyncReport"
                                    || reportSchedule.ReportName == "LowBalanceReport"
                            || reportSchedule.ReportName == "MinNotesThresholdReport"

                            || reportSchedule.ReportName == "CurrentLowBalanceReport"
                                    || reportSchedule.ReportName == "OutOfCashReport"
                            || reportSchedule.ReportName == "CurrentOutOfCashReport"
                                    || reportSchedule.ReportName == "PurgeBinAlertsReport"
                                    || reportSchedule.ReportName == "CashWithdrawalsReport"
                                    || reportSchedule.ReportName == "CassetteDispensingReport"
                            || reportSchedule.ReportName == "CashPositionsReport"
                            || reportSchedule.ReportName == "CurrentCashPositionsReport"
                            || reportSchedule.ReportName == "CashWithdrawalsSummaryReport"
                            || reportSchedule.ReportName == "CardCaptureReport"
                            || reportSchedule.ReportName == "MemberBankTransactionReport"
                            || reportSchedule.ReportName == "AlertsReport"

                            || reportSchedule.ReportName == "ReplenishmentRemainingNotesReport"
                            || reportSchedule.ReportName == "CashUtilizationReport"
                            || reportSchedule.ReportName == "ATMSummaryReport"
                            || reportSchedule.ReportName == "SwitchDispensingReport")
                        {
                            if (reportSchedule.ReportName == "PNCWeeklyAnalysisForBNA" || reportSchedule.ReportName == "PNCWeeklyAnalysisForCPM" || reportSchedule.ReportName == "PNCWeeklyAnalysisForSDM" || reportSchedule.ReportName == "PNCWeeklyAnalysisForSDMBNA" ||
                            reportSchedule.ReportName == "PNCWeeklyAnalysisForSDMCPM")
                            {
                                if (totalDeposits + totalRejects != 0)
                                {
                                    rptDoc.SetParameterValue("accPerc", Math.Round((decimal)totalDeposits / (totalDeposits + totalRejects) * 100, 2));
                                    rptDoc.SetParameterValue("rejPerc", Math.Round((decimal)totalRejects / (totalDeposits + totalRejects) * 100, 2));
                                }
                                else
                                {
                                    rptDoc.SetParameterValue("accPerc", 0);
                                    rptDoc.SetParameterValue("rejPerc", 0);
                                }
                            }

                            else if (reportSchedule.ReportName == "SwitchDispensingReport")
                                rptDoc.Subreports[0].SetDataSource(ds);

                            else if (reportSchedule.ReportName == "BNACounterSummaryReport")
                                rptDoc.Subreports[0].SetDataSource(ds.Tables[1]);

                            else if (reportSchedule.ReportName == "CPMCounterSummaryReport")
                                rptDoc.Subreports[0].SetDataSource(ds.Tables[1]);

                            //Change on 12/06
                            //rptDoc.SetParameterValue("FromDate", isWeeklyAnalysis?gFrom: reportTask.ScheduleDate);
                            //rptDoc.SetParameterValue("ToDate", isWeeklyAnalysis?gTo:reportTask.ScheduleDate);


                            if (reportSchedule.IsWeekly || reportSchedule.IsMonthly)
                            {
                                rptDoc.SetParameterValue("FromDate", fromDate);
                                rptDoc.SetParameterValue("ToDate", toDate);
                            }
                            //else if (reportSchedule.IsMonthly)
                            //{

                            //    rptDoc.SetParameterValue("FromDate", fromDate);
                            //    rptDoc.SetParameterValue("ToDate", toDate);
                            //    //isReportParamAttached = true;
                            //}
                            else if (reportSchedule.MinutesToScheduleAgain.Value > 1440)
                            {
                                DateTime startDate = new DateTime(gScheduleDate.Year, gScheduleDate.Month, 1);
                                DateTime endDate = startDate.AddMonths(1).AddDays(-1);


                                rptDoc.SetParameterValue("FromDate", isWeeklyAnalysis ? gFrom : startDate);
                                rptDoc.SetParameterValue("ToDate", isWeeklyAnalysis ? gTo : endDate);
                            }
                            else
                            {
                                //Change done on 2/12/2014
                                //rptDoc.SetParameterValue("FromDate", reportSchedule.ReportNextGeneratedAt.AddDays(-1));
                                //rptDoc.SetParameterValue("ToDate", reportSchedule.ReportNextGeneratedAt.AddDays(-1));

                                rptDoc.SetParameterValue("FromDate", reportTask.ScheduleDate);
                                rptDoc.SetParameterValue("ToDate", reportTask.ScheduleDate);

                            }

                            rptDoc.SetParameterValue("GeneratedBy", "System");
                            rptDoc.SetParameterValue("total", ds.Tables[0].Rows.Count);
                        }



                        if (reportSchedule.ReportExportType == 1)
                            rptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, reportTask.FilePathAttachment);
                        else if (reportSchedule.ReportExportType == 2)
                            rptDoc.ExportToDisk(ExportFormatType.Excel, reportTask.FilePathAttachment);
                        else
                        {
                            string[] paths = reportTask.FilePathAttachment.Split(';');
                            rptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, paths[0]);
                            rptDoc.ExportToDisk(ExportFormatType.Excel, paths[1]);


                        }



                        reportTask.Status = "Processed";
                        reportTask.RetryCount = reportSchedule.RetryCount;
                        reportTask.Save();
                        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Processed " + reportSchedule.ReportFriendlyName);
                        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        //{
                        //    ReportTaskDetail reportTaskDetail = new ReportTaskDetail();
                        //    reportTaskDetail.ReportTaskId = reportTask.ReportTaskId;
                        //    reportTaskDetail.AtmId = Atm.LoadAtm("title='" + ds.Tables[0].Rows[i][0] + "'").ATMId;
                        //    reportTaskDetail.Save();
                        //}
                    }
                    else
                    {
                        reportTask.FilePathAttachment = "";
                        reportTask.Status = "Processed";
                        reportTask.RetryCount = reportSchedule.RetryCount;
                        reportTask.Save();
                    }
                }
            }
            finally
            {
                if (rptDoc != null)
                    rptDoc.Close();
            }
            LogableTask.LogMonoActivityTask("ExecuteTask", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Exit");
        }

        private void EmailReport()
        {
            LogableTask task = LogableTask.NewTask("EmailReport");
            ReportTask.ReportTaskReader reader = null;
            try
            {
                //if (appSettings.SmtpServer == null || appSettings.SmtpPort == null)
                //    throw new Exception("Configuration is missing for sending email");
                //SmtpClient client = new SmtpClient(appSettings.SmtpServer, (int)appSettings.SmtpPort);


                reader = ReportTask.ExecuteReader("status = 'Processed' and retry_count>0");
                while (reader.Read())
                {
                    try
                    {
                        reader.CurrentReportTask.RetryCount--;
                        reader.CurrentReportTask.LastInvokedAt = DateTime.Now;
                        reader.CurrentReportTask.Save();


                        ReportSchedule reportSchedule = ReportSchedule.LoadReportScheduleByPk(reader.CurrentReportTask.ReportScheduleId);
                        Region organizaton = Region.LoadRegionByPk(reportSchedule.OrganizationId.Value);
                        if (organizaton.SmtpServer == null || organizaton.SmtpPort == null)
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Configuration is missing for sending email");
                            continue;
                        }
                        SmtpClient client = null;

                        //if (organizaton.SmtpPort.Value == 25)
                        //    client = new SmtpClient(organizaton.SmtpServer);
                        //else
                        client = new SmtpClient(organizaton.SmtpServer, (int)organizaton.SmtpPort);


                        if (System.Configuration.ConfigurationManager.AppSettings["isPasswordRequired"] == "1")
                        {
                            NetworkCredential netCredential = new NetworkCredential(organizaton.SmtpUsername, Cryptic.DecryptString(organizaton.SmtpPassword));
                            client.Credentials = netCredential;
                            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "password set");
                        }


                        MailMessage mailMsg = new MailMessage();
                        mailMsg.From = new MailAddress(organizaton.SmtpUsername);



                        if (reader.CurrentReportTask.FilePathAttachment.Length == 0)
                            mailMsg.Subject = "CCMS - " + reportSchedule.ReportFriendlyName;
                        else
                        {
                            if (reportSchedule.IsWeekly || reportSchedule.IsMonthly)
                                mailMsg.Subject = "CCMS - " + reportSchedule.ReportFriendlyName + " generated for " + reader.CurrentReportTask.FromDate.Value.ToString("dd/MM/yyyy") + " - " + reader.CurrentReportTask.ToDate.Value.ToString("dd/MM/yyyy");
                            else
                                mailMsg.Subject = "CCMS - " + reportSchedule.ReportFriendlyName + " generated for " + reader.CurrentReportTask.ScheduleDate.ToString("dd/MM/yyyy");
                        }
                        string[] receipients = reportSchedule.ReportReceipients.Split(';');
                        foreach (string receipient in receipients)
                        {
                            mailMsg.To.Add(new MailAddress(receipient));
                        }

                        //helperCommand.CommandText = "select atm_id from report_task_detail where report_task_id=" + reader.CurrentReportTask.ReportTaskId;
                        //SqlDataReader reportTaskDetailReader = helperCommand.ExecuteReader();
                        //while (reportTaskDetailReader.Read())
                        //{

                        //    helperCommand1.CommandText = "select user_id from user_ATMs where atm_id=" + reportTaskDetailReader.GetInt32(0);
                        //    SqlDataReader userReader = helperCommand1.ExecuteReader();
                        //    while (userReader.Read())
                        //    {
                        //        AppUser user = AppUser.LoadAppUserByPk(userReader.GetInt32(0));
                        //        if (user.UserEmail.Length > 0)
                        //        {
                        //            MailAddress mailAddress = new MailAddress(user.UserEmail);
                        //            if (!mailMsg.To.Contains(mailAddress))
                        //                mailMsg.To.Add(mailAddress);
                        //        }
                        //        else
                        //            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "user email is not defined" + user.UserLogin);
                        //    }
                        //    userReader.Close();
                        //}
                        //reportTaskDetailReader.Close();

                        mailMsg.Body = "This is automatically generated email from CCMS Server<br/>Report Title : " + reportSchedule.ReportFriendlyName + "<br/>";

                        if (reader.CurrentReportTask.FilePathAttachment.Length == 0)
                            //alertType.AlertDefaultText.Replace("[ALERT_ID]", reader.GetInt32(0).ToString()).Replace("[GENERATED_AT]", reader.GetDateTime(3).ToString("dd/MM/yyyy HH:mm:ss")) + "<br/>" + alertType.AlertAdditionalText + "<br/>";
                            mailMsg.Body += "<b>No Data found to generate report.</b>";

                        mailMsg.Body += "<br/><br/>";
                        mailMsg.IsBodyHtml = true;
                        Attachment attachment = null;
                        if (reader.CurrentReportTask.FilePathAttachment.Length > 0)
                        {

                            string[] paths = reader.CurrentReportTask.FilePathAttachment.Split(';');
                            foreach (string path in paths)
                            {
                                if (!File.Exists(path))
                                    throw new Exception(string.Format("File[{0}] does not exists", path));
                                attachment = new Attachment(path);
                                mailMsg.Attachments.Add(attachment);

                            }
                        }
                        client.Timeout = 300 * 1000;
                        client.Send(mailMsg);
                        reader.CurrentReportTask.Status = "Sent";
                        reader.CurrentReportTask.FailureReason = "";
                        reader.CurrentReportTask.Save();
                        for (int i = 0; i < mailMsg.Attachments.Count; i++)
                            mailMsg.Attachments[i].Dispose();
                        //if (attachment != null)
                        //    attachment.Dispose();
                        if (reader.CurrentReportTask.FilePathAttachment.Length > 0)
                        {
                            string[] paths = reader.CurrentReportTask.FilePathAttachment.Split(';');
                            foreach (string path in paths)
                                File.Delete(path);
                        }

                    }

                    catch (Exception ex)
                    {
                        try
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                            string msg = ex.Message;
                            if (ex.InnerException != null)
                                msg += "inner exception: " + ex.InnerException.Message + "stack trace: " + ex.InnerException.StackTrace;

                            if (msg.Length > 500)
                                msg = msg.Substring(0, 499);
                            // else
                            //     msg = ex.Message;
                            msg = msg.Replace("'", "''");
                            if (reader != null)
                            {
                                reader.CurrentReportTask.FailureReason = msg;
                                if (reader.CurrentReportTask.RetryCount == 0)
                                    reader.CurrentReportTask.Status = "Retries Exhausted";
                                reader.CurrentReportTask.Save();
                            }
                        }
                        catch (Exception innerException)
                        {
                            EventLog.WriteEntry("CurrencyReportSchedular", String.Format("{0} {1}", innerException.Message, innerException.StackTrace), EventLogEntryType.Error);
                        }

                    }
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                //if (helperCommand != null)
                //    if (helperCommand.Connection != null)
                //        helperCommand.Connection.Close();

                //if (helperCommand1 != null)
                //    if (helperCommand1.Connection != null)
                //        helperCommand1.Connection.Close();

                task.EndTask();

            }
        }
        private DataTable GetDataTable(string SQL)
        {
            SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
            cmd.CommandText = SQL;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        private DataTable GetCheckAcceptorGraph(int type)
        {
            string SQL = "select top 5 comment comment_text,count(*) counter from ej_parsed_cpm_transaction inner join atm on  ej_parsed_cpm_transaction.atm_id = atm.atm_id" +
                       " where 1=1 " + GetFilter() +
                       " and comment is not null and len(comment)>1 group by comment order by count(*) desc";
            DataTable dt = GetDataTable(SQL);
            //   AddTsn(ref dt, "ej_parsed_cpm_transaction");
            return dt;

        }
        private DataTable GetCashAcceptorDataTable()
        {
            string SQL = "select top 5 comment comment_text,count(*) counter from ej_parsed_bna_transaction inner join atm on  ej_parsed_bna_transaction.atm_id = atm.atm_id" +
                       " where 1=1 " + GetFilter() +
                       " and comment is not null and len(comment)>1 group by comment order by count(*) desc";
            DataTable dt = GetDataTable(SQL);
            return dt;
        }
        private DataTable GetNoteRejectReasonsDataTable()
        {
            string SQL = "select comment comment_text,count(*) counter from ej_parsed_bna_transaction inner join atm on  ej_parsed_bna_transaction.atm_id = atm.atm_id" +
                       " where status = 'Failed' " + GetFilter() +
                       " and comment is not null and len(comment)>1 group by comment";
            DataTable dt = GetDataTable(SQL);

            return dt;
        }
        private DataTable GetCPMRejectCausesDataTable(int type)
        {
            string SQL = "select comment comment_text ,count(*) counter from ej_parsed_cpm_transaction inner join atm on  ej_parsed_cpm_transaction.atm_id = atm.atm_id" +
                       " where status = 'Failed' " + GetFilter() + " and len(comment)>1 group by comment";
            DataTable dt = GetDataTable(SQL);

            return dt;

        }
        private DataTable GetSDMRejectCausesDataTable(int type)
        {
            string SQL = "select comment comment_text ,count(*) counter from ej_parsed_cpm_transaction inner join atm on  ej_parsed_cpm_transaction.atm_id = atm.atm_id" +
                       " where status = 'Failed' " + GetFilter() + " and len(comment)>1 group by comment";
            DataTable dt = GetDataTable(SQL);

            SQL = "select comment comment_text,count(*) counter from ej_parsed_bna_transaction inner join atm on  ej_parsed_bna_transaction.atm_id = atm.atm_id" +
                   " where status = 'Failed' " + GetFilter() +
                   " and comment is not null and len(comment)>1 group by comment";
            DataTable dt1 = GetDataTable(SQL);
            dt.Merge(dt1);
            return dt;

        }
        private void ExportCashOrder(DateTime scheduleDate, ReportTask reportTask)
        {
            SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
            cmd.CommandText = @"select c.order_number,c.cassette1_denomination,c.cassette2_denomination,
                                    c.cassette3_denomination,c.cassette4_denomination,c.cassette5_denomination,c.cassette6_denomination,
                                    c.cassette7_denomination,title, ip , cash_order_id,cash_order_type,cash_order_datetime,
                                    cassette1_suggested_notes,cassette2_suggested_notes,cassette3_suggested_notes,
                                    cassette4_suggested_notes,cassette5_suggested_notes,cassette6_suggested_notes,cassette7_suggested_notes,
                                    c.cassette1_denomination*cassette1_suggested_notes+
                                    c.cassette2_denomination*cassette2_suggested_notes+
                                    c.cassette3_denomination*cassette3_suggested_notes+
                                    c.cassette4_denomination*cassette4_suggested_notes+
                                    c.cassette5_denomination*cassette5_suggested_notes+
                                    c.cassette6_denomination*cassette6_suggested_notes+
                                    c.cassette7_denomination*cassette7_suggested_notes sum,c.creation_time,c.replenishment_datetime,c.is_hold,cit_atm_title,gl_number,location,city
                                      from cash_orders c, atm, app_user where app_user.user_id = c.created_by and c.atm_id = atm.atm_id and c.is_cancelled=0  
                                      and atm.is_active = 1 and cash_order_datetime >= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + "',103) " +
                                        " and cash_order_datetime <= convert(datetime,'" + scheduleDate.ToString("dd/MM/yyyy") + " 23:59:59',103) ";
                                        
                
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);



            //       System.Data.DataTable dt = (System.Data.DataTable)Cache["dtCashOrders"];
            if (dt.Rows.Count > 0)
            {
                
                //AppSetting appSetting = (AppSetting)Application[ApplicationVars.AppSettings.ToString()];
                string zipFilePath = appSettings.TemporaryFolder + "\\Template.zip";
                if (!File.Exists(zipFilePath))
                    throw new Exception("Template file does not exists.Please upload template file before generating report");
                string extractFilePath = appSettings.TemporaryFolder + "\\CashOrders";

                if (Directory.Exists(extractFilePath))
                    Directory.Delete(extractFilePath, true);

                if (!Directory.Exists(extractFilePath))
                    Directory.CreateDirectory(extractFilePath);

                Avanza.CCMS.DAL.Utility.ExpandFolder(zipFilePath, extractFilePath);

                Avanza.CCMS.DAL.Utility.UpdateSheet3(extractFilePath + "\\xl\\worksheets\\sheet3.xml", scheduleDate, dt);

                if (File.Exists(extractFilePath + "\\xl\\calcChain.xml"))
                    File.Delete(extractFilePath + "\\xl\\calcChain.xml");

                Avanza.CCMS.DAL.Utility.UpdateWorkSheet(extractFilePath + "\\xl\\workbook.xml");
                Avanza.CCMS.DAL.Utility.ZipFolder(extractFilePath);
                if (File.Exists(extractFilePath + ".xlsx"))
                    File.Delete(extractFilePath + ".xlsx");
                File.Move(extractFilePath + ".zip", extractFilePath + ".xlsx");
                reportTask.FilePathAttachment = extractFilePath + ".xlsx";
            }
        }

    }
}
