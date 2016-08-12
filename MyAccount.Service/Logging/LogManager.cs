using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;

namespace MyAccount.Service.Logging
{
    public static class LogManager
    {
        private static ILogger logger = new LoggerConfiguration()
             .MinimumLevel.Fatal()
             .WriteTo.ColoredConsole()
             .WriteTo.RollingFile(@"Log-{Date}.txt")
             .CreateLogger();

        public static ILogger GetLogger()
        {
            return logger;
        }
    }
}
