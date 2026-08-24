using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace Avanza.CCMS
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            //EView360CashDataParser stl = new EView360CashDataParser();
            //stl.OnDebug();
            //Thread.Sleep(System.Threading.Timeout.Infinite);


            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new EView360CashDataParser()
            };
            ServiceBase.Run(ServicesToRun);

            //#endif

            //    IHost host = Host.CreateDefaultBuilder(args)
            //.UseWindowsService(config =>
            //{
            //    config.ServiceName = "EV360 Cash Data Parser";
            //})
            //.ConfigureServices(services =>
            //{
            //    services.AddHostedService<EView360CashDataParser>();
            //})
            ////.ConfigureAppConfiguration(b => {
            ////    b.AddJsonFile("appsettings.json");
            ////}
            ////)
            //.Build();

            //    host.Run();
            //    ServiceBase[] ServicesToRun;

            //    // More than one user Service may run within the same process. To add
            //    // another service to this process, change the following line to
            //    // create a second service object. For example,
            //    //
            //    //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
            //    //
            //    ServicesToRun = new ServiceBase[] { new EView360CashDataParser() };

            //    ServiceBase.Run(ServicesToRun);
        }
    }
}