using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRequestor
{
    public class DataSetResult
    {
        public DataSet DataSet { set; get; }
        public string ExceptionMessage { set; get; }

        public DataSetResult(DataSet ds, string result)
        {
            this.DataSet = ds;
            this.ExceptionMessage = result;
        }
    }
}
