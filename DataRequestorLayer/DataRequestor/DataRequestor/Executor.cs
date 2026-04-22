using Encryption;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DataRequestor
{
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(Exception exception, DataTable data)
        {
            _exception = exception;
            _data = data;
        }

        public CustomEventArgs(Exception exception, DataSet dataSet)
        {
            _exception = exception;
            _dataSet = dataSet;
        }
        public Exception _exception { get; set; }
        public DataTable _data { get; set; }
        public DataSet _dataSet { get; set; }
    }

    public static class ServerMemoryCache
    {
        static MemoryCacheOptions cacheOptions = new MemoryCacheOptions();
        private static IMemoryCache cache = new MemoryCache(cacheOptions);
        private static MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                                .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                                .SetPriority(CacheItemPriority.Normal);

        public static IMemoryCache GetMemoryCache()
        {
            return cache;
        }
        public static void SetMemoryCache(string cacheKeyHash, DataSet ds)
        {
            cache?.Set(cacheKeyHash, ds, cacheEntryOptions);
        }
    }
    public class Executor : ConnectionInitializer
    {
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;
        private static IMemoryCache _cache = ServerMemoryCache.GetMemoryCache();
        //public Executor(IMemoryCache cache) : base()
        //{
        //    _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        //}
        public Executor() : base()
        { }

        public T ExecuteDSRequest<T>(string spName, SqlParameter[] spParams, List<string> atmIds, bool readFromCache = true)
        {
            List<Task<DataTable>> TasksDataSets = new List<Task<DataTable>>();
            List<string> RequestsInfo = new List<string>();
            DataTable table = new DataTable();
            string resultMsg = string.Empty;
            if (spParams == null)
                spParams = new SqlParameter[] { };
            RequestsInfo = FilterRequest(atmIds, false);

            if (RequestsInfo != null && RequestsInfo.Count > 0 && RequestsInfo.All(x => x.Length == 0))
            {
                if (RaiseCustomEvent != null)
                {
                    RaiseCustomEvent(this, new CustomEventArgs(new NullReferenceException("AtmId/s do not exist in system"), new DataTable()));
                    return default(T);
                }
                else
                {
                    object o2 = new DataTableResult(null, "AtmId/s do not exist in system");
                    if (o2 is T)
                        return (T)o2;
                    return default(T);
                }
            }

            TasksDataSets = GetDataTables(RequestsInfo, this.DBServers, spName, spParams, readFromCache);
            List<DataTable> listDT = new List<DataTable>();
            for (int i = 0; i < TasksDataSets.Count; i++)
            {
                if (TasksDataSets[i].Status.ToString() == "RanToCompletion")
                    listDT.Add(TasksDataSets[i].Result);
                if (TasksDataSets[i].Exception != null && !string.IsNullOrEmpty(TasksDataSets[i].Exception.Message))
                    resultMsg += TasksDataSets[i].Exception.ToString();
            }
            var rows = listDT.SelectMany(dt => dt.AsEnumerable());
            table = rows.Count() > 0 ? rows.CopyToDataTable() : new DataTable();
            table.TableName = "Table";
            object o = new DataTableResult(table, resultMsg);
            if (o is T)
                return (T)o;
            return default(T);
        }

        public T ExecuteDSRequest<T>(string spName, SqlParameter[] spParams, List<string> atmIds, string atmIdLst, bool readFromCache = true)
        {
            List<Task<DataTable>> TasksDataSets = new List<Task<DataTable>>();
            List<string> RequestsInfo = new List<string>();
            DataTable table = new DataTable();
            string resultMsg = string.Empty;
            if (spParams == null)
                spParams = new SqlParameter[] { };
            RequestsInfo = FilterRequest(atmIds, false);

            if (RequestsInfo != null && RequestsInfo.Count > 0 && RequestsInfo.All(x => x.Length == 0))
            {
                if (RaiseCustomEvent != null)
                {
                    RaiseCustomEvent(this, new CustomEventArgs(new NullReferenceException("AtmId/s do not exist in system"), new DataTable()));
                    return default(T);
                }
                else
                {
                    object o2 = new DataTableResult(null, "AtmId/s do not exist in system");
                    if (o2 is T)
                        return (T)o2;
                    return default(T);
                }
            }

            TasksDataSets = GetDataTables(RequestsInfo, this.DBServers, spName, spParams, readFromCache);
            List<DataTable> listDT = new List<DataTable>();
            for (int i = 0; i < TasksDataSets.Count; i++)
            {
                if (TasksDataSets[i].Status.ToString() == "RanToCompletion")
                    listDT.Add(TasksDataSets[i].Result);
                if (TasksDataSets[i].Exception != null && !string.IsNullOrEmpty(TasksDataSets[i].Exception.Message))
                    resultMsg += TasksDataSets[i].Exception.ToString();
            }
            var rows = listDT.SelectMany(dt => dt.AsEnumerable());
            table = rows.Count() > 0 ? rows.CopyToDataTable() : new DataTable();
            table.TableName = "Table";
            object o = new DataTableResult(table, resultMsg);
            if (o is T)
                return (T)o;
            return default(T);
        }
        public T ExecuteDSRequestForDataSet<T>(string spName, SqlParameter[] spParams, List<string> atmIds, bool readFromCache = true)
        {
            string resultMsg = string.Empty;
            if (spParams == null)
                spParams = new SqlParameter[] { };
            List<string>  RequestsInfo = FilterRequest(atmIds, false);

            if (RequestsInfo != null && RequestsInfo.Count > 0 && RequestsInfo.All(x => x.Length == 0))
            {
                if (RaiseCustomEvent != null)
                {
                    RaiseCustomEvent(this, new CustomEventArgs(new NullReferenceException("AtmId/s do not exist in system"), new DataTable()));

                    return default(T);
                }
                else
                {
                    object o2 = new DataTableResult(null, "AtmId/s do not exist in system");
                    if (o2 is T)
                        return (T)o2;
                    return default(T);
                }
            }

            List<Task<DataSet>>  TasksDataSets = GetDataSets(RequestsInfo, this.DBServers, spName, spParams, readFromCache);

            // Create a new DataSet to hold the merged tables
            DataSet mergedDataSet = new DataSet();

            // Loop through each Task<DataSet> and merge the tables
            foreach (var task in TasksDataSets)
            {
                if (task.Status.ToString() == "RanToCompletion")
                {
                    DataSet taskDataSet = task.Result;

                    // Loop through the tables in the taskDataSet
                    for (int i = 0; i < taskDataSet.Tables.Count; i++)
                    {
                        DataTable originalTable = taskDataSet.Tables[i];

                        // Check if a table with the same index already exists in the mergedDataSet
                        // If it exists, merge the current originalTable with the existing table
                        if (mergedDataSet.Tables.Count > i)
                        {
                            DataTable mergedTable = mergedDataSet.Tables[i];
                            mergedTable.Merge(originalTable);
                        }
                        else
                        {
                            // If a table with the same index does not exist, add it to the mergedDataSet
                            DataTable newMergedTable = originalTable.Copy();
                            mergedDataSet.Tables.Add(newMergedTable);
                        }
                    }
                }
                if (task.Exception != null && !string.IsNullOrEmpty(task.Exception.Message))
                    resultMsg += task.Exception.ToString();
            }

            object o = new DataSetResult(mergedDataSet, resultMsg);
            if (o is T)
                return (T)o;

            return default(T);
        }

        public T ExecuteDSRequestForDataSet<T>(string spName, SqlParameter[] spParams, List<string> atmIds, string atmIdLst, bool readFromCache = true)
        {
            string resultMsg = string.Empty;
            if (spParams == null)
                spParams = new SqlParameter[] { };
            List<string> RequestsInfo = FilterRequest(atmIds, false);

            if (RequestsInfo != null && RequestsInfo.Count > 0 && RequestsInfo.All(x => x.Length == 0))
            {
                if (RaiseCustomEvent != null)
                {
                    RaiseCustomEvent(this, new CustomEventArgs(new NullReferenceException("AtmId/s do not exist in system"), new DataTable()));

                    return default(T);
                }
                else
                {
                    object o2 = new DataTableResult(null, "AtmId/s do not exist in system");
                    if (o2 is T)
                        return (T)o2;
                    return default(T);
                }
            }

            List<Task<DataSet>> TasksDataSets = GetDataSets(RequestsInfo, this.DBServers, spName, spParams, readFromCache);

            // Create a new DataSet to hold the merged tables
            DataSet mergedDataSet = new DataSet();

            // Loop through each Task<DataSet> and merge the tables
            foreach (var task in TasksDataSets)
            {
                if (task.Status.ToString() == "RanToCompletion")
                {
                    DataSet taskDataSet = task.Result;

                    // Loop through the tables in the taskDataSet
                    for (int i = 0; i < taskDataSet.Tables.Count; i++)
                    {
                        DataTable originalTable = taskDataSet.Tables[i];

                        // Check if a table with the same index already exists in the mergedDataSet
                        // If it exists, merge the current originalTable with the existing table
                        if (mergedDataSet.Tables.Count > i)
                        {
                            DataTable mergedTable = mergedDataSet.Tables[i];
                            mergedTable.Merge(originalTable);
                        }
                        else
                        {
                            // If a table with the same index does not exist, add it to the mergedDataSet
                            DataTable newMergedTable = originalTable.Copy();
                            mergedDataSet.Tables.Add(newMergedTable);
                        }
                    }
                }
                if (task.Exception != null && !string.IsNullOrEmpty(task.Exception.Message))
                    resultMsg += task.Exception.ToString();
            }

            object o = new DataSetResult(mergedDataSet, resultMsg);
            if (o is T)
                return (T)o;

            return default(T);
        }

        public List<Task<DataTable>> GetDataTables(List<string> requestsInfo, List<DBServerInfo> servers, string sp, SqlParameter[] sParams, bool readFromCache)
        {
            LogableTask.LogMonoActivityTask("GetDataTables", MethodBase.GetCurrentMethod(), TraceLevel.Info, "sp=[" + sp + "]");

            //List<string> ids = new List<string>();
            List<Task<DataTable>> tasks = new List<Task<DataTable>>();
            bool reqsNotEmpty = requestsInfo.Any(r => !string.IsNullOrEmpty(r));

            //parameter values for cache key
            string spParamsText = string.Empty;
            for (int k = 0; k < sParams.Length; k++)
            {
                spParamsText += sParams[k].ParameterName + ":" + sParams[k].Value.ToString();
            }

            // multiple requests
            for (int i = 0; i < requestsInfo.Count; i++)
            {
                if (requestsInfo[i].Length == 0)
                    continue;

                Task<DataTable> task = null;

                try
                {
                    //if (reqsNotEmpty && string.IsNullOrEmpty(requestsInfo[i]))
                    //{
                    //    tasks.Add(Task.FromException<DataTable>(new Exception("No matching records found for processing...")));
                    //    continue;
                    //}

                    // Generate key: Hash( {ServerName_SPName_Paramerater.Values} );
                    string cacheKey = servers[i].ServerName + "_" + sp + "_" + spParamsText;
                    string cacheKeyHash = cacheKey.GetHashCode().ToString();
                    DataSet dataSet = new DataSet();

                    //Search data in cache for server[i]
                    if (readFromCache && _cache != null && _cache.TryGetValue(cacheKeyHash, out dataSet))
                    {
                        task = new Task<DataTable>(() =>
                        {
                            DataSet ds = _cache.Get<DataSet>(cacheKeyHash);
                            return ds.Tables[0];
                        });
                    }
                    //Search data in database and store in cache
                    else
                    {
                        string temp = string.Empty;
                    temp = new string(requestsInfo[i].TrimEnd(',').ToCharArray());
                    DBServerInfo server = new DBServerInfo
                    {
                        ServerConnection = servers[i].ServerConnection,
                        ServerCredentials = servers[i].ServerCredentials
                    };
                    string connStr = Cryptic.DecryptString(server.ServerConnection, Helper.ConstractKey(false)).TrimEnd('\0') + Cryptic.DecryptString(server.ServerCredentials, Helper.ConstractKey(false)).TrimEnd('\0');

                    task = new Task<DataTable>(() =>
                    {
                        //if (requestsInfo[i].Length == 0)
                        //    throw new Exception("No matching records found for processing....");

                        SqlConnection connection = new SqlConnection(connStr);

                        connection.Open();
                        SqlCommand cmd = connection.CreateCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sp;
                        for (int j = 0; j < sParams.Count(); j++)
                        {
                            if (reqsNotEmpty && sParams[j].ParameterName.ToLower().Contains("atmid"))
                            {
                                cmd.Parameters.Add(new SqlParameter(sParams[j].ParameterName, sParams[j].SqlDbType) { Value = temp });
                                //cmd.Parameters[j].Value = temp;
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter(sParams[j].ParameterName, sParams[j].SqlDbType) { Value = sParams[j].Value });
                                //cmd.Parameters.Add(new SqlParameter(sParams[j].ParameterName, sParams[j].SqlDbType));
                                //cmd.Parameters[j].Value = sParams[j].Value;
                            }
                        }
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        cmd.Connection.Close();
                        connection.Close();

                        //Store in cache
                        //var cacheEntryOptions = new MemoryCacheEntryOptions()
                        //        .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                        //        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                        //        .SetPriority(CacheItemPriority.Normal);

                        //_cache?.Set(cacheKeyHash, ds, cacheEntryOptions);
                        ServerMemoryCache.SetMemoryCache(cacheKeyHash, ds);

                        return ds.Tables[0];
                    });
                    }
                    task.Start();
                    tasks.Add(task);
                    if (RaiseCustomEvent != null)
                    {
                        while (tasks.Any())
                        {
                            Task<Task<DataTable>> taskReponse = System.Threading.Tasks.Task.WhenAny(tasks);
                            if (taskReponse.Status == TaskStatus.RanToCompletion)
                            {
                                RaiseCustomEvent(this, new CustomEventArgs(taskReponse.Exception, taskReponse.Result.Result));
                                tasks.Remove(taskReponse.Result);
                            }
                        }
                    }
                    else
                        System.Threading.Tasks.Task.WaitAll(tasks.ToArray(), 30000);
                }
                catch (Exception ex)
                {
                    LogableTask.LogMonoActivityTask("Executor", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);

                    if (RaiseCustomEvent != null)
                        RaiseCustomEvent(this, new CustomEventArgs(ex, new DataTable()));

                    int ind = tasks.FindIndex(s => s == task);
                    if (ind != -1)
                        tasks[ind] = System.Threading.Tasks.Task.FromException<DataTable>(ex);
                }
            }
            if (RaiseCustomEvent != null && (tasks is null || tasks.Count == 0) && requestsInfo.All(x => x.Length == 0))
            {
                RaiseCustomEvent(this, new CustomEventArgs(new NullReferenceException("AtmId/s do not exist in system"), new DataTable()));
            }

            return tasks;
        }

        public List<Task<DataSet>> GetDataSets(List<string> requestsInfo, List<DBServerInfo> servers, string sp, SqlParameter[] sParams, bool readFromCache = true)
        {
            LogableTask.LogMonoActivityTask("GetDataSets", MethodBase.GetCurrentMethod(), TraceLevel.Info, "sp=[" + sp + "]");

            //List<string> ids = new List<string>();
            List<Task<DataSet>> tasks = new List<Task<DataSet>>();
            bool reqsNotEmpty = requestsInfo.Any(r => !string.IsNullOrEmpty(r));

            //parameter values for cache key
            string spParamsText = string.Empty;
            for (int k = 0; k < sParams.Length; k++)
            {
                spParamsText += sParams[k].ParameterName + ":" + sParams[k].Value.ToString();
            }

            // multiple requests
            for (int i = 0; i < requestsInfo.Count; i++)
            {
                if (requestsInfo[i].Length == 0)
                    continue;

                Task<DataSet> task = null;

                try
                {
                    //if (reqsNotEmpty && string.IsNullOrEmpty(requestsInfo[i]))
                    //{
                    //    tasks.Add(Task.FromException<DataTable>(new Exception("No matching records found for processing...")));
                    //    continue;
                    //}

                    // Generate key: Hash( {ServerName_SPName_Paramerater.Values} );
                    string cacheKey = servers[i].ServerName + "_" + sp + "_" + spParamsText;
                    string cacheKeyHash = cacheKey.GetHashCode().ToString();
                    DataSet dataSet = new DataSet();

                    //Search data in cache for server[i]
                    if (readFromCache && _cache != null && _cache.TryGetValue(cacheKeyHash, out dataSet))
                    {
                        task = new Task<DataSet>(() =>
                        {
                            DataSet ds = _cache.Get<DataSet>(cacheKeyHash);
                            return ds;
                        });
                    }
                    //Search data in database and store in cache
                    else
                    {
                        string temp = string.Empty;
                        temp = new string(requestsInfo[i].TrimEnd(',').ToCharArray());
                        DBServerInfo server = new DBServerInfo
                        {
                            ServerConnection = servers[i].ServerConnection,
                            ServerCredentials = servers[i].ServerCredentials
                        };
                        string connStr = Cryptic.DecryptString(server.ServerConnection, Helper.ConstractKey(false)).TrimEnd('\0') + Cryptic.DecryptString(server.ServerCredentials, Helper.ConstractKey(false)).TrimEnd('\0');

                        task = new Task<DataSet>(() =>
                        {
                            //if (requestsInfo[i].Length == 0)
                            //    throw new Exception("No matching records found for processing....");

                            SqlConnection connection = new SqlConnection(connStr);

                            connection.Open();
                            SqlCommand cmd = connection.CreateCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = sp;
                            for (int j = 0; j < sParams.Count(); j++)
                            {
                                if (reqsNotEmpty && sParams[j].ParameterName.ToLower().Contains("atmid"))
                                {
                                    cmd.Parameters.Add(new SqlParameter(sParams[j].ParameterName, sParams[j].SqlDbType) { Value = temp });
                                    //cmd.Parameters[j].Value = temp;
                                }
                                else
                                {
                                    cmd.Parameters.Add(new SqlParameter(sParams[j].ParameterName, sParams[j].SqlDbType) { Value = sParams[j].Value });
                                    //cmd.Parameters.Add(new SqlParameter(sParams[j].ParameterName, sParams[j].SqlDbType));
                                    //cmd.Parameters[j].Value = sParams[j].Value;
                                }
                            }
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            cmd.Connection.Close();
                            connection.Close();

                            //Store in cache
                            //var cacheEntryOptions = new MemoryCacheEntryOptions()
                            //        .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                            //        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                            //        .SetPriority(CacheItemPriority.Normal);

                            //_cache?.Set(cacheKeyHash, ds, cacheEntryOptions);
                            ServerMemoryCache.SetMemoryCache(cacheKeyHash, ds);

                            return ds;
                        });
                    }
                    task.Start();
                    tasks.Add(task);

                    if (RaiseCustomEvent != null)
                    {
                        while (tasks.Any())
                        {
                            Task<Task<DataSet>> taskReponse = System.Threading.Tasks.Task.WhenAny(tasks);
                            if (taskReponse.Status == TaskStatus.RanToCompletion)
                            {
                                RaiseCustomEvent(this, new CustomEventArgs(taskReponse.Exception, taskReponse.Result.Result));
                                tasks.Remove(taskReponse.Result);
                            }
                        }
                    }
                    else
                        System.Threading.Tasks.Task.WaitAll(tasks.ToArray(), 30000);

                }
                catch (Exception ex)
                {
                    LogableTask.LogMonoActivityTask("Executor", MethodBase.GetCurrentMethod(), TraceLevel.Error, ex);

                    if (RaiseCustomEvent != null)
                        RaiseCustomEvent(this, new CustomEventArgs(ex, new DataSet()));

                    int ind = tasks.FindIndex(s => s == task);
                    if (ind != -1)
                        tasks[ind] = System.Threading.Tasks.Task.FromException<DataSet>(ex);
                }
            }

            if (RaiseCustomEvent != null && (tasks is null || tasks.Count == 0) && requestsInfo.All(x => x.Length == 0))
            {
                RaiseCustomEvent(this, new CustomEventArgs(new NullReferenceException("AtmId/s do not exist in system"), new DataSet()));
            }

            return tasks;
        }

        public T ExecuteScalarRequest<T>(string spName, SqlParameter[] spParams)
        {
            return default(T);
        }
        public T ExecuteNonQueryRequest<T>(string spName, SqlParameter[] spParams)
        {
            return default(T);
        }
        public static async Task<DataTable> GetDataTable(string requestsInfo, DBServerInfo server, string sp, SqlParameter[] sParams)
        {
            Executor executor = new Executor();
            var tasks = executor.GetDataSets(new List<string> { requestsInfo }, new List<DBServerInfo> { server }, sp, sParams);

            if (tasks.Count > 0)
            {
                return (await tasks[0]).Tables[0];
            }

            return null;
        }

    }
}
