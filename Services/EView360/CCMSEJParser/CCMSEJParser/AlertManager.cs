using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Diagnostics;
using ServicesDAL;

namespace CCMSEJParser
{
    enum AlertStatus
    {
        Up = 1,
        Down = 0
    }
    static class AlertManager
    {
        public static void GenerateConditionalOrResolveAlert(int atm_id, int alertTypeID, string msg, Event_Type eventType, bool isResolved, bool isMsgUsedAsCriteria)
        {    
            SqlCommand cmd = null;
            object alertID = null;
            LogableTask task = LogableTask.NewTask("GenerateTerminalAlert");
            try
            {
                cmd = ConnectionFactory.GetNewCommand(true, DatabaseName.Core);
                if (isMsgUsedAsCriteria)
                {
                    string[] msgParts = msg.Split('|');

                    cmd.CommandText = string.Format(@"select atm_alert_id
                                                  from atm_alert
                                                  where  atm_id = {0} and  alert_type_id ={1} and resolve_at is null and alert_msg like '" + msgParts[0] + "%'", atm_id, alertTypeID);
                }
                else
                    cmd.CommandText = string.Format(@"select atm_alert_id
                                                  from atm_alert
                                                  where  atm_id = {0} and  alert_type_id ={1} and resolve_at is null", atm_id, alertTypeID);
                alertID = cmd.ExecuteScalar();
                if (alertID == null && !isResolved) // no alert in db;
                {
                    AtmAlert alert = new AtmAlert();
                    alert.EventCount = 1;
                    alert.AtmId = atm_id;
                    alert.GeneratedAt = DateTime.Now;
                    alert.AlertTypeId = alertTypeID;
                    alert.GenerateNotificationSent = false;
                    alert.ResolveNotificationSent = false;
                    alert.GenerateAtRetryRemaining = 10;//Atm.LoadAtmByPk(atm_id).RetryCountAlert;
                    alert.ResolveAtRetryRemaining = alert.GenerateAtRetryRemaining;
                    alert.AlertMsg = msg;
                    alert.Save();
                    
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for terminal " + atm_id);
                }
                else
                {

                    if (alertID != null)
                    {
                        AtmAlert atmAlert = AtmAlert.LoadAtmAlert($"atm_alert_id=" +long.Parse(alertID.ToString()));
                        if (atmAlert != null)
                        {
                            if (isResolved)
                            {
                                atmAlert.ResolveAt = DateTime.Now;
                                atmAlert.Save();
                            }
                            else
                            {
                                atmAlert.EventCount++;
                                atmAlert.Save();
                            }
                        }
                    }


                }
            }

            finally
            {
                if (cmd != null)
                    if (cmd.Connection != null)
                        cmd.Connection.Close();
                task.EndTask();
            }
        }
        public static int GenerateTerminalAlert(int atm_id, int alertTypeID, string msg, SqlTransaction trxn, Event_Type eventType, int taskID,
           int? entityID, string entityType)
        {
            LogableTask task = LogableTask.NewTask("GenerateTerminalAlert");
            try
            {

                AtmAlert alert = new AtmAlert();
                alert.AtmId = atm_id;
                alert.GeneratedAt = DateTime.Now;
                alert.AlertTypeId = alertTypeID;
                alert.GenerateNotificationSent = false;
                alert.ResolveNotificationSent = null;
                alert.GenerateAtRetryRemaining = 10;
                alert.ResolveAtRetryRemaining = 0;
                alert.TaskId = taskID;
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

             alert.AlertTypeId == (int)EnumAlertType.ATMCashLevelFileDownloadFailed
             )
                {
                    alert.ExpirationTime = DateTime.Now.AddDays(2);


                }


                alert.Save(trxn.Connection, trxn);
   
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added of type " + alertTypeID + " for terminal " + atm_id);
                
                return (int)alert.AtmAlertId;
            }

            finally
            {
                task.EndTask();
            }
        }
        
         public static void GenerateTerminalAlert(int atm_id, int alertTypeID, string msg, Event_Type eventType)
        {          
            LogableTask task = LogableTask.NewTask("GenerateTerminalAlert");
            try
            {
                AtmAlert alert = new AtmAlert();
                alert.AtmId = atm_id;
                alert.GeneratedAt = DateTime.Now;
                alert.AlertTypeId = alertTypeID;
                alert.GenerateNotificationSent = false;
                alert.ResolveNotificationSent = null;
                alert.GenerateAtRetryRemaining = 10;//Atm.LoadAtmByPk(atm_id).RetryCountAlert;
                alert.ResolveAtRetryRemaining = 0;
                alert.AlertMsg = msg;

                if (alert.AlertTypeId == (int)EnumAlertType.DenominationMissing ||
                    alert.AlertTypeId == (int)EnumAlertType.TerminalNotLicensed ||
                    alert.AlertTypeId == (int)EnumAlertType.ConfigurationUploadFailed ||
                    alert.AlertTypeId == (int)EnumAlertType.ConfigurationMismatch ||
                    alert.AlertTypeId == (int)EnumAlertType.CashOrderUploadFailed ||
                    alert.AlertTypeId == (int)EnumAlertType.CashOrderField20Missing ||
                    alert.AlertTypeId == (int)EnumAlertType.ATMCashLevelFileDownloadFailed ||
                    alert.AlertTypeId == (int)EnumAlertType.SummaryDataRegenerated ||
                    alert.AlertTypeId == (int)EnumAlertType.ATMInactivityPeriodElapsed
                             )
                {
                    //                alert.ExpirationTime = DateTime.Now.AddDays(int.Parse(ConfigurationManager.AppSettings["AlertExpirationTime"]));
                    if (CCMSEJParser.Service1.appSettings.AlertExpirationTime.HasValue)
                        alert.ExpirationTime = DateTime.Now.AddDays(CCMSEJParser.Service1.appSettings.AlertExpirationTime.Value);
                    else
                        alert.ExpirationTime = DateTime.Now.AddDays(3);


                }
                alert.Save();
                
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for terminal " + atm_id);
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                throw;
            }

            finally
            {
                task.EndTask();
            }
        }
    }
}
