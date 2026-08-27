using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace DailyFeedGenerator
{
    internal class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
//#if DEBUG
//            DailyFeedGenerator stl = new DailyFeedGenerator();
//            stl.OnDebug();
//            Thread.Sleep(System.Threading.Timeout.Infinite);

//#else

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new DailyFeedGenerator() 
			};
            ServiceBase.Run(ServicesToRun);

//#endif

        }
    }
}
