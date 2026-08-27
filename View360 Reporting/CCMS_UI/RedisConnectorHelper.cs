using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using ServicesDAL;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Services.Description;

namespace CCMSUI
{
    public class RedisConnectorHelper
    {
        public class RedisCacheProvider
        {
            public static IDistributedCache GetCache()
            {
                var redisCacheOptions = new RedisCacheOptions
                {
                    Configuration = "127.0.0.1:6379",
                    ConfigurationOptions = new ConfigurationOptions()
                    {
                        EndPoints = { "127.0.0.1:6379" },
                        ConnectRetry = 3,
                        AbortOnConnectFail = false,
                        ConnectTimeout = 30000,
                        SyncTimeout = 30000,
                    }
                };

                return new RedisCache(redisCacheOptions);
            }
        }

        public static string ReadData(string key)
        {
            string value = string.Empty;
            try
            {
                IDistributedCache cache = RedisCacheProvider.GetCache();                
                byte[] cachedValue = cache.Get(key);
                return Encoding.ASCII.GetString(cachedValue);
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("ReadData", MethodBase.GetCurrentMethod(), TraceLevel.Error, "Exception at ReadData, as: " + ex.Message);
            }
            return value;
        }
        public static void RemoveData(string key) 
        {
            try 
            {
                IDistributedCache cache = RedisCacheProvider.GetCache();
                cache.Remove(key);
            }
            catch (Exception ex)
            {
                LogableTask.LogMonoActivityTask("RemoveData", MethodBase.GetCurrentMethod(), TraceLevel.Error, "Exception at RemoveData, as: " + ex.Message);
            }
        }
    }
}