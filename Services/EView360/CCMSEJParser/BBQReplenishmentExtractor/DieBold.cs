using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Avanza.CCMS.DAL;
using System.Data.SqlClient;

namespace NCR.CCMS.Parser
{

    public class ParserDibold
    {
        public ParserDibold()
        {
            throw new Exception("not implemented");
        }

        public ParserDibold(ref string str, int a, int b)
        {
            throw new Exception("not implemented");
        }
        public ArrayList GetTransactions()
        {
            throw new Exception("not implemented");

        }

        public void SaveTransactions()
        {
            throw new Exception("not implemented");
        }
        public void ParseAndSaveEJ(ref string formattedEJLog, Task CurrentFileDownloadInfo, LogableTask task, SqlTransaction dbTrx)
        {
            throw new Exception("not implemented");
        }


    }
}
