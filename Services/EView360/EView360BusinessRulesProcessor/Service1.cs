using Encryption;
using Microsoft.Win32;
using ServicesDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using MSMQ.Messaging;
using System.Net;

namespace View360BusinessRulesProcessor
{
    public partial class EV360BusinessRulesProcessor : BackgroundService
    {
        System.Threading.Timer timer;
        System.Threading.Timer timerScheduleThreadForExecution;
        static AppSetting appSetting = null;
        //static List<DateTime> listNormalDays = null;
        //decimal minOperatingBalance = 0;
        public static string[] denominationMapping = System.Configuration.ConfigurationManager.AppSettings["denominationMapping"].Split(',');
        int workerThread = int.Parse(System.Configuration.ConfigurationManager.AppSettings["workerThread"]);
        //private static MessageQueue queue = new MessageQueue($@".\private$\{System.Configuration.ConfigurationManager.AppSettings["View360BusinessRPQueueName"]}");

        //public  int ATMID = 0;
        public static bool GenerateConditionalTerminalAlert(long atmID, int alertTypeID, string msg, bool isResolved, Event_Type eventType, long taskID,
            bool isResolveNotificationEnabled)
        {
            bool isAlertInsertedOrUpdated = false;
            LogableTask task = LogableTask.NewTask("GenerateConditionalTerminalAlert");
            SqlCommand cmd = null;
            SqlTransaction trxn = null;
            object alertID = null;
            try
            {
                cmd = ConnectionFactory.GetNewCommand(true, DatabaseName.Cash);
                cmd.CommandText = string.Format(@"select atm_alert_id from atm_alert where  atm_id = {0} and  alert_type_id ={1} and resolve_at is null ", atmID, alertTypeID);

                alertID = cmd.ExecuteScalar();

                if (alertID == null && !isResolved) // no alert in db;
                {
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    trxn = cmd.Connection.BeginTransaction();
                    cmd.Transaction = trxn;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                    //Generate and resolve Alert
                    AtmAlert alert = new AtmAlert();
                    alert.AlertMsg = msg;
                    alert.AtmId = atmID;
                    alert.GeneratedAt = DateTime.Now;
                    alert.ResolveAt = null;
                    alert.AlertTypeId = alertTypeID;
                    alert.GenerateNotificationSent = false;
                    alert.ResolveNotificationSent = false;
                    alert.GenerateAtRetryRemaining = 10;
                    alert.ResolveAtRetryRemaining = isResolveNotificationEnabled ? 10 : 0;
                    alert.TaskId = taskID;
                    alert.Save();
                    //SmsTaskHelper.CheckConfiguration(null, null, null, alert.AlertTypeId, "0", trxn);
                    //SmsTaskHelper.CheckConfiguration(null, null, null, alert.AtmAlertId, alert.AlertTypeId, "", alert.AtmId.Value, 0, "", "", "", taskID, trxn);

                    //isAlertInserted = true;
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for terminal " + atmID);
                    //GenerateIntegratedAlert(alertTypeID, msg, alert.AtmId.Value, EntityType.ATM, eventType, null, trxn, alert.AtmAlertId, isResolveNotificationEnabled);
                    isAlertInsertedOrUpdated = true;
                }
                else if (alertID != null && isResolved) // Down alert exists. Now insert notification for active alert
                {
                    isAlertInsertedOrUpdated = true;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    trxn = cmd.Connection.BeginTransaction();
                    cmd.Transaction = trxn;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                    AtmAlert alert = AtmAlert.LoadAtmAlert("atm_alert_id="+int.Parse(alertID.ToString()));
                    alert.ResolveAt = DateTime.Now;
                    alert.AlertTypeId = alertTypeID;
                    alert.Save();
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert updated for terminal " + atmID);
                    //cmd.CommandText = string.Format(@"select id from ccms_integrated_alert where  entity_id = {0} and  alert_type_id ={1} ", atmID, alertTypeID);
                    //cmd.CommandText = string.Format(@"select id from ccms_integrated_alert where  atm_alert_id = {0}", alert.AtmAlertId);

                    //object result = cmd.ExecuteScalar();
                    //if (result != null)
                    //{
                    //    int id = int.Parse(result.ToString());
                    //    CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlertByPk(id);
                    //    ccmsIntAlert.ResolvedAt = DateTime.Now;
                    //    ccmsIntAlert.AlertTypeId = alertTypeID;
                    //    ccmsIntAlert.Save();
                    //}

                }


                if (trxn != null)
                    trxn.Commit();

                //return isAlertInserted;
                return isAlertInsertedOrUpdated;
            }
            catch (Exception ex)
            {
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                if (trxn != null)
                    trxn.Rollback();
                throw;
            }


            finally
            {
                if (cmd != null)
                    if (cmd.Connection != null)
                        cmd.Connection.Close();
                task.EndTask();
            }

        }


        public static long GenerateConditionalTerminalAlert(long atm_id, int alertTypeID, string msg, SqlTransaction trxn, Event_Type eventType, long taskID,
       long? entityID, string entityType)
        {
            long newAlertID = -1;
            LogableTask task = LogableTask.NewTask("GenerateConditionalTerminalAlert");
            //SqlCommand cmd = null;
            try
            {
                //  cmd = ConnectionFactory.GetNewCommand(true);
                DataTable result = ExecuteStoredProcedure("GetAtmAlert",
                    "alert_type_id = " + alertTypeID + " and resolve_at is null and atm_id=" + atm_id, 2, null);

                //                cmd.CommandText = string.Format(@"select atm_alert_id
                //                                                  from atm_alert
                //                                                  where alert_type_id = {0} and resolve_at is null and atm_id={1}", alertTypeID, atm_id);

                //  if (int.Parse(result.Rows[0][0].ToString()) == 0)


                //object alertID = cmd.ExecuteScalar();
                if (int.Parse(result.Rows[0][0].ToString()) == 0) // no alert in db; 
                {
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "No Alert in db for type " + alertTypeID + " so going to add it");
                    //AppSetting appSetting = AppSetting.LoadAppSetting("1=1");
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
                    alert.TaskId = taskID;
                    alert.Save();
                    //SmsTaskHelper.CheckConfiguration(null, null, null, alert.AlertTypeId, "0", trxn);
                    //SmsTaskHelper.CheckConfiguration(null, null, null, alert.AtmAlertId, alert.AlertTypeId, "", alert.AtmId.Value, 0, "", "", "", taskID, trxn);
                    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for terminal " + atm_id);
                    //GenerateIntegratedAlert(alertTypeID, msg, alert.AtmId.Value, EntityType.ATM,
                      // eventType, null, trxn, alert.AtmAlertId, false);
                    newAlertID = alert.AtmAlertId;


                }
                return newAlertID;
            }

            finally
            {
                //if (cmd != null)
                //    if (cmd.Connection != null)
                //        cmd.Connection.Close();
                task.EndTask();
            }
        }
        public static long GenerateTerminalAlert(long atm_id, int alertTypeID, string msg, SqlTransaction trxn, Event_Type eventType, int taskID,
           long? entityID, string entityType)
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
                    //alert.ExpirationTime = DateTime.Now.AddDays(int.Parse(ConfigurationManager.AppSettings["AlertExpirationTime"]));

                    alert.ExpirationTime = DateTime.Now.AddDays(2);


                }


                alert.Save();
                //SmsTaskHelper.CheckConfiguration(null, null, null, alert.AtmAlertId, alert.AlertTypeId, "", alert.AtmId.Value, 0, "", "", "", taskID, trxn);
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for terminal " + atm_id);
                //GenerateIntegratedAlert(alertTypeID, msg, alert.AtmId.Value, EntityType.ATM,
                 //  eventType, null, trxn, alert.AtmAlertId, true);
                return alert.AtmAlertId;
            }

            finally
            {
                task.EndTask();
            }
        }

      


        public static void HandleReplenishment(Replenishment replenishment, Atm ATM, SqlTransaction trxn, NoteSetType noteSetType, int taskID)
        {
            bool isAlertGenEnabled = true;
            DataTable dtReplenishmentRow = ExecuteStoredProcedure("GetReplenishmentRow",
                "  atm_id =" + ATM.ATMId + " and rep_datetime > convert(datetime,'" + replenishment.RepDatetime.ToString("dd/MM/yyyy HH:mm:ss") + "',103) ", 2, null);
            if (dtReplenishmentRow.Rows.Count > 0)
            {
                if (long.Parse(dtReplenishmentRow.Rows[0][0].ToString()) > 0)
                    isAlertGenEnabled = false;
            }

            if (replenishment.IsSwap && isAlertGenEnabled)
            {
                AtmAlert atmAlert = AtmAlert.LoadAtmAlert("alert_type_id=" + (int)EnumAlertType.PurgeBinThresholdReached + " and atm_id=" + ATM.ATMId + " and resolve_at is null");
                if (atmAlert != null)
                {
                    atmAlert.ResolveAt = DateTime.Now;
                    atmAlert.Save();
                    //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Purge bin alert resolved for atm_id = " + ATM.ATMId);

                    //CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert.AtmAlertId);
                    //if (ccmsIntAlert != null)
                    //{
                    //    ccmsIntAlert.ResolvedAt = DateTime.Now;
                    //    ccmsIntAlert.Save();
                    //    //  task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Purge bin alert from ccms integrated alert resolved for atm_id = " + ATM.ATMId);
                    //}
                }
            }
            if (isAlertGenEnabled)
                GenerateTerminalAlert(ATM.ATMId, (int)EnumAlertType.ReplenishmentAtATM, "Repenishment At ATM", trxn, Event_Type.Information, taskID, replenishment.ReplenishmentId, "Replenishment");


            if (replenishment.IsSwap)
                ExecuteStoredProcedure("UpdateCashPosition",
                    " atm_id =" + ATM.ATMId + " and last_trxn_at >=convert(datetime,'" + replenishment.RepDatetime.ToString("dd/MM/yyyy") + "',103) " +
                    " and last_trxn_at <=convert(datetime,'" + replenishment.RepDatetime.ToString("dd/MM/yyyy") + " 23:59:59',103)", -1, trxn);









        }


        static decimal GetATMMinOperatingBalance(Atm atm, DateTime? Day)
        {
            decimal minOperatingBalance = 0;
            minOperatingBalance = atm.MinOperatingBalance.Value;

            return minOperatingBalance;

        }

        //DataTable ExecuteStoredProcedure(string storedProcedureName, string whereClause, int functionID, SqlTransaction trxn)
        //{
        //    SqlCommand cmd = null;

        //    if (trxn != null)
        //    {
        //        cmd = trxn.Connection.CreateCommand();
        //        cmd.Transaction = trxn;
        //    }
        //    else
        //        cmd = ConnectionFactory.GetNewCommand(false);

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = storedProcedureName;
        //    cmd.Parameters.Add("whereClause", whereClause);
        //    if (functionID > 0)
        //        cmd.Parameters.Add("functionID", functionID);
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adapter.Fill(dt);
        //    return dt;
        //}

        public static void MinThresholdProcessing(Atm ATM, string[] subParts, ParsedTransaction parsedTransaction, NoteSetType noteSetType, long taskID)
        {
            if (ATM.Type1MinNotesThresholdValue.HasValue)
            {
                if (ATM.Type1MinNotesThresholdValue > 0)
                {
                    if ((decimal)parsedTransaction.CashRemaining1 <= ATM.Type1MinNotesThresholdValue)
                    {
                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type1MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                        (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                        parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                        parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                        parsedTransaction.CashRemaining4 * noteSetType.DenominationType4)
                        , false, Event_Type.Information, taskID, false);
                    }
                    else

                        //ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = "+(int)EnumAlertType.Type1MinNotesThresholdReached+" and resolve_at is null and atm_id="+ATM.ATMId, trxn);
                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type1MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);
                }
            }
            if (ATM.Type2MinNotesThresholdValue.HasValue)
            {
                if (ATM.Type2MinNotesThresholdValue > 0)
                {
                    if ((decimal)parsedTransaction.CashRemaining2 <= ATM.Type2MinNotesThresholdValue)
                    {
                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type2MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                        (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                        parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                        parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                        parsedTransaction.CashRemaining4 * noteSetType.DenominationType4), false, Event_Type.Information, taskID, false);
                    }
                    else
                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type2MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);
                    //ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = " + (int)EnumAlertType.Type2MinNotesThresholdReached + " and resolve_at is null and atm_id=" + ATM.ATMId, trxn);
                }
            }
            if (ATM.Type3MinNotesThresholdValue.HasValue)
            {
                if (ATM.Type3MinNotesThresholdValue > 0)
                {
                    if ((decimal)parsedTransaction.CashRemaining3 <= ATM.Type3MinNotesThresholdValue)
                    {
                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type3MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                        (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                        parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                        parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                        parsedTransaction.CashRemaining4 * noteSetType.DenominationType4), false, Event_Type.Information, taskID, false);
                    }
                    else
                        //ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = " + (int)EnumAlertType.Type3MinNotesThresholdReached + " and resolve_at is null and atm_id=" + ATM.ATMId, trxn);
                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type3MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);
                }
            }
            if (ATM.Type4MinNotesThresholdValue.HasValue)
            {
                if (ATM.Type4MinNotesThresholdValue > 0)
                {
                    if ((decimal)parsedTransaction.CashRemaining4 <= ATM.Type4MinNotesThresholdValue)
                    {
                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type4MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                        (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                        parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                        parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                        parsedTransaction.CashRemaining4 * noteSetType.DenominationType4), false, Event_Type.Information, taskID, false);
                    }
                    else
                        // ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = " + (int)EnumAlertType.Type4MinNotesThresholdReached + " and resolve_at is null and atm_id=" + ATM.ATMId, trxn);
                        GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type4MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);

                }

            }

            DataTable dtExistingReplenishment = ExecuteStoredProcedure("GetReplenishmentRow",
  string.Format("rep_datetime in (select  max(rep_datetime) from replenishment where  " +
                                        " atm_id ={1} and rep_datetime<=convert(datetime,'{0}',101)) and atm_id={1}", subParts[0], ATM.ATMId), 1, null);



            //bool repUpdated = false;
            if (dtExistingReplenishment.Rows.Count > 0)
            {
                //Changes done on 21/5/2015
                //Changes done on 13/01/2014 to generate alerts in case of type 1 reaches below threshold value.
                if (ATM.Type1MinNotesThreshold.HasValue)
                {
                    if (ATM.Type1MinNotesThreshold > 0)
                    {
                        if (int.Parse(dtExistingReplenishment.Rows[0]["cash_added1"].ToString()) != 0)
                        {
                            if ((decimal)parsedTransaction.CashRemaining1 / int.Parse(dtExistingReplenishment.Rows[0]["cash_added1"].ToString()) * 100 <= ATM.Type1MinNotesThreshold)
                            {
                                GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type1MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                                (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                                parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                                parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                                parsedTransaction.CashRemaining4 * noteSetType.DenominationType4)
                                , false, Event_Type.Information, taskID, false);
                            }
                            else 
                            //ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = "+(int)EnumAlertType.Type1MinNotesThresholdReached+" and resolve_at is null and atm_id="+ATM.ATMId, trxn);
                            GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type1MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);
                        }
                    }
                }
                if (ATM.Type2MinNotesThreshold.HasValue)
                {
                    if (ATM.Type1MinNotesThreshold > 0)
                    {
                        if (int.Parse(dtExistingReplenishment.Rows[0]["cash_added2"].ToString()) != 0)
                        {
                            if ((decimal)parsedTransaction.CashRemaining2 / int.Parse(dtExistingReplenishment.Rows[0]["cash_added2"].ToString()) * 100 <= ATM.Type2MinNotesThreshold)
                            {
                                GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type2MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                                (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                                parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                                parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                                parsedTransaction.CashRemaining4 * noteSetType.DenominationType4), false, Event_Type.Information, taskID, false);
                            }
                            else 
                            GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type2MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);
                        }
                        //ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = " + (int)EnumAlertType.Type2MinNotesThresholdReached + " and resolve_at is null and atm_id=" + ATM.ATMId, trxn);
                    }
                }
                if (ATM.Type3MinNotesThreshold.HasValue)
                {
                    if (ATM.Type3MinNotesThreshold > 0)
                    {
                        if (int.Parse(dtExistingReplenishment.Rows[0]["cash_added3"].ToString()) != 0)
                        {
                            if ((decimal)parsedTransaction.CashRemaining3 / int.Parse(dtExistingReplenishment.Rows[0]["cash_added3"].ToString()) * 100 <= ATM.Type3MinNotesThreshold)
                            {
                                GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type3MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                                (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                                parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                                parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                                parsedTransaction.CashRemaining4 * noteSetType.DenominationType4), false, Event_Type.Information, taskID, false);
                            }
                            else 
                            //ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = " + (int)EnumAlertType.Type3MinNotesThresholdReached + " and resolve_at is null and atm_id=" + ATM.ATMId, trxn);
                            GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type3MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);
                        }
                    }
                }
                if (ATM.Type4MinNotesThreshold.HasValue)
                {
                    if (ATM.Type4MinNotesThreshold > 0)
                    {
                        if (int.Parse(dtExistingReplenishment.Rows[0]["cash_added4"].ToString()) != 0)
                        {
                            if ((decimal)parsedTransaction.CashRemaining4 / int.Parse(dtExistingReplenishment.Rows[0]["cash_added4"].ToString()) * 100 <= ATM.Type4MinNotesThreshold)
                            {
                                GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type4MinNotesThresholdReached, parsedTransaction.CashRemaining1 + "|" + parsedTransaction.CashRemaining2 + "|" + parsedTransaction.CashRemaining3 + "|" + parsedTransaction.CashRemaining4 + "|" +
                                (parsedTransaction.CashRemaining1 * noteSetType.DenominationType1 +
                                parsedTransaction.CashRemaining2 * noteSetType.DenominationType2 +
                                parsedTransaction.CashRemaining3 * noteSetType.DenominationType3 +
                                parsedTransaction.CashRemaining4 * noteSetType.DenominationType4), false, Event_Type.Information, taskID, false);
                            }
                            else 
                            // ConnectionFactory.ExecuteQuery("update atm_alert set resolve_at = getdate(),resolve_at_retry_remaining=10 where alert_type_id = " + (int)EnumAlertType.Type4MinNotesThresholdReached + " and resolve_at is null and atm_id=" + ATM.ATMId, trxn);
                            GenerateConditionalTerminalAlert(ATM.ATMId, (int)EnumAlertType.Type4MinNotesThresholdReached, "", true, Event_Type.Information, taskID, false);
                        }
                    }
                }

            }
        }


        public static void UpdateCashPosition(string currentCassetteStatus, Atm atm, NoteSetType noteSetType, SqlTransaction trxn, long taskID, ParsedTransaction parsedTrxn,
       ref bool isOutOfCashAlertResolved, ref bool isLowBalanceAlertResolved, ref bool isOutOfCashAlertGenerated, ref bool isLowBalanceAlertGenerated)
        {
            //Added on 06-Sep-2015 by IK
            /////////////////////////////
            /////////////////////////////
            CashPosition cashPosition = null;
            LogableTask task = LogableTask.NewTask();
            try
            {
                string[] parts = currentCassetteStatus.Split('|');
                DateTime lastTrxnAt = DateTime.ParseExact(parts[0], "MM/dd/yyyy HH:mm:ss", null);

                DataTable dt = ExecuteStoredProcedure("GetCashPosition",
                    "atm_id =" + atm.ATMId + " and last_trxn_at >=convert(datetime,'" + lastTrxnAt.ToString("dd/MM/yyyy") + "',103) " +
                    " and last_trxn_at <=convert(datetime,'" + lastTrxnAt.ToString("dd/MM/yyyy") + " 23:59:59',103)", 1, null);

                if (dt.Rows.Count == 0)
                //CashPosition cashPosition = CashPosition.LoadCashPosition();

                // if (cashPosition == null)
                {
                    cashPosition = new CashPosition();
                    cashPosition.AtmId = atm.ATMId;
                    cashPosition.LastTrxnAt = lastTrxnAt;

                    cashPosition.PurgeCassette1Notes = 0;
                    cashPosition.PurgeCassette2Notes = 0;
                    cashPosition.PurgeCassette3Notes = 0;
                    cashPosition.PurgeCassette4Notes = 0;
                    cashPosition.PurgeCassette5Notes = 0;
                    cashPosition.PurgeCassette6Notes = 0;
                    cashPosition.PurgeCassette7Notes = 0;


                    DataTable dtYesterdayCashPosition = ExecuteStoredProcedure("GetCashPosition",
                    "atm_id =" + atm.ATMId + " and last_trxn_at >=convert(datetime,'" + lastTrxnAt.AddDays(-1).ToString("dd/MM/yyyy") + "',103) " +
                   " and last_trxn_at <=convert(datetime,'" + lastTrxnAt.AddDays(-1).ToString("dd/MM/yyyy") + " 23:59:59',103)", 1, null);

                    //CashPosition lastCashPosition = CashPosition.LoadCashPosition(");

                    //if (lastCashPosition != null)
                    if (dtYesterdayCashPosition.Rows.Count > 0)
                    {

                        DataTable dtCurrentDayReplenishment = ExecuteStoredProcedure("GetReplenishmentRow",
                        "atm_id =" + atm.ATMId + " and rep_datetime >=convert(datetime,'" + lastTrxnAt.ToString("dd/MM/yyyy") + "',103) " +
                        " and rep_datetime <=convert(datetime,'" + lastTrxnAt.ToString("dd/MM/yyyy") + " 23:59:59',103)", 1, null);


                        //Replenishment currentDayReplenishment = Replenishment.LoadReplenishment();

                        // if (currentDayReplenishment == null)
                        if (dtCurrentDayReplenishment.Rows.Count == 0)
                        {
                            cashPosition.PurgeCassette1Notes = int.Parse(dtYesterdayCashPosition.Rows[0]["purge_cassette1_notes"].ToString());
                            cashPosition.PurgeCassette2Notes = int.Parse(dtYesterdayCashPosition.Rows[0]["purge_cassette2_notes"].ToString());
                            cashPosition.PurgeCassette3Notes = int.Parse(dtYesterdayCashPosition.Rows[0]["purge_cassette3_notes"].ToString());
                            cashPosition.PurgeCassette4Notes = int.Parse(dtYesterdayCashPosition.Rows[0]["purge_cassette4_notes"].ToString());
                            cashPosition.PurgeCassette5Notes = int.Parse(dtYesterdayCashPosition.Rows[0]["purge_cassette5_notes"].ToString());
                            cashPosition.PurgeCassette6Notes = int.Parse(dtYesterdayCashPosition.Rows[0]["purge_cassette6_notes"].ToString());
                            cashPosition.PurgeCassette7Notes = int.Parse(dtYesterdayCashPosition.Rows[0]["purge_cassette7_notes"].ToString());
                        }
                    }



                    if (currentCassetteStatus.Contains("Replenishment"))
                    {
                        //05/23/2017 13:38:18|Replenishment|OrderMissing|20170523133612|20170523133818|-1|0|0|0|500|0|0|0|1992|0|478|1469|0|0|0|8|0|22|31|0|0|0|2000|0|500|2000|0|0|0
                        cashPosition.Cassette1Notes = int.Parse(parts[27]);
                        cashPosition.Cassette2Notes = int.Parse(parts[28]);
                        cashPosition.Cassette3Notes = int.Parse(parts[29]);
                        cashPosition.Cassette4Notes = int.Parse(parts[30]);
                        cashPosition.Cassette5Notes = int.Parse(parts[31]);
                        cashPosition.Cassette6Notes = int.Parse(parts[32]);
                        cashPosition.Cassette7Notes = int.Parse(parts[33]);
                        cashPosition.LastTrxnAt = lastTrxnAt;
                    }
                    else if (currentCassetteStatus.Contains("TestCash"))
                    {

                        if (currentCassetteStatus.Contains("Dummy"))
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "EOD Dummy test cash is being used.");

                            cashPosition.PurgeCassette1Notes = int.Parse(parts[9]);
                            cashPosition.PurgeCassette2Notes = int.Parse(parts[10]);
                            cashPosition.PurgeCassette3Notes = int.Parse(parts[11]);
                            cashPosition.PurgeCassette4Notes = int.Parse(parts[12]);
                            cashPosition.PurgeCassette5Notes = int.Parse(parts[13]);
                            cashPosition.PurgeCassette6Notes = int.Parse(parts[14]);
                            cashPosition.PurgeCassette7Notes = int.Parse(parts[15]);

                        }

                        cashPosition.Cassette1Notes = int.Parse(parts[2]) - int.Parse(parts[9]);
                        cashPosition.Cassette2Notes = int.Parse(parts[3]) - int.Parse(parts[10]);
                        cashPosition.Cassette3Notes = int.Parse(parts[4]) - int.Parse(parts[11]);
                        cashPosition.Cassette4Notes = int.Parse(parts[5]) - int.Parse(parts[12]);
                        cashPosition.Cassette5Notes = int.Parse(parts[6]) - int.Parse(parts[13]);
                        cashPosition.Cassette6Notes = int.Parse(parts[7]) - int.Parse(parts[14]);
                        cashPosition.Cassette7Notes = int.Parse(parts[8]) - int.Parse(parts[15]);

                        cashPosition.PurgeCassette1Notes += int.Parse(parts[9]);
                        cashPosition.PurgeCassette2Notes += int.Parse(parts[10]);
                        cashPosition.PurgeCassette3Notes += int.Parse(parts[11]);
                        cashPosition.PurgeCassette4Notes += int.Parse(parts[12]);

                    }
                    else
                    {

                        cashPosition.Cassette1Notes = int.Parse(parts[3]) - int.Parse(parts[10]) - int.Parse(parts[17]);
                        cashPosition.Cassette2Notes = int.Parse(parts[4]) - int.Parse(parts[11]) - int.Parse(parts[18]);
                        cashPosition.Cassette3Notes = int.Parse(parts[5]) - int.Parse(parts[12]) - int.Parse(parts[19]);
                        cashPosition.Cassette4Notes = int.Parse(parts[6]) - int.Parse(parts[13]) - int.Parse(parts[20]);
                        cashPosition.Cassette5Notes = int.Parse(parts[7]) - int.Parse(parts[14]) - int.Parse(parts[21]);
                        cashPosition.Cassette6Notes = int.Parse(parts[8]) - int.Parse(parts[15]) - int.Parse(parts[22]);
                        cashPosition.Cassette7Notes = int.Parse(parts[9]) - int.Parse(parts[16]) - int.Parse(parts[23]);


                        cashPosition.PurgeCassette1Notes += int.Parse(parts[17]);
                        cashPosition.PurgeCassette2Notes += int.Parse(parts[18]);
                        cashPosition.PurgeCassette3Notes += int.Parse(parts[19]);
                        cashPosition.PurgeCassette4Notes += int.Parse(parts[20]);
                        cashPosition.PurgeCassette5Notes += int.Parse(parts[21]);
                        cashPosition.PurgeCassette6Notes += int.Parse(parts[22]);
                        cashPosition.PurgeCassette7Notes += int.Parse(parts[23]);


                    }
                    cashPosition.TaskId = taskID;
                    cashPosition.Save();
                }
                else
                {
                    cashPosition = new CashPosition();
                    cashPosition.isNewEntity = false;
                    cashPosition.CashPositionId = int.Parse(dt.Rows[0]["cash_position_id"].ToString());
                    cashPosition.AtmId = int.Parse(dt.Rows[0]["atm_id"].ToString());
                    cashPosition.Cassette1Notes = int.Parse(dt.Rows[0]["cassette1_notes"].ToString());
                    cashPosition.Cassette2Notes = int.Parse(dt.Rows[0]["cassette2_notes"].ToString());
                    cashPosition.Cassette3Notes = int.Parse(dt.Rows[0]["cassette3_notes"].ToString());
                    cashPosition.Cassette4Notes = int.Parse(dt.Rows[0]["cassette4_notes"].ToString());
                    cashPosition.Cassette5Notes = 0;
                    cashPosition.Cassette6Notes = 0;
                    cashPosition.Cassette7Notes = 0;
                    cashPosition.TaskId = int.Parse(dt.Rows[0]["task_id"].ToString());
                    cashPosition.LastTrxnAt = DateTime.Parse(dt.Rows[0]["last_trxn_at"].ToString());

                    cashPosition.PurgeCassette1Notes = int.Parse(dt.Rows[0]["purge_cassette1_notes"].ToString());
                    cashPosition.PurgeCassette2Notes = int.Parse(dt.Rows[0]["purge_cassette2_notes"].ToString());
                    cashPosition.PurgeCassette3Notes = int.Parse(dt.Rows[0]["purge_cassette3_notes"].ToString());
                    cashPosition.PurgeCassette4Notes = int.Parse(dt.Rows[0]["purge_cassette4_notes"].ToString());
                    cashPosition.PurgeCassette5Notes = 0;
                    cashPosition.PurgeCassette6Notes = 0;
                    cashPosition.PurgeCassette7Notes = 0;



                    if (DateTime.ParseExact(parts[0], "MM/dd/yyyy HH:mm:ss", null) < cashPosition.LastTrxnAt)
                    {
                        LogableTask.LogMonoActivityTask("Ignore Trxn", MethodBase.GetCurrentMethod(), TraceLevel.Info, "Cash position is not updated bcoz we have trxn of future date: " + cashPosition.LastTrxnAt);
                        return;
                    }
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Change done by IK on 31/08/2016
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (currentCassetteStatus.Contains("CashWithdrawal"))
                        cashPosition.LastTrxnAt = DateTime.ParseExact(parts[0], "MM/dd/yyyy HH:mm:ss", null);

                    //if (parsedTrxn != null)
                    //{
                    //    if (cashPosition.Cassette1Notes != parsedTrxn.CashRemaining1 ||
                    //        cashPosition.Cassette2Notes != parsedTrxn.CashRemaining2 ||
                    //        cashPosition.Cassette3Notes != parsedTrxn.CashRemaining3 ||
                    //        cashPosition.Cassette4Notes != parsedTrxn.CashRemaining4 ||
                    //        cashPosition.Cassette5Notes != parsedTrxn.CashRemaining5 ||
                    //        cashPosition.Cassette6Notes != parsedTrxn.CashRemaining6 ||
                    //        cashPosition.Cassette7Notes != parsedTrxn.CashRemaining7)
                    //    {
                    //        GenerateTerminalAlert(cashPosition.AtmId, (int)EnumAlertType.CounterDiscrepency, cashPosition.Cassette1Notes + "|" +
                    //            cashPosition.Cassette2Notes + "|" + cashPosition.Cassette3Notes + "|" + cashPosition.Cassette4Notes + "|" + cashPosition.Cassette5Notes + "|" +
                    //            cashPosition.Cassette6Notes + "|" + cashPosition.Cassette7Notes + "|" + parsedTrxn.CashRemaining1 + "|" +
                    //            parsedTrxn.CashRemaining2 + "|" + parsedTrxn.CashRemaining3 + "|" + parsedTrxn.CashRemaining4 + "|" +
                    //            parsedTrxn.CashRemaining5 + "|" + parsedTrxn.CashRemaining6 + "|" + parsedTrxn.CashRemaining7, trxn, Event_Type.Information, taskID, null, null);
                    //    }
                    //}

                    if (cashPosition.PurgeCassette1Notes == null)
                        cashPosition.PurgeCassette1Notes = 0;
                    if (cashPosition.PurgeCassette2Notes == null)
                        cashPosition.PurgeCassette2Notes = 0;
                    if (cashPosition.PurgeCassette3Notes == null)
                        cashPosition.PurgeCassette3Notes = 0;
                    if (cashPosition.PurgeCassette4Notes == null)
                        cashPosition.PurgeCassette4Notes = 0;
                    if (cashPosition.PurgeCassette5Notes == null)
                        cashPosition.PurgeCassette5Notes = 0;
                    if (cashPosition.PurgeCassette6Notes == null)
                        cashPosition.PurgeCassette6Notes = 0;
                    if (cashPosition.PurgeCassette7Notes == null)
                        cashPosition.PurgeCassette7Notes = 0;

                    //if (currentCassetteStatus.Contains("CountsCleared"))
                    //{
                    //    cashPosition.Cassette1Notes = 0;
                    //    cashPosition.Cassette2Notes = 0;
                    //    cashPosition.Cassette3Notes = 0;
                    //    cashPosition.Cassette4Notes = 0;
                    //    cashPosition.Cassette5Notes = 0;
                    //    cashPosition.Cassette6Notes = 0;
                    //    cashPosition.Cassette7Notes = 0;
                    //}

                    if (currentCassetteStatus.Contains("Replenishment"))
                    {
                        //If the replenishment is swap ,update current counters else add in existing counters. 
                        if (int.Parse(parts[parts.Length - 1]) == 1 || parts.Length == 34)
                        {
                            cashPosition.Cassette1Notes = int.Parse(parts[27]);
                            cashPosition.Cassette2Notes = int.Parse(parts[28]);
                            cashPosition.Cassette3Notes = int.Parse(parts[29]);
                            cashPosition.Cassette4Notes = int.Parse(parts[30]);
                            cashPosition.Cassette5Notes = int.Parse(parts[31]);
                            cashPosition.Cassette6Notes = int.Parse(parts[32]);
                            cashPosition.Cassette7Notes = int.Parse(parts[33]);
                        }
                        else
                        {
                            cashPosition.Cassette1Notes += int.Parse(parts[27]);
                            cashPosition.Cassette2Notes += int.Parse(parts[28]);
                            cashPosition.Cassette3Notes += int.Parse(parts[29]);
                            cashPosition.Cassette4Notes += int.Parse(parts[30]);
                            cashPosition.Cassette5Notes += int.Parse(parts[31]);
                            cashPosition.Cassette6Notes += int.Parse(parts[32]);
                            cashPosition.Cassette7Notes += int.Parse(parts[33]);
                        }
                        //cashPosition.LastTrxnAt = DateTime.MinValue;
                    }
                    else if (currentCassetteStatus.Contains("TestCash"))
                    {
                        if (currentCassetteStatus.Contains("Dummy"))
                        {
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "EOD Dummy test cash ignored because record already exists for that day.");
                            return;
                        }
                        cashPosition.Cassette1Notes = int.Parse(parts[2]) - int.Parse(parts[9]);
                        cashPosition.Cassette2Notes = int.Parse(parts[3]) - int.Parse(parts[10]);
                        cashPosition.Cassette3Notes = int.Parse(parts[4]) - int.Parse(parts[11]);
                        cashPosition.Cassette4Notes = int.Parse(parts[5]) - int.Parse(parts[12]);
                        cashPosition.Cassette5Notes = int.Parse(parts[6]) - int.Parse(parts[13]);
                        cashPosition.Cassette6Notes = int.Parse(parts[7]) - int.Parse(parts[14]);
                        cashPosition.Cassette7Notes = int.Parse(parts[8]) - int.Parse(parts[15]);

                        cashPosition.PurgeCassette1Notes += int.Parse(parts[9]);
                        cashPosition.PurgeCassette2Notes += int.Parse(parts[10]);
                        cashPosition.PurgeCassette3Notes += int.Parse(parts[11]);
                        cashPosition.PurgeCassette4Notes += int.Parse(parts[12]);

                    }
                    else
                    {

                        cashPosition.Cassette1Notes = int.Parse(parts[3]) - int.Parse(parts[10]) - int.Parse(parts[17]);
                        cashPosition.Cassette2Notes = int.Parse(parts[4]) - int.Parse(parts[11]) - int.Parse(parts[18]);
                        cashPosition.Cassette3Notes = int.Parse(parts[5]) - int.Parse(parts[12]) - int.Parse(parts[19]);
                        cashPosition.Cassette4Notes = int.Parse(parts[6]) - int.Parse(parts[13]) - int.Parse(parts[20]);
                        cashPosition.Cassette5Notes = int.Parse(parts[7]) - int.Parse(parts[14]) - int.Parse(parts[21]);
                        cashPosition.Cassette6Notes = int.Parse(parts[8]) - int.Parse(parts[15]) - int.Parse(parts[22]);
                        cashPosition.Cassette7Notes = int.Parse(parts[9]) - int.Parse(parts[16]) - int.Parse(parts[23]);


                        cashPosition.PurgeCassette1Notes += int.Parse(parts[17]);
                        cashPosition.PurgeCassette2Notes += int.Parse(parts[18]);
                        cashPosition.PurgeCassette3Notes += int.Parse(parts[19]);
                        cashPosition.PurgeCassette4Notes += int.Parse(parts[20]);
                        cashPosition.PurgeCassette5Notes += int.Parse(parts[21]);
                        cashPosition.PurgeCassette6Notes += int.Parse(parts[22]);
                        cashPosition.PurgeCassette7Notes += int.Parse(parts[23]);
                    }
                    cashPosition.TaskId = taskID;
                    cashPosition.Save();

                }
                decimal currentBalance = cashPosition.Cassette1Notes.Value * noteSetType.DenominationType1.Value
                    + cashPosition.Cassette2Notes.Value * noteSetType.DenominationType2.Value
                    + cashPosition.Cassette3Notes.Value * noteSetType.DenominationType3.Value
                    + cashPosition.Cassette4Notes.Value * noteSetType.DenominationType4.Value;
                    //+ cashPosition.Cassette5Notes.Value * noteSetType.DenominationType5.Value
                    //+ cashPosition.Cassette6Notes.Value * noteSetType.DenominationType6.Value
                    //+ cashPosition.Cassette7Notes.Value * noteSetType.DenominationType7.Value;


                //Change on 18/05/2014...09:10
                bool isAlertGenEnabled = true;
                //DataTable dtCashPositionExists = ExecuteStoredProcedure("GetCashPosition",
                //   "atm_id =" + atm.ATMId + " and last_trxn_at > convert(datetime,'" + lastTrxnAt.ToString("dd/MM/yyyy HH:mm:ss") + "',103)", 2, null);

                //if (dtCashPositionExists.Rows.Count > 0)
                //{
                //    if (int.Parse(dtCashPositionExists.Rows[0][0].ToString()) > 0)
                //        isAlertGenEnabled = false;
                //}

                //Change done by IK on 6-sep-2015
                decimal minOperatingBalance = GetATMMinOperatingBalance(atm, cashPosition.LastTrxnAt);
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (currentBalance < minOperatingBalance && currentBalance > atm.OutOfCashThreshold)
                {
                    if (isAlertGenEnabled)
                    {
                        if (!isLowBalanceAlertGenerated)
                        {
                            string msg = cashPosition.Cassette1Notes.Value + "," +
                                  cashPosition.Cassette2Notes.Value + "," + cashPosition.Cassette3Notes.Value + "," + cashPosition.Cassette4Notes.Value + "," +
                                      cashPosition.Cassette5Notes.Value + "," + cashPosition.Cassette6Notes.Value + "," + cashPosition.Cassette7Notes.Value + "," + currentBalance + "," + minOperatingBalance;
                            GenerateConditionalTerminalAlert(atm.ATMId, (int)EnumAlertType.MinOperatingBalance, msg, trxn, Event_Type.Alert, taskID, null, null);
                            isLowBalanceAlertResolved = false;
                            isLowBalanceAlertGenerated = true;
                        }
                    }
                }

                else if (currentBalance <= 0 || currentBalance <= atm.OutOfCashThreshold)
                {
                    if (isAlertGenEnabled)
                    {
                        if (!isOutOfCashAlertGenerated)
                        {//Delete low balance alert before adding out of cash alert.
                            AtmAlert atmAlert = AtmAlert.LoadAtmAlert("alert_type_id=" + (int)EnumAlertType.MinOperatingBalance + " and atm_id=" + atm.ATMId + " and resolve_at is null");
                            if (atmAlert != null)
                            {
                                atmAlert.Delete();
                                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Low balance alert deleted for atm_id = " + atm.ATMId);
                                //CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert.AtmAlertId);
                                //if (ccmsIntAlert != null)
                                //{
                                //    ccmsIntAlert.Delete();
                                //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Low balance alert deleted from ccms integrated alert for atm_id = " + atm.ATMId);
                                //}
                            }
                            //ExecuteStoredProcedure("DeleteAlert", "alert_type_id=" + (int)EnumAlertType.MinOperatingBalance + " and atm_id=" + atm.ATMId + " and resolve_at is null", -1, trxn);
                            string msg = cashPosition.Cassette1Notes.Value + "," +
                               cashPosition.Cassette2Notes.Value + "," + cashPosition.Cassette3Notes.Value + "," + cashPosition.Cassette4Notes.Value + "," +
                                   cashPosition.Cassette5Notes.Value + "," + cashPosition.Cassette6Notes.Value + "," + cashPosition.Cassette7Notes.Value + "," + currentBalance;
                            GenerateConditionalTerminalAlert(atm.ATMId, (int)EnumAlertType.ATMOutOfCash, msg, trxn, Event_Type.Alert, taskID, null, null);
                            isOutOfCashAlertResolved = false;
                            isOutOfCashAlertGenerated = true;
                        }

                    }
                }

                if (currentBalance > minOperatingBalance && isAlertGenEnabled)
                {
                    //task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Going to fetch low balance alert for atm_id = " + atm.ATMId);
                    ////Causing deadlock
                    //DataTable dtUpdateAlert = ExecuteStoredProcedure("UpdateAlert", "alert_type_id=" + (int)EnumAlertType.MinOperatingBalance + " and atm_id=" + atm.ATMId + " and resolve_at is null", -1, trxn);
                    //isLowBalanceAlertResolved = true;//No need to look in database as there is no alert
                    //isLowBalanceAlertGenerated = false;
                    if (!isLowBalanceAlertResolved)
                    {
                        AtmAlert atmAlert = AtmAlert.LoadAtmAlert("alert_type_id=" + (int)EnumAlertType.MinOperatingBalance + " and atm_id=" + atm.ATMId + " and resolve_at is null");
                        if (atmAlert != null)
                        {
                            atmAlert.ResolveAt = DateTime.Now;
                            atmAlert.Save();
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Low balance alert resolved for atm_id = " + atm.ATMId);
                            //CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert.AtmAlertId);
                            //if (ccmsIntAlert != null)
                            //{
                            //    ccmsIntAlert.ResolvedAt = DateTime.Now;
                            //    ccmsIntAlert.Save();
                            //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Low balance alert from ccms integrated alert resolved for atm_id = " + atm.ATMId);
                            //}
                            isLowBalanceAlertResolved = true;
                            isLowBalanceAlertGenerated = false;
                        }
                        else
                        {
                            isLowBalanceAlertResolved = true;//No need to look in database as there is no alert
                            isLowBalanceAlertGenerated = false;
                        }
                    }

                }

                if (currentBalance > atm.OutOfCashThreshold && isAlertGenEnabled)
                {
                    if (!isOutOfCashAlertResolved)
                    {
                        //DataTable dtUpdateAlert = ExecuteStoredProcedure("UpdateAlert", "alert_type_id=" + (int)EnumAlertType.ATMOutOfCash + " and atm_id=" + atm.ATMId + " and resolve_at is null", -1, trxn);
                        //isOutOfCashAlertResolved = true;
                        //isOutOfCashAlertGenerated = false;
                        AtmAlert atmAlert = AtmAlert.LoadAtmAlert("alert_type_id=" + (int)EnumAlertType.ATMOutOfCash + " and atm_id=" + atm.ATMId + " and resolve_at is null");
                        if (atmAlert != null)
                        {
                            atmAlert.ResolveAt = DateTime.Now;
                            atmAlert.Save();
                            task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Out Of Cash alert resolved for atm_id = " + atm.ATMId);
                            //CcmsIntegratedAlert ccmsIntAlert = CcmsIntegratedAlert.LoadCcmsIntegratedAlert("atm_alert_id=" + atmAlert.AtmAlertId);
                            //if (ccmsIntAlert != null)
                            //{
                            //    ccmsIntAlert.ResolvedAt = DateTime.Now;
                            //    ccmsIntAlert.Save();
                            //    task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Verbose, "Out Of Cash alert from ccms integrated alert resolved for atm_id = " + atm.ATMId);
                            //}
                            isOutOfCashAlertResolved = true;
                            isOutOfCashAlertGenerated = false;
                        }
                        else
                        {
                            isOutOfCashAlertResolved = true;
                            isOutOfCashAlertGenerated = false;
                        }
                    }
                }
                GeneratePurgeBinAlert(atm, cashPosition, trxn, taskID);
            }
            finally
            {
                try
                {
                    task.EndTask();
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("CurrencyParser", ex.Message + " " + ex.StackTrace);
                }

            }
        }
        public static DataTable ExecuteStoredProcedure(string storedProcedureName, int messageProcessorID)
        {
            SqlCommand cmd = null;

            cmd = ConnectionFactory.GetNewCommand(false, DatabaseName.Cash);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            cmd.CommandText = storedProcedureName;
            cmd.Parameters.Add("@messageProcessorId", SqlDbType.Int);
            cmd.Parameters[0].Value = messageProcessorID;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable ExecuteStoredProcedure(string storedProcedureName, string whereClause, int functionID, SqlTransaction trxn)
        {

            LogableTask.LogMonoActivityTask("execProc", MethodBase.GetCurrentMethod(), TraceLevel.Info, "calling with params " + storedProcedureName + "," + whereClause);
            SqlCommand cmd = null;

            if (trxn != null)
            {
                cmd = trxn.Connection.CreateCommand();
                cmd.Transaction = trxn;
            }
            else
                cmd = ConnectionFactory.GetNewCommand(false, DatabaseName.Cash);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcedureName;
            cmd.CommandTimeout = 120;

            if (whereClause != null)
            {
                cmd.Parameters.Add("whereClause", SqlDbType.VarChar);
                cmd.Parameters[0].Value = whereClause;
            }

            if (functionID > 0)
            {
                cmd.Parameters.Add("functionID", SqlDbType.Int);
                cmd.Parameters[1].Value = functionID;
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }


        public static void ExecuteStoredProcedure(string storedProcedureName, string whereClause, SqlTransaction trxn)
        {
            LogableTask.LogMonoActivityTask("execProc", MethodBase.GetCurrentMethod(), TraceLevel.Info, "calling with params " + storedProcedureName + "," + whereClause);

            SqlCommand cmd = null;

            if (trxn != null)
            {
                cmd = trxn.Connection.CreateCommand();
                cmd.Transaction = trxn;
            }
            else
                cmd = ConnectionFactory.GetNewCommand(true, DatabaseName.Cash);
            cmd.CommandTimeout = 120;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcedureName;
            if (whereClause != null)
            {
                cmd.Parameters.Add("@id", SqlDbType.VarChar);
                cmd.Parameters[0].Value = whereClause;
            }
            cmd.ExecuteNonQuery();

            if (cmd != null)
                if (cmd.Connection != null)
                    cmd.Connection.Close();
        }

        private static void GeneratePurgeBinAlert(Atm atm, CashPosition cashPosition, SqlTransaction trxn, long taskID)
        {
            StringBuilder builder = new StringBuilder();

            int[] purgeCassetteThresholds = new int[7];
            int[] purgeCassetteCounters = {cashPosition.PurgeCassette1Notes.Value,
                                          cashPosition.PurgeCassette2Notes.Value,
                                          cashPosition.PurgeCassette3Notes.Value,
                                          cashPosition.PurgeCassette4Notes.Value,
                                          cashPosition.PurgeCassette5Notes.Value,
                                          cashPosition.PurgeCassette6Notes.Value,
                                          cashPosition.PurgeCassette7Notes.Value};
            bool[] alertCategory = new bool[7];
            purgeCassetteThresholds[0] = (atm.Purge1Threshold == null ? 0 : atm.Purge1Threshold.Value);
            purgeCassetteThresholds[1] = (atm.Purge2Threshold == null ? 0 : atm.Purge2Threshold.Value);
            purgeCassetteThresholds[2] = (atm.Purge3Threshold == null ? 0 : atm.Purge3Threshold.Value);
            purgeCassetteThresholds[3] = (atm.Purge4Threshold == null ? 0 : atm.Purge4Threshold.Value);
            purgeCassetteThresholds[4] = (atm.Purge5Threshold == null ? 0 : atm.Purge5Threshold.Value);
            purgeCassetteThresholds[5] = (atm.Purge6Threshold == null ? 0 : atm.Purge6Threshold.Value);
            purgeCassetteThresholds[6] = (atm.Purge7Threshold == null ? 0 : atm.Purge7Threshold.Value);

            alertCategory[0] = (atm.IsPurge1ThresholdSelected == null ? false : atm.IsPurge1ThresholdSelected.Value);
            alertCategory[1] = (atm.IsPurge2ThresholdSelected == null ? false : atm.IsPurge2ThresholdSelected.Value);
            alertCategory[2] = (atm.IsPurge3ThresholdSelected == null ? false : atm.IsPurge3ThresholdSelected.Value);
            alertCategory[3] = (atm.IsPurge4ThresholdSelected == null ? false : atm.IsPurge4ThresholdSelected.Value);
            alertCategory[4] = (atm.IsPurge5ThresholdSelected == null ? false : atm.IsPurge5ThresholdSelected.Value);
            alertCategory[5] = (atm.IsPurge6ThresholdSelected == null ? false : atm.IsPurge6ThresholdSelected.Value);
            alertCategory[6] = (atm.IsPurge7ThresholdSelected == null ? false : atm.IsPurge7ThresholdSelected.Value);



            decimal totalPurgeCount = 0;
            decimal totalPurgeThresholdCount = 0;
            for (int i = 0; i < 7; i++)
            {
                if (!alertCategory[i] && purgeCassetteThresholds[i] > 0)
                {
                    if (purgeCassetteCounters[i] >= purgeCassetteThresholds[i])
                    {
                        ///Which cassette,Current Position,threshold
                        GenerateConditionalTerminalAlert(atm.ATMId, (int)EnumAlertType.PurgeBinThresholdReached, (i + 1) + "," + purgeCassetteCounters[i] + "," + purgeCassetteThresholds[i], trxn, Event_Type.Alert, taskID, null, null);
                    }
                }
                else if (alertCategory[i] && purgeCassetteThresholds[i] > 0)
                {
                    totalPurgeCount += purgeCassetteCounters[i];
                    totalPurgeThresholdCount += purgeCassetteThresholds[i];
                    //builder.Append("Cassette" + (i + 1) + "[" + purgeCassetteCounters[i] + "],");
                    builder.Append((i + 1) + "," + purgeCassetteCounters[i] + "," + purgeCassetteThresholds[i] + ",");
                }
            }


            if (totalPurgeCount >= totalPurgeThresholdCount && totalPurgeCount > 0)
            {
                string cassetteIndexes = builder.ToString();
                cassetteIndexes = cassetteIndexes.Substring(0, cassetteIndexes.LastIndexOf(","));
                GenerateConditionalTerminalAlert(atm.ATMId, (int)EnumAlertType.PurgeBinThresholdReached, cassetteIndexes, trxn, Event_Type.Alert, taskID, null, null);
            }
        }

        //public EV360BusinessRulesProcessor()
        //{
        //    InitializeComponent();
        //}

        //protected override void OnStart(string[] args)
        //{
        //    timerScheduleThreadForExecution = new Timer(ScheduleThreadForExecution, null, new TimeSpan(0, 0, 25), new TimeSpan(0, 0, 0, 0, -1));
        //}
        //void ScheduleThreadForExecution(object state)
        //{
        //    try
        //    {
        //        string connectionStr = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\CCMS").GetValue("ConnectionString", "");
        //        connectionStr = Encryption.Cryptic.DecryptString(connectionStr);
        //        ConnectionFactory.Initialize(connectionStr, true);
        //        appSetting = AppSetting.LoadAppSetting("1=1");
        //        XmlLogWriter.InitXmlLogWriter(appSetting.LogFilePath + "\\View360BusinessRuleProcessor_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");

        //        LogableTask.LogMonoActivityTask("DisplayVersion", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : View360 Business Rule Processor Build 2.1.1 Modified Date :5-Dec-2022");
        //        LogableTask.LogMonoActivityTask("Schedular", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Worker Threads begin execution after 15 seconds.");
        //        timer = new System.Threading.Timer(new System.Threading.TimerCallback(DoWork), null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));
        //        System.Threading.Tasks.Task.Factory.StartNew(() => PurgingManager.PurgeManager.DoPurge());
        //    }
        //    catch (Exception ex)
        //    {
        //        try
        //        {
        //            EventLog.WriteEntry("View360BusinessRulesProcessor", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
        //            //EventLog.WriteEntry("CurrencyMngServer", "Service is idle", EventLogEntryType.Warning);
        //            timerScheduleThreadForExecution.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));
        //        }
        //        catch (Exception innerException)
        //        {
        //        }
        //    }
        //}

        private void ProcessRercord(DataTable dt, LogableTask logTask)
        {
            SqlTransaction trxn = null;
            //SqlCommand cmd = null;
            bool a = false, b = false, c = false, d = false;
            //listNormalDays = Utility.GetEvents("Normal");
            StringBuilder processedIds = new StringBuilder();
            int atmID, taskID = 0;
            //cmd = ConnectionFactory.GetNewCommand(true);
            //int lastProcessedATMID = 0;
            //DateTime lastProcessedDate = DateTime.MinValue;
            DateTime eventOccuredAt = DateTime.MinValue;

            //Dictionary<int, Hashtable> atmEventsToProcess = new Dictionary<int, Hashtable>();
            StringBuilder ignoredTasks = new StringBuilder();
            DataTable dtWithdrawals = dt.Clone();
            DataTable dtDepositSUmmary = dt.Clone();
            DataTable dtBNACountsCleared = dt.Clone();
            DataTable dtCPMCountsCleared = dt.Clone();
            DataTable dtReplenishment = dt.Clone();
            DataTable dtTestCash = dt.Clone();
            EventManager eventManager = new EventManager();

            DateTime lastExecutedAt = DateTime.Now;
            Atm atm = null;
            int lastProcessedATMID = -1;

            DataTable dtATMs = dt.DefaultView.ToTable(true, new string[] { "atm_id" });
            LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "jobs to schedule:" + dtATMs.Rows.Count);

            foreach (DataRow dr in dtATMs.Rows)
            {
                DataTable dtResult = dt.Clone();
                DataRow[] drArraysPerATM = dt.Select("atm_id =" + dr["atm_id"], "event_occured_at asc");

                System.Threading.Tasks.Task.Factory.StartNew(() => Filter(drArraysPerATM, dtResult));
                LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "jobs scheduled for atm:" + dr["atm_id"]);

            }
            LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "jobs scheduled");

            //foreach (DataRow dr in dt.Rows)
            //{
            //    try
            //    {
            //        atmID = int.Parse(dr["atm_id"].ToString());
            //        taskID = int.Parse(dr["task_id"].ToString());
            //        eventOccuredAt = DateTime.Parse(dr["event_occured_at"].ToString());

            //        if (atmID != lastProcessedATMID)
            //            atm = Atm.LoadAtmByPk(atmID);

            //        if (dr["event_type"].ToString() == "ChequeDepositSummary" || dr["event_type"].ToString() == "CashDepositSummary")
            //            Filter(eventOccuredAt, dtDepositSUmmary, dr, atm, ignoredTasks);
            //        //eventManager.ExecuteDepositSummary(dr.Table);

            //        else if (dr["event_type"].ToString() == "BNACountsCleared")
            //            Filter(eventOccuredAt, dtBNACountsCleared, dr, atm, ignoredTasks);
            //        //eventManager.ExecuteBNACountsCleared(dr.Table);

            //        else if (dr["event_type"].ToString() == "CPMCountsCleared")
            //            Filter(eventOccuredAt, dtCPMCountsCleared, dr, atm, ignoredTasks);
            //        //eventManager.ExecuteCPMCountsCleared(dr.Table);

            //        else if (dr["event_type"].ToString() == "CashWithdrawal")
            //            Filter(eventOccuredAt, dtWithdrawals, dr, atm, ignoredTasks);
            //        //eventManager.ExecuteWithdrawals(dr.Table);

            //        else if (dr["event_type"].ToString() == "Replenishment")
            //            Filter(eventOccuredAt, dtReplenishment, dr, atm, ignoredTasks);
            //        //eventManager.ExecuteReplenishment(dr.Table);

            //        else if (dr["event_type"].ToString() == "TestCash")
            //            Filter(eventOccuredAt, dtTestCash, dr, atm, ignoredTasks);
            //        //eventManager.ExecuteTestCash(dr.Table);

            //        lastProcessedATMID = atm.ATMId;

            //        if ((DateTime.Now - lastExecutedAt).TotalSeconds > 5)
            //        {
            //            if (dtWithdrawals.Rows.Count > 0)
            //            {
            //                eventManager.ExecuteWithdrawals(dtWithdrawals);
            //                dtWithdrawals.Rows.Clear();
            //            }

            //            if (dtTestCash.Rows.Count > 0)
            //            {
            //                eventManager.ExecuteTestCash(dtTestCash);
            //                dtTestCash.Rows.Clear();
            //            }

            //            if (dtReplenishment.Rows.Count > 0)
            //            {
            //                eventManager.ExecuteReplenishment(dtReplenishment);
            //                dtReplenishment.Rows.Clear();
            //            }

            //            if (dtDepositSUmmary.Rows.Count > 0)
            //            {
            //                eventManager.ExecuteDepositSummary(dtDepositSUmmary);
            //                dtDepositSUmmary.Rows.Clear();
            //            }

            //            if (dtCPMCountsCleared.Rows.Count > 0)
            //            {
            //                eventManager.ExecuteCPMCountsCleared(dtCPMCountsCleared);
            //                dtCPMCountsCleared.Rows.Clear();
            //            }

            //            if (dtBNACountsCleared.Rows.Count > 0)
            //            {
            //                eventManager.ExecuteBNACountsCleared(dtBNACountsCleared);
            //                dtBNACountsCleared.Rows.Clear();
            //            }

            //            lastExecutedAt = DateTime.Now;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            //    }


            //    //lastProcessedATMID = atm.ATMId;
            //    //lastProcessedDate = DateTime.Parse(dr["event_occured_at"].ToString());




            //}
            //if (dtWithdrawals.Rows.Count > 0)
            //    eventManager.ExecuteWithdrawals(dtWithdrawals);

            //if (dtTestCash.Rows.Count > 0)
            //    eventManager.ExecuteTestCash(dtTestCash);

            //if (dtReplenishment.Rows.Count > 0)
            //    eventManager.ExecuteReplenishment(dtReplenishment);

            //if (dtDepositSUmmary.Rows.Count > 0)
            //    eventManager.ExecuteDepositSummary(dtDepositSUmmary);

            //if (dtCPMCountsCleared.Rows.Count > 0)
            //    eventManager.ExecuteCPMCountsCleared(dtCPMCountsCleared);

            //if (dtBNACountsCleared.Rows.Count > 0)
            //    eventManager.ExecuteBNACountsCleared(dtBNACountsCleared);


            //if (dtToProcess.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dtToProcess.Rows)
            //    {

            //    }
            //}


            //if (processedIds.Length > 0)
            //    ExecuteStoredProcedure("UpdatePostProcessingTasksById", processedIds.ToString() + "'-1'", trxn);

        }

        private static void Filter(DataRow[] dr, DataTable dtResult)
        {
            EventManager eventManager = new EventManager();

            DataTable dtWithdrawals = dtResult.Clone();//.Select("event_type='CashWithdrawal'").CopyToDataTable();
            DataTable dtTestCash = dtResult.Clone(); //.Select("event_type='TestCash'").CopyToDataTable();
            DataTable dtReplenishment = dtResult.Clone();//.Select("event_type='Replenishment'").CopyToDataTable();
            DataTable dtChequeDepositSummary = dtResult.Clone();//.Select("event_type='ChequeDepositSummary'").CopyToDataTable();
            DataTable dtCashDepositSummary = dtResult.Clone();//.Select("event_type='CashDepositSummary'").CopyToDataTable();
            DataTable dtCPMCountsCleared = dtResult.Clone();//.Select("event_type='CPMCountsCleared'").CopyToDataTable();
            DataTable dtBNACountsCleared = dtResult.Clone();//.Select("event_type='BNACountsCleared'").CopyToDataTable();

            //StringBuilder withdrawalsIgnoredTasks = new StringBuilder();
            //StringBuilder testCashIgnoredTasks = new StringBuilder();
            //StringBuilder replenishmentIgnoredTasks = new StringBuilder();
            //StringBuilder chqDepositSummaryIgnoredTasks = new StringBuilder();
            //StringBuilder cashDepositSummaryIgnoredTasks = new StringBuilder();
            //StringBuilder cpmCountsClearedIgnoredTasks = new StringBuilder();
            //StringBuilder bnaCountsClearedIgnoredTasks = new StringBuilder();

            LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "filtering started for atm:" + dr[0]["atm_id"]);

            DateTime eventOccuredAt = DateTime.MinValue;
            string eventType = "";


            foreach (DataRow _dr in dr)
            {
                eventOccuredAt = DateTime.Parse(_dr["event_occured_at"].ToString());
                eventType = _dr["event_type"].ToString();
                string query = "event_type ='" + eventType + "' and event_occured_at>#" + eventOccuredAt.Date.ToString("yyyy-MM-dd") + "# and event_occured_at<#" + eventOccuredAt.ToString("yyyy-MM-dd HH:mm:ss") + "#";
                LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, query + "query for atm:" + dr[0]["atm_id"]);

                if (_dr["event_type"].ToString() == "CashWithdrawal")
                {
                    RemoveIfEventWithPastDateTimeExists(ref dtWithdrawals, query);
                    DataRow newDataRow = DoClone(dtWithdrawals, _dr);
                    dtWithdrawals.Rows.Add(newDataRow);
                }

                else if (_dr["event_type"].ToString() == "TestCash")
                {
                    RemoveIfEventWithPastDateTimeExists(ref dtTestCash, query);
                    DataRow newDataRow = DoClone(dtTestCash, _dr);
                    dtTestCash.Rows.Add(newDataRow);
                }

                else if (_dr["event_type"].ToString() == "Replenishment")
                {
                    RemoveIfEventWithPastDateTimeExists(ref dtReplenishment, query);
                    DataRow newDataRow = DoClone(dtReplenishment, _dr);
                    dtReplenishment.Rows.Add(newDataRow);
                }

                else if (_dr["event_type"].ToString() == "ChequeDepositSummary")
                {
                    RemoveIfEventWithPastDateTimeExists(ref dtChequeDepositSummary, query);
                    DataRow newDataRow = DoClone(dtChequeDepositSummary, _dr);
                    dtChequeDepositSummary.Rows.Add(newDataRow);
                }

                else if (_dr["event_type"].ToString() == "CashDepositSummary")
                {
                    RemoveIfEventWithPastDateTimeExists(ref dtCashDepositSummary, query);
                    DataRow newDataRow = DoClone(dtCashDepositSummary, _dr);
                    dtCashDepositSummary.Rows.Add(newDataRow);
                }

                else if (_dr["event_type"].ToString() == "CPMCountsCleared")
                {
                    RemoveIfEventWithPastDateTimeExists(ref dtCPMCountsCleared, query);
                    DataRow newDataRow = DoClone(dtCPMCountsCleared, _dr);
                    dtCPMCountsCleared.Rows.Add(newDataRow);
                }

                else if (_dr["event_type"].ToString() == "BNACountsCleared")
                {
                    RemoveIfEventWithPastDateTimeExists(ref dtBNACountsCleared, query);
                    DataRow newDataRow = DoClone(dtBNACountsCleared, _dr);
                    dtBNACountsCleared.Rows.Add(newDataRow);
                }


            }
            LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "filtering end for atm:" + dr[0]["atm_id"]);

            //if (dtResult.Rows.Count > 0)
            //{
            LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, dr.Length + "records needs to be processed for atm:" + dr[0]["atm_id"]);

            //**************************************************************************************************************************************************************************************************************************//
            eventManager.ExecuteWithdrawals(dtWithdrawals);
            LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, dtWithdrawals.Rows.Count + "ExecuteWithdrawals for atm:" + dr[0]["atm_id"]);
            //**************************************************************************************************************************************************************************************************************************//
            eventManager.ExecuteTestCash(dtTestCash);
            LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, dtTestCash.Rows.Count + "ExecuteTestCash for atm:" + dr[0]["atm_id"]);
            //**************************************************************************************************************************************************************************************************************************//
            eventManager.ExecuteReplenishment(dtReplenishment);
            LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, dtReplenishment.Rows.Count + "ExecuteReplenishment for atm:" + dr[0]["atm_id"]);
            //**************************************************************************************************************************************************************************************************************************//
            eventManager.ExecuteDepositSummary(dtChequeDepositSummary);
            LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, dtChequeDepositSummary.Rows.Count + "ExecuteDepositSummary for atm:" + dr[0]["atm_id"]);

            //**************************************************************************************************************************************************************************************************************************//
            eventManager.ExecuteDepositSummary(dtCashDepositSummary);
            LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, dtCashDepositSummary.Rows.Count + "ExecuteDepositSummary for atm:" + dr[0]["atm_id"]);
            //**************************************************************************************************************************************************************************************************************************//
            eventManager.ExecuteCPMCountsCleared(dtCPMCountsCleared);
            LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, dtCPMCountsCleared.Rows.Count + "ExecuteCPMCountsCleared for atm:" + dr[0]["atm_id"]);
            //**************************************************************************************************************************************************************************************************************************//
            eventManager.ExecuteBNACountsCleared(dtBNACountsCleared);
            LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, dtBNACountsCleared.Rows.Count + "ExecuteBNACountsCleared for atm:" + dr[0]["atm_id"]);


            LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "execution scheduled for atm:" + dr[0]["atm_id"]);

            //}
            //else
            //  LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "NO execution scheduled for atm:" + dr[0]["atm_id"]);




        }

        private static void RemoveIfEventWithPastDateTimeExists(ref DataTable dtResult, string query)
        {
            DataRow[] drArray = dtResult.Select(query);

            if (drArray.Length > 0)
            {
                //ignoredTasks.Append(drArray[0]["parser_post_processing_task_id"] + ",");
                dtResult.Rows.Remove(drArray[0]);
            }
            //else
            //    ignoredTasks.Add(int.Parse(parserPostProcessingTaskID), new List<int>() { 1});

            //if (ignoredTasks.ContainsKey())
        }

        private static void Filter(DateTime eventOccuredAt, DataTable dtWithdrawals, DataRow dr, Atm atm, StringBuilder ignoredTasks)
        {
            string query = "atm_id = " + atm.ATMId + " and event_occured_at>#" + eventOccuredAt.Date.ToString("yyyy-MM-dd") + "# and event_occured_at<#" + eventOccuredAt.ToString("yyyy-MM-dd HH:mm:ss") + "#";

            DataRow[] drArray = dtWithdrawals.Select(query);
            if (drArray.Length > 0)
            {
                ignoredTasks.Append(drArray[0]["parser_post_processing_task_id"] + ",");

                dtWithdrawals.Rows.Remove(drArray[0]);
            }
            DataRow newDataRow = DoClone(dtWithdrawals, dr);
            dtWithdrawals.Rows.Add(newDataRow);
        }

        private static DataRow DoClone(DataTable dtWithdrawals, DataRow dr)
        {
            DataRow newDataRow = dtWithdrawals.NewRow();
            newDataRow["parser_post_processing_task_id"] = dr["parser_post_processing_task_id"];
            newDataRow["entity_id"] = dr["entity_id"];
            newDataRow["event_info"] = dr["event_info"];
            newDataRow["event_occured_at"] = dr["event_occured_at"];
            newDataRow["event_type"] = dr["event_type"];
            newDataRow["task_id"] = dr["task_id"];
            newDataRow["atm_id"] = dr["atm_id"];
            newDataRow["creation_time"] = dr["creation_time"];
            return newDataRow;
        }

        //public void ExecuteQueue()
        //{
        //    try
        //    {
        //        if (queue != null)
        //        {
        //            queue.ReceiveCompleted += Queue_ReceiveCompleted;
        //            queue.BeginReceive();
        //        }
        //        else
        //            LogableTask.LogMonoActivityTask("ExecuteQueue", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, "View360BusinessRuleProcessor Queue do not exist");
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry("View360BusinessRuleProcessor - ExecuteQueue", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
        //        LogableTask.LogMonoActivityTask("ExecuteQueue", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.Message);
        //    }
        //}

        //private async void Queue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        //{
        //    try
        //    {
        //        Message message = queue.EndReceive(e.AsyncResult);
        //        message.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
        //        long atmId = (long)message.Body;
        //        Atm atm = Atm.LoadAtmByPk(atmId);
        //        ScheduleThread(atm.MessageProcessorId);
        //        //FileDetail fileDetail = JsonConvert.DeserializeObject<FileDetail>(message.Body.ToString());
        //        //string respone = ParseDataForMessageBus(fileDetail.fileContent, fileDetail.atmIp);
        //        //if (respone == "success")
        //        //{
        //        //    ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
        //        //    string url = ConfigurationManager.AppSettings["View360Url"];
        //        //    WebRequest request = WebRequest.Create(url);
        //        //    using (WebResponse response = await request.GetResponseAsync())
        //        //    {
        //        //        // Process the response if needed
        //        //    }
        //        //    ServicePointManager.ServerCertificateValidationCallback = null;
        //        //    File.Delete(fileDetail.fileName);
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        LogableTask.LogMonoActivityTask("Queue_ReceiveCompleted", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.Message);
        //    }
        //    finally
        //    {
        //        try
        //        {
        //            queue.BeginReceive();
        //        }
        //        catch (Exception ex)
        //        {
        //            LogableTask.LogMonoActivityTask("Queue_ReceiveCompleted", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex.Message);
        //        }
        //    }
        //}

        protected void ScheduleThread(object state)
        {
            LogableTask logTask = LogableTask.NewTask();
            int i = int.Parse(state.ToString());
            try
            {
                LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "going to process records for processor id:" + (i + 1));
                DataTable dt = ExecuteStoredProcedure("GetPostProcessingTasks", i + 1);
                if (dt.Rows.Count > 0)
                    ProcessRercord(dt, logTask);
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("PostProcessingError", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                try
                {
                    logTask.EndTask();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void DoInit()
        {
            string connectionStr = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\NCR\\EV360").GetValue("ConnectionString", "");
            connectionStr = Encryption.Cryptic.DecryptString(connectionStr, Helper.ConstractKey(false));
            ConnectionFactory.Initialize(connectionStr, true, DatabaseName.Core);
            ConnectionFactory.Initialize(connectionStr.Replace("Core", "Cash"), true, DatabaseName.Cash);
            appSetting = AppSetting.LoadAppSetting("1=1");
            XmlLogWriter.InitXmlLogWriter(appSetting.LogFilePath + "\\View360BusinessRuleProcessor_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
        }
        protected override async System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                DoInit();
               // ExecuteQueue();
                //XmlLogWriter.InitXmlLogWriter(appSetting.LogFilePath + "\\View360BusinessRuleProcessor_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");

                //LogableTask.LogMonoActivityTask("DisplayVersion", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : View360 Business Rule Processor Build 2.1.1 Modified Date :5-Dec-2022");
                //LogableTask.LogMonoActivityTask("Schedular", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Worker Threads begin execution after 15 seconds.");
                ////timer = new System.Threading.Timer(new System.Threading.TimerCallback(DoWork), null, new TimeSpan(0, 0, 15), new TimeSpan(0, 0, 0, 0, -1));
                System.Threading.Tasks.Task.Factory.StartNew(() => PurgingManager.PurgeManager.DoPurge());

                DoWork();
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await System.Threading.Tasks.Task.Delay(5 * 60 * 1000, stoppingToken);//TODO: to be changed later
            }
        }
        private void DoWork()
        {
            //timer.Change(-1, -1);
            try
            {
                XmlLogWriter.InitXmlLogWriter(appSetting.LogFilePath + "\\View360BusinessRuleProcessor_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : View360 Business Rule Processor Build 2.1.1");
                LogableTask logTask = LogableTask.NewTask();

                for (int i = 0; i < workerThread; i++)
                {
                    System.Threading.Tasks.Task.Factory.StartNew(() => ScheduleThread(i));
                    LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "task scheduled for processor id:" + (i + 1));
                    Thread.Sleep(2 * 1000);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    LogableTask.LogMonoActivityTask("", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                }
                catch (Exception innerException)
                {
                }

            }
            finally
            {
                //try
                //{
                //    if (appSetting != null)
                //        timer.Change(new TimeSpan(0, (int)appSetting.CcmsParserRefreshInterval, 0), new TimeSpan(0, 0, 0, 0, -1));
                //    else
                //        timer.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));

                //    if (appSetting != null)
                //        LogableTask.LogMonoActivityTask("", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to sleep for " + appSetting.CcmsParserRefreshInterval + " min");
                //}
                //catch (Exception ex)
                //{
                //    try
                //    {
                //        EventLog.WriteEntry("CurrencyParser", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                //    }
                //    catch (Exception innerException)
                //    {
                //    }

                //}

            }



        }

        //protected override void OnStop()
        //{
        //    //LogableTask.LogMonoActivityTask("ServiceStartUp", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Warning, "Service Stopped");
        //}
    }
}
