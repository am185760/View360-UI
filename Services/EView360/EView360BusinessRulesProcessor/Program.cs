using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace View360BusinessRulesProcessor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
   .UseWindowsService(config =>
   {
       config.ServiceName = "EV360BusinessRulesProcessor";
   })
   .ConfigureServices(services =>
   {
       services.AddHostedService<EV360BusinessRulesProcessor>();
   })
   //.ConfigureAppConfiguration(b => {
   //    b.AddJsonFile("appsettings.json");
   //}
   //)
   .Build();

            host.Run();


        }
    }
}
