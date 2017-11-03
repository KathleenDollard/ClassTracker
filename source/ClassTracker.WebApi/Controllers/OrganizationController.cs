using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KadGen.ClassTracker.Service;
using KadGen.ClassTracker.WebApi.ViewModels;
using System.Linq;
using KadGen.Common;
using System;
using Microsoft.Extensions.Logging;

namespace KadGen.ClassTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrganizationController : Controller
    {
        private OrganizationService _service;
        private ILogger<OrganizationController> _logger;

        public OrganizationController(OrganizationService service,
            ILogger<OrganizationController> logger )
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public DataResult<IEnumerable<OrganizationViewModel>> Get()
        {
            _logger.LogInformation(LoggingEvents.GetAll, "Getting organizations");
            try
            {
                var result = _service.GetAll();
                return result.CreateWithMap(list => list
                    .Select(x => new OrganizationViewModel(x)));
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.UncaughtError, "Eeek!!! OMG! The exception wasn't caught");
                return Result.CreateErrorResult<DataResult<IEnumerable<OrganizationViewModel>>>(new Error(ErrorCode.ExceptionThrown, ex, null));
            }
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            _logger.LogInformation(LoggingEvents.GetItem, "Getting organization {Id}", id);
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
