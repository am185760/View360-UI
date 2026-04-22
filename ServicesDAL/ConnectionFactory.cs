using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



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
    bool IsClosed { get; }
    int Depth { get; }
    int FieldCount { get; }
    //        object Current { get;}
    void Close();
    bool Read();
}

public class ConnectionFactory
{
    public static object lockObj = new object();
    static long max_id;
    static long next_id = 0;
    static int incrementValue = 1000;

    static long max_id_ref;
    static long next_id_ref = 0;
    static int incrementValue_ref = 100;

    public static string connectionStringCash;
    public static string connectionStringTx;
    public static string connectionStringCore;

    /// <summary>
    /// eg eg System.Data.SqlClient.SqlConnection, System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
    /// </summary>
    /// <param name="className">eg System.Data.SqlClient.SqlConnection, System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
    /// it must have a public conctructor receiving connectionString as parameter</param>
    /// <param name="connectionString">a valid connection string to be user for every conection </param>
    //public static void Initialize(string[] connectionString, bool testConnection, DatabaseName dbName)
    //{
    //    string currentConnectionString = "";
    //    if (dbName.Equals(DatabaseName.Core))
    //        currentConnectionString = connectionStringCore = connectionString[0];
    //    if (dbName.Equals(DatabaseName.Cash))
    //        currentConnectionString = connectionStringCash = connectionString[1];
    //    if (dbName.Equals(DatabaseName.Tx))
    //        currentConnectionString = connectionStringTx = connectionString[2];

    //    if (testConnection)
    //    {
    //        SqlConnection conn = new SqlConnection(currentConnectionString);
    //        conn.Open();
    //        conn.Close();
    //    }
    //}
    public static void Initialize(string connectionString, bool testConnection, DatabaseName dbName)
    {
         if (dbName.Equals(DatabaseName.Core))
             connectionStringCore = connectionString;
        if (dbName.Equals(DatabaseName.Cash))
            connectionStringCash = connectionString;
        if (dbName.Equals(DatabaseName.Tx))
            connectionStringTx = connectionString;

        if (testConnection)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            conn.Close();
        }
    }


    public static long GetNextId(DatabaseName databaseName)
    {
        lock(lockObj)
        {
            if (next_id == 0 || (next_id == max_id - 1))
            {
                SqlCommand cmd = ConnectionFactory.GetNewCommand(true, databaseName);

                cmd.CommandText = "select  nextid  from token;update token set nextid = nextid +" + incrementValue;
                next_id = (long)cmd.ExecuteScalar();
                max_id = incrementValue + next_id;
                cmd.Connection.Close();
                return next_id;
            }
            else
            {
                return ++next_id;
            }
        }
    }


    public static long GetNextReferenceId(DatabaseName databaseName)
    {
        if (next_id_ref == 0 || (next_id_ref == max_id_ref - 1))
        {
            SqlCommand cmd = ConnectionFactory.GetNewCommand(true, databaseName);

            cmd.CommandText = "select  sms_task_reference_no  from token;update token set sms_task_reference_no = sms_task_reference_no +" + incrementValue_ref;
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
    public static SqlConnection GetNewConnection(DatabaseName dbName)
    {
        SqlConnection con = null;
        if (dbName.Equals(DatabaseName.Core))
            con = new SqlConnection(connectionStringCore);

        if (dbName.Equals(DatabaseName.Tx))
            con = new SqlConnection(connectionStringTx);

        if (dbName.Equals(DatabaseName.Cash))
            con = new SqlConnection(connectionStringCash);
        return con;
    }

    public static SqlCommand GetNewCommand(bool openConnection, DatabaseName dbName)
    {
        SqlConnection con = null;
        if (dbName.Equals(DatabaseName.Core))
            con = new SqlConnection(connectionStringCore);

        if (dbName.Equals(DatabaseName.Tx))
            con = new SqlConnection(connectionStringTx);

        if (dbName.Equals(DatabaseName.Cash))
            con = new SqlConnection(connectionStringCash);

        if (openConnection)
            con.Open();
        return con.CreateCommand();
    }

    public static object ExecuteScalar(string query, DatabaseName databaseName)
    {
        SqlCommand dbCmd = GetNewConnection(databaseName).CreateCommand();
        try
        {
            dbCmd.Connection.Open();
            dbCmd.CommandText = query;
            return dbCmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw new Exception("", ex);
        }
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

    public static void ExecuteQuery(string query, DatabaseName databaseName)
    {
        SqlCommand dbCmd = GetNewConnection(databaseName).CreateCommand();
        try
        {
            dbCmd.Connection.Open();
            dbCmd.CommandText = query;
            dbCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception("", ex);
        }
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
    public void Add(ISaveAble obj, DatabaseName databaseName)
    {
        lock (BufferedDBSerializer.Instance)
        {
            queue.Enqueue(obj);
            if (queue.Count >= 50)
                Flush(databaseName);
        }
    }
    public static BufferedDBSerializer Instance
    {
        get { return _instance; }
    }

    public void Flush(DatabaseName databaseName)
    {
        StringBuilder aggregatedQuery = new StringBuilder(1000);
        while (queue.Count > 0)
            aggregatedQuery.Append(((ISaveAble)queue.Dequeue()).SaveQuery);
        ConnectionFactory.ExecuteQuery(aggregatedQuery.ToString(), databaseName);
    }

}
