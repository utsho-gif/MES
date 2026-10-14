using Microsoft.AspNetCore.Mvc;

namespace MES.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetIp()
        {
            string remoteIpAddress = HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? "127.0.0.1";
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                remoteIpAddress = Request.Headers["X-Forwarded-For"];
            return remoteIpAddress;
        }
    }
}
