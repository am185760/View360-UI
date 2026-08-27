using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Avanza.iSuite.DAL;
using Avanza.CCMS.DAL;
using System.Reflection;
using System.Diagnostics;
using System.Configuration;

namespace Avanza.CCMS
{
    static class AlertManager
    {
        public static void GenerateTerminalAlert(int atm_id, int alertTypeID, string msg, SqlTransaction trxn, int expirationTime,int retryCount)
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
                alert.GenerateAtRetryRemaining = retryCount;
                alert.ResolveAtRetryRemaining = 0;
                alert.AlertMsg = msg;
                alert.ExpirationTime = DateTime.Now.AddDays(expirationTime);
                alert.Save(trxn.Connection, trxn);
                task.Log(MethodBase.GetCurrentMethod(), TraceLevel.Info, "Alert added for terminal " + atm_id);
            }
            finally
            {
                task.EndTask();
            }
        }





    }
}
