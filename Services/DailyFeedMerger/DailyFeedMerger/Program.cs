using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DailyFeedMerger
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            //            DailyFeedMerger stl = new DailyFeedMerger();
            //            stl.OnDebug();
            //            Thread.Sleep(System.Threading.Timeout.Infinite);

            

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new DailyFeedMerger()
            };
            ServiceBase.Run(ServicesToRun);
            
        }
    }
}
