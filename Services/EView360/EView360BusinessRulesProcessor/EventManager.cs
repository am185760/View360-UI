
using ServicesDAL;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading;

namespace View360BusinessRulesProcessor
{
    public class EventManager
    {
        //int bucketSize = 0;
        //int startWithdrawalRowIndex = 0;
        //int startTestCashRowIndex = 0;
        //int startReplenishmentRowIndex = 0;
        //int startDepositSummaryRowIndex = 0;
        //int startBNACountsClearedRowIndex = 0;
        //int startCPMCountsClearedRowIndex = 0;
        bool isWithdrawalProcessed = false;
        EventProcessor.WithdrawalProcessor withdrawalProcessor = new EventProcessor.WithdrawalProcessor();
        EventProcessor.TestCashProcessor testCashProcessor = new EventProcessor.TestCashProcessor();
        EventProcessor.ReplenishmentProcessor replenishmentProcessor = new EventProcessor.ReplenishmentProcessor();
        EventProcessor.DepositSummaryProcessor depositProcessor = new EventProcessor.DepositSummaryProcessor();
        EventProcessor.BNACountsClearedProcessor BNACountsClearedProcessor = new EventProcessor.BNACountsClearedProcessor();
        EventProcessor.CPMCountsClearedProcessor cpmCountsClearedProcessor = new EventProcessor.CPMCountsClearedProcessor();
        
        //public Dictionary<int, List<int>> withdrawalIgnored = new Dictionary<int, List<int>>();
        //public Dictionary<int, List<int>> testCashIgnored = new Dictionary<int, List<int>>();
        //public Dictionary<int, List<int>> replenishmentIgnored = new Dictionary<int, List<int>>();
        //public Dictionary<int, List<int>> depositIgnored = new Dictionary<int, List<int>>();
        //public Dictionary<int, List<int>> BNACountsClearedIgnored = new Dictionary<int, List<int>>();
        //public Dictionary<int, List<int>> cpmCountsClearedIgnored = new Dictionary<int, List<int>>();

      

        Queue<ParserPostProcessingTask> queue = new Queue<ParserPostProcessingTask>();
        public void ExecuteWithdrawals(DataTable dtWithdrawals)
        {
            List<System.Threading.Tasks.Task> listTask = new List<System.Threading.Tasks.Task>();

            DataTable dtLocal = dtWithdrawals.Copy();
            foreach (DataRow dr in dtLocal.Rows)
            {
                ParserPostProcessingTask _parserPostProcessingTask = Utility.CreateParserPostProcessingTaskObjectFromDataRow(dr);
                queue.Enqueue(_parserPostProcessingTask);
            }
            listTask.Add(System.Threading.Tasks.Task.Factory.StartNew(() => withdrawalProcessor.Run(queue)));
            System.Threading.Tasks.Task.WaitAll(listTask.ToArray());
            isWithdrawalProcessed = true;
        }
        public void ExecuteTestCash(DataTable dtTestCash)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() => testCashProcessor.Run(dtTestCash));
        }
        public void ExecuteReplenishment(DataTable dtReplenishment)
        {
            if (dtReplenishment.Rows.Count > 0) {
                while (!isWithdrawalProcessed)
                {
                    Thread.Sleep(5000);
                    LogableTask.LogMonoActivityTask("", MethodBase.GetCurrentMethod(), System.Diagnostics.TraceLevel.Info, "waiting for withdrawal transactions to be processed:" + dtReplenishment.Rows[0]["atm_id"]);
                }
                System.Threading.Tasks.Task.Factory.StartNew(() => replenishmentProcessor.Run(dtReplenishment));
            }
        }
        public void ExecuteDepositSummary(DataTable dtDeposits)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() => depositProcessor.Run(dtDeposits));
        }
        public void ExecuteBNACountsCleared(DataTable dtBNACountsCleared)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() => BNACountsClearedProcessor.Run(dtBNACountsCleared));            
        }
        public void ExecuteCPMCountsCleared(DataTable dtCPMCountsCleared)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() => cpmCountsClearedProcessor.Run(dtCPMCountsCleared));
        }
    }
}
