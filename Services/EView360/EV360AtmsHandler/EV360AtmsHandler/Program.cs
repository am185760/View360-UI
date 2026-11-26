using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace EV360AtmsHandler
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //#if DEBUG
            //EV360AtmHandler service = new EV360AtmHandler();
            //service.OnDebug();
            //System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            //#else

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new EV360AtmHandler()
            };
            ServiceBase.Run(ServicesToRun);


        }

    }
}
