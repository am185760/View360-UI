using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Avanza.CCMS.DAL;
using Avanza.iSuite.DAL;
using System.Data.SqlClient;
using System.Data;

namespace Avanza.CCMS.DAL
{
    public static class SmsTaskHelper
    {
        static DataTable dataTable = null;
     //   static object sync = new object();
        //edited by shariq 
        static SqlCommand cmd = null;
        static DataTable dt;
        static SmsTaskHelper()
        {
            cmd = ConnectionFactory.GetNewCommand(false);
            cmd.CommandText = @"select smsTemplateConfiguration.alert_type_id,smsTemplateConfiguration.channel_id,smsTemplateConfiguration.sms_template_configuration_id
                            ,smsTemplateConfiguration.sms_transaction_type_detail_id,smsTemplateConfiguration.status,smsTemplateConfiguration.template_id
                            ,smsTransactionType.action_code,smsTransactionType.sms_transaction_type_detail_id,smsTransactionType.transaction_type_id
                             from sms_template_configuration smsTemplateConfiguration left outer join sms_transaction_type_detail smsTransactionType
                               on smsTemplateConfiguration.sms_transaction_type_detail_id = smsTransactionType.sms_transaction_type_detail_id";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Change done on 16Nov2015
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            dataTable = new DataTable();
            cmd.CommandText = "Select * from exception_handling_criteria";
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);


        }

        private static string NormalizeString(string msg)
        {
            string result = "";
            if (msg.Contains("\\r\\n"))
            {
                string[] parts = msg.Split(new string[] { "\\r\\n" }, StringSplitOptions.RemoveEmptyEntries);
                result = parts[0];
                if (parts.Length > 1)
                {
                    for (int j = 1; j < parts.Length; j++)
                    {
                        result += "\r\n" + parts[j];
                    }
                }

            }
            else
                result = msg;

            return result;
        }
        public static bool IsDisputedTrxn(string tempEj, ref bool isSMSTaskRequired, IDbTransaction dbTrxn, EnumTransactionType enumTransactionType)
        {
            bool disputedFlag = false;
            bool isPreconditionMatched = true;
            string msg = null;
            List<int> list = new List<int>();
            int idx = -1;
            //Static constructor will take care of loading datatable.

            //bool isSMSTaskRequired = false;
            //bool isPostConditionMatched = false;
            //if (dataTable == null)
            //{
            //    lock (sync)
            //    {
            //        if (dataTable == null)
            //        {
            //            dataTable = new DataTable();
            //            string query = "Select * from exception_handling_criteria";
            //            // ConnectionFactory.connectionString = "Data Source=(local);Initial Catalog=ccms;Integrated Security=True";
            //            SqlCommand cmd = ConnectionFactory.GetNewCommand(false);
            //            cmd.CommandText = query;
            //            SqlDataAdapter adpter = new SqlDataAdapter(cmd);
            //            adpter.Fill(dataTable);

            //        }
            //    }
            //}
            
            DataRow[] drArrayPreconditions = dataTable.Select("is_precondition = 1 and transaction_type_id = " + (int)enumTransactionType);
            for (int index = 0; index < drArrayPreconditions.Length; index++)
            {
                if (!tempEj.Contains(NormalizeString(drArrayPreconditions[index]["message"].ToString())))
                {
                    isPreconditionMatched = false;
                    break;
                }
            }
            if (isPreconditionMatched)
            {
                DataRow[] drArrayPostconditions = dataTable.Select("is_disputed = 1 AND is_precondition = 0 and transaction_type_id = " + (int)enumTransactionType);
                for (int index = 0; index < drArrayPostconditions.Length; index++)
                {
                    msg = NormalizeString(drArrayPostconditions[index]["message"].ToString());
                    idx = tempEj.IndexOf(msg);
                    
                    if (idx > -1)
                    {
                        list.Add(idx);
                        if (bool.Parse(drArrayPostconditions[index]["is_sms_task_required"].ToString()))
                        {
                            disputedFlag = true;
                            isSMSTaskRequired = true;
                            break;
                        }
                        else
                        {
                            disputedFlag = true;
                            break;                            
                        }
                    }
                    
                    //else if (tempEj.Contains(NormalizeString(drArrayPostconditions[index]["message"].ToString())) && drArrayPostconditions[index]["is_sms_task_required"].ToString() == "False")
                    //{
                    //    disputedFlag = true;
                    //    break;
                    //}
                }
                if (disputedFlag)
                {
                    DataRow[] drClearDisputedFlagConditions = dataTable.Select("is_disputed = 0 AND is_precondition = 0 and transaction_type_id = " + (int)enumTransactionType);
                    for (int index = 0; index < drClearDisputedFlagConditions.Length; index++)
                    {
                        msg = NormalizeString(drClearDisputedFlagConditions[index]["message"].ToString());
                        idx =tempEj.LastIndexOf(msg);
                        if (idx>-1)
                        {
                            if (idx > list.Max() || list.Count==0)
                            {
                                disputedFlag = false;
                                //Added on 27Oct to disable sms task creation.
                                isSMSTaskRequired = false;
                            }
                        }
                    }

                }

            }
            return disputedFlag;
        }
        //call saveTask method****



        public static void SaveTask(EjParsedTransactions objEjParsedTransaction, int? captureId, int atmID, int userID, IDbTransaction dbTrxn)
        {
            CheckConfiguration(objEjParsedTransaction.TransactionTypeId, objEjParsedTransaction.Status.ToString(), captureId, null, null, null, atmID, userID, objEjParsedTransaction.Pan, "", objEjParsedTransaction.Tsn, objEjParsedTransaction.TaskId.Value, dbTrxn);
        }
        public static void SaveTask(EjParsedBnaTransaction objEjParsedBnaTransaction, int? captureId, int atmID, int userID, IDbTransaction dbTrxn)
        {
            CheckConfiguration(objEjParsedBnaTransaction.TransactionTypeId, objEjParsedBnaTransaction.Status, captureId, null, null, null, atmID, userID, objEjParsedBnaTransaction.Pan, objEjParsedBnaTransaction.AccountNo, objEjParsedBnaTransaction.Seq, objEjParsedBnaTransaction.TaskId, dbTrxn);
        }
        public static void SaveTask(EjParsedCpmTransaction objEjParsedCpmTransaction, int? captureId, int atmID, int userID, IDbTransaction dbTrxn)
        {
            CheckConfiguration(objEjParsedCpmTransaction.TransactionTypeId, objEjParsedCpmTransaction.Status, captureId, null, null, null, atmID, userID, objEjParsedCpmTransaction.Pan, objEjParsedCpmTransaction.AccountNo, objEjParsedCpmTransaction.Seq, objEjParsedCpmTransaction.TaskId, dbTrxn);
        }
        public static void SaveTask(EjCapturedCard objEjCapturedCard, string status, int? transactionTypeId, int? captureId, int atmID, int userID, IDbTransaction dbTrxn)
        {
            CheckConfiguration(transactionTypeId, status, captureId, null, null, null, atmID, userID, objEjCapturedCard.PAN, "", objEjCapturedCard.TSN.ToString(), objEjCapturedCard.TaskId, dbTrxn);
        }
        public static void SaveTask(AtmAlert atmAlert, int? captureid, int atmID, int userID, SqlTransaction dbTrxn)
        {
            CheckConfiguration(null, null, captureid, atmAlert.AtmAlertId, atmAlert.AlertTypeId, null, atmID, userID, "", "", "", 1, dbTrxn);
        }

        public static void CheckConfiguration(
          int? transactionTypeId,
          string status,
          int? captureId,
          int? atmAlertId,
          int? alertTypeID,
          string actionCode,
          int atmID,
          int userID,
          string PAN,
          string accountNo,
          string tsn,
          int taskID,
          IDbTransaction dbTrxn,
          string bankName=null)
        {
            DataRow[] dataRowArray;
            if (actionCode == null)
            {
                string str = status.Length != 1 ? status : (status == "0" ? "Successful" : (status == "1" ? "Failed" : (status == "2" ? "Suspicious" : "None")));
                dataRowArray = SmsTaskHelper.dt.Select("transaction_type_id = '" + (object)transactionTypeId + "' and status = '" + str + "'");
            }
            else if (alertTypeID.HasValue)
                dataRowArray = SmsTaskHelper.dt.Select("alert_type_id = '" + (object)alertTypeID + "'");
            else
                dataRowArray = SmsTaskHelper.dt.Select("transaction_type_id = '" + (object)transactionTypeId + "' and action_code = '" + actionCode + "'");
            if (dataRowArray.Length <= 0)
                return;
            dataRowArray[0][1].ToString();
            SmsTask smsTask = new SmsTask()
            {
                RetryRemaining = 10,
                Status = "Scheduled",
                TemplateId = int.Parse(dataRowArray[0]["template_id"].ToString()),
                CreationTime = DateTime.Now,
                CapturedTransactionId = captureId,
                AtmAlertId = atmAlertId,
                AtmId = atmID,
                UserId = userID
            };
            smsTask.IsEligible = smsTask.UserId != 1 ? new bool?(false) : new bool?(true);
            smsTask.LastInvokedAt = new DateTime?(DateTime.Now);
            smsTask.TaskId = new int?(taskID);
            smsTask.Pan = PAN;
            smsTask.AccountNo = accountNo;
            smsTask.Tsn = tsn;
            smsTask.BankName = bankName;
            if (transactionTypeId.HasValue)
            {
                TransactionType transactionType = TransactionType.LoadTransactionTypeByPk(transactionTypeId.Value);
                if (transactionType != null)
                    smsTask.TransactionFriendlyName = transactionType.TransactionTypeName;
            }
            else if (alertTypeID.HasValue)
            {
                AlertType alertType = AlertType.LoadAlertTypeByPk(alertTypeID.Value);
                if (alertType != null)
                    smsTask.TransactionFriendlyName = alertType.AlertTypeName;
            }
            if (dbTrxn != null)
                smsTask.Save(dbTrxn.Connection, dbTrxn);
            else
                smsTask.Save();
        }
    }
}