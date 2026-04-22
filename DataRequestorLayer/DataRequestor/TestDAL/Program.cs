using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRequestor
{
    class Program
    {
        static void Main(string[] args)
        {
            Executor EXEC = new Executor();
            //DateTime d = DateTime.Now;
            //long n = long.Parse(d.ToString("yyyyMMddHHmmss"));

            //DateTime dd = DateTime.ParseExact(n.ToString(), "yyyyMMddHHmmss",null);
            //TaskExecutor TE = new TaskExecutor();
            //E.PushFileContent("3.9.0.0", "counter_09022023171600_3199_1.zip", Encoding.UTF8.GetBytes("Eslam"));

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@AtmId";
            param1.SqlDbType = SqlDbType.VarChar;
            //param1.Direction = ParameterDirection.Input;
            param1.Value = "3900,3909,1500";


            DataTableResult result2 = EXEC.ExecuteDSRequest<DataTableResult>("Select * from Core.dbo.note_set_type", new List<string> { "5", "6", "1500" });

            DataTableResult result = EXEC.ExecuteDSRequest<DataTableResult>("GetAllAtms", new SqlParameter[] { param1 }, new List<string> { "3900", "3909", "1500" });
            //List<Task<DataTable>> result = EXEC.ExecuteDSRequest<List<Task<DataTable>>>("GetAllAtms", new SqlParameter[] { param1 });
        }
    }
}
