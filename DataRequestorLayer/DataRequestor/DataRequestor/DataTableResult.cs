using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataRequestor
{
    public class DataTableResult
    {
        public DataTable Table { set; get; }
        public string ExceptionMessage { set; get; }

        public DataTableResult(DataTable dt,string result)
        {
            this.Table = dt;
            this.ExceptionMessage = result;
        }
    }
}
