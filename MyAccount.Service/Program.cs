using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using MyAccount.Service.Logging;
using MyAccount.Service.SecondService;
using System.ServiceModel;
using System.Web.Http.SelfHost;
using System.Web.Http;

namespace MyAccount.Service
{
    class Program
    {
        private static ILogger logger = LogManager.GetLogger();

        private static void Main(string[] args)
        {
            RunSecondService();
            RunFirstService();
            logger.Information("HttpSelfHostServer завершил работу");
            logger.Information("ServiceHost завершил работу");
        }

        private static void RunFirstService()
        {
            HttpSelfHostConfiguration configuration = new HttpSelfHostConfiguration("http://localhost:2222");

            configuration.Routes.MapHttpRoute(
                name: "MyService",
                routeTemplate: "import.{controller}",
                defaults: null);
            
            logger.Debug("HttpSelfHostServer создаётся");
            HttpSelfHostServer server = new HttpSelfHostServer(configuration);

            logger.Debug("HttpSelfHostServer запускаем");
            server.OpenAsync().Wait();
            logger.Information("HttpSelfHostServer запустился");
            Console.ReadLine();
        }

        private static void RunSecondService()
        {
            Type serviceType = typeof(UserInfoProvider);
            Uri uri = new Uri("http://localhost:8080/");

            logger.Debug("ServiceHost создаётся");
            ServiceHost host = new ServiceHost(serviceType, uri);
            
            logger.Debug("ServiceHost запускаем");
            host.Open();
            logger.Information("ServiceHost запустился");
        }
    }
}