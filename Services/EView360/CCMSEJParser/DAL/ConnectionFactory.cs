using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace Avanza.iSuite.DAL
{
    public enum Database
    {
        SqlServer2000,
        unknown
    }

    public interface ISaveAble
    {
        void Save();
        string SaveQuery
        {
            get;
        }
    }
    interface IEntityReader
    {
        bool IsClosed { get;}
        int Depth { get;}
        int FieldCount { get;}
        //        object Current { get;}
        void Close();
        bool Read();
    }

    public class ConnectionFactory
    {
        static int max_id;
        static int next_id = 0;
        static int incrementValue = 100;

        static int max_id_ref;
        static int next_id_ref = 0;
        static int incrementValue_ref = 100;

        public static string connectionString;

        /// <summary>
        /// eg eg System.Data.SqlClient.SqlConnection, System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
        /// </summary>
        /// <param name="className">eg System.Data.SqlClient.SqlConnection, System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
        /// it must have a public conctructor receiving connectionString as parameter</param>
        /// <param name="connectionString">a valid connection string to be user for every conection </param>
        public static void Initialize(string connectionString, bool testConnection)
        {
            ConnectionFactory.connectionString = connectionString;
            if (testConnection)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                conn.Close();
            }
        }

        
        public static int GetNextId()
        {
            if (next_id == 0 || (next_id == max_id - 1))
            {
                SqlCommand cmd = ConnectionFactory.GetNewCommand(true);

                cmd.CommandText = "select nextid from token;update token set nextid = nextid +" + incrementValue;
                next_id = (int)cmd.ExecuteScalar();
                max_id = incrementValue + next_id;
                cmd.Connection.Close();
                return next_id;
            }
            else
            {
                return ++next_id;
            }
        }


        public static int GetNextReferenceId()
        {
            if (next_id_ref == 0 || (next_id_ref == max_id_ref - 1))
            {
                SqlCommand cmd = ConnectionFactory.GetNewCommand(true);

                cmd.CommandText = "select sms_task_reference_no from token;update token set sms_task_reference_no = sms_task_reference_no +" + incrementValue_ref;
                next_id_ref = (int)cmd.ExecuteScalar();
                max_id_ref = incrementValue_ref + next_id_ref;
                cmd.Connection.Close();
                return next_id_ref;
            }
            else
            {
                return ++next_id_ref;
            }
        }



        /// <summary>
        /// to get new connection you have to open connection and close by your self
        /// </summary>
        /// <returns><see cref="IDbConnection"/></returns>
        public static SqlConnection GetNewConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static SqlCommand GetNewCommand(bool openConnection)
        {
            SqlConnection con = new SqlConnection(connectionString);
            if (openConnection)
                con.Open();
            return con.CreateCommand();
        }

        public static object ExecuteScalar(string query)
        {
            SqlCommand dbCmd = GetNewConnection().CreateCommand();
            try
            {
                dbCmd.Connection.Open();
                dbCmd.CommandText = query;
                return dbCmd.ExecuteScalar();
            }
            //catch (Exception ex)
            //{
            //    throw new Exception("", ex);
            //}
            finally
            {
                if (dbCmd.Connection != null)
                    dbCmd.Connection.Close();
            }

        }
        public static object ExecuteScalar(string query, SqlTransaction trx)
        {
            SqlCommand dbCmd = trx.Connection.CreateCommand();
            dbCmd.Transaction = trx;
            dbCmd.CommandText = query;
            return dbCmd.ExecuteScalar();
        }

        public static void ExecuteQuery(string query)
        {
            SqlCommand dbCmd = GetNewConnection().CreateCommand();
            try
            {
                dbCmd.Connection.Open();
                dbCmd.CommandText = query;
                dbCmd.ExecuteNonQuery();
            }
            //catch (Exception ex)
            //{
            //    throw new Exception("", ex);
            //}
            finally
            {
                if (dbCmd.Connection != null)
                    dbCmd.Connection.Close();
            }
        }


        public static void ExecuteQuery(string query, SqlTransaction trx)
        {
            SqlCommand dbCmd = trx.Connection.CreateCommand();
            dbCmd.CommandText = query;
            dbCmd.Transaction = trx;
            dbCmd.ExecuteNonQuery();
        }
    }

    public class BufferedDBSerializer
    {
        static System.Collections.Generic.Queue<ISaveAble> queue = new Queue<ISaveAble>(50);
        static BufferedDBSerializer _instance;

        /// <summary>
        /// this function is intended to be used only for less important information to be saved to db b/c of 
        /// difficulty in keeping tace what has been saved and what not
        /// to ensure serialization call flush, by default flush is called when queue size reaches 50 items
        /// </summary>
        /// <param name="obj"></param>
        public void Add(ISaveAble obj)
        {
            lock (BufferedDBSerializer.Instance)
            {
                queue.Enqueue(obj);
                if (queue.Count >= 50)
                    Flush();
            }
        }
        public static BufferedDBSerializer Instance
        {
            get { return _instance; }
        }

        public void Flush()
        {
            StringBuilder aggregatedQuery = new StringBuilder(1000);
            while (queue.Count > 0)
                aggregatedQuery.Append(((ISaveAble)queue.Dequeue()).SaveQuery);
            ConnectionFactory.ExecuteQuery(aggregatedQuery.ToString());
        }

    }
}