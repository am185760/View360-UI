using Encryption;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
namespace DataRequestor
{

    public class ServerHealthStatus
    {
        public DateTime lastPoolAt;
        public bool isHealthy;
    }
    public class ConnectionInitializer
    {
        ConcurrentDictionary<string, ServerHealthStatus> dictionaryServerHealthStatus = new ConcurrentDictionary<string, ServerHealthStatus>();
        public string regKey = @"SOFTWARE\NCR\EV360";

        public string InfoPath { set; get; }
        public List<DBServerInfo> DBServers { set; get; }
        public List<AppServerInfo> AppServers { set; get; }
        public ConnectionInitializer()
        {

            //string temp = (string)Registry.LocalMachine.OpenSubKey(regKey).GetValue("ConnectionString", "");
            string temp = (string)Registry.LocalMachine.OpenSubKey(regKey).GetValue("CoreConnStrPath", "");
            this.InfoPath = Encryption.Cryptic.DecryptString(temp, Helper.ConstractKey(false)).TrimEnd('\0');

            this.DBServers = new List<DBServerInfo>();
            this.AppServers = new List<AppServerInfo>();
            this.LoadServersInfo();
        }
        public ConnectionInitializer(string key)
        {
            string temp = (string)Registry.LocalMachine.OpenSubKey(regKey).GetValue(key, "");
            this.InfoPath = Encryption.Cryptic.DecryptString(temp, Helper.ConstractKey(false)).TrimEnd('\0');
            this.DBServers = new List<DBServerInfo>();
            this.AppServers = new List<AppServerInfo>();
            this.LoadServersInfo();
        }
        public static bool IsDBServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException ex)
                {
                    throw ex;
                    //return false;
                }
            }
        }
        public static bool PingAppServer(string hostUri, int portNumber)
        {
            try
            {
                using (var client = new TcpClient(hostUri, portNumber))
                    return true;
            }
            catch (SocketException ex)
            {
                return false;
            }
        }
        public void LoadServersInfo()
        {
            try
            {
                string key = Helper.ConstractKey(false);
                //string temp = (string)Registry.LocalMachine.OpenSubKey(regKey).GetValue("ConnectionString", "");
                //string connStr = Encryption.Cryptic.DecryptString(temp, key).TrimEnd('\0');
                string connStr = string.Empty;
                string temp = string.Empty;
                using (StreamReader r = new StreamReader(this.InfoPath))
                {
                    temp = r.ReadToEnd();
                    connStr = Encryption.Cryptic.DecryptString(temp, key).TrimEnd('\0');
                }
                if (string.IsNullOrEmpty(connStr))
                {
                    this.DBServers.Add(new DBServerInfo());
                    this.AppServers.Add(new AppServerInfo());
                    return;
                }
                var result = ConnectAndExecute(connStr, "LoadServersInfo", new List<SqlParameter>());
                if (result == null || result == new { } || result.ToString() == string.Empty)
                {
                    this.DBServers.Add(new DBServerInfo());
                    this.AppServers.Add(new AppServerInfo());
                    return;
                    //throw new Exception("Can't find Servers information in DB!");
                }

                string json = Encoding.UTF8.GetString((byte[])result);
                JObject obj = JObject.Parse(json);
                var dbServers = obj["DBServers"];
                var appServers = obj["AppServers"];

                this.DBServers = JsonConvert.DeserializeObject<List<DBServerInfo>>(dbServers.ToString());
                this.AppServers = JsonConvert.DeserializeObject<List<AppServerInfo>>(appServers.ToString());

                if (this.AppServers == null)
                    this.AppServers = new List<AppServerInfo>();
                if (this.DBServers == null)
                {
                    this.DBServers = new List<DBServerInfo>();
                    this.DBServers.Add(new DBServerInfo());
                }
                string logPath = ConnectAndExecuteQuery(connStr, "select logfile_path from app_setting").ToString();
                try
                {
                    XmlLogWriter.InitXmlLogWriter(logPath + "\\DataRequestor_" + DateTime.Now.ToString("yyyyMMdd") + "_" + Process.GetCurrentProcess().Id + ".txt");
                    string fileName = $"DataRequestor_{DateTime.Now:yyyyMMdd}_{Process.GetCurrentProcess().Id}.txt";
                }
                catch (Exception ex) { }
            }
            catch (Exception ex)
            {
                this.DBServers.Add(new DBServerInfo());
                this.AppServers.Add(new AppServerInfo());
                return;
            }
            //using (StreamReader r = new StreamReader(this.InfoPath))
            //{
            //    string json = r.ReadToEnd();
            //    JObject obj = JObject.Parse(json);
            //    var dbServers = obj["DBServers"];
            //    var appServers = obj["AppServers"];

            //    this.DBServers = JsonConvert.DeserializeObject<List<DBServerInfo>>(dbServers.ToString());
            //    this.AppServers = JsonConvert.DeserializeObject<List<AppServerInfo>>(appServers.ToString());
            //}
        }
        public string SaveServersInfo()
        {
            string resultMsg = string.Empty;
            try
            {
                var jsonString = JsonConvert.SerializeObject(this);
                byte[] arr = Encoding.UTF8.GetBytes(jsonString);
                string key = Helper.ConstractKey(false);
                string connStr = Cryptic.DecryptString(DBServers[0].ServerConnection, key).TrimEnd('\0') + Cryptic.DecryptString(DBServers[0].ServerCredentials, key).TrimEnd('\0');
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter { ParameterName = "Info", SqlDbType = SqlDbType.VarBinary, Value = arr });

                var result = ConnectAndExecute(connStr, "SaveServersInfo", sqlParams);
                if ((int)result < 1)
                    resultMsg = "DB server 1 (Core): Settings could not be saved\n";

                //using (StreamWriter file = File.CreateText(this.InfoPath))
                //{
                //    file.Write(Encryption.Cryptic.EncryptString(connStr,key));
                //    //JsonSerializer serializer = new JsonSerializer();
                //    //serializer.Serialize(file, connStr);
                //}
                return resultMsg;
            }
            catch (Exception ex)
            {
                resultMsg += ex.Message;
                return resultMsg;
            }
        }

        public bool IsServerAlive(string serverName)
        {
            bool result = false;

            if (serverName.Contains("\\"))
                serverName = serverName.Substring(0, serverName.IndexOf("\\"));

            if (serverName.Equals("."))
                serverName = "localhost";

            if (dictionaryServerHealthStatus.ContainsKey(serverName))
            {
                ServerHealthStatus healthStatus = dictionaryServerHealthStatus[serverName];
                if (healthStatus.lastPoolAt < DateTime.Now)
                {
                    try
                    {
                        Ping ping = new Ping();

                        
                         PingReply reply = ping.Send(serverName);
                        if (reply.Status == IPStatus.Success)
                            result = healthStatus.isHealthy = true;
                        else
                            result = healthStatus.isHealthy = false;

                    }
                    catch (Exception ex)
                    {
                        healthStatus.isHealthy = false;
                    }
                    healthStatus.lastPoolAt = healthStatus.lastPoolAt.AddMinutes(5);
                }
                result = healthStatus.isHealthy;
            }
            else
            {
                try
                {
                    Ping ping = new Ping();
                    PingReply reply = ping.Send(serverName);
                    ServerHealthStatus healthStatus = new ServerHealthStatus();
                    healthStatus.lastPoolAt = DateTime.Now;
                    if (reply.Status == IPStatus.Success)
                        result = healthStatus.isHealthy = true;
                    else
                        result = healthStatus.isHealthy = false;

                    dictionaryServerHealthStatus.TryAdd(serverName, healthStatus);
                }
                catch (Exception ex)
                {
                    ServerHealthStatus healthStatus = new ServerHealthStatus();
                    healthStatus.lastPoolAt = DateTime.Now;
                    result = healthStatus.isHealthy = false;
                    dictionaryServerHealthStatus.TryAdd(serverName, healthStatus);
                }

            }
            return result;
        }
        public List<string> FilterRequest(List<string> Atms, bool byIP)
        {
            List<string> info = new List<string>();
            for (int i = 0; i < this.DBServers.Count; i++)
            {
                //if (!byIP)
                //    info.Add("-1");
                //else
                info.Add("");
            }
            if (!byIP)
            {
                //return info;
                for (int i = 0; i < Atms.Count; i++)
                {
                    for (int j = 0; j < this.DBServers.Count; j++)
                    {
                        if (IsServerAlive(this.DBServers[j].ServerName))
                        {
                            if (this.DBServers[j].AtmIds.Contains(Atms[i]))
                            {
                                info[j] += Atms[i] + ",";
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Atms.Count; i++)
                {
                    for (int j = 0; j < this.DBServers.Count; j++)
                    {
                        if (IsServerAlive(this.DBServers[j].ServerName))
                        {
                            bool exist = this.DBServers[j].AtmInfo.ContainsKey(Atms[i]);
                            if (exist)
                            {
                                info[j] += this.DBServers[j].AtmInfo[Atms[i]] + ",";
                                break;
                                //info[0] = j.ToString() + "," + this.DBServers[j].AtmInfo[Atms[i]];
                            }
                        }
                    }
                }
            }

            // To log if 0 atm are returned
            if (info.All(x => string.IsNullOrEmpty(x)))
            {
                LogableTask.LogMonoActivityTask("FilterRequest", MethodBase.GetCurrentMethod(), TraceLevel.Warning, "0 Atm returned, the Atm's count coming in parameter = " + Atms.Count);
            }


            return info;
        }
        public object ConnectAndExecute(string connectionStr, string spName, List<SqlParameter> spParams)
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.Clear();
            for (int i = 0; i < spParams.Count(); i++)
            {
                cmd.Parameters.Add(new SqlParameter(spParams[i].ParameterName, spParams[i].SqlDbType));
                cmd.Parameters[i].Value = spParams[i].Value;
            }
            var result = cmd.ExecuteScalar();
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            connection.Close();
            connection.Dispose();
            return result;
        }

        public DataTable ConnectAndExecuteDT(string connectionStr, string spName, List<SqlParameter> spParams)
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.Clear();
            for (int i = 0; i < spParams.Count(); i++)
            {
                cmd.Parameters.Add(new SqlParameter(spParams[i].ParameterName, spParams[i].SqlDbType) { Value = spParams[i].Value });
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            connection.Close();
            connection.Dispose();
            return ds.Tables[0];
        }
        public object ConnectAndExecuteQuery(string connectionStr, string query)
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;



            //cmd.Parameters.Clear();
            var result = cmd.ExecuteScalar();
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            connection.Close();
            connection.Dispose();
            return result;



        }

    }

}
