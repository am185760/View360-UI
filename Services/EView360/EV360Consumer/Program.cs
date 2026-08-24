using System.ServiceProcess;
using System.Threading;

namespace EV360Consumer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            //EV360Consumer stl = new EV360Consumer();
            //stl.OnDebug();
            //Thread.Sleep(System.Threading.Timeout.Infinite);


            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] { new EV360Consumer() };
            ServiceBase.Run(ServicesToRun);
        }
    }
}