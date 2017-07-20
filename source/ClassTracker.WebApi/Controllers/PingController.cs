using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace KadGen.ClassTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
