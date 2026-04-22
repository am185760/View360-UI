using DataRequestor;
using Encryption;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EView360Models.ViewModels;

namespace DataRequestorMiddleware.Services.Admin
{
    public class AtmHandlerService
    {
        public static ConnectionInitializer conn;
        public DBServerInfo coreDB;
        public AtmHandlerService()
        {
            string key = Helper.ConstractKey(false);
            conn = new ConnectionInitializer();
            coreDB = conn.DBServers[0];
            string coreConnStr = Cryptic.DecryptString(coreDB.ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(coreDB.ServerCredentials, key).TrimEnd('\0');

        }
        public void HandleAtmMessageProcessor(Dictionary<string, int> ServerMaxProcessors)
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

                    //var maxProcessor = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings[$"MaxProcessorOfServer{serverId}"]);
                    var maxProcessor = ServerMaxProcessors.Where(x => x.Key == $"MaxProcessorOfServer{serverId}").FirstOrDefault().Value;
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

                    //dt = conn.ConnectAndExecuteDT(coreConnStr, "GetUnAssignMessageProcessorIdsAtms", new List<SqlParameter> { param1 });

                    ///// Assigning new processor id to atms
                    //while (dt.Rows.Count > 0)
                    //{
                    //    dataTable = conn.ConnectAndExecuteDT(connStr, "GetServerAtmsMessageProcessorCount", new List<SqlParameter> { param1 });
                    //    var highestProcessorId = dataTable.Rows.Count == 0 ? "0" : dataTable.AsEnumerable().Select(row => row.Field<long?>("message_processor_id")).Select(val => val.Value).ToList().Max().ToString();
                    //    int procesorId = Convert.ToInt32(highestProcessorId) + 1;


                    //    int takeDatatableTill = dt.Rows.Count > maxProcessor ? maxProcessor : dt.Rows.Count;
                    //    if (takeDatatableTill > 0)
                    //    {
                    //        string query = string.Empty;

                    //        dt = dt.Select().Take(takeDatatableTill).CopyToDataTable();
                    //        foreach (DataRow dr in dt.Rows)
                    //        {
                    //            query += $"update atm set message_processor_id = {procesorId}, is_edited = 1 where ATM_id = {dr["ATM_id"]} ;";
                    //        }
                    //        result = conn.ConnectAndExecuteQuery(coreConnStr, query);

                    //        dt = conn.ConnectAndExecuteDT(coreConnStr, "GetUnAssignMessageProcessorIdsAtms", new List<SqlParameter> { param1 });
                    //    }
                    //}
                }

                LogableTask.LogMonoActivityTask("HandleAtmMessageProcessor", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Max processor id info updated in atm");
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("HandleAtmMessageProcessor", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
            }
        }
        //        public void HandleAtms(long atmId, Dictionary<string, int> ServerMaxProcessors)
        //        {
        //            string key = Helper.ConstractKey(false);
        //            string connStr = string.Empty;
        //            string coreConnStr = string.Empty;
        //            int availableSpace = 0;
        //            int count = 0;
        //            string IDs = string.Empty;
        //            List<string> AtmIds = new List<string>();

        //            conn.LoadServersInfo();
        //            try
        //            {
        //                LogableTask.LogMonoActivityTask("GetAtmById", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to get Unassigned Atms from core DB");
        //                coreConnStr = Cryptic.DecryptString(coreDB.ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(coreDB.ServerCredentials, key).TrimEnd('\0');
        //                SqlParameter param = new SqlParameter("AtmsIds", SqlDbType.VarChar) { Value = atmId };
        //                DataTable dataTable = conn.ConnectAndExecuteDT(coreConnStr, "GetAtmById", new List<SqlParameter>() { param });

        //                object check = conn.ConnectAndExecuteQuery(coreConnStr, "select * from atm where Atm_Id = 2");
        //                LogableTask.LogMonoActivityTask("GetAtmById", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "got all Unassigned Atms from core DB");
        //                //if (dataTable == null || dataTable.Rows.Count == 0)
        //                //{
        //                //    LogableTask.LogMonoActivityTask("GetAtmById", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "not found any unassigned ATM, All ATMs assigned to specific server");
        //                //    return;
        //                //}
        //                int serverId;
        //                if (dataTable != null && dataTable.Rows.Count > 0)
        //                {

        //                }
        //                for (int i = 0; i < conn.DBServers.Count; i++)
        //                {
        //                    try
        //                    {
        //                        object result = null;
        //                        serverId = i + 1;
        //                        if (count == dataTable.Rows.Count || (count > 0 && dataTable.Rows.Count <= count))
        //                            break;
        //                        availableSpace = Convert.ToInt32(conn.DBServers[i].MaxATMs) - Convert.ToInt32(conn.DBServers[i].AtmIds.Count);
        //                        if (availableSpace > 0)
        //                        {
        //                            connStr = Cryptic.DecryptString(conn.DBServers[i].ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(conn.DBServers[i].ServerCredentials, key).TrimEnd('\0');
        //                            DataTable dt = dataTable.Select().Skip(count).Take(availableSpace).CopyToDataTable();
        //                            IDs = string.Empty;
        //                            for (int j = 0; j < dt.Rows.Count; j++)
        //                            {
        //                                IDs += dt.Rows[j][0] + ",";
        //                                dt.Rows[j][108] = serverId;
        //                                dt.Rows[j][109] = 0;
        //                                if (conn.DBServers[i].AtmInfo == null)
        //                                {
        //                                    conn.DBServers[i].AtmIds = new List<string>();
        //                                    conn.DBServers[i].AtmInfo = new Dictionary<string, string>();
        //                                }
        //                                if (!conn.DBServers[i].AtmInfo.Keys.Contains(dt.Rows[j][4].ToString()))
        //                                {
        //                                    conn.DBServers[i].AtmIds.Add(dt.Rows[j][0].ToString());
        //                                    conn.DBServers[i].AtmInfo.Add(dt.Rows[j][4].ToString(), dt.Rows[j][0].ToString());
        //                                }
        //                                if (!AtmIds.Contains(dt.Rows[j]["ATM_id"].ToString()))
        //                                {
        //                                    AtmIds.Add(dt.Rows[j]["ATM_id"].ToString());
        //                                }
        //                            }

        //                            IDs = IDs.TrimEnd(',');
        //                            count += availableSpace;
        //                            var atmIds = dt.AsEnumerable().Select(s => s.Field<long>("ATM_id").ToString()).Distinct().ToList();
        //                            string query = $"update atm set assigned_server = {serverId} where ATM_id in ({string.Join(",", atmIds)})";
        //                            result = conn.ConnectAndExecuteQuery(coreConnStr, query);


        //                            if (serverId > 1)
        //                            {
        //                                query = string.Empty;
        //                                result = conn.ConnectAndExecuteQuery(connStr, query);
        //                                foreach (DataRow dr in dt.Rows)
        //                                {
        //                                    int index = 1;
        //                                    query += "insert into atm (";
        //                                    foreach (DataColumn column in dt.Columns)
        //                                    {
        //                                        query += $"{column.ColumnName} ";
        //                                        if (index != dt.Columns.Count)
        //                                        {
        //                                            query += ",";
        //                                        }
        //                                        index++;
        //                                    }

        //                                    query += ") VALUES (";
        //                                    index = 1;
        //                                    foreach (DataColumn column in dt.Columns)
        //                                    {
        //                                        if (column.ColumnName == "ATM_id")
        //                                        {
        //                                            query += $@"{dr["ATM_id"]}";
        //                                        }
        //                                        else if (DBNull.Value.Equals(dr[column.ColumnName]))
        //                                        {
        //                                            query += $"null";
        //                                        }
        //                                        else if (column.DataType == typeof(string) || column.DataType == typeof(DateTime))
        //                                        {
        //                                            query += $@"'{dr[column.ColumnName]}' ";
        //                                        }
        //                                        else if (column.DataType == typeof(Boolean))
        //                                        {
        //                                            query += Convert.ToBoolean(dr[column.ColumnName]) == false ? 0 : 1;
        //                                        }
        //                                        else
        //                                        {
        //                                            query += $@"{dr[column.ColumnName]}";
        //                                        }




        //                                        if (index != dt.Columns.Count)
        //                                        {
        //                                            query += ",";
        //                                        }
        //                                        index++;
        //                                    }

        //                                    query += " );";
        //                                }
        //                                // Inserting atm with default values
        //                                result = conn.ConnectAndExecuteQuery(connStr, query);

        //                                //query = string.Empty;
        //                                //foreach (DataRow dr in dt.Rows)
        //                                //{
        //                                //    query += "update atm set created_by = 0";

        //                                //    foreach (DataColumn column in dt.Columns)
        //                                //    {
        //                                //        if (column.ColumnName == "ATM_id" || column.ColumnName == "created_by")
        //                                //        {
        //                                //            continue;
        //                                //        }
        //                                //        else if (string.IsNullOrEmpty(dr[column.ColumnName].ToString()))
        //                                //        {
        //                                //            continue;
        //                                //        }
        //                                //        else if (column.DataType == typeof(string) || column.DataType == typeof(DateTime))
        //                                //        {
        //                                //            query += $", {column.ColumnName} = '{dr[column.ColumnName]}'";
        //                                //        }
        //                                //        else if (column.DataType == typeof(Boolean))
        //                                //        {
        //                                //            query += $", {column.ColumnName} = '{Convert.ToBoolean(dr[column.ColumnName])}'";
        //                                //        }
        //                                //        else
        //                                //        {
        //                                //            query += $", {column.ColumnName} = {dr[column.ColumnName]}";
        //                                //        }
        //                                //    }
        //                                //    query += $" where ATM_id = {dr["ATM_id"]};";
        //                                //}
        //                                // updating atm data on others servers 
        //                                result = conn.ConnectAndExecuteQuery(connStr, query);

        //                            }
        //                            var maxProcessor = ServerMaxProcessors.Where(x => x.Key == $"MaxProcessorOfServer{serverId}").FirstOrDefault().Value;
        //                            if (maxProcessor == 0)
        //                            {
        //                                LogableTask.LogMonoActivityTask("HandleAtmMessageProcessor", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, $"Max processor of server {serverId} is not available in app config");
        //                                return;
        //                            }
        //                            SqlParameter param1 = new SqlParameter("ServerNum", SqlDbType.Int) { Value = serverId };
        //                            DataTable maxProcessorDt = conn.ConnectAndExecuteDT(coreConnStr, "GetServerAtmsMessageProcessorCount", new List<SqlParameter> { param1 });


        //                            int availableProcessorId;
        //                            foreach (DataRow dr in maxProcessorDt.Rows)
        //                            {
        //                                int processorIdCount = Convert.ToInt32(dr["count"].ToString());
        //                                int procesorId = Convert.ToInt32(dr["message_processor_id"].ToString());
        //                                if (processorIdCount < maxProcessor)
        //                                {
        //                                    //availableProcssorIdsCount = maxProcessor - processorIdCount;
        //                                    //param1 = new SqlParameter("ServerNum", SqlDbType.Int) { Value = serverId };
        //                                    //dt = conn.ConnectAndExecuteDT(connStr, "GetUnAssignMessageProcessorIdsAtms", new List<SqlParameter> { param1 });
        //                                    //int takeDatatableTill = dt.Rows.Count > availableProcssorIdsCount ? availableProcssorIdsCount : dt.Rows.Count;
        //                                    //if (takeDatatableTill > 0)
        //                                    //{
        //                                    //    dt = dt.Select().Take(takeDatatableTill).CopyToDataTable();
        //                                    //    query = string.Empty;
        //                                    //    foreach (DataRow dr1 in dt.Rows)
        //                                    //    {
        //                                    //        //dr1["message_processor_id"] = procesorId;
        //                                    //        query += $"update atm set message_processor_id = {procesorId} ,is_edited = 1 where ATM_id = {dr1["ATM_id"]} ;";
        //                                    //    }

        //                                    //    result = conn.ConnectAndExecuteQuery(coreConnStr, query);
        //                                    availableProcessorId = procesorId;
        //                                }
        //                                else
        //                                {
        //                                    availableProcessorId = procesorId + 1;
        //                                }
        //                            }
        //                            query = $"update atm set assigned_server = {serverId} message_processor_id = {availableProcessorId} WHERE ATM_id = {atmId}";

        //                        }
        //                        //SqlParameter param = new SqlParameter("AtmsInfo", SqlDbType.Structured) { Value = dt }; 
        //                        //if (i > 0)
        //                        //    result = conn.ConnectAndExecute(connStr, "SaveATMInfo", new List<SqlParameter> { param });
        //                        //if ((result != null && Convert.ToInt32(result) <= availableSpace) || (i == 0 && availableSpace > 0))
        //                        //{
        //                        //    LogableTask.LogMonoActivityTask("SaveATMInfo", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "ATMs saved into the assigned DB server");
        //                        //    param = new SqlParameter("AtmsID", SqlDbType.VarChar) { Value = IDs };
        //                        //    SqlParameter param1 = new SqlParameter("ServerNum", SqlDbType.Int) { Value = serverId };
        //                        //    result = conn.ConnectAndExecute(coreConnStr, "UpdateATMInfoInCore", new List<SqlParameter> { param, param1 });
        //                        //    if (result != null)
        //                        //        LogableTask.LogMonoActivityTask("UpdateATMInfoInCore", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "ATMs assigned to server in core DB");
        //                        //}
        //                    }
        //                        else
        //                    {
        //                        LogableTask.LogMonoActivityTask("HandleATMs", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "No free capacity in DB server " + serverId);
        //                    }
        //                }
        //                //        catch (Exception ex)
        //                //{
        //                //    LogableTask.LogMonoActivityTask("HandleATMs", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
        //                //}
        //                CreateConfigurationTask(connStr, 0, new List<string> { atmId.ToString() });
        //                //}
        //                conn.SaveServersInfo();
        //                LogableTask.LogMonoActivityTask("HandleATMs", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "DB servers info updated in core DB");

        //            }//
        //         //foreach (var AtmId in AtmIds)
        //         //{
        //                    }
        //            catch (Exception ex)
        //            {
        //    LogableTask.LogMonoActivityTask("HandleATMs", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);
        //}
        //        }


        public async Task<BaseModel> HandleAtms(string atmId, Dictionary<string, int> ServerMaxProcessors)
        {
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
                LogableTask.LogMonoActivityTask("GetAtmById", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "Going to get atm with atmId = " + atmId);
                coreConnStr = Cryptic.DecryptString(coreDB.ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(coreDB.ServerCredentials, key).TrimEnd('\0');
                SqlParameter param = new SqlParameter("AtmsIds", SqlDbType.VarChar) { Value = atmId };
                DataTable dataTable = conn.ConnectAndExecuteDT(coreConnStr, "GetAtmById", new List<SqlParameter>() { param });
                string query = string.Empty;
                LogableTask.LogMonoActivityTask("GetAtmById", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "got  atm with atmId = " + atmId + " from core DB");
                bool isSpaceAvailableInServers = false;
                int serverId;
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < conn.DBServers.Count; i++)
                    {
                        object result = null;
                        serverId = i + 1;
                        if (count == dataTable.Rows.Count || (count > 0 && dataTable.Rows.Count <= count))
                            break;
                        if (string.IsNullOrEmpty(conn.DBServers[i].MaxATMs))
                        {
                            throw new Exception($"Max Atms is empty in server {serverId}");
                        }
                        availableSpace = Convert.ToInt32(conn.DBServers[i].MaxATMs) - Convert.ToInt32(conn.DBServers[i].AtmIds.Count);
                        if (availableSpace > 0)
                        {
                            isSpaceAvailableInServers = true;
                            connStr = Cryptic.DecryptString(conn.DBServers[i].ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(conn.DBServers[i].ServerCredentials, key).TrimEnd('\0');
                            IDs = string.Empty;
                            for (int j = 0; j < dataTable.Rows.Count; j++)
                            {
                                IDs += dataTable.Rows[j][0] + ",";
                                dataTable.Rows[j][108] = serverId;
                                dataTable.Rows[j][109] = 0;
                                if (conn.DBServers[i].AtmInfo == null)
                                {
                                    conn.DBServers[i].AtmIds = new List<string>();
                                    conn.DBServers[i].AtmInfo = new Dictionary<string, string>();
                                }
                                if (!conn.DBServers[i].AtmInfo.Keys.Contains(dataTable.Rows[j][4].ToString()))
                                {
                                    conn.DBServers[i].AtmIds.Add(dataTable.Rows[j][0].ToString());
                                    conn.DBServers[i].AtmInfo.Add(dataTable.Rows[j][4].ToString(), dataTable.Rows[j][0].ToString());
                                }
                                if (!AtmIds.Contains(dataTable.Rows[j]["ATM_id"].ToString()))
                                {
                                    AtmIds.Add(dataTable.Rows[j]["ATM_id"].ToString());
                                }
                            }

                            IDs = IDs.TrimEnd(',');

                            var maxProcessor = ServerMaxProcessors.Where(x => x.Key == $"MaxProcessorOfServer{serverId}").FirstOrDefault().Value;
                            if (maxProcessor == 0)
                            {
                                LogableTask.LogMonoActivityTask("HandleAtmMessageProcessor", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Error, $"Max processor of server {serverId} is not available in app config");
                                //return;
                            }

                            // assign server and message processor id
                            SqlParameter param1 = new SqlParameter("ServerNum", SqlDbType.Int) { Value = serverId };
                            DataTable maxProcessorDt = conn.ConnectAndExecuteDT(coreConnStr, "GetServerAtmsMessageProcessorCount", new List<SqlParameter> { param1 });


                            int availableProcessorId = 0;
                            foreach (DataRow dr in maxProcessorDt.Rows)
                            {
                                int processorIdCount = Convert.ToInt32(dr["count"].ToString());
                                int procesorId = Convert.ToInt32(dr["message_processor_id"].ToString());
                                if (processorIdCount < maxProcessor)
                                {
                                    availableProcessorId = procesorId;
                                }
                                else
                                {
                                    availableProcessorId = procesorId + 1;
                                }
                                break;
                            }
                            int messageProcessorId = availableProcessorId == 0 ? 1 : availableProcessorId;
                            dataTable.Rows[0]["assigned_server"] = serverId;
                            dataTable.Rows[0]["message_processor_id"] = availableProcessorId;
                            if (serverId > 1)
                            {
                                query = string.Empty;
                                foreach (DataRow dr in dataTable.Rows)
                                {
                                    int index = 1;
                                    //query += "insert into atm (";
                                    //foreach (DataColumn column in dataTable.Columns)
                                    //{
                                    //    query += $"{column.ColumnName} ";
                                    //    if (index != dataTable.Columns.Count)
                                    //    {
                                    //        query += ",";
                                    //    }
                                    //    index++;
                                    //}

                                    //query += ") VALUES (";
                                    //index = 1;
                                    //foreach (DataColumn column in dataTable.Columns)
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




                                    //    if (index != dataTable.Columns.Count)
                                    //    {
                                    //        query += ",";
                                    //    }
                                    //    index++;
                                    //}

                                    //query += " );";

                                    query += GenerateInsertQuery("atm", dr);
                                    // Inserting atm into server
                                    result = conn.ConnectAndExecuteQuery(connStr, query);

                                }
                            }
                            query = $"update atm set assigned_server = {serverId} ,message_processor_id = {messageProcessorId} WHERE ATM_id = {atmId}";
                            result = conn.ConnectAndExecuteQuery(coreConnStr, query);
                            conn.SaveServersInfo();
                            break;
                        }
                    }
                }
                if (!isSpaceAvailableInServers)
                {
                    return new BaseModel { IsSuccess = false, Message = "All servers capacity is full please make new server or increase its capacity" };

                }
                CreateConfigurationTask(connStr, 0, new List<string> { atmId });

                return new BaseModel { IsSuccess = true, Message = "Succesfully assign server to atm" };
                //LogableTask.LogMonoActivityTask("HandleATMs", System.Reflection.MethodBase.GetCurrentMethod(), TraceLevel.Info, "DB servers info updated in core DB");
            }
            catch (Exception ex)
            {
                return new BaseModel { IsSuccess = false, Message = ex.Message  };
                //throw;
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
