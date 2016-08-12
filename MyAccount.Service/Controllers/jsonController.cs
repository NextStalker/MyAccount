using MyAccount.Service.FirstService;
using MyAccount.Service.Logging;
using Serilog;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAccount.Service.Controllers
{
    public class jsonController : ApiController
    {
        private static ILogger logger = LogManager.GetLogger();

        public void Post(SyncProfileRequest json)
        {
            SyncProfileRequestList.Instance.Add(json);
        }
    }
}
