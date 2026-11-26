using DataRequestor;
using Encryption;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
namespace EV360AtmsHandler
{
    public partial class EV360AtmHandler : ServiceBase
    {
        public static int ExecutionTimerInMS = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ExecutionTimerInMS"]);
        public static int ExecutionTimerOfAtmInSecounds = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ExecutionTimerOfAtmInSecounds"]);
        public static int ExecutionTimerOfNoteSetTypeInSecound = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ExecutionTimerOfNoteSetTypeInSecound"]);
        public static int ExecutionTimerOfAppSettingInSecound = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ExecutionTimerOfAppSettingInSecound"]);

        System.Timers.Timer timer = new System.Timers.Timer();
        System.Threading.Timer atmTimer;
        System.Threading.Timer noteSetTypeTimmer;
        System.Threading.Timer appSettingTimer;

        public static ConnectionInitializer conn;
        public DBServerInfo coreDB;
        public static string logFilePath = System.Configuration.ConfigurationManager.AppSettings["LogFilePath"];
        System.Threading.Timer timerScheduleThreadForExecution;
        public EV360AtmHandler()
        {
            InitializeComponent();
        }
        void ScheduleThreadForExecution(object state)
        {
            try
            {
                string key = Helper.ConstractKey(false);
                conn = new ConnectionInitializer();
                coreDB = conn.DBServers[0];
                string coreConnStr = Cryptic.DecryptString(coreDB.ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(coreDB.ServerCredentials, key).TrimEnd('\0');

                DataTable dataTable = conn.ConnectAndExecuteDT(coreConnStr, "GetAllAppSetting", new List<SqlParameter>());
                logFilePath = dataTable.Rows[0]["logFile_path"].ToString() == string.Empty ? logFilePath : dataTable.Rows[0]["logFile_path"].ToString();
                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EV360AtmHandler_{1:yyMMMdd}.txt", logFilePath, DateTime.Now));
                LogableTask.LogMonoActivityTask("DisplayVersion", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Version : EV360AtmHandler Server 1.0.0.0, Modified Date Mar-2023");
                LogableTask.LogMonoActivityTask("Schedular", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Worker Threads begin execution after 15 seconds.");

                atmTimer = new System.Threading.Timer(AtmHandler, null, new TimeSpan(0, 0, 3), new TimeSpan(0, 0, 0, 0, -1));
                noteSetTypeTimmer = new System.Threading.Timer(NoteSetTypeHandler, null, new TimeSpan(0, 1, 0), new TimeSpan(0, 0, 0, 0, -1));
                appSettingTimer = new System.Threading.Timer(AppSettingHandler, null, new TimeSpan(0, 2, 0), new TimeSpan(0, 0, 0, 0, -1));

                //timer.Elapsed += new ElapsedEventHandler(HandleAtmMessageProcessor);

                //timer.Elapsed += new ElapsedEventHandler(HandleAtms);
                //timer.Elapsed += new ElapsedEventHandler(HandleEditAtms);
                //timer.Elapsed += new ElapsedEventHandler(HandleDeletedAtms);

                //timer.Elapsed += new ElapsedEventHandler(HandleEditNoteSetType);
                //timer.Elapsed += new ElapsedEventHandler(HandleNoteSetType);
                //timer.Elapsed += new ElapsedEventHandler(HandleDeletedNoteSetType);

                //timer.Elapsed += new ElapsedEventHandler(HandleAppSetting);
                //timer.Elapsed += new ElapsedEventHandler(HandleEditAppSetting);

                timer.Interval = ExecutionTimerInMS;
                timer.Enabled = true;
                EventLog.WriteEntry("EV360AtmHandler", "EV360AtmHandler Service Started Successfully", EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("EV360AtmHandler", ex.Message + " " + ex.StackTrace, EventLogEntryType.Error);
                timerScheduleThreadForExecution.Change(new TimeSpan(0, 5, 0), new TimeSpan(0, 0, 0, 0, -1));
            }
        }
        protected override void OnStart(string[] args)
        {
            // ThreadPool.SetMinThreads(400, 400);
            timerScheduleThreadForExecution = new System.Threading.Timer(ScheduleThreadForExecution, null, new TimeSpan(0, 0, 5), new TimeSpan(0, 0, 0, 0, -1));
            EventLog.WriteEntry("EV360AtmHandler", "Thread schedular sent startup request", EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            LogableTask.LogMonoActivityTask("Stop", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "EV360AtmHandler stopped");
        }

        void DoWork(object state)
        {

        }
        public void AtmHandler(object state)
        {
            object source;
            ElapsedEventArgs e;
            try
            {
                HandleAtms();
                HandleEditAtms();
                HandleDeletedAtms();

                HandleAtmMessageProcessor();
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("AtmHandler", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                atmTimer.Change(new TimeSpan(0, 0, 0, ExecutionTimerOfAtmInSecounds), new TimeSpan(0, 0, 0, 0, -1));
            }
        }
        public void NoteSetTypeHandler(Object state)
        {
            try
            {
                HandleNoteSetType();
                HandleEditNoteSetType();
                HandleDeletedNoteSetType();
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("NoteSetTypeHandler", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                noteSetTypeTimmer.Change(new TimeSpan(0, 0, ExecutionTimerOfNoteSetTypeInSecound), new TimeSpan(0, 0, 0, 0, -1));
            }
        }

        public void AppSettingHandler(Object state)
        {
            try
            {
                HandleAppSetting();
                HandleEditAppSetting();
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("AppSettingHandler", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            finally
            {
                appSettingTimer.Change(new TimeSpan(0, 0, ExecutionTimerOfAppSettingInSecound), new TimeSpan(0, 0, 0, 0, -1));
            }
        }
        public void HandleAtms()
        {
            LogableTask.LogMonoActivityTask("HandleAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going in handle atm method");

            string key = Helper.ConstractKey(false);
            string connStr = string.Empty;
            string coreConnStr = string.Empty;
            int availableSpace = 0;
            int count = 0;
            string IDs = string.Empty;
            List<string> AtmIds = new List<string>();

            conn.LoadServersInfo();
            try
            {
                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EV360AtmHandler_{1:yyMMMdd}.txt", logFilePath, DateTime.Now));
                LogableTask.LogMonoActivityTask("GetUnassignedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to get Unassigned Atms from core DB");
                coreConnStr = Cryptic.DecryptString(coreDB.ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(coreDB.ServerCredentials, key).TrimEnd('\0');
                DataTable dataTable = conn.ConnectAndExecuteDT(coreConnStr, "GetUnassignedAtms", new List<SqlParameter>());
                LogableTask.LogMonoActivityTask("GetUnassignedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "got all Unassigned Atms from core DB");
                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    LogableTask.LogMonoActivityTask("GetUnassignedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "not found any unassigned ATM, All ATMs assigned to specific server");
                    return;
                }
                for (int i = 0; i < conn.DBServers.Count; i++)
                {
                    try
                    {
                        object result = null;
                        int serverId = i + 1;
                        if (count == dataTable.Rows.Count || (count > 0 && dataTable.Rows.Count <= count))
                            break;
                        availableSpace = Convert.ToInt32(conn.DBServers[i].MaxATMs) - Convert.ToInt32(conn.DBServers[i].AtmIds.Count);
                        if (availableSpace > 0)
                        {
                            connStr = Cryptic.DecryptString(conn.DBServers[i].ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(conn.DBServers[i].ServerCredentials, key).TrimEnd('\0');
                            DataTable dt = dataTable.Select().Skip(count).Take(availableSpace).CopyToDataTable();
                            IDs = string.Empty;
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                IDs += dt.Rows[j][0] + ",";
                                dt.Rows[j][108] = serverId;
                                dt.Rows[j][109] = 0;
                                if (conn.DBServers[i].AtmInfo == null)
                                {
                                    conn.DBServers[i].AtmIds = new List<string>();
                                    conn.DBServers[i].AtmInfo = new Dictionary<string, string>();
                                }
                                if (!conn.DBServers[i].AtmInfo.Keys.Contains(dt.Rows[j][4].ToString()))
                                {
                                    conn.DBServers[i].AtmIds.Add(dt.Rows[j][0].ToString());
                                    conn.DBServers[i].AtmInfo.Add(dt.Rows[j][4].ToString(), dt.Rows[j][0].ToString());
                                }
                                if (!AtmIds.Contains(dt.Rows[j]["ATM_id"].ToString()))
                                {
                                    AtmIds.Add(dt.Rows[j]["ATM_id"].ToString());
                                }
                            }

                            IDs = IDs.TrimEnd(',');
                            count += availableSpace;
                            var atmIds = dt.AsEnumerable().Select(s => s.Field<long>("ATM_id").ToString()).Distinct().ToList();
                            LogableTask.LogMonoActivityTask("HandleAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Assigning serverId = {serverId} to atmIds = ( {string.Join(",", atmIds)})");
                            string query = string.Empty;
                            

                            if (serverId > 1)
                            {
                                query = string.Empty;
                                int countccc = 0;
                                foreach (DataRow dr in dt.Rows)
                                {
                                    countccc++;
                                    int index = 1;
                                    #region insertQuery
                                    //query += "insert into atm (";
                                    //foreach (DataColumn column in dt.Columns)
                                    //{
                                    //    query += $"{column.ColumnName} ";
                                    //    if (index != dt.Columns.Count)
                                    //    {
                                    //        query += ",";
                                    //    }
                                    //    index++;
                                    //}

                                    //query += ") VALUES (";
                                    //index = 1;
                                    //foreach (DataColumn column in dt.Columns)
                                    //{
                                    //    if (column.ColumnName == "ATM_id")
                                    //    {
                                    //        query += $@"{dr["ATM_id"]}";
                                    //    }
                                    //    else if (DBNull.Value.Equals(dr[column.ColumnName]))
                                    //    {
                                    //        query += $"null";
                                    //    }
                                    //    else if (column.DataType == typeof(string) || column.DataType == typeof(DateTime))
                                    //    {
                                    //        query += $@"'{dr[column.ColumnName]}' ";
                                    //    }
                                    //    else if (column.DataType == typeof(Boolean))
                                    //    {
                                    //        query += Convert.ToBoolean(dr[column.ColumnName]) == false ? 0 : 1;
                                    //    }
                                    //    else
                                    //    {
                                    //        query += $@"{dr[column.ColumnName]}";
                                    //    }




                                    //    if (index != dt.Columns.Count)
                                    //    {
                                    //        query += ",";
                                    //    }
                                    //    index++;
                                    //}

                                    //query += " );";
                                    query += GenerateInsertQuery("atm", dr);
                                    #endregion
                                }
                                LogableTask.LogMonoActivityTask("HandleAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"{countccc} Atm inserts query of server = {serverId}");
                                LogableTask.LogMonoActivityTask("HandleAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"{query}");

                                // Inserting atm with default values
                                LogableTask.LogMonoActivityTask("HandleAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Going to insert {countccc} atm in serverId = {serverId}");
                                result = conn.ConnectAndExecuteQuery(connStr, query);
                                LogableTask.LogMonoActivityTask("HandleAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Succesfully  inserted {countccc} atm in serverId = {serverId}");
                                query = $"update atm set assigned_server = {serverId} where ATM_id in ({string.Join(",", atmIds)})";
                                result = conn.ConnectAndExecuteQuery(coreConnStr, query);
                                query = string.Empty;
                                //foreach (DataRow dr in dt.Rows)
                                //{
                                //    query += "update atm set created_by = 0";

                                //    foreach (DataColumn column in dt.Columns)
                                //    {
                                //        if (column.ColumnName == "ATM_id" || column.ColumnName == "created_by")
                                //        {
                                //            continue;
                                //        }
                                //        else if (string.IsNullOrEmpty(dr[column.ColumnName].ToString()))
                                //        {
                                //            continue;
                                //        }
                                //        else if (column.DataType == typeof(string) || column.DataType == typeof(DateTime))
                                //        {
                                //            query += $", {column.ColumnName} = '{dr[column.ColumnName]}'";
                                //        }
                                //        else if (column.DataType == typeof(Boolean))
                                //        {
                                //            query += $", {column.ColumnName} = '{Convert.ToBoolean(dr[column.ColumnName])}'";
                                //        }
                                //        else
                                //        {
                                //            query += $", {column.ColumnName} = {dr[column.ColumnName]}";
                                //        }
                                //    }
                                //    query += $" where ATM_id = {dr["ATM_id"]};";
                                //}
                                //// updating atm data on others servers 
                                //result = conn.ConnectAndExecuteQuery(connStr, query);

                            }

                            //SqlParameter param = new SqlParameter("AtmsInfo", SqlDbType.Structured) { Value = dt }; 
                            //if (i > 0)
                            //    result = conn.ConnectAndExecute(connStr, "SaveATMInfo", new List<SqlParameter> { param });
                            //if ((result != null && Convert.ToInt32(result) <= availableSpace) || (i == 0 && availableSpace > 0))
                            //{
                            //    LogableTask.LogMonoActivityTask("SaveATMInfo", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "ATMs saved into the assigned DB server");
                            //    param = new SqlParameter("AtmsID", SqlDbType.VarChar) { Value = IDs };
                            //    SqlParameter param1 = new SqlParameter("ServerNum", SqlDbType.Int) { Value = serverId };
                            //    result = conn.ConnectAndExecute(coreConnStr, "UpdateATMInfoInCore", new List<SqlParameter> { param, param1 });
                            //    if (result != null)
                            //        LogableTask.LogMonoActivityTask("UpdateATMInfoInCore", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "ATMs assigned to server in core DB");
                            //}
                        }
                        else
                        {
                            LogableTask.LogMonoActivityTask("HandleATMs", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "No free capacity in DB server " + serverId);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogableTask.LogMonoActivityTask("HandleATMs", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
                    }
                    finally
                    {
                        LogableTask.LogMonoActivityTask("HandleAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Return from atm method");

                    }

                }//
                foreach (var AtmId in AtmIds)
                {
                    try
                    {
                        LogableTask.LogMonoActivityTask("HandleAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Going to creating task of atmId = {AtmId}");
                        CreateConfigurationTask(connStr, 0, new List<string> { AtmId });
                        LogableTask.LogMonoActivityTask("HandleAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Succesfully created task of atmId = {AtmId}");
                    }
                    catch (Exception ex)
                    {
                        LogableTask.LogMonoActivityTask("HandleATMs", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error,$"Exception while adding task of atmId ={AtmId} :{ex}");
                    }
                }
                conn.SaveServersInfo();
                LogableTask.LogMonoActivityTask("HandleATMs", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "DB servers info updated in core DB");
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("HandleATMs", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
        }
        static string GenerateInsertQuery(string tableName, DataRow dataRow)
        {
            // Create a list of column names
            var columnNames = dataRow.Table.Columns.Cast<DataColumn>().Select(col => col.ColumnName);

            // Create a list of parameter values
            var parameterValues = columnNames.Select(col => FormatValueForInsert(dataRow[col]));

            // Create the insert query with embedded values
            string columns = string.Join(", ", columnNames);
            string values = string.Join(", ", parameterValues);
            string insertQuery = $"INSERT INTO {tableName} ({columns}) VALUES ({values} );";

            return insertQuery;
        }

        // Format values for direct insertion into the SQL query
        static string FormatValueForInsert(object value)
        {
            if (value is int || value is long || value is decimal)
            {
                return value.ToString();
            }
            // Handle varbinary(max) data type
            if (value is byte[] varbinaryValue)
            {
                return "0x" + BitConverter.ToString(varbinaryValue).Replace("-", "");
            }
            else if (value is DateTime)
            {
                return $"'{((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss")}'";
            }
            else if (value is string || value is bool)
            {
                return $"'{value}'";
            }


            return "''"; // Default for unsupported types
        }

        public void HandleEditAtms()
        {
            bool isEdited = false;
            string key = Helper.ConstractKey(false);
            string connStr = string.Empty;
            string coreConnStr = string.Empty;
            int availableSpace = 0;
            int count = 0;
            List<string> IDs = new List<string>();
            object result = null;
            conn.LoadServersInfo();
            try
            {
                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EV360AtmHandler_{1:yyMMMdd}.txt", logFilePath, DateTime.Now));

                LogableTask.LogMonoActivityTask("GetEditedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going in HandleEditAtms method");
                LogableTask.LogMonoActivityTask("GetEditedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to get Edited Atms from core DB");
                coreConnStr = Cryptic.DecryptString(coreDB.ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(coreDB.ServerCredentials, key).TrimEnd('\0');

                for (int serverNumber = 0; serverNumber < conn.DBServers.Count; serverNumber++)
                {
                    int serverId = serverNumber + 1;
                    SqlParameter param = new SqlParameter("@ServerNum", SqlDbType.VarChar) { Value = serverId };
                    DataTable dataTable = conn.ConnectAndExecuteDT(coreConnStr, "GetEditedAtms", new List<SqlParameter> { param });
                    LogableTask.LogMonoActivityTask("GetEditedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "got all Edited Atms of core DB " + serverId);

                    if (dataTable == null || dataTable.Rows.Count == 0)
                    {
                        LogableTask.LogMonoActivityTask("GetEditedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "not found any edited ATM, All ATMs are up to date in core DB " + serverId);
                        continue;
                    }

                    isEdited = true;
                    connStr = Cryptic.DecryptString(conn.DBServers[serverNumber].ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(conn.DBServers[serverNumber].ServerCredentials, key).TrimEnd('\0');
                    //SqlParameter param2 = new SqlParameter("AtmsInfo", SqlDbType.Structured) { Value = dataTable };
                    //result = conn.ConnectAndExecute(connStr, "UpdateAtmsInfo", new List<SqlParameter> { param2 });
                    if (serverId > 1)
                    {
                        int counter = 0;
                        string query = string.Empty;
                        LogableTask.LogMonoActivityTask("GetEditedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Making update query of {counter}atm.");

                        foreach (DataRow dr in dataTable.Rows)
                        {
                            counter++;
                            //foreach (DataColumn column in dataTable.Columns)
                            //{
                            //    if (column.ColumnName == "ATM_id" || column.ColumnName == "is_edited")
                            //    {
                            //        continue;
                            //    }
                            //    else if (string.IsNullOrEmpty(dr[column.ColumnName].ToString()))
                            //    {
                            //        continue;
                            //    }
                            //    else if (column.DataType == typeof(string) || column.DataType == typeof(DateTime))
                            //    {
                            //        query += $", {column.ColumnName} = '{dr[column.ColumnName]}'";
                            //    }
                            //    else if (column.DataType == typeof(Boolean))
                            //    {
                            //        var value = Convert.ToBoolean(dr[column.ColumnName]) == false ? 0 : 1;
                            //        query += $", {column.ColumnName} = {value}";
                            //    }
                            //    else
                            //    {
                            //        query += $", {column.ColumnName} = {dr[column.ColumnName]}";
                            //    }
                            //}
                            //query += $" where ATM_id = {dr["ATM_id"]};";
                            query += GenerateUpdateQuery("atm", dr, "ATM_id");
                        }
                        LogableTask.LogMonoActivityTask("GetEditedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Succesfully made update query of {counter}atm.");

                        query += "update atm set is_edited = 0;";
                        // updating atm data on others servers 
                        LogableTask.LogMonoActivityTask("GetEditedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Going to update {counter} atm in serverid= {serverId}");
                        result = conn.ConnectAndExecuteQuery(connStr, query);
                        LogableTask.LogMonoActivityTask("GetEditedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Succesfully updated {counter} atm in serverid= {serverId}");

                    }

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        IDs.Add(dataTable.Rows[i][0].ToString());
                        var item = conn.DBServers[serverNumber].AtmInfo.Where(kvp => kvp.Value.Equals(dataTable.Rows[i]["ATM_id"].ToString()) && !kvp.Key.Equals(dataTable.Rows[i]["IP"].ToString()));
                        if (item.Count() > 0)
                        {
                            var atmInfo = item.FirstOrDefault();
                            conn.DBServers[serverNumber].AtmInfo.Remove(atmInfo.Key);
                            conn.DBServers[serverNumber].AtmInfo.Add(dataTable.Rows[i]["IP"].ToString(), dataTable.Rows[i]["ATM_id"].ToString());
                        }
                    }
                }

                if (isEdited)
                {
                    IDs = IDs.Distinct().ToList();
                    LogableTask.LogMonoActivityTask("UpdateEditedATMInfoInCore", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to Reset is_edit flag in atm");
                    SqlParameter param1 = new SqlParameter("AtmsID", SqlDbType.VarChar) { Value = string.Join(",", IDs) };
                    result = conn.ConnectAndExecute(coreConnStr, "UpdateEditedATMInfoInCore", new List<SqlParameter> { param1 });
                    if (result != null)
                        LogableTask.LogMonoActivityTask("UpdateEditedATMInfoInCore", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "ATMs Updated to server in core DB");

                    conn.SaveServersInfo();
                }
                LogableTask.LogMonoActivityTask("HandleEditAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to Reset is_edit flag in atm");
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("HandleEditAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            LogableTask.LogMonoActivityTask("HandleEditAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Return from HandleEditAtms method");
        }

        public void HandleDeletedAtms()
        {
            string key = Helper.ConstractKey(false);
            string connStr = string.Empty;
            string coreConnStr = string.Empty;
            int availableSpace = 0;
            int count = 0;
            string IDs = string.Empty;
            object result = null;
            conn.LoadServersInfo();
            try
            {
                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EV360AtmHandler_{1:yyMMMdd}.txt", logFilePath, DateTime.Now));

                LogableTask.LogMonoActivityTask("HandleDeletedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to HandleDeletedAtms method");
                LogableTask.LogMonoActivityTask("HandleDeletedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to get all Atms from core DB");
                coreConnStr = Cryptic.DecryptString(coreDB.ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(coreDB.ServerCredentials, key).TrimEnd('\0');
                DataTable dataTable = conn.ConnectAndExecuteDT(coreConnStr, "GetAllAtms", new List<SqlParameter>());
                LogableTask.LogMonoActivityTask("HandleDeletedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "got all Atms from core DB");
                List<string> atmsIds = new List<string>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    atmsIds.Add(dataTable.Rows[i]["ATM_id"].ToString());
                }
                for (int ServerNumber = 0; ServerNumber < conn.DBServers.Count; ServerNumber++)
                {
                    var deletedAtms = conn.DBServers[ServerNumber].AtmIds.Where(x => !atmsIds.Contains(x)).ToList();
                    if (deletedAtms?.Count > 0)
                    {
                        conn.DBServers[ServerNumber].AtmIds.RemoveAll(x => deletedAtms.Contains(x));

                        foreach (var atm in deletedAtms)
                        {
                            var atmInfo = conn.DBServers[ServerNumber].AtmInfo.Where(x => x.Value.Equals(atm)).First();
                            conn.DBServers[ServerNumber].AtmInfo.Remove(atmInfo.Key);
                        }

                        connStr = Cryptic.DecryptString(conn.DBServers[ServerNumber].ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(conn.DBServers[ServerNumber].ServerCredentials, key).TrimEnd('\0');
                        SqlParameter param = new SqlParameter("AtmsIds", SqlDbType.VarChar) { Value = string.Join(",", deletedAtms) };
                        result = conn.ConnectAndExecute(connStr, "DeleteAtmInfo", new List<SqlParameter> { param });
                        if (result != null)
                            LogableTask.LogMonoActivityTask("HandleDeletedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"{deletedAtms.Count} ATMs are deleted from core DB server {ServerNumber + 1}");

                    }


                }
                conn.SaveServersInfo();
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("HandleDeletedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
            LogableTask.LogMonoActivityTask("HandleDeletedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Return from HandleDeletedAtms method");
        }


        public void HandleNoteSetType()
        {
            string key = Helper.ConstractKey(false);
            string connStr = string.Empty;
            string coreConnStr = string.Empty;
            try
            {
                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EV360AtmHandler_{1:yyMMMdd}.txt", logFilePath, DateTime.Now));
                LogableTask.LogMonoActivityTask("HandleNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going in HandleNoteSetType method");
                LogableTask.LogMonoActivityTask("GetAllNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to get all NoteSetType from core DB");
                coreConnStr = Cryptic.DecryptString(coreDB.ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(coreDB.ServerCredentials, key).TrimEnd('\0');
                DataTable dataTable = conn.ConnectAndExecuteDT(coreConnStr, "GetAllNoteSetType", new List<SqlParameter>());
                LogableTask.LogMonoActivityTask("GetAllNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "got all NoteSetType from core DB");

                for (int ServerNumber = 0; ServerNumber < conn.DBServers.Count; ServerNumber++)
                {
                    object result = null;
                    int serverId = ServerNumber + 1;
                    string query = string.Empty;

                    connStr = Cryptic.DecryptString(conn.DBServers[ServerNumber].ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(conn.DBServers[ServerNumber].ServerCredentials, key).TrimEnd('\0');
                    //SqlParameter param = new SqlParameter("NoteSetTypesInfo", SqlDbType.Structured) { Value = dataTable };
                    //result = conn.ConnectAndExecute(connStr, "SaveNoteSetTypeInfo", new List<SqlParameter> { param });
                    if (serverId > 1)
                    {

                        DataTable dt = conn.ConnectAndExecuteDT(connStr, "GetAllNoteSetType", new List<SqlParameter>());

                        var Ids = new HashSet<long>(dt.AsEnumerable()
                            .Select(row => row.Field<long>("note_set_type_id"))).ToList();
                        //Ids.Remove(1);
                        var varUnmatched = from all in dataTable.AsEnumerable()
                                           let id = all.Field<long>("note_set_type_id")
                                           where !Ids.Contains(id)
                                           select all;

                        DataTable dtInsert = varUnmatched.AsEnumerable().Count() > 0 ? varUnmatched.CopyToDataTable() : null;

                        if (dtInsert?.Rows.Count > 0)
                        {
                            int counter = 0;
                            LogableTask.LogMonoActivityTask("GetAllNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Make insert query of noteSetType of server {serverId} ");

                            foreach (DataRow dr in dtInsert.Rows)
                            {
                                counter++;
                                int index = 1;
                                //query += "insert into note_set_type (";
                                //foreach (DataColumn column in dataTable.Columns)
                                //{
                                //    query += $"{column.ColumnName} ";
                                //    if (index != dt.Columns.Count)
                                //    {
                                //        query += ",";
                                //    }
                                //    index++;
                                //}

                                //query += ") VALUES (";
                                //index = 1;
                                //foreach (DataColumn column in dataTable.Columns)
                                //{
                                //    if (column.ColumnName == "note_set_type_id")
                                //    {
                                //        query += $@"{dr["note_set_type_id"]}";
                                //    }
                                //    else if (DBNull.Value.Equals(dr[column.ColumnName]))
                                //    {
                                //        query += $"null";
                                //    }
                                //    else if (column.DataType == typeof(string) || column.DataType == typeof(DateTime))
                                //    {
                                //        query += $@"'{dr[column.ColumnName]}' ";
                                //    }
                                //    else if (column.DataType == typeof(Boolean))
                                //    {
                                //        query += Convert.ToBoolean(dr[column.ColumnName]) == false ? 0 : 1;
                                //    }
                                //    else
                                //    {
                                //        //string value = string.IsNullOrEmpty(dr[column.ColumnName].ToString()) == true ? "null" : dr[column.ColumnName].ToString();
                                //        query += $@"{dr[column.ColumnName]}";
                                //    }

                                //    //query += dr[column.ColumnName];

                                //    if (index != dt.Columns.Count)
                                //    {
                                //        query += ",";
                                //    }
                                //    index++;
                                //}

                                //query += " );";

                                query += GenerateInsertQuery("note_set_type", dr);
                            }
                            result = conn.ConnectAndExecuteQuery(connStr, query);
                        }
                    }
                }

                LogableTask.LogMonoActivityTask("HandleNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "NoteSetType is updated in DB Servers");
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("HandleNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }

            LogableTask.LogMonoActivityTask("HandleNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Return from HandleNoteSetType method");
        }

        public void HandleEditNoteSetType()
        {
            bool isEdited = false;
            string key = Helper.ConstractKey(false);
            string connStr = string.Empty;
            string coreConnStr = string.Empty;
            int availableSpace = 0;
            int count = 0;
            List<string> IDs = new List<string>();
            object result = null;
            try
            {
                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EV360AtmHandler_{1:yyMMMdd}.txt", logFilePath, DateTime.Now));
                LogableTask.LogMonoActivityTask("GetEditedNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going in GetEditedNoteSetType method");
                LogableTask.LogMonoActivityTask("GetEditedNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to get Edited NoteSetType from core DB");
                coreConnStr = Cryptic.DecryptString(coreDB.ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(coreDB.ServerCredentials, key).TrimEnd('\0');
                DataTable dataTable = conn.ConnectAndExecuteDT(coreConnStr, "GetEditedNoteSetType", new List<SqlParameter>());

                for (int ServerNumber = 1; ServerNumber < conn.DBServers.Count; ServerNumber++)
                {

                    int serverId = ServerNumber + 1;
                    LogableTask.LogMonoActivityTask("GetEditedNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Got all Edited NoteSetType of core DB " + serverId);
                    if (dataTable == null || dataTable.Rows.Count == 0)
                    {
                        LogableTask.LogMonoActivityTask("GetEditedNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "not found any edited NoteSetType, All NoteSetType are up to date in core DB " + serverId);
                        continue;
                    }

                    isEdited = true;
                    if (serverId > 1)
                    {
                        connStr = Cryptic.DecryptString(conn.DBServers[ServerNumber].ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(conn.DBServers[ServerNumber].ServerCredentials, key).TrimEnd('\0');
                        string query = string.Empty;
                        LogableTask.LogMonoActivityTask("GetEditedNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to make update query of noteSetType for server =" + serverId);
                        int counter = 0;
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            counter++;
                            //query += "Update note_set_type set is_edited = 0";
                            //foreach (DataColumn column in dataTable.Columns)
                            //{
                            //    if (column.ColumnName == "note_set_type_id" || column.ColumnName == "is_edited")
                            //    {
                            //        continue;
                            //    }
                            //    else if (string.IsNullOrEmpty(dr[column.ColumnName].ToString()))
                            //    {
                            //        continue;
                            //    }
                            //    else if (column.DataType == typeof(string) || column.DataType == typeof(DateTime))
                            //    {
                            //        query += $", {column.ColumnName} = '{dr[column.ColumnName]}'";
                            //    }
                            //    else if (column.DataType == typeof(Boolean))
                            //    {
                            //        query += $", {column.ColumnName} = '{Convert.ToBoolean(dr[column.ColumnName])}'";
                            //    }
                            //    else
                            //    {
                            //        query += $", {column.ColumnName} = {dr[column.ColumnName]}";
                            //    }

                            //    //query += item.ToString();
                            //}
                            //query += $" where note_set_type_id = {dr["note_set_type_id"]} ;";
                            query += GenerateUpdateQuery("note_set_type", dr, "note_set_type_id");
                        }
                        LogableTask.LogMonoActivityTask("GetEditedNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Succesfully made {counter} updated query for noteSetType of server  =" + serverId);

                        LogableTask.LogMonoActivityTask("GetEditedNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Going to update {counter} noteSetType of server = {serverId}");
                        result = conn.ConnectAndExecuteQuery(connStr, query);
                    }
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (!IDs.Contains(dataTable.Rows[i]["note_set_type_id"]))
                        {
                            IDs.Add(dataTable.Rows[i]["note_set_type_id"].ToString());
                        }
                    }
                }

                if (isEdited)
                {

                    IDs = IDs.Distinct().ToList();
                    LogableTask.LogMonoActivityTask("UpdateEditedNoteSetTypeInfoInCore", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Updating Edited NoteSetType into the  DB server");
                    SqlParameter param1 = new SqlParameter("@NoteSetTypeID", SqlDbType.VarChar) { Value = string.Join(",", IDs) };
                    result = conn.ConnectAndExecute(coreConnStr, "UpdateEditedNoteSetTypeInfoInCore", new List<SqlParameter> { param1 });
                    if (result != null)
                        LogableTask.LogMonoActivityTask("UpdateEditedNoteSetTypeInfoInCore", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "NoteSetType Updated to server in core DB");

                }
                LogableTask.LogMonoActivityTask("HandleEditNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "DB servers info updated in core DB");
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("HandleEditNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }

            LogableTask.LogMonoActivityTask("GetEditedNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Return from GetEditedNoteSetType method");
        }
        public void HandleDeletedNoteSetType()
        {
            string key = Helper.ConstractKey(false);
            string connStr = string.Empty;
            string coreConnStr = string.Empty;
            int count = 0;
            object result = null;
            try
            {
                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EV360AtmHandler_{1:yyMMMdd}.txt", logFilePath, DateTime.Now));
                LogableTask.LogMonoActivityTask("HandleDeletedNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going in HandleDeletedNoteSetType");
                LogableTask.LogMonoActivityTask("HandleDeletedNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to get all Atms from core DB");
                coreConnStr = Cryptic.DecryptString(coreDB.ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(coreDB.ServerCredentials, key).TrimEnd('\0');
                DataTable dataTable = conn.ConnectAndExecuteDT(coreConnStr, "GetAllNoteSetType", new List<SqlParameter>());
                LogableTask.LogMonoActivityTask("HandleDeletedNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "got all Atms from core DB");
                List<string> noteSetTypeIds = new List<string>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    noteSetTypeIds.Add(dataTable.Rows[i]["note_set_type_id"].ToString());
                }
                for (int ServerNumber = 0; ServerNumber < conn.DBServers.Count; ServerNumber++)
                {
                    List<string> deleteNoteSetType = new List<string>();

                    connStr = Cryptic.DecryptString(conn.DBServers[ServerNumber].ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(conn.DBServers[ServerNumber].ServerCredentials, key).TrimEnd('\0');

                    DataTable dbServerNoteSetType = conn.ConnectAndExecuteDT(connStr, "GetAllNoteSetType", new List<SqlParameter>());

                    if (dbServerNoteSetType.Rows.Count > 0)
                    {
                        for (int i = 0; i < dbServerNoteSetType.Rows.Count; i++)
                        {
                            var noteSetType = noteSetTypeIds.Where(x => x.Equals(dbServerNoteSetType.Rows[i]["note_set_type_id"].ToString()));
                            if (!noteSetType.Any())
                            {
                                deleteNoteSetType.Add(dbServerNoteSetType.Rows[i]["note_set_type_id"].ToString());
                            }
                        }
                    }
                    if (deleteNoteSetType.Any())
                    {
                        SqlParameter param = new SqlParameter("@NoteSetTypeIds", SqlDbType.VarChar) { Value = string.Join(",", deleteNoteSetType) };
                        result = conn.ConnectAndExecute(connStr, "DeleteNoteSetType", new List<SqlParameter> { param });
                        if (result != null)
                            LogableTask.LogMonoActivityTask("HandleDeletedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"{deleteNoteSetType.Count} NoteSetType are deleted from core DB server {ServerNumber + 1}");
                    }

                }
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("HandleDeletedAtms", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }

            LogableTask.LogMonoActivityTask("HandleDeletedNoteSetType", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Return from HandleDeletedNoteSetType");
        }

        public void HandleAppSetting()
        {
            string key = Helper.ConstractKey(false);
            string connStr = string.Empty;
            string coreConnStr = string.Empty;
            try
            {
                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EV360AtmHandler_{1:yyMMMdd}.txt", logFilePath, DateTime.Now));
                LogableTask.LogMonoActivityTask("HandleAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going in HandleAppSetting");
                LogableTask.LogMonoActivityTask("GetAllAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to get all AppSetting from core DB");
                coreConnStr = Cryptic.DecryptString(coreDB.ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(coreDB.ServerCredentials, key).TrimEnd('\0');
                DataTable dataTable = conn.ConnectAndExecuteDT(coreConnStr, "GetAllAppSetting", new List<SqlParameter>());
                LogableTask.LogMonoActivityTask("GetAllAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "got all AppSetting from core DB");

                for (int ServerNumber = 0; ServerNumber < conn.DBServers.Count; ServerNumber++)
                {
                    object result = null;
                    int serverId = ServerNumber + 1;
                    connStr = Cryptic.DecryptString(conn.DBServers[ServerNumber].ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(conn.DBServers[ServerNumber].ServerCredentials, key).TrimEnd('\0');
                    //SqlParameter param = new SqlParameter("@AppSetttingInfo", SqlDbType.Structured) { Value = dataTable };
                    //result = conn.ConnectAndExecute(connStr, "SaveAppSettingInfo", new List<SqlParameter> { param });
                    DataTable dt = conn.ConnectAndExecuteDT(connStr, "GetAllAppSetting", new List<SqlParameter>());
                    string query = string.Empty;
                    LogableTask.LogMonoActivityTask("HandleAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Making insert query of app_setting");

                    if (dt.Rows.Count == 0)
                    {
                        int index = 1;
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            query += GenerateInsertQuery("app_setting", dr);
                            //query += "insert into app_setting (";
                            //foreach (DataColumn column in dataTable.Columns)
                            //{
                            //    query += $"{column.ColumnName} ";
                            //    if (index != dt.Columns.Count)
                            //    {
                            //        query += ",";
                            //    }
                            //    index++;
                            //}

                            //query += ") VALUES (";
                            //index = 1;
                            //foreach (DataColumn column in dataTable.Columns)
                            //{
                            //    if (column.ColumnName == "app_setting_id")
                            //    {
                            //        query += $@"{dr["app_setting_id"]}";
                            //    }
                            //    else if (DBNull.Value.Equals(dr[column.ColumnName]))
                            //    {
                            //        query += $"null";
                            //    }
                            //    else if (column.DataType == typeof(string) || column.DataType == typeof(DateTime))
                            //    {
                            //        query += $@"'{dr[column.ColumnName]}' ";
                            //    }
                            //    else if (column.DataType == typeof(Boolean))
                            //    {
                            //        query += Convert.ToBoolean(dr[column.ColumnName]) == false ? 0 : 1;
                            //    }
                            //    else
                            //    {
                            //        //string value = string.IsNullOrEmpty(dr[column.ColumnName].ToString()) == true ? "null" : dr[column.ColumnName].ToString();
                            //        query += $@"{dr[column.ColumnName]}";
                            //    }

                            //    //query += dr[column.ColumnName];

                            //    if (index != dt.Columns.Count)
                            //    {
                            //        query += ",";
                            //    }
                            //    index++;
                            //}

                            //query += " );";
                        }
                        LogableTask.LogMonoActivityTask("HandleAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Succesfully made insert query");
                        result = conn.ConnectAndExecuteQuery(connStr, query);
                    }
                }
                LogableTask.LogMonoActivityTask("HandleAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "AppSetting is inserted in DB Servers");
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("HandleAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }

            LogableTask.LogMonoActivityTask("HandleAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Return from HandleAppSetting");
        }
        public void HandleEditAppSetting()
        {
            bool isEdited = false;
            string key = Helper.ConstractKey(false);
            string connStr = string.Empty;
            string coreConnStr = string.Empty;
            int availableSpace = 0;
            int count = 0;
            List<string> IDs = new List<string>();
            object result = null;
            try
            {
                XmlLogWriter.InitXmlLogWriter(String.Format("{0}\\EV360AtmHandler_{1:yyMMMdd}.txt", logFilePath, DateTime.Now));
                LogableTask.LogMonoActivityTask("GetEditedAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to get Edited AppSetting from core DB");
                coreConnStr = Cryptic.DecryptString(coreDB.ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(coreDB.ServerCredentials, key).TrimEnd('\0');
                DataTable dataTable = conn.ConnectAndExecuteDT(coreConnStr, "GetEditedAppSetting", new List<SqlParameter>());

                for (int serverNumber = 0; serverNumber < conn.DBServers.Count; serverNumber++)
                {
                    int serverId = serverNumber + 1;
                    LogableTask.LogMonoActivityTask("GetEditedAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "got all Edited AppSetting of core DB " + serverId);
                    if (dataTable == null || dataTable.Rows.Count == 0)
                    {
                        LogableTask.LogMonoActivityTask("GetEditedAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "not found any edited AppSetting, All AppSetting are up to date in core DB " + serverId);
                        continue;
                    }

                    isEdited = true;
                    connStr = Cryptic.DecryptString(conn.DBServers[serverNumber].ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(conn.DBServers[serverNumber].ServerCredentials, key).TrimEnd('\0');


                    string query = string.Empty;
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        //query += "Update app_setting set is_edited = 0";
                        //foreach (DataColumn column in dataTable.Columns)
                        //{
                        //    if (column.ColumnName == "app_setting_id" || column.ColumnName == "is_edited" || column.ColumnName == "ServersInfo")
                        //    {
                        //        continue;
                        //    }
                        //    else if (string.IsNullOrEmpty(dr[column.ColumnName].ToString()))
                        //    {
                        //        continue;
                        //    }
                        //    else if (column.DataType == typeof(string) || column.DataType == typeof(DateTime))
                        //    {
                        //        query += $", {column.ColumnName} = '{dr[column.ColumnName]}'";
                        //    }
                        //    else if (column.DataType == typeof(Boolean))
                        //    {
                        //        var value = Convert.ToBoolean(dr[column.ColumnName]) == false ? 0 : 1;
                        //        query += $", {column.ColumnName} = " + value + "";
                        //    }
                        //    else
                        //    {
                        //        query += $", {column.ColumnName} = {dr[column.ColumnName]}";
                        //    }

                        //    //query += item.ToString();
                        //}
                        //query += $" where app_setting_id = {dr["app_setting_id"]} ;";
                        query += GenerateUpdateQuery("app_setting", dr, "app_setting_id");
                    }
                    LogableTask.LogMonoActivityTask("HandleAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Succesfully made update query");


                    LogableTask.LogMonoActivityTask("HandleAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to update app_setting");
                    result = conn.ConnectAndExecuteQuery(connStr, query);
                    LogableTask.LogMonoActivityTask("HandleAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "app_setting sucessfully updated");

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (!IDs.Contains(dataTable.Rows[i]["app_setting_id"]))
                        {
                            IDs.Add(dataTable.Rows[i]["app_setting_id"].ToString());
                        }
                    }
                }
                IDs = IDs.Distinct().Select(x => x.ToString()).ToList();
                if (isEdited)
                {
                    LogableTask.LogMonoActivityTask("UpdateEditedAppSettingInfoInCore", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Updating Edited AppSetting into the  DB server");
                    SqlParameter param1 = new SqlParameter("@AppSettingsIds", SqlDbType.VarChar) { Value = string.Join(",", IDs) };
                    result = conn.ConnectAndExecute(coreConnStr, "UpdateEditedAppSettingInfoInCore", new List<SqlParameter> { param1 });
                    if (result != null)
                        LogableTask.LogMonoActivityTask("UpdateEditedAppSettingInfoInCore", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "AppSetting Updated to server in core DB");

                }
                LogableTask.LogMonoActivityTask("HandleEditAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "DB servers info updated in core DB");
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("HandleEditAppSetting", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
        }


        public void HandleAtmMessageProcessor()
        {

            string key = Helper.ConstractKey(false);
            string connStr = string.Empty;
            string coreConnStr = string.Empty;
            int availableProcssorIdsCount = 0;
            object result = null;
            try
            {
                coreConnStr = Cryptic.DecryptString(coreDB.ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(coreDB.ServerCredentials, key).TrimEnd('\0');
                for (int j = 0; j < conn.DBServers.Count; j++)
                {
                    DataTable dt = new DataTable();
                    int serverId = j + 1;
                    LogableTask.LogMonoActivityTask("HandleAtmMessageProcessor", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Going to get all processor count of server {serverId}");

                    connStr = Cryptic.DecryptString(conn.DBServers[j].ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(conn.DBServers[j].ServerCredentials, key).TrimEnd('\0');
                    SqlParameter param1 = new SqlParameter("ServerNum", SqlDbType.Int) { Value = serverId };
                    DataTable dataTable = conn.ConnectAndExecuteDT(coreConnStr, "GetServerAtmsMessageProcessorCount", new List<SqlParameter> { param1 });
                    LogableTask.LogMonoActivityTask("GetServerAtmsMessageProcessorCount", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "got all Edited AppSetting of core DB " + serverId);

                    var maxProcessor = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings[$"MaxProcessorOfServer{serverId}"]);
                    if (maxProcessor == 0)
                    {
                        LogableTask.LogMonoActivityTask("HandleAtmMessageProcessor", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, $"Max processor of server {serverId} is not available in app config");
                        return;
                    }
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        int processorIdCount = Convert.ToInt32(dr["count"].ToString());
                        int procesorId = Convert.ToInt32(dr["message_processor_id"].ToString());
                        if (processorIdCount < maxProcessor)
                        {
                            availableProcssorIdsCount = maxProcessor - processorIdCount;
                            param1 = new SqlParameter("ServerNum", SqlDbType.Int) { Value = serverId };
                            dt = conn.ConnectAndExecuteDT(connStr, "GetUnAssignMessageProcessorIdsAtms", new List<SqlParameter> { param1 });
                            int takeDatatableTill = dt.Rows.Count > availableProcssorIdsCount ? availableProcssorIdsCount : dt.Rows.Count;
                            if (takeDatatableTill > 0)
                            {
                                dt = dt.Select().Take(takeDatatableTill).CopyToDataTable();
                                string query = string.Empty;
                                foreach (DataRow dr1 in dt.Rows)
                                {
                                    //dr1["message_processor_id"] = procesorId;
                                    query += $"update atm set message_processor_id = {procesorId} ,is_edited = 1 where ATM_id = {dr1["ATM_id"]} ;";
                                }

                                result = conn.ConnectAndExecuteQuery(coreConnStr, query);
                            }
                        }

                    }

                    dt = conn.ConnectAndExecuteDT(coreConnStr, "GetUnAssignMessageProcessorIdsAtms", new List<SqlParameter> { param1 });

                    /// Assigning new processor id to atms
                    while (dt.Rows.Count > 0)
                    {
                        dataTable = conn.ConnectAndExecuteDT(connStr, "GetServerAtmsMessageProcessorCount", new List<SqlParameter> { param1 });
                        var highestProcessorId = dataTable.Rows.Count == 0 ? "0" : dataTable.AsEnumerable().Select(row => row.Field<long?>("message_processor_id")).Select(val => val.Value).ToList().Max().ToString();
                        int procesorId = Convert.ToInt32(highestProcessorId) + 1;


                        int takeDatatableTill = dt.Rows.Count > maxProcessor ? maxProcessor : dt.Rows.Count;
                        if (takeDatatableTill > 0)
                        {
                            string query = string.Empty;

                            dt = dt.Select().Take(takeDatatableTill).CopyToDataTable();
                            foreach (DataRow dr in dt.Rows)
                            {
                                query += $"update atm set message_processor_id = {procesorId}, is_edited = 1 where ATM_id = {dr["ATM_id"]} ;";
                            }
                            result = conn.ConnectAndExecuteQuery(coreConnStr, query);

                            dt = conn.ConnectAndExecuteDT(coreConnStr, "GetUnAssignMessageProcessorIdsAtms", new List<SqlParameter> { param1 });
                        }
                    }
                }

                LogableTask.LogMonoActivityTask("HandleAtmMessageProcessor", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Max processor id info updated in atm");
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("HandleAtmMessageProcessor", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
        }
        static string GenerateUpdateQuery(string tableName, DataRow updateRow, string PrimaryKeyColumnName)
        {
            // Create a list of column names
            var columnNames = updateRow.Table.Columns.Cast<DataColumn>().Select(col => col.ColumnName);

            // Create a parameterized update query
            string setClause = string.Join(", ", columnNames.Select(col => $"{col} = {FormatValueForInsert(updateRow[col])}"));

            // Identify the primary key or a unique identifier for the update
            string primaryKeyColumn = PrimaryKeyColumnName;
            string primaryKeyValue = updateRow[primaryKeyColumn].ToString();

            // Create the update query
            string updateQuery = $"UPDATE {tableName} SET {setClause} WHERE {primaryKeyColumn} = {primaryKeyValue}";

            return updateQuery;
        }

        // Format values for direct insertion into the SQL query
        static string FormatValueForUpdate(object value)
        {
            if (value is int || value is decimal)
            {
                return value.ToString();
            }
            else if (value is bool)
            {
                return ((bool)value) ? "1" : "0";
            }
            else if (value is DateTime)
            {
                return $"'{((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss")}'";
            }
            else if (value is string || value is bool)
            {
                return $"'{value}'";
            }

            return "''"; // Default for unsupported types
        }
        public void OnDebug()
        {
            OnStart(null);
        }
        public void CreateConfigurationTask(string connString, long createdBy, List<string> atmIds)
        {
            object result = null;
            if (atmIds?.Count > 0)
            {
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@atmIds",
                    SqlDbType = SqlDbType.VarChar,
                    Value = string.Join(",", atmIds)
                };
                SqlParameter param2 = new SqlParameter()
                {
                    ParameterName = "@CreatedBy",
                    SqlDbType = SqlDbType.BigInt,
                    Value = createdBy
                };

                DataTable dt = conn.ConnectAndExecuteDT(connString, "CreateConfigurationTask", new List<SqlParameter> { param1, param2 });
                if (dt.Rows.Count > 0)
                    LogableTask.LogMonoActivityTask("CreateConfigurationTask", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, $"Task of Atm : {atmIds.FirstOrDefault()} is successfully created");
            }
        }
    }
}
