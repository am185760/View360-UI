using System.ServiceProcess;
using System.Threading;

namespace ATM360
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            //#if DEBUG
            //EView360ATMStreaming stl = new EView360ATMStreaming();
            //stl.OnDebug();
            //Thread.Sleep(System.Threading.Timeout.Infinite);

            //#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new EView360ATMStreaming()
            };
            ServiceBase.Run(ServicesToRun);

            //#endif
        }
    }
}
