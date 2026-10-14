using Microsoft.AspNetCore.Mvc;
using MES.Core.Response;

namespace MES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : BaseController
    {
        [HttpGet("ping")]
        public QueryResult<string> Ping()
        {
            return new QueryResult<string>
            {
                IsResult = true,
                IsSuccessful = true,
                Result = "MES API Service is running."
            };
        }
    }
}
