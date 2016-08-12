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
            logger.Debug("Создаём HttpSelfHostConfiguration");
            HttpSelfHostConfiguration configuration = new HttpSelfHostConfiguration("http://localhost:2222");

            logger.Debug("Прописываем Routes");
            configuration.Routes.MapHttpRoute(
                name: "MyService",
                routeTemplate: "import.{controller}",
                defaults: null);
            
            logger.Debug("Создаём HttpSelfHostServer");
            HttpSelfHostServer server = new HttpSelfHostServer(configuration);

            logger.Debug("Запускаем HttpSelfHostServer");
            server.OpenAsync().Wait();
            logger.Information("HttpSelfHostServer работает");
            Console.ReadLine();

            server.CloseAsync();
        }

        private static void RunSecondService()
        {
            Type serviceType = typeof(UserInfoProvider);
            Uri uri = new Uri("http://localhost:8080/");

            logger.Debug("Создаём ServiceHost");
            ServiceHost host = new ServiceHost(serviceType, uri);
            
            logger.Debug("Запускаем ServiceHost");
            host.Open();
        }
    }
}