using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace CCMSReportSchedular
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //CurrencyReportSchedular stl = new CurrencyReportSchedular();
            //stl.OnDebug();
            //Thread.Sleep(System.Threading.Timeout.Infinite);

            //#if DEBUG
            //            CurrencyReportSchedular service = new CurrencyReportSchedular();
            //            service.OnDebug();
            //            System.Threading.Thread.Sleep(System.Threading.Thread.time);
            //#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new CurrencyReportSchedular() 
			};
            ServiceBase.Run(ServicesToRun);
            }
    }
}
