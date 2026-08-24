using System.ServiceProcess;
using System.Threading;

namespace CCMSEJParser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //Service1 stl = new Service1();
            //stl.OnDebug();
            //Thread.Sleep(System.Threading.Timeout.Infinite);

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
   {
                                  new Service1()
   };
            ServiceBase.Run(ServicesToRun);

            //#endif
        }
    }
}
