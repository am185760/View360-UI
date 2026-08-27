using System;
using System.Data;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Win32;
using Encryption;
using ServicesDAL;
using System.Diagnostics;
using System.Reflection;

namespace CCMSUI.CCMS
{
    public partial class TempRp1 : System.Web.UI.Page
    {
        ReportDocument rptDoc;

        //private readonly string reportDateFormat = System.Configuration.ConfigurationManager.AppSettings["reportDateFormat"];
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (this.rptDoc != null)
            {
                this.rptDoc.Close();
                this.rptDoc.Dispose();
            }
            //Session["TaskStatusReportData"] = null;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            string connectionStr = (string)Registry.LocalMachine.OpenSubKey(@"SOFTWARE\NCR\EV360", false).GetValue("ConnectionString", "");
            connectionStr = Cryptic.DecryptString(connectionStr, Helper.ConstractKey(false)).Replace("\0", "");
            ConnectionFactory.Initialize(connectionStr, true, DatabaseName.Core);
            AppSetting appSetting = AppSetting.LoadAppSetting("1=1");
            string logPath = appSetting.LogFilePath;
            try
            {
                XmlLogWriter.InitXmlLogWriter(logPath + "\\ReportingApi_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
            }
            catch (Exception ex) { }

            LogableTask.LogMonoActivityTask("Page_Init", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Entered in ReportPopup Page_Init");

            try
            {
                StringBuilder builder = new StringBuilder();
                string ReportName = (string)Request.Params["Report"];
                string ReportTitle = (string)Request.Params["ReportTitle"];
                string FromDate = HttpUtility.HtmlDecode((string)Request.Params["FromDate"]);
                string ToDate = HttpUtility.HtmlDecode((string)Request.Params["ToDate"]);
                string GeneratedBy = (string)Request.Params["GeneratedBy"];
                string UserId = (string)Request.Params["userId"];
                string ArchiveYear = (string)Request.Params["ArchiveYear"];
                var data = RedisConnectorHelper.ReadData(Request.Params["redisKey"]);


                if (ReportName == null)
                {
                    ShowAlertMessage("Invalid Request");
                    LogableTask.LogMonoActivityTask("ReadData", MethodBase.GetCurrentMethod(), TraceLevel.Error, "ReportName came null from param, so Invalid Request");
                    return;
                }
                if (Request.Params["redisKey"] == null && Cache["data"] == null)
                {
                    ShowAlertMessage("Invalid Request");
                    LogableTask.LogMonoActivityTask("ReadData", MethodBase.GetCurrentMethod(), TraceLevel.Error, "DataTable came null from param, so Invalid Request");
                    return;
                }


                LogableTask.LogMonoActivityTask("Page_Init", MethodBase.GetCurrentMethod(), TraceLevel.Info, "going in RedisConnectorHelper.ReadData");
                var SubReportData = RedisConnectorHelper.ReadData(Request.Params["redisKeySubReport"]);
                LogableTask.LogMonoActivityTask("Page_Init", MethodBase.GetCurrentMethod(), TraceLevel.Info, "returned from RedisConnectorHelper.ReadData");


                rptDoc = new ReportDocument();

                ParameterFields pFields = new ParameterFields();
                ParameterField pField = new ParameterField();
                ParameterDiscreteValue disVal = new ParameterDiscreteValue();
                ParameterRangeValue rVal = new ParameterRangeValue();


                rptDoc.Load(Server.MapPath("Reports/" + ReportName));


                if (ReportName == "ATMWithoutWithdrawal.rpt")
                {
                    pField = new ParameterField();
                    disVal = new ParameterDiscreteValue();
                    pField.ParameterFieldName = "generatedFor";
                    disVal.Value = DateTime.ParseExact(FromDate, "MM/dd/yyyy", null).ToString("dd/MM/yyyy");
                    //disVal.Value = DateTime.ParseExact(FromDate, "MM/dd/yyyy", null);
                    pField.CurrentValues.Add(disVal);

                    pFields.Add(pField);
                    //Removed for NBE
                    //pField = new ParameterField();
                    //disVal = new ParameterDiscreteValue();
                    //pField.ParameterFieldName = "total";
                    //disVal.Value = total;
                    //pField.CurrentValues.Add(disVal);
                    //pFields.Add(pField);

                    //CrystalReportViewer1.ParameterFieldInfo = pFields;
                }

                else if (ReportName.Contains("BankSettlementsDR.rpt"))
                {
                    pField = new ParameterField();
                    disVal = new ParameterDiscreteValue();
                    pField.ParameterFieldName = "ReportDate";
                    disVal.Value = (string)Request.Params["rDate"];
                    pField.CurrentValues.Add(disVal);
                    pFields.Add(pField);

                    pField = new ParameterField();
                    disVal = new ParameterDiscreteValue();
                    pField.ParameterFieldName = "opening_balance";
                    disVal.Value = (string)Request.Params["balance"];
                    pField.CurrentValues.Add(disVal);
                    pFields.Add(pField);


                    pField = new ParameterField();
                    disVal = new ParameterDiscreteValue();
                    pField.ParameterFieldName = "cash_Recv";
                    disVal.Value = (string)Request.Params["cashRecv"];
                    pField.CurrentValues.Add(disVal);
                    pFields.Add(pField);


                    pField = new ParameterField();
                    disVal = new ParameterDiscreteValue();
                    pField.ParameterFieldName = "cash_Ret";
                    disVal.Value = (string)Request.Params["cashRet"];
                    pField.CurrentValues.Add(disVal);
                    pFields.Add(pField);

                    pField = new ParameterField();
                    disVal = new ParameterDiscreteValue();
                    pField.ParameterFieldName = "title";
                    disVal.Value = (string)Request.Params["title"];
                    pField.CurrentValues.Add(disVal);
                    pFields.Add(pField);


                    CrystalReportViewer1.ParameterFieldInfo = pFields;
                }
                else
                {
                    if ((string)Request.Params["Bypass"] == "0" || (string)Request.Params["Bypass"] == null)
                    {


                        pField = new ParameterField();
                        disVal = new ParameterDiscreteValue();
                        pField.ParameterFieldName = "FromDate";
                        //disVal.Value = DateTime.Parse(FromDate);
                        if (ReportName.Contains("SuspiciousReplenishment"))
                            disVal.Value = DateTime.ParseExact(FromDate, "MM/dd/yyyy hh:mm:ss", null);
                        else
                            disVal.Value = DateTime.ParseExact(FromDate, "MM/dd/yyyy", null);

                        pField.CurrentValues.Add(disVal);
                        pFields.Add(pField);

                        pField = new ParameterField();
                        disVal = new ParameterDiscreteValue();
                        pField.ParameterFieldName = "ToDate";
                        // disVal.Value = DateTime.Parse(ToDate);
                        if (ReportName.Contains("SuspiciousReplenishment"))
                            disVal.Value = DateTime.ParseExact(ToDate, "MM/dd/yyyy hh:mm:ss", null);
                        else
                            disVal.Value = DateTime.ParseExact(ToDate, "MM/dd/yyyy", null);

                        pField.CurrentValues.Add(disVal);
                        pFields.Add(pField);

                        pField = new ParameterField();
                        disVal = new ParameterDiscreteValue();
                        pField.ParameterFieldName = "GeneratedBy";
                        disVal.Value = GeneratedBy;
                        pField.CurrentValues.Add(disVal);
                        pFields.Add(pField);



                        if (ReportName.Contains("CashPositionsRpt.rpt") || ReportName.Contains("CashWithdrawals.rpt") || ReportName.Contains("ReplenishmentReturned.rpt") || ReportName.Contains("SuspiciousReplenishment.rpt"))
                        {
                            if (!ReportName.Contains("NoCashWithdrawals"))
                            {
                                pField = new ParameterField();
                                disVal = new ParameterDiscreteValue();
                                pField.ParameterFieldName = "suppressDetail";
                                disVal.Value = Request.Params["suppressDetail"];
                                pField.CurrentValues.Add(disVal);
                                pFields.Add(pField);
                            }

                        }

                        //pField = new ParameterField();
                        //disVal = new ParameterDiscreteValue();
                        //pField.ParameterFieldName = "suppressGroup";
                        //disVal.Value = true;
                        //pField.CurrentValues.Add(disVal);
                        //pFields.Add(pField);


                        if (ReportName == "PNCNotesDepWeeklyAnalysis.rpt")
                        {
                            pField = new ParameterField();
                            disVal = new ParameterDiscreteValue();
                            pField.ParameterFieldName = "accPerc";
                            disVal.Value = decimal.Parse(Request.Params["accPerc"]);
                            pField.CurrentValues.Add(disVal);
                            pFields.Add(pField);

                            pField = new ParameterField();
                            disVal = new ParameterDiscreteValue();
                            pField.ParameterFieldName = "rejPerc";
                            disVal.Value = decimal.Parse(Request.Params["rejPerc"]);
                            pField.CurrentValues.Add(disVal);
                            pFields.Add(pField);
                        }
                        //else if (ReportName == "RepExceptionByTimeReport.rpt")
                        //{
                        //    pField = new ParameterField();
                        //    disVal = new ParameterDiscreteValue();
                        //    pField.ParameterFieldName = "ExecutionTimeLimit";
                        //    disVal.Value = (string)Request.Params["ExecutionTimeLimit"];
                        //    pField.CurrentValues.Add(disVal);
                        //    pFields.Add(pField);
                        //}

                    }
                }



                rptDoc.SummaryInfo.ReportTitle = ReportTitle;
                DataTable dt = new DataTable();
                DataTable dtSubReport = new DataTable();
                DataSet dsSubReport = null;
                //if (ReportName.Contains("EjBnaTransactions") && data != null)
                //{
                //    var decodedHtmlData = HttpUtility.HtmlDecode(data);
                //    dt = JsonConvert.DeserializeObject<DataTable>(decodedHtmlData);
                //}
                if (data != null && data != string.Empty)
                {
                    dt = JsonConvert.DeserializeObject<DataTable>(data);
                }

                if (SubReportData != null && SubReportData != string.Empty)
                {
                    dtSubReport = JsonConvert.DeserializeObject<DataTable>(SubReportData);
                }

                if (ReportName.Contains("TaskStatus"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"TaskStatusReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"TaskStatusReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"TaskStatusReportData_{UserId}"] = dt;


                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "TaskStatus";
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("AuditLogRpt"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"AuditLogReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"AuditLogReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"AuditLogReportData_{UserId}"] = dt;


                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "DataTable1";
                    rptDoc.SetDataSource(ds);

                    #region AuditLogSubReport
                    if (dtSubReport?.Rows.Count == 0 && Cache[$"AuditLogSubReport_{UserId}"] != null)
                    {
                        dtSubReport = ((DataTable)Cache[$"AuditLogSubReport_{UserId}"]).Copy();
                    }


                    if (dtSubReport != null)
                    {
                        Cache[$"AuditLogSubReport_{UserId}"] = dtSubReport;

                        dsSubReport = new DataSet();
                        dtSubReport.TableName = "DataTable1";
                        dsSubReport.Tables.Add(dtSubReport);
                    }
                    #endregion
                }
                else if (ReportName.Contains("DeadATMsReport"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"DeadATMRptData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"DeadATMRptData_{UserId}"]).Copy();
                    }
                    Cache["data"] = Cache[$"DeadATMRptData_{UserId}"] = dt;
                    DataSet ds = new DataSet();
                    dt.TableName = "dtDeadATMs";
                    ds.Tables.Add(dt);
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("ATMWithoutWithdrawal"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"ATMWithoutWithdrawalData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"ATMWithoutWithdrawalData_{UserId}"]).Copy();
                    }
                    Cache["data"] = Cache[$"ATMWithoutWithdrawalData_{UserId}"] = dt;
                    DataSet ds = new DataSet();
                    dt.TableName = "DataTable1";
                    ds.Tables.Add(dt);
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("PurgeBinThresholdReport"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"PurgeBinThresholdReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"PurgeBinThresholdReportData_{UserId}"]).Copy();
                    }
                    Cache["data"] = Cache[$"PurgeBinThresholdReportData_{UserId}"] = dt;
                    DataSet ds = new DataSet();
                    dt.TableName = "DataTable1";
                    ds.Tables.Add(dt);
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("CashPositionsRpt"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"CashPositionsRptData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"CashPositionsRptData_{UserId}"]).Copy();
                    }
                    Cache["data"] = Cache[$"CashPositionsRptData_{UserId}"] = dt;
                    DataSet ds = new DataSet();
                    dt.TableName = "DataTable1";
                    ds.Tables.Add(dt);
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("LowBalanceReport") && ReportTitle.Contains("Out Of Cash Report"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"OutOfCashReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"OutOfCashReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"OutOfCashReportData_{UserId}"] = dt;

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "DataTable1";
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("LowBalanceReport"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"LowBalanceReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"LowBalanceReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"LowBalanceReportData_{UserId}"] = dt;

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "DataTable1";
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("EjBnaTransactionsSummary"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"EjBnaTransactionsSummary_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"EjBnaTransactionsSummary_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"EjBnaTransactionsSummary_{UserId}"] = dt;

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "DataTable1";
                    rptDoc.SetDataSource(ds);
                    #region BnaNotesUtilizationDetail
                    if (dtSubReport?.Rows.Count == 0 && Cache[$"BnaNotesUtilizationDetail_{UserId}"] != null)
                    {
                        dtSubReport = ((DataTable)Cache[$"BnaNotesUtilizationDetail_{UserId}"]).Copy();
                    }

                    if (dtSubReport != null)
                    {
                        Cache[$"BnaNotesUtilizationDetail_{UserId}"] = dtSubReport;

                        dsSubReport = new DataSet();
                        dtSubReport.TableName = "DataTable1";
                        dsSubReport.Tables.Add(dtSubReport);
                    }
                    #endregion
                }
                else if (ReportName.Contains("EjBnaTransactions"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"EjBnaTransactions_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"EjBnaTransactions_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"EjBnaTransactions_{UserId}"] = dt;

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "DataTable1";
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("BNACounterSummaryRpt") || ReportName.Contains("BNACounterRpt"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"BNACounterSummaryReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"BNACounterSummaryReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"BNACounterSummaryReportData_{UserId}"] = dt;

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "BNACounter";
                    rptDoc.SetDataSource(ds);
                    ///For Sub Report
                    #region BnaCounterSubReport
                    if (dtSubReport?.Rows.Count == 0 && Cache[$"BNACounterSubReporttData_{UserId}"] != null)
                    {
                        dtSubReport = ((DataTable)Cache[$"BNACounterSubReporttData_{UserId}"]).Copy();
                    }


                    if (dtSubReport != null)
                    {
                        Cache[$"BNACounterSubReporttData_{UserId}"] = dtSubReport;

                        dsSubReport = new DataSet();
                        dtSubReport.TableName = "DataTable1";
                        dsSubReport.Tables.Add(dtSubReport);
                    }
                    #endregion
                    //}
                }
                else if (ReportName.Contains("CashUtilization"))
                {

                    if (dt.Rows.Count == 0 && Cache[$"CashUtilizationReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"CashUtilizationReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"CashUtilizationReportData_{UserId}"] = dt;

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "Summary";
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("ReplenishmentReturned"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"ReplenishmentReturnedReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"ReplenishmentReturnedReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"ReplenishmentReturnedReportData_{UserId}"] = dt;

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "DataTable1";
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("Alerts"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"AlertMonitoringReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"AlertMonitoringReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"AlertMonitoringReportData_{UserId}"] = dt;


                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "DataTable1";
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("SuspiciousReplenishment"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"ReplenishmentReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"ReplenishmentReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"ReplenishmentReportData_{UserId}"] = dt;


                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "SuspiciousReplenishment";
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("NoCashWithdrawals"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"NoCashWithdrawalReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"NoCashWithdrawalReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"NoCashWithdrawalReportData_{UserId}"] = dt;

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "DataTable1";
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("CashWithdrawals"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"CashWithdrawalReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"CashWithdrawalReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"CashWithdrawalReportData_{UserId}"] = dt;

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "DataTable1";
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("CashWithdrawalSummary"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"CashWithdrawalSummaryReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"CashWithdrawalSummaryReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"CashWithdrawalSummaryReportData_{UserId}"] = dt;

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "DataTable1";
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("UserList"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"UsersReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"UsersReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"UsersReportData_{UserId}"] = dt;


                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "DataTable1";
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("GroupList"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"GroupsReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"GroupsReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"GroupsReportData_{UserId}"] = dt;

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "DataTable1";
                    rptDoc.SetDataSource(ds);
                }
                else if (ReportName.Contains("AtmSummary"))
                {
                    if (dt.Rows.Count == 0 && Cache[$"AtmSummaryReportData_{UserId}"] != null)
                    {
                        dt = ((DataTable)Cache[$"AtmSummaryReportData_{UserId}"]).Copy();
                    }

                    Cache["data"] = Cache[$"AtmSummaryReportData_{UserId}"] = dt;

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.Tables[0].TableName = "DataTable1";
                    rptDoc.SetDataSource(ds);
                }

                if (rptDoc.Subreports.Count > 0 && dsSubReport != null)
                    rptDoc.Subreports[0].SetDataSource(dsSubReport);

                //}
                //rptDoc.SetDataSource((DataSet)Session[SessionVars.dtReportDataSet.ToString()]);

                //if (rptDoc.Subreports.Count > 0 && Session["subReport"] != null)
                //    rptDoc.Subreports[0].SetDataSource((DataSet)Session["subReport"]);

                //if (rptDoc.Subreports.Count == 2)
                //    rptDoc.Subreports[1].SetDataSource((DataSet)Session["subReport"]);
                if (dt.Rows.Count > 0)
                {
                    pField = new ParameterField();
                    disVal = new ParameterDiscreteValue();
                    pField.ParameterFieldName = "total";
                    disVal.Value = dt.Rows.Count > 0 ? dt.Rows.Count : 0;
                    pField.CurrentValues.Add(disVal);
                    pFields.Add(pField);
                    CrystalReportViewer1.ReportSource = rptDoc;
                    CrystalReportViewer1.DataBind();
                    CrystalReportViewer1.ParameterFieldInfo = pFields;
                }
                else
                {
                    ShowAlertMessage("No Record Found");
                }

                LogableTask.LogMonoActivityTask("Page_Init", MethodBase.GetCurrentMethod(), TraceLevel.Info, "going in to-remove redisKey");
                RedisConnectorHelper.RemoveData(Request.Params["redisKey"]);
                LogableTask.LogMonoActivityTask("Page_Init", MethodBase.GetCurrentMethod(), TraceLevel.Info, "return from to-remove redisKey");

                LogableTask.LogMonoActivityTask("Page_Init", MethodBase.GetCurrentMethod(), TraceLevel.Info, "going in to-remove redisKeySubReport");
                RedisConnectorHelper.RemoveData(Request.Params["redisKeySubReport"]);
                LogableTask.LogMonoActivityTask("Page_Init", MethodBase.GetCurrentMethod(), TraceLevel.Info, "return from to-remove redisKeySubReport");
            }
            catch (Exception ex) 
            {
                LogableTask.LogMonoActivityTask("Page_Init", MethodBase.GetCurrentMethod(), TraceLevel.Error, "Exception at ReportPopup Page_Init, as: " + ex.Message);
            }
            LogableTask.LogMonoActivityTask("Page_Init", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Exit from ReportPopup");
        }

        public static JsonTextReader ConvertStringToJsonReader(string jsonString)
        {
            StringReader stringReader = new StringReader(jsonString);
            JsonTextReader jsonReader = new JsonTextReader(stringReader);
            return jsonReader;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        public void ShowAlertMessage(string message)
        {
            //string message = "Hello! Mudassar.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        private void SetDepositsAmount(DataTable pDataTable)
        {
            for (int i = 0; i < pDataTable.Rows.Count; i++)
            {
                pDataTable.Rows[i]["total"] = ExtractDepositAmount(pDataTable.Rows[i]["cassette1_denomination_detail"].ToString(), pDataTable.Rows[i]["cassette2_denomination_detail"].ToString(), pDataTable.Rows[i]["cassette3_denomination_detail"].ToString(), pDataTable.Rows[i]["cassette4_denomination_detail"].ToString());
            }
        }
        public string ExtractDepositAmount(string pCassette1Detail, string pCassette2Detail, string pCassette3Detail, string pCassette4Detail)
        {

            int[] cassette1 = !string.IsNullOrEmpty(pCassette1Detail) ? ParseCassetteDetail(pCassette1Detail) : new int[0];
            int[] cassette2 = !string.IsNullOrEmpty(pCassette2Detail) ? ParseCassetteDetail(pCassette2Detail) : new int[0];
            int[] cassette3 = !string.IsNullOrEmpty(pCassette3Detail) ? ParseCassetteDetail(pCassette3Detail) : new int[0];
            int[] cassette4 = !string.IsNullOrEmpty(pCassette4Detail) ? ParseCassetteDetail(pCassette4Detail) : new int[0];
            int cassette1total = !string.IsNullOrEmpty(pCassette1Detail) ? ParseCassettetotal(pCassette1Detail) : 0;
            int cassette2total = !string.IsNullOrEmpty(pCassette2Detail) ? ParseCassettetotal(pCassette2Detail) : 0;
            int cassette3total = !string.IsNullOrEmpty(pCassette3Detail) ? ParseCassettetotal(pCassette3Detail) : 0;
            int cassette4total = !string.IsNullOrEmpty(pCassette4Detail) ? ParseCassettetotal(pCassette4Detail) : 0;
            int[] cassette = ParseCassette(pCassette1Detail);

            int[] cassetteDetailTotal = new int[cassette1.Length];
            for (int i = 0; i < cassette1.Length; i++)
            {
                cassetteDetailTotal[i] = cassette1[i] + cassette2[i] + cassette3[i] + cassette4[i];
            }

            int cassettetotal = cassette1total + cassette2total + cassette3total + cassette4total;

            string data = null;

            if (System.Web.Configuration.WebConfigurationManager.AppSettings["IsDisplayDepositDenomination"] == "true")
            {

                for (int i = 0; i < cassetteDetailTotal.Length - 1; i++)
                {
                    data += cassette[i].ToString() + "*" + cassetteDetailTotal[i].ToString() + "<br>";
                }

                data += "=" + cassettetotal.ToString();
            }
            else
            {
                data = cassettetotal.ToString();
            }


            return data;

        }

        private int ParseCassettetotal(string pCassetteDetail)
        {
            int cassetteAmount = 0;
            string[] cassetteDetails = null;

            if (pCassetteDetail.Contains("="))
            {
                cassetteDetails = pCassetteDetail.Split('=');
                cassetteAmount = int.Parse(cassetteDetails[1].Trim());
            }


            return cassetteAmount;
        }

        private int[] ParseCassette(string pCassetteDetail)
        {

            string[] cassetteDetails = null;
            string[] seperator = { "<br>" };
            cassetteDetails = pCassetteDetail.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            int[] cassettecount = new int[cassetteDetails.Length];
            for (int i = 0; i < cassetteDetails.Length - 1; i++)
            {

                string[] temp = cassetteDetails[i].Split('*');
                cassettecount[i] = int.Parse(temp[0]);
            }

            return cassettecount;
        }

        private int[] ParseCassetteDetail(string pCassetteDetail)
        {

            string[] cassetteDetails = null;
            string[] seperator = { "<br>" };
            cassetteDetails = pCassetteDetail.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            int[] cassettecount = new int[cassetteDetails.Length];
            for (int i = 0; i < cassetteDetails.Length - 1; i++)
            {

                string[] temp = cassetteDetails[i].Split('*');
                cassettecount[i] = int.Parse(temp[1]);
            }

            return cassettecount;
        }

        private bool ContainColumn(string columnName, DataTable table)
        {
            DataColumnCollection columns = table.Columns;
            if (columns.Contains(columnName))
            {
                return true;
            }
            return false;
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
    }
}