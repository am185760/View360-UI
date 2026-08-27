using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System.Diagnostics;
using System.Configuration;
using ServicesDAL;

namespace DailyFeedGenerator
{
    enum AlertStatus
    {
        Up = 1,
        Down = 0
    }
    static class AlertManager
    {
    //    public static void GenerateConditionalOrResolveAlert(int atm_id, int alertTypeID, string msg, Event_Type eventType, bool isResolved, bool isMsgUsedAsCriteria)
    //    {
    //        SqlCommand cmd = null;
    //        object alertID = null;
    //        LogableTask task = LogableTask.NewTask("GenerateTerminalAlert");
    //        try
    //        {
    //            cmd = ConnectionFactory.GetNewCommand(true);
    //            if (isMsgUsedAsCriteria)
    //            {
    //                string[] msgParts = msg.Split('|');

    //                cmd.CommandText = string.Format(@"select atm_alert_id
    //                                              from atm_alert
    //                                              where  atm_id = {0} and  alert_type_id ={1} and resolve_at is null and alert_msg like '" + msgParts[0] + "%'", atm_id, alertTypeID);
    //            }
    //            else
    //                cmd.CommandText = string.Format(@"select atm_alert_id
    //                                              from atm_alert
    //                                              where  atm_id = {0} and  alert_type_id ={1} and resolve_at is null", atm_id, alertTypeID);
    //            alertID = cmd.ExecuteScalar();
    //            if (alertID == null && !isResolved) // no alert in db;
    //            {
    //                AtmAlert alert = new AtmAlert();
    //                alert.EventCount = 1;
    //                alert.AtmId = atm_id;
    //                alert.GeneratedAt = DateTime.Now;
    //                alert.AlertTypeId = alertTypeID;
    //                alert.GenerateNotificationSent = false;
    //                alert.ResolveNotificationSent = false;
    //                alert.GenerateAtRetryRemaining = Atm.LoadAtmByPk(atm_id).RetryCountAlert;
    //                alert.ResolveAtRetryRemaining = alert.GenerateAtRetryRemaining;
    //                alert.AlertMsg = msg;
    //                alert.Save();
    //                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for terminal " + atm_id);
    //                GenerateIntAlert(alertTypeID, msg, alert.AtmId.Value, EntityType.ATM,
    //                   eventType, null, null, alert.AtmAlertId);


    //            }
    //            else
    //            {

    //                if (alertID != null)
    //                {
    //                    AtmAlert atmAlert = AtmAlert.LoadAtmAlertByPk(int.Parse(alertID.ToString()));
    //                    if (atmAlert != null)
    //                    {
    //                        if (isResolved)
    //                        {
    //                            atmAlert.ResolveAt = DateTime.Now;
    //                            atmAlert.Save();
    //                            CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert.AtmAlertId);
    //                            if (ccmsIntAlert != null)
    //                            {
    //                                ccmsIntAlert.ResolvedAt = DateTime.Now;
    //                                ccmsIntAlert.Save();
    //                            }
    //                        }
    //                        else
    //                        {
    //                            //if (atmAlert.EventCount == null)
    //                            //    atmAlert.EventCount = 0;
    //                            atmAlert.EventCount++;
    //                            atmAlert.Save();
    //                            CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert.AtmAlertId);
    //                            if (ccmsIntAlert != null)
    //                            {
    //                                //if (ccmsIntAlert.EventCount == null)
    //                                //    ccmsIntAlert.EventCount = 0;
    //                                ccmsIntAlert.EventCount++;
    //                                ccmsIntAlert.Save();
    //                            }
    //                        }
    //                    }
    //                }


    //            }



    //        }

    //        finally
    //        {
    //            if (cmd != null)
    //                if (cmd.Connection != null)
    //                    cmd.Connection.Close();
    //            task.EndTask();
    //        }
    //    }
    //    public static int GenerateTerminalAlert(int atm_id, int alertTypeID, string msg, SqlTransaction trxn, Event_Type eventType, int taskID,
    //       int? entityID, string entityType)
    //    {
    //        LogableTask task = LogableTask.NewTask("GenerateTerminalAlert");
    //        try
    //        {

    //            AtmAlert alert = new AtmAlert();
    //            alert.AtmId = atm_id;
    //            alert.GeneratedAt = DateTime.Now;
    //            alert.AlertTypeId = alertTypeID;
    //            alert.GenerateNotificationSent = false;
    //            alert.ResolveNotificationSent = null;
    //            alert.GenerateAtRetryRemaining = 10;
    //            alert.ResolveAtRetryRemaining = 0;
    //            alert.TaskId = taskID;
    //            alert.AlertMsg = msg;
    //            if (entityID != null)
    //                alert.EntityId = entityID.Value;
    //            if (entityType != null)
    //                alert.EntityType = entityType;

    //            if (alert.AlertTypeId == (int)EnumAlertType.DenominationMissing ||
    //alert.AlertTypeId == (int)EnumAlertType.TerminalNotLicensed ||
    //alert.AlertTypeId == (int)EnumAlertType.ConfigurationUploadFailed ||
    //alert.AlertTypeId == (int)EnumAlertType.ConfigurationMismatch ||
    //alert.AlertTypeId == (int)EnumAlertType.CashOrderUploadFailed ||
    //         alert.AlertTypeId == (int)EnumAlertType.CashOrderField20Missing ||

    //         alert.AlertTypeId == (int)EnumAlertType.ATMCashLevelFileDownloadFailed
    //         )
    //            {
    //                //alert.ExpirationTime = DateTime.Now.AddDays(int.Parse(ConfigurationManager.AppSettings["AlertExpirationTime"]));

    //                alert.ExpirationTime = DateTime.Now.AddDays(2);


    //            }


    //            alert.Save(trxn.Connection, trxn);
    //            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added of type " + alertTypeID + " for terminal " + atm_id);
    //            GenerateIntegratedAlert(alertTypeID, msg, alert.AtmId.Value, EntityType.ATM,
    //               eventType, null, trxn, alert.AtmAlertId);
    //            return alert.AtmAlertId;
    //        }

    //        finally
    //        {
    //            task.EndTask();
    //        }
    //    }
    //       public static void GenerateIntegratedAlert(int alertTypeID, string msg,
    //      int entityID, EntityType entityType, Event_Type eventType, int? ftpFileInfoId, SqlTransaction trxn, int? atmAlertID)
    //    {
    //        LogableTask task = LogableTask.NewTask("GenerateIntegratedAlert");
    //        long orgID = -1;
    //        try
    //        {
    //            CcmsIntegratedAlert alert = new CcmsIntegratedAlert();
    //            if (atmAlertID != null)
    //                alert.AtmAlertId = atmAlertID;
    //            alert.AlertTypeId = alertTypeID;
    //            alert.AlertType = AlertType.LoadAlertTypeByPk(alertTypeID).AlertTypeName;
    //            alert.EntityId = entityID;
    //            alert.EntityType = entityType.ToString();
    //            alert.AlertLevel = eventType.ToString();
    //            alert.AlertStatus = "Unread";
    //            alert.GeneratedAt = DateTime.Now;
    //            alert.AlertText = msg;
    //            alert.ExpirationTime = DateTime.Now.AddDays(2);
    //            alert.GenerateNotificationSent = false;
    //            alert.ResolveNotificationSent = false;
    //            if (alert.EntityType == EntityType.ATM.ToString())
    //            {
    //                Atm atm = Atm.LoadAtmByPk(entityID);
    //                alert.GenerateRetryRemaining = atm.RetryCountAlert;
    //                alert.ResolveRetryRemaining = atm.RetryCountAlert;
    //                orgID = long.Parse(GetOrganization(atm.RegionId).ToString());
    //            }
    //            else if (alert.EntityType == EntityType.Organization.ToString())
    //            {
    //                alert.FtpFileInfoId = ftpFileInfoId;
    //                FtpFileInfo ftpFileInfo = FtpFileInfo.LoadFtpFileInfoByPk(ftpFileInfoId.Value);
    //                Region region = Region.LoadRegionByPk(ftpFileInfo.RegionId);
    //                alert.GenerateRetryRemaining = region.RetryCountAlert; // add field in region table for this....
    //                alert.ResolveRetryRemaining = region.RetryCountAlert;
    //                orgID = long.Parse(FtpFileInfo.LoadFtpFileInfoByPk(ftpFileInfoId.Value).RegionId.ToString());
    //            }
    //            alert.ModuleType = "CURRENCY";
    //            alert.OrganizationId = int.Parse(orgID.ToString());

    //            if (trxn != null)
    //                alert.Save(trxn.Connection, trxn);
    //            else
    //                alert.Save();
    //            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added of type " + alertTypeID);
    //        }

    //        finally
    //        {
    //            task.EndTask();
    //        }
    //    }
    //    public static int GetOrganization(int region_id)
    //    {
    //        Region region = Region.LoadRegionByPk(region_id);
    //        if (region.IsOrganization)
    //        {
    //            return region.RegionId;
    //        }
    //        else
    //            return GetOrganization(region.ParentRegionId.Value);
    //    }
    //     public static void GenerateTerminalAlert(int atm_id, int alertTypeID, string msg, Event_Type eventType)
    //    {
    //        LogableTask task = LogableTask.NewTask("GenerateTerminalAlert");
    //        try
    //        {
    //            AtmAlert alert = new AtmAlert();
    //            alert.AtmId = atm_id;
    //            alert.GeneratedAt = DateTime.Now;
    //            alert.AlertTypeId = alertTypeID;
    //            alert.GenerateNotificationSent = false;
    //            alert.ResolveNotificationSent = null;
    //            alert.GenerateAtRetryRemaining = Atm.LoadAtmByPk(atm_id).RetryCountAlert;
    //            alert.ResolveAtRetryRemaining = 0;
    //            alert.AlertMsg = msg;

    //            if (alert.AlertTypeId == (int)EnumAlertType.DenominationMissing ||
    //                alert.AlertTypeId == (int)EnumAlertType.TerminalNotLicensed ||
    //                alert.AlertTypeId == (int)EnumAlertType.ConfigurationUploadFailed ||
    //                alert.AlertTypeId == (int)EnumAlertType.ConfigurationMismatch ||
    //                alert.AlertTypeId == (int)EnumAlertType.CashOrderUploadFailed ||
    //                alert.AlertTypeId == (int)EnumAlertType.CashOrderField20Missing ||
    //                alert.AlertTypeId == (int)EnumAlertType.ATMCashLevelFileDownloadFailed ||
    //                alert.AlertTypeId == (int)EnumAlertType.SummaryDataRegenerated ||
    //                alert.AlertTypeId == (int)EnumAlertType.ATMInactivityPeriodElapsed
    //                         )
    //            {
    //                //                alert.ExpirationTime = DateTime.Now.AddDays(int.Parse(ConfigurationManager.AppSettings["AlertExpirationTime"]));
    //                if (DailyFeedGenerator.appSetting.AlertExpirationTime.HasValue)
    //                    alert.ExpirationTime = DateTime.Now.AddDays(DailyFeedGenerator.appSetting.AlertExpirationTime.Value);
    //                else
    //                    alert.ExpirationTime = DateTime.Now.AddDays(3);


    //            }
    //            alert.Save();
    //            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for terminal " + atm_id);
    //            GenerateIntAlert(alertTypeID, msg, alert.AtmId.Value, EntityType.ATM,
    //               eventType, null, null, alert.AtmAlertId);
    //        }
    //        catch (Exception ex)
    //        {
    //            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
    //            throw;
    //        }

    //        finally
    //        {
    //            task.EndTask();
    //        }
    //    }
      
      
    

       
        //public static void GenerateIntegratedAlert(int alertTypeID, string msg,
        //    int entityID, EntityType entityType, Event_Type eventType, int? ftpFileInfoId, SqlTransaction trxn)
        //{
        //    LogableTask task = LogableTask.NewTask("GenerateIntegratedAlert");
        //    int orgID = -1;
        //    try
        //    {
        //        CcmsIntegratedAlert alert = new CcmsIntegratedAlert();
        //        alert.AlertTypeId = alertTypeID;
        //        alert.AlertType = AlertType.LoadAlertTypeByPk(alertTypeID).AlertTypeName;
        //        alert.EntityId = entityID;
        //        alert.EntityType = entityType.ToString();
        //        alert.AlertLevel = eventType.ToString();
        //        alert.AlertStatus = "Unread";
        //        alert.GeneratedAt = DateTime.Now;
        //        alert.AlertText = msg;
        //        alert.ExpirationTime = DateTime.Now.AddDays(DailyFeedGenerator.appSetting.AlertExpirationTime.Value);
        //        alert.GenerateNotificationSent = false;
        //        alert.ResolveNotificationSent = false;
        //        if (alert.EntityType == EntityType.ATM.ToString())
        //        {
        //            Atm atm = Atm.LoadAtmByPk(entityID);
        //            alert.GenerateRetryRemaining = atm.RetryCountAlert;
        //            alert.ResolveRetryRemaining = atm.RetryCountAlert;
        //            orgID = GetOrganization(atm.RegionId);

        //        }
        //        else if (alert.EntityType == EntityType.Organization.ToString())
        //        {
        //            alert.FtpFileInfoId = ftpFileInfoId;
        //            FtpFileInfo ftpFileInfo = FtpFileInfo.LoadFtpFileInfoByPk(ftpFileInfoId.Value);
        //            Region region = Region.LoadRegionByPk(ftpFileInfo.RegionId);
        //            alert.GenerateRetryRemaining = region.RetryCountAlert; // add field in region table for this....
        //            alert.ResolveRetryRemaining = region.RetryCountAlert;
        //            orgID = FtpFileInfo.LoadFtpFileInfoByPk(ftpFileInfoId.Value).RegionId;
        //        }
        //        alert.ModuleType = "CURRENCY";
        //        alert.OrganizationId = orgID;

        //        if (trxn != null)
        //            alert.Save(trxn.Connection, trxn);
        //        else
        //            alert.Save();
        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added of type " + alertTypeID);
        //    }

        //    finally
        //    {
        //        task.EndTask();
        //    }
        //}
        //public static void GenerateIntAlert(int alertTypeID, string msg, int entityID, EntityType entityType, Event_Type eventType, int? ftpFileInfoId, SqlTransaction trxn, int? atmAlertID)
        //{
        //    LogableTask task = LogableTask.NewTask("GenerateIntegratedAlert");
        //    int orgID = -1;
        //    try
        //    {
        //        CcmsIntegratedAlert alert = new CcmsIntegratedAlert();
        //        if (atmAlertID != null)
        //            alert.AtmAlertId = atmAlertID;
        //        alert.EventCount = 1;
        //        alert.AlertTypeId = alertTypeID;
        //        alert.AlertType = AlertType.LoadAlertTypeByPk(alertTypeID).AlertTypeName;
        //        alert.EntityId = entityID;
        //        alert.EntityType = entityType.ToString();
        //        alert.AlertLevel = eventType.ToString();
        //        alert.AlertStatus = "Unread";
        //        alert.GeneratedAt = new DateTime?(DateTime.Now);
        //        alert.AlertText = msg;
        //        alert.ExpirationTime = new DateTime?(DateTime.Now.AddDays(2.0));
        //        alert.GenerateNotificationSent = false;
        //        alert.ResolveNotificationSent = false;
        //        if (alert.EntityType == EntityType.ATM.ToString())
        //        {
        //            Atm atm = Atm.LoadAtmByPk(entityID);
        //            alert.GenerateRetryRemaining = new int?(atm.RetryCountAlert);
        //            alert.ResolveRetryRemaining = new int?(atm.RetryCountAlert);
        //            orgID = GetOrganization(atm.RegionId);
        //        }
        //        else if (alert.EntityType == EntityType.Organization.ToString())
        //        {
        //            alert.FtpFileInfoId = ftpFileInfoId;
        //            Region region = Region.LoadRegionByPk(FtpFileInfo.LoadFtpFileInfoByPk(ftpFileInfoId.Value).RegionId);
        //            alert.GenerateRetryRemaining = new int?(region.RetryCountAlert);
        //            alert.ResolveRetryRemaining = new int?(region.RetryCountAlert);
        //            orgID = FtpFileInfo.LoadFtpFileInfoByPk(ftpFileInfoId.Value).RegionId;
        //        }
        //        alert.ModuleType = "CURRENCY";
        //        alert.OrganizationId = orgID;
        //        if (trxn != null)
        //        {
        //            alert.Save(trxn.Connection, trxn);
        //        }
        //        else
        //        {
        //            alert.Save();
        //        }
        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added of type " + alertTypeID);
        //    }
        //    finally
        //    {
        //        task.EndTask();
        //    }
        //}
        //public static void GenerateCCMSEvent(string eventId, string eventName, string eventType, string entityId, string entityType,
        //    string source, string destination, SqlTransaction trxn)
        //{
        //    CcmsEvent ccmsEvent = new CcmsEvent();
        //    ccmsEvent.EventId = eventId;
        //    ccmsEvent.EventName = eventName;
        //    ccmsEvent.EventType = eventType;
        //    ccmsEvent.EntityId = entityId;
        //    ccmsEvent.EntityType = entityType;
        //    ccmsEvent.Sender = source;
        //    ccmsEvent.Recipient = destination;

        //    if (trxn != null)
        //        ccmsEvent.Save(trxn.Connection, trxn);
        //    else
        //        ccmsEvent.Save();

        //}

        //public static void GenerateOrganizationAlert(int ftp_file_info_id, int alertTypeID, string msg, Event_Type eventType, int organizationID)
        //{
        //    LogableTask task = LogableTask.NewTask("GenerateOrganizationAlert");
        //    try
        //    {

        //        OrganizationAlert alert = new OrganizationAlert();
        //        alert.GeneratedAt = DateTime.Now;
        //        alert.AlertTypeId = alertTypeID;
        //        alert.FtpFileInfoId = ftp_file_info_id;
        //        alert.ExpirationTime = DateTime.Now.AddDays(DailyFeedGenerator.appSetting.AlertExpirationTime.Value);

        //        //                alert.ExpirationTime = DateTime.Now.AddDays(int.Parse(ConfigurationManager.AppSettings["AlertExpirationTime"]));

        //        alert.AlertMsg = msg;
        //        alert.RetryRemaining = 10;
        //        alert.GenerateNotificationSent = false;
        //        alert.Save();
        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for ftp file info = " + ftp_file_info_id);
        //        FtpFileInfo ftpFileInfo = FtpFileInfo.LoadFtpFileInfoByPk(ftp_file_info_id);
        //        GenerateIntegratedAlertForOrg(alertTypeID, msg, ftpFileInfo.RegionId, EntityType.Organization,
        //            eventType, ftp_file_info_id, null, organizationID);
        //    }
        //    catch (Exception ex)
        //    {
        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
        //    }
        //    finally
        //    {
        //        task.EndTask();
        //    }
        //}
        //public static void GenerateIntegratedAlertForOrg(int alertTypeID, string msg,
        //   int entityID, EntityType entityType, Event_Type eventType, int? ftpFileInfoId, SqlTransaction trxn
        //    , int organizationID)
        //{
        //    LogableTask task = LogableTask.NewTask("GenerateIntegratedAlert");
        //    int orgID = -1;
        //    try
        //    {
        //        CcmsIntegratedAlert alert = new CcmsIntegratedAlert();
        //        alert.AlertTypeId = alertTypeID;
        //        alert.AlertType = AlertType.LoadAlertTypeByPk(alertTypeID).AlertTypeName;
        //        alert.EntityId = entityID;
        //        alert.EntityType = entityType.ToString();
        //        alert.AlertLevel = eventType.ToString();
        //        alert.AlertStatus = "Unread";
        //        alert.GeneratedAt = DateTime.Now;
        //        alert.AlertText = msg;
        //        alert.ExpirationTime = DateTime.Now.AddDays(DailyFeedGenerator.appSetting.AlertExpirationTime.Value);
        //        alert.GenerateNotificationSent = false;
        //        alert.ResolveNotificationSent = false;

        //        alert.FtpFileInfoId = ftpFileInfoId;
        //        //FtpFileInfo ftpFileInfo = FtpFileInfo.LoadFtpFileInfoByPk(ftpFileInfoId.Value);
        //        Region region = Region.LoadRegionByPk(organizationID);
        //        alert.GenerateRetryRemaining = region.RetryCountAlert; // add field in region table for this....
        //        alert.ResolveRetryRemaining = region.RetryCountAlert;
        //        orgID = FtpFileInfo.LoadFtpFileInfoByPk(ftpFileInfoId.Value).RegionId;

        //        alert.ModuleType = "CURRENCY";
        //        alert.OrganizationId = orgID;

        //        if (trxn != null)
        //            alert.Save(trxn.Connection, trxn);
        //        else
        //            alert.Save();
        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added of type " + alertTypeID);
        //    }

        //    finally
        //    {
        //        task.EndTask();
        //    }
        //}
        //public static void GenerateOrganizationAlert(int ftp_file_info_id, int alertTypeID, string msg, SqlTransaction trxn, Event_Type eventType
        //    , int organizationID)
        //{
        //    LogableTask task = LogableTask.NewTask("GenerateOrganizationAlert");
        //    try
        //    {
        //        OrganizationAlert alert = new OrganizationAlert();
        //        alert.GeneratedAt = DateTime.Now;
        //        alert.AlertTypeId = alertTypeID;
        //        alert.FtpFileInfoId = ftp_file_info_id;
        //        alert.ExpirationTime = DateTime.Now.AddDays(DailyFeedGenerator.appSetting.AlertExpirationTime.Value);

        //        //                alert.ExpirationTime = DateTime.Now.AddDays(int.Parse(ConfigurationManager.AppSettings["AlertExpirationTime"]));

        //        alert.AlertMsg = msg;
        //        alert.RetryRemaining = Region.LoadRegionByPk(organizationID).RetryCountAlert;
        //        alert.GenerateNotificationSent = false;
        //        alert.Save(trxn.Connection, trxn);
        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for ftp file info = " + ftp_file_info_id);

        //        //Going to insert in integrated alert table...
        //        //    GenerateIntegratedAlert(int alertTypeID, string msg,
        //        //int entityID, EntityType entityType, Event_Type eventType,int? ftpFileInfoId,SqlTransaction trxn)
        //        FtpFileInfo ftpFileInfo = FtpFileInfo.LoadFtpFileInfoByPk(ftp_file_info_id);
        //        GenerateIntegratedAlertForOrg(alertTypeID, msg, ftpFileInfo.RegionId, EntityType.Organization,
        //            eventType, ftp_file_info_id, trxn, organizationID);
        //    }

        //    finally
        //    {
        //        task.EndTask();
        //    }
        //}


        //public static void GenerateOrganizationAlert(int ftp_file_info_id, int alertTypeID, string msg, int organizationID)
        //{
        //    LogableTask task = LogableTask.NewTask("GenerateOrganizationAlert");
        //    try
        //    {

        //        OrganizationAlert alert = new OrganizationAlert();
        //        alert.GeneratedAt = DateTime.Now;
        //        alert.AlertTypeId = alertTypeID;
        //        alert.FtpFileInfoId = ftp_file_info_id;
        //        alert.ExpirationTime = DateTime.Now.AddDays(int.Parse(ConfigurationManager.AppSettings["AlertExpirationTime"]));
        //        alert.AlertMsg = msg;
        //        alert.RetryRemaining = Region.LoadRegionByPk(organizationID).RetryCountDffUpload;
        //        alert.GenerateNotificationSent = false;
        //        alert.Save();
        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for ftp file info = " + ftp_file_info_id);
        //    }
        //    catch (Exception ex)
        //    {
        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
        //    }
        //    finally
        //    {
        //        task.EndTask();
        //    }
        //}
        //public static void GenerateOrganizationAlert(int ftp_file_info_id, int alertTypeID, string msg, SqlTransaction trxn, int organizationID)
        //{
        //    LogableTask task = LogableTask.NewTask("GenerateOrganizationAlert");
        //    try
        //    {
        //        OrganizationAlert alert = new OrganizationAlert();
        //        alert.GeneratedAt = DateTime.Now;
        //        alert.AlertTypeId = alertTypeID;
        //        alert.FtpFileInfoId = ftp_file_info_id;
        //        alert.ExpirationTime = DateTime.Now.AddDays(int.Parse(ConfigurationManager.AppSettings["AlertExpirationTime"]));
        //        alert.AlertMsg = msg;
        //        alert.RetryRemaining = Region.LoadRegionByPk(organizationID).RetryCountDffUpload;
        //        alert.GenerateNotificationSent = false;
        //        alert.Save(trxn.Connection, trxn);
        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for ftp file info = " + ftp_file_info_id);
        //    }
        //    catch (Exception ex)
        //    {
        //        task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
        //    }
        //    finally
        //    {
        //        task.EndTask();
        //    }
        //}
    }
}
