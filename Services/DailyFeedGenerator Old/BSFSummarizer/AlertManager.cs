using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System.Diagnostics;
using System.Configuration;
using ServicesDAL;

namespace Avanza.CCMS
{
    static class AlertManager
    {
        public static void GenerateTerminalAlert(long atm_id, int alertTypeID, string msg, SqlTransaction trxn, int expirationTime,int retryCount)
        {
           // LogableTask task = LogableTask.NewTask("GenerateTerminalAlert");
            try
            {
                AtmAlert alert = new AtmAlert();
                alert.AtmId = atm_id;
                alert.GeneratedAt = DateTime.Now;
                alert.AlertTypeId = alertTypeID;
                alert.GenerateNotificationSent = false;
                alert.ResolveNotificationSent = null;
                alert.GenerateAtRetryRemaining = retryCount;
                alert.ResolveAtRetryRemaining = 0;
                alert.AlertMsg = msg;
                alert.ExpirationTime = DateTime.Now.AddDays(expirationTime);
                alert.Save(trxn.Connection, trxn);
                //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for terminal " + atm_id);
            }
            finally
            {
                //task.EndTask();
            }
        }
        //public static void GenerateIntegratedAlert(int alertTypeID, string msg, int entityID, EntityType entityType, Event_Type eventType, int? ftpFileInfoId, SqlTransaction trxn, int? atmAlertID)
        //{
        //    LogableTask task = LogableTask.NewTask("GenerateIntegratedAlert");
        //    int orgID = -1;
        //    try
        //    {
        //        //CcmsIntegratedAlert alert = new CcmsIntegratedAlert();
        //        //if (atmAlertID != null)
        //        //    alert.AtmAlertId = atmAlertID;
        //        //alert.AlertTypeId = alertTypeID;
        //        //alert.AlertType = AlertType.LoadAlertTypeByPk(alertTypeID).AlertTypeName;
        //        //alert.EntityId = entityID;
        //        //alert.EntityType = entityType.ToString();
        //        //alert.AlertLevel = eventType.ToString();
        //        //alert.AlertStatus = "Unread";
        //        //alert.GeneratedAt = new DateTime?(DateTime.Now);
        //        //alert.AlertText = msg;
        //        //alert.ExpirationTime = new DateTime?(DateTime.Now.AddDays(2.0));
        //        //alert.GenerateNotificationSent = false;
        //        //alert.ResolveNotificationSent = false;
        //        //if (alert.EntityType == EntityType.ATM.ToString())
        //        //{
        //        //    Atm atm = Atm.LoadAtmByPk(entityID);
        //        //    alert.GenerateRetryRemaining = new int?(atm.RetryCountAlert);
        //        //    alert.ResolveRetryRemaining = new int?(atm.RetryCountAlert);
        //        //    orgID = GetOrganization(atm.RegionId);
        //        //}
        //        //else if (alert.EntityType == EntityType.Organization.ToString())
        //        //{
        //        //    alert.FtpFileInfoId = ftpFileInfoId;
        //        //    Region region = Region.LoadRegionByPk(FtpFileInfo.LoadFtpFileInfoByPk(ftpFileInfoId.Value).RegionId);
        //        //    alert.GenerateRetryRemaining = new int?(region.RetryCountAlert);
        //        //    alert.ResolveRetryRemaining = new int?(region.RetryCountAlert);
        //        //    orgID = FtpFileInfo.LoadFtpFileInfoByPk(ftpFileInfoId.Value).RegionId;
        //        //}
        //        //alert.ModuleType = "CURRENCY";
        //        //alert.OrganizationId = orgID;
        //        //if (trxn != null)
        //        //{
        //        //    alert.Save(trxn.Connection, trxn);
        //        //}
        //        //else
        //        //{
        //        //    alert.Save();
        //        //}
        //        //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added of type " + alertTypeID);
        //    }
        //    finally
        //    {
        //        task.EndTask();
        //    }
        //}
        //public static long GetOrganization(int region_id)
        //{
        //    Region region = Region.LoadRegionByPk(region_id);
        //    //if (region.IsOrganization)
        //    {
        //        return region.RegionId;
        //    }
        //}

        public static void GenerateTerminalAlert(long atm_id, int alertTypeID, string msg, SqlTransaction trxn, Event_Type eventType, long taskID, long? entityID, string entityType)
        {

            LogableTask task = LogableTask.NewTask("GenerateTerminalAlert");
            try
            {
                AtmAlert alert = new AtmAlert
                {
                    AtmId = atm_id,
                    GeneratedAt = DateTime.Now,
                    AlertTypeId = alertTypeID,
                    GenerateNotificationSent = false,
                    ResolveNotificationSent = null,
                    GenerateAtRetryRemaining = 10,
                    ResolveAtRetryRemaining = 0
                };
                alert.TaskId = taskID;
                alert.AlertMsg = msg;
                if (entityID.HasValue)
                {
                    alert.EntityId = entityID;
                }
                if (entityType != null)
                {
                    alert.EntityType = entityType;
                }
                if (alert.AlertTypeId == 11 || alert.AlertTypeId == 10 || alert.AlertTypeId == 8 ||
                    alert.AlertTypeId == 12 || alert.AlertTypeId == 7 || alert.AlertTypeId == 9 || alert.AlertTypeId == 13)
                {
                    alert.ExpirationTime = DateTime.Now.AddDays(2);
                }
                alert.Save(trxn.Connection, trxn);
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for terminal " + atm_id);
                //GenerateIntegratedAlert(alertTypeID, msg, alert.AtmId.Value, EntityType.ATM, eventType, null, trxn, alert.AtmAlertId);

            }
            finally
            {
                task.EndTask();
            }

        }





    }
}
