using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Avanza.iSuite.DAL;
using System.Diagnostics;
using System.Reflection;
using System.Data;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Xml;
using System.Collections;


namespace Avanza.CCMS.DAL
{
    public static class Utility
    {
 
        static ArrayList _Files = null;


        private static  string GenerateSheetHeaderAndDefaultSheetData(DateTime orderDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            builder.Append("<worksheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\">");
            builder.Append("    <dimension ref=\"A1:L40\"/>");
            builder.Append("    <sheetViews>");
            builder.Append("        <sheetView tabSelected=\"1\" view=\"pageBreakPreview\" topLeftCell=\"A2\" zoomScale=\"60\" zoomScaleNormal=\"100\" workbookViewId=\"0\">");
            builder.Append("		            <selection activeCell=\"K38\" sqref=\"K38\"/>");
            builder.Append("        </sheetView>");
            builder.Append("    </sheetViews>");
            builder.Append("    <sheetFormatPr defaultRowHeight=\"13.5\"/>");
            builder.Append("    <cols>");
            builder.Append("    <col min=\"1\" max=\"1\" width=\"7.7109375\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("    <col min=\"2\" max=\"2\" width=\"9.140625\" style=\"140\"/>");

            builder.Append("            <col min=\"3\" max=\"3\" width=\"11.140625\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("    <col min=\"4\" max=\"4\" width=\"21.7109375\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("             <col min=\"5\" max=\"5\" width=\"11.7109375\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("            <col min=\"6\" max=\"6\" width=\"10.85546875\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("            <col min=\"7\" max=\"7\" width=\"14.28515625\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("            <col min=\"8\" max=\"8\" width=\"10.5703125\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("            <col min=\"9\" max=\"9\" width=\"14\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("           <col min=\"10\" max=\"10\" width=\"14.140625\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("           <col min=\"11\" max=\"11\" width=\"21.7109375\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("           <col min=\"12\" max=\"16384\" width=\"9.140625\" style=\"140\"/>");
            builder.Append("       </cols>");
            builder.Append("       <sheetData>");
            builder.Append("           <row r=\"1\" spans=\"1:12\">");
            builder.Append("              <c r=\"K1\" s=\"141\"/>");
            builder.Append("          </row>");
            builder.Append("          <row r=\"2\" spans=\"1:12\">");
            builder.Append("              <c r=\"F2\" s=\"142\" t=\"s\">");
            builder.Append("                <v>7</v>");
            builder.Append("              </c><c r=\"G2\" s=\"143\"/>");
            builder.Append("              <c r=\"H2\" s=\"143\"/>");
            builder.Append("             <c r=\"I2\" s=\"144\"/>");
            builder.Append("              <c r=\"J2\" s=\"145\" t=\"s\">");
            builder.Append("                <v>0</v>");
            builder.Append("              </c><c r=\"K2\" s=\"174\">");
            builder.Append("                <v>" + orderDate.ToOADate() + "</v>");
            builder.Append("              </c>");
            builder.Append("          </row>");
            builder.Append("          <row r=\"3\" spans=\"1:12\">");
            builder.Append("              <c r=\"I3\" s=\"147\"/>");
            builder.Append("              <c r=\"J3\" s=\"147\" t=\"s\">");
            builder.Append("                <v>1</v>");
            builder.Append("              </c>");

            builder.Append("              <c r=\"K3\" s=\"175\" t=\"inlineStr\">");
            builder.Append("                 <is>");
            builder.Append("                     <t>" + orderDate.DayOfWeek + "</t>");
            builder.Append("                  </is>");
            builder.Append("             </c>");
            builder.Append("          </row>");
            builder.Append("          <row r=\"4\" spans=\"1:12\">");
            builder.Append("              <c r=\"J4\" s=\"148\"/>");
            builder.Append("          </row>");
            builder.Append("          <row r=\"5\" spans=\"1:12\">");
            builder.Append("              <c r=\"A5\" s=\"141\"/>");
            builder.Append("              <c r=\"F5\" s=\"149\" t=\"s\">");
            builder.Append("                <v>5</v>");
            builder.Append("             </c><c r=\"G5\" s=\"150\"/>");
            builder.Append("              <c r=\"J5\" s=\"151\"/>");
            builder.Append("              <c r=\"K5\" s=\"152\"/>");
            builder.Append("              <c r=\"L5\" s=\"141\"/>");
            builder.Append("          </row>");
            builder.Append("          <row r=\"6\" spans=\"1:12\">");
            builder.Append("              <c r=\"A6\" s=\"153\" t=\"s\">");
            builder.Append("                <v>90</v>");
            builder.Append("             </c><c r=\"B6\" s=\"154\" t=\"s\">");
            builder.Append("                <v>2</v>");
            builder.Append("             </c><c r=\"C6\" s=\"154\" t=\"s\">");
            builder.Append("                <v>3</v>");
            builder.Append("             </c><c r=\"D6\" s=\"154\" t=\"s\">");
            builder.Append("                <v>4</v>");
            builder.Append("            </c><c r=\"E6\" s=\"150\">");
            builder.Append("                <v>1000</v>");
            builder.Append("            </c><c r=\"F6\" s=\"154\">");
            builder.Append("               <v>500</v>");
            builder.Append("           </c><c r=\"G6\" s=\"154\">");
            builder.Append("               <v>200</v>");
            builder.Append("          </c><c r=\"H6\" s=\"145\">");
            builder.Append("              <v>100</v>");
            builder.Append("          </c><c r=\"I6\" s=\"150\" t=\"s\">");
            builder.Append("              <v>6</v>");
            builder.Append("          </c><c r=\"J6\" s=\"144\" t=\"s\">");
            builder.Append("              <v>24</v>");
            builder.Append("          </c><c r=\"K6\" s=\"146\" t=\"s\">");
            builder.Append("              <v>301</v>");
            builder.Append("          </c><c r=\"L6\" s=\"145\" t=\"s\">");
            builder.Append("               <v>423</v>");
            builder.Append("           </c>");
            builder.Append("       </row>");
            return builder.ToString();
        }
        private static string GenerateFormulaRowAndSheetEndTag(int idx)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("<row r=\"{0}\" spans=\"1:12\" s=\"160\" customFormat=\"1\">", idx, idx - 1));
            builder.Append(string.Format("<c r=\"E{0}\" s=\"176\"><f>SUM(E7:E{1})</f><v>25100000</v></c>", idx, idx - 1));
            builder.Append(string.Format("<c r=\"F{0}\" s=\"176\"><f>SUM(F7:F{1})</f><v>25100000</v></c>", idx, idx - 1));
            builder.Append(string.Format("<c r=\"G{0}\" s=\"176\"><f>SUM(G7:G{1})</f><v>25100000</v></c>", idx, idx - 1));
            builder.Append(string.Format("<c r=\"H{0}\" s=\"176\"><f>SUM(H7:H{1})</f><v>25100000</v></c>", idx, idx - 1));
            builder.Append(string.Format("<c r=\"I{0}\" s=\"176\"><f>SUM(I7:I{1})</f><v>25100000</v></c>", idx, idx - 1));
            builder.Append("</row>");
            builder.Append(string.Format("<row r=\"{0}\" spans=\"1:12\" s=\"160\" customFormat=\"1\"/>", idx + 1));
            builder.Append(string.Format("<row r=\"{0}\" spans=\"1:12\" s=\"160\" customFormat=\"1\"/>", idx + 2));
            builder.Append("</sheetData>");
            return builder.ToString();
        }
        private static string GenerateFooter()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<sortState ref=\"A7:M422\">");
            builder.Append("                <sortCondition ref=\"B7\"/>");
            builder.Append("            </sortState>");
            builder.Append("<pageMargins left=\"0.75\" right=\"0.75\" top=\"1\" bottom=\"1\" header=\"0.5\" footer=\"0.5\"/>");
            builder.Append("<pageSetup scale=\"79\" orientation=\"landscape\" horizontalDpi=\"4294967293\" r:id=\"rId1\"/>");
            builder.Append("<headerFooter alignWithMargins=\"0\"/>");
            builder.Append("<drawing r:id=\"rId2\"/>");
            builder.Append("</worksheet>");
            return builder.ToString();
        }
        public static void UpdateSheet3(string filePath, DateTime orderDate, System.Data.DataTable dt)
        {
            StringBuilder builder = new StringBuilder();
            string headerWithDefaultRow = GenerateSheetHeaderAndDefaultSheetData(orderDate);
            string footer = GenerateFooter();
            int idx = 7;
            foreach (DataRow dr in dt.Rows)
            {//c.cassette1_denomination,c.cassette1_suggested_notes



                builder.Append(string.Format("<row r=\"{0}\" spans=\"1:12\" s=\"160\" customFormat=\"1\">", idx));
                builder.Append(string.Format("<c r=\"A{0}\" s=\"155\" t=\"inlineStr\"><is><t>{1}</t></is></c>", idx, dr["cit_atm_title"]));
                builder.Append(string.Format("<c r=\"B{0}\" s=\"156\" t=\"inlineStr\"><is><t>{1}</t></is></c>", idx, dr["title"]));
                builder.Append(string.Format("<c r=\"C{0}\" s=\"156\" t=\"inlineStr\"><is><t>{1}</t></is></c>", idx, dr["gl_number"]));
                builder.Append(string.Format("<c r=\"D{0}\" s=\"156\"  t=\"inlineStr\"><is><t>{1}</t></is></c>", idx, dr["location"]));
                builder.Append(string.Format("<c r=\"E{0}\" s=\"157\"><v>{1}</v></c>", idx, int.Parse(dr["cassette1_denomination"].ToString()) * int.Parse(dr["cassette1_suggested_notes"].ToString())));
                builder.Append(string.Format("<c r=\"F{0}\" s=\"157\"><v>{1}</v></c>", idx, int.Parse(dr["cassette2_denomination"].ToString()) * int.Parse(dr["cassette2_suggested_notes"].ToString())));
                builder.Append(string.Format("<c r=\"G{0}\" s=\"157\"><v>{1}</v></c>", idx, int.Parse(dr["cassette3_denomination"].ToString()) * int.Parse(dr["cassette3_suggested_notes"].ToString())));
                builder.Append(string.Format("<c r=\"H{0}\" s=\"157\"><v>{1}</v></c>", idx, int.Parse(dr["cassette4_denomination"].ToString()) * int.Parse(dr["cassette4_suggested_notes"].ToString())));
                builder.Append(string.Format("<c r=\"I{0}\" s=\"158\"><f>SUM(E{0}:H{0})</f><v>2600000</v></c>", idx));
                builder.Append(string.Format("<c r=\"J{0}\" s=\"159\" t=\"inlineStr\"><is><t>{1}</t></is></c>", idx, dr["city"]));

                if (dr["cash_order_datetime"].ToString() != dr["replenishment_datetime"].ToString())
                {
                    builder.Append(string.Format("<c r=\"K{0}\" s=\"156\" t=\"inlineStr\"><is><t>{1}</t></is></c>", idx, DateTime.Parse(dr["replenishment_datetime"].ToString()).ToString("dd-MMM")));
                    builder.Append(string.Format("<c r=\"L{0}\" s=\"156\" t=\"inlineStr\"><is><t>{1}</t></is></c>", idx, DateTime.Parse(dr["replenishment_datetime"].ToString()).ToString("HH:mm")));
                }
                else
                {
                    builder.Append(string.Format("<c r=\"K{0}\" s=\"156\"/>", idx));
                    builder.Append(string.Format("<c r=\"L{0}\" s=\"156\"/>", idx));
                }


                builder.Append("</row>");
                idx++;
            }
            File.WriteAllText(filePath, headerWithDefaultRow + builder.ToString() + GenerateFormulaRowAndSheetEndTag(idx) + footer);
        }

        public static void UpdateWorkSheet(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            xmlDoc.ChildNodes[1].RemoveChild(xmlDoc.ChildNodes[1].ChildNodes[0]);
            xmlDoc.Save(filePath);
        }
        public static void ZipFolder(string basePath)
        {
            zipFolder(basePath, false);
        }
        public static void BuildList(string SearchPath, int RecursionLevel)
        {
            //new ArrayList();
            DirectoryInfo ThisLevel = new DirectoryInfo(SearchPath);
            DirectoryInfo[] ChildLevel = ThisLevel.GetDirectories();
            if (RecursionLevel != 1)
            {
                foreach (DirectoryInfo Child in ChildLevel)
                {
                    BuildList(Child.FullName, RecursionLevel - 1);
                }
            }
            FileInfo[] ChildFiles = ThisLevel.GetFiles();
            foreach (FileInfo ChildFile in ChildFiles)
            {
                _Files.Add(ChildFile.FullName);
            }
        }
        public static void zipFolder(string basePath, bool deleteAfter)
        {
            string zipFileName = basePath + ".zip";
            ZipOutputStream os = new ZipOutputStream(File.OpenWrite(zipFileName));

            FileStream fs;

            _Files = new ArrayList();
            BuildList(basePath, 0);

            foreach (string s in _Files)
            {
                string sourceFileName = s;

                //string path = Path.GetFileName(sourceFileName);
                string path = Path.GetFullPath(sourceFileName).Replace(basePath + "\\", "");
                //string path1 = Path.GetExtension(path2);

                ZipEntry ze = new ZipEntry(path);
                ze.CompressionMethod = CompressionMethod.Deflated;
                os.PutNextEntry(ze);

                fs = File.OpenRead(sourceFileName);

                byte[] buff = new byte[1024];
                int n = 0;
                while ((n = fs.Read(buff, 0, buff.Length)) > 0)
                {
                    os.Write(buff, 0, n);

                }
                fs.Close();
            }

            os.CloseEntry();
            os.Close();

            if (deleteAfter)
            {
                Directory.Delete(basePath, true);
            }
        }
        public static void ExpandFolder(string zipFile, string baseFolder)
        {
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }
            FileStream fr = File.OpenRead(zipFile);
            ZipInputStream ins = new ZipInputStream(fr);
            //ZipFile zf = new ZipFile(zipFile);
            ZipEntry ze = ins.GetNextEntry();
            while (ze != null)
            {
                if (ze.IsDirectory)
                {
                    Directory.CreateDirectory(baseFolder + "\\" + ze.Name);
                }
                else if (ze.IsFile)
                {
                    if (!Directory.Exists(baseFolder + "\\" + Path.GetDirectoryName(ze.Name)))
                    {
                        Directory.CreateDirectory(baseFolder + "\\" + Path.GetDirectoryName(ze.Name));
                    }

                    FileStream fs = File.Create(baseFolder + "\\" + ze.Name);

                    byte[] writeData = new byte[ze.Size];
                    int iteration = 0;
                    while (true)
                    {
                        int size = 2048;
                        size = ins.Read(writeData, (int)Math.Min(ze.Size, (iteration * 2048)), (int)Math.Min(ze.Size - (int)Math.Min(ze.Size, (iteration * 2048)), 2048));
                        if (size > 0)
                        {
                            fs.Write(writeData, (int)Math.Min(ze.Size, (iteration * 2048)), size);
                        }
                        else
                        {
                            break;
                        }
                        iteration++;
                    }
                    fs.Close();
                }
                ze = ins.GetNextEntry();
            }
            ins.Close();
            fr.Close();
        }
        public static  List<DateTime> GetEvents(string text)
        {
            List<DateTime> list = new List<DateTime>();
            SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
            cmd.CommandText = "select convert(varchar,event_start,103),convert(varchar,event_end ,103) from event where title like '%" + text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                DateTime dtStartEvent = DateTime.ParseExact(dr[0].ToString(), "dd/MM/yyyy", null);
                DateTime dtEndEvent = DateTime.ParseExact(dr[1].ToString(), "dd/MM/yyyy", null);

                do
                {
                    if (!list.Contains(dtStartEvent))
                        list.Add(dtStartEvent);

                    dtStartEvent = dtStartEvent.AddDays(1);

                } while (dtStartEvent.Date <= dtEndEvent.Date);

            }
            return list;
        }


        public static int GenerateConditionalTerminalAlert(int atm_id, int alertTypeID, string msg, SqlTransaction trxn, Event_Type eventType, int taskID,
           int? entityID, string entityType)
        {
            int newAlertID = -1;
            LogableTask task = LogableTask.NewTask("GenerateConditionalTerminalAlert");
            SqlCommand cmd = null;
            try
            {
                cmd = ConnectionFactory.GetNewCommand(true);
                //Added on 10/01/2016 to handle timeout issue.
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                cmd.CommandTimeout = 0;
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                cmd.CommandText = string.Format(@"select atm_alert_id
                                                  from atm_alert
                                                  where alert_type_id = {0} and resolve_at is null and atm_id={1}", alertTypeID, atm_id);

                object alertID = cmd.ExecuteScalar();
                if (alertID == null) // no alert in db; 
                {
                    AppSetting appSetting = AppSetting.LoadAppSetting("1=1");
                    AtmAlert alert = new AtmAlert();
                    alert.AtmId = atm_id;
                    alert.GeneratedAt = DateTime.Now;
                    alert.AlertTypeId = alertTypeID;
                    alert.GenerateNotificationSent = false;
                    alert.ResolveNotificationSent = null;
                    alert.GenerateAtRetryRemaining = 10;
                    alert.ResolveAtRetryRemaining = 0;
                    alert.AlertMsg = msg;
                    if (entityID != null)
                        alert.EntityId = entityID.Value;
                    if (entityType != null)
                        alert.EntityType = entityType;

                    if (alert.AlertTypeId == (int)EnumAlertType.DenominationMissing ||
                        alert.AlertTypeId == (int)EnumAlertType.TerminalNotLicensed ||
                        alert.AlertTypeId == (int)EnumAlertType.ConfigurationUploadFailed ||
                        alert.AlertTypeId == (int)EnumAlertType.ConfigurationMismatch ||
                        alert.AlertTypeId == (int)EnumAlertType.CashOrderUploadFailed ||
                        alert.AlertTypeId == (int)EnumAlertType.CashOrderField20Missing ||
                        alert.AlertTypeId == (int)EnumAlertType.ATMCashLevelFileDownloadFailed)
                    {
                        //alert.ExpirationTime = DateTime.Now.AddDays(int.Parse(ConfigurationManager.AppSettings["AlertExpirationTime"]));
                        alert.ExpirationTime = DateTime.Now.AddDays(appSetting.AlertExpirationTime.Value);
                    }
                    alert.Save(trxn.Connection, trxn);
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for terminal " + atm_id);
                    GenerateIntegratedAlert(alertTypeID, msg, alert.AtmId.Value, EntityType.ATM,
                       eventType, null, trxn, alert.AtmAlertId);
                    newAlertID = alert.AtmAlertId;


                }
                return newAlertID;
            }

            finally
            {
                if (cmd != null)
                    if (cmd.Connection != null)
                        cmd.Connection.Close();
                task.EndTask();
            }
        }
        public static void GenerateIntegratedAlert(int alertTypeID, string msg,
           int entityID, EntityType entityType, Event_Type eventType, int? ftpFileInfoId, SqlTransaction trxn, int? atmAlertID)
        {
            LogableTask task = LogableTask.NewTask("GenerateIntegratedAlert");
            long orgID = -1;
            try
            {
                CcmsIntegratedAlert alert = new CcmsIntegratedAlert();
                if (atmAlertID != null)
                    alert.AtmAlertId = atmAlertID;
                alert.AlertTypeId = alertTypeID;
                alert.AlertType = AlertType.LoadAlertTypeByPk(alertTypeID).AlertTypeName;
                alert.EntityId = entityID;
                alert.EntityType = entityType.ToString();
                alert.AlertLevel = eventType.ToString();
                alert.AlertStatus = "Unread";
                alert.GeneratedAt = DateTime.Now;
                alert.AlertText = msg;
                alert.ExpirationTime = DateTime.Now.AddDays(2);
                alert.GenerateNotificationSent = false;
                alert.ResolveNotificationSent = false;
                if (alert.EntityType == EntityType.ATM.ToString())
                {
                    Atm atm = Atm.LoadAtmByPk(entityID);
                    alert.GenerateRetryRemaining = atm.RetryCountAlert;
                    alert.ResolveRetryRemaining = atm.RetryCountAlert;
                    orgID = long.Parse(GetOrganization(atm.RegionId).ToString());
                }
                else if (alert.EntityType == EntityType.Organization.ToString())
                {
                    alert.FtpFileInfoId = ftpFileInfoId;
                    FtpFileInfo ftpFileInfo = FtpFileInfo.LoadFtpFileInfoByPk(ftpFileInfoId.Value);
                    Region region = Region.LoadRegionByPk(ftpFileInfo.RegionId);
                    alert.GenerateRetryRemaining = region.RetryCountAlert; // add field in region table for this....
                    alert.ResolveRetryRemaining = region.RetryCountAlert;
                    orgID = long.Parse(FtpFileInfo.LoadFtpFileInfoByPk(ftpFileInfoId.Value).RegionId.ToString());
                }
                alert.ModuleType = "CURRENCY";
                alert.OrganizationId = int.Parse(orgID.ToString());

                if (trxn != null)
                    alert.Save(trxn.Connection, trxn);
                else
                    alert.Save();
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added of type " + alertTypeID);
            }

            finally
            {
                task.EndTask();
            }
        }
        public static int GetOrganization(int region_id)
        {
            Region region = Region.LoadRegionByPk(region_id);
            if (region.IsOrganization)
            {
                return region.RegionId;
            }
            else
                return GetOrganization(region.ParentRegionId.Value);
        }
        public static void GenerateOrganizationAlert(int ftp_file_info_id, int alertTypeID, string msg, Event_Type eventType, int organizationID,int alertExpirationInDays)
        {
            LogableTask task = LogableTask.NewTask("GenerateOrganizationAlert");
            try
            {

                OrganizationAlert alert = new OrganizationAlert();
                alert.GeneratedAt = DateTime.Now;
                alert.AlertTypeId = alertTypeID;
                alert.FtpFileInfoId = ftp_file_info_id;
                alert.ExpirationTime = DateTime.Now.AddDays(alertExpirationInDays);

                //                alert.ExpirationTime = DateTime.Now.AddDays(int.Parse(ConfigurationManager.AppSettings["AlertExpirationTime"]));

                alert.AlertMsg = msg;
                alert.RetryRemaining = 10;
                alert.GenerateNotificationSent = false;
                alert.Save();
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for ftp file info = " + ftp_file_info_id);
                FtpFileInfo ftpFileInfo = FtpFileInfo.LoadFtpFileInfoByPk(ftp_file_info_id);
                GenerateIntegratedAlertForOrg(alertTypeID, msg, ftpFileInfo.RegionId, EntityType.Organization,
                    eventType, ftp_file_info_id, null, organizationID,alertExpirationInDays);
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                task.EndTask();
            }
        }
        public static void GenerateIntegratedAlertForOrg(int alertTypeID, string msg,
           int entityID, EntityType entityType, Event_Type eventType, int? ftpFileInfoId, SqlTransaction trxn
            , int organizationID,int alertExpirationInDays)
        {
            LogableTask task = LogableTask.NewTask("GenerateIntegratedAlert");
            int orgID = -1;
            try
            {
                CcmsIntegratedAlert alert = new CcmsIntegratedAlert();
                alert.AlertTypeId = alertTypeID;
                alert.AlertType = AlertType.LoadAlertTypeByPk(alertTypeID).AlertTypeName;
                alert.EntityId = entityID;
                alert.EntityType = entityType.ToString();
                alert.AlertLevel = eventType.ToString();
                alert.AlertStatus = "Unread";
                alert.GeneratedAt = DateTime.Now;
                alert.AlertText = msg;
                alert.ExpirationTime = DateTime.Now.AddDays(alertExpirationInDays);
                alert.GenerateNotificationSent = false;
                alert.ResolveNotificationSent = false;

                alert.FtpFileInfoId = ftpFileInfoId;
                //FtpFileInfo ftpFileInfo = FtpFileInfo.LoadFtpFileInfoByPk(ftpFileInfoId.Value);
                Region region = Region.LoadRegionByPk(organizationID);
                alert.GenerateRetryRemaining = region.RetryCountAlert; // add field in region table for this....
                alert.ResolveRetryRemaining = region.RetryCountAlert;
                orgID = FtpFileInfo.LoadFtpFileInfoByPk(ftpFileInfoId.Value).RegionId;

                alert.ModuleType = "CURRENCY";
                alert.OrganizationId = orgID;

                if (trxn != null)
                    alert.Save(trxn.Connection, trxn);
                else
                    alert.Save();
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added of type " + alertTypeID);
            }

            finally
            {
                task.EndTask();
            }
        }
        public static void GenerateOrganizationAlert(int ftp_file_info_id, int alertTypeID, string msg, SqlTransaction trxn, Event_Type eventType
            , int organizationID, int alertExpirationInDays)
        {
            LogableTask task = LogableTask.NewTask("GenerateOrganizationAlert");
            try
            {
                OrganizationAlert alert = new OrganizationAlert();
                alert.GeneratedAt = DateTime.Now;
                alert.AlertTypeId = alertTypeID;
                alert.FtpFileInfoId = ftp_file_info_id;
                alert.ExpirationTime = DateTime.Now.AddDays(alertExpirationInDays);

                //                alert.ExpirationTime = DateTime.Now.AddDays(int.Parse(ConfigurationManager.AppSettings["AlertExpirationTime"]));

                alert.AlertMsg = msg;
                alert.RetryRemaining = Region.LoadRegionByPk(organizationID).RetryCountAlert;
                alert.GenerateNotificationSent = false;
                alert.Save(trxn.Connection, trxn);
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for ftp file info = " + ftp_file_info_id);

                //Going to insert in integrated alert table...
                //    GenerateIntegratedAlert(int alertTypeID, string msg,
                //int entityID, EntityType entityType, Event_Type eventType,int? ftpFileInfoId,SqlTransaction trxn)
                FtpFileInfo ftpFileInfo = FtpFileInfo.LoadFtpFileInfoByPk(ftp_file_info_id);
                GenerateIntegratedAlertForOrg(alertTypeID, msg, ftpFileInfo.RegionId, EntityType.Organization,
                    eventType, ftp_file_info_id, trxn, organizationID,alertExpirationInDays);
            }

            finally
            {
                task.EndTask();
            }
        }

    }
}
