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
            ILogger<OrganizationController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public DataResult<IEnumerable<OrganizationViewModel>> Get()
        {
            try
            {
                var result = _service.GetAll();
                return result.CreateWithMap(list => list
                    .Select(x => new OrganizationViewModel(x)));
            }
            catch (Exception ex)
            {
                return Result.CreateErrorResult<DataResult<IEnumerable<OrganizationViewModel>>>(new Error(ErrorCode.ExceptionThrown, ex, null));
            }
        }

        [HttpGet("{id}")]
        public DataResult<OrganizationViewModel> Get(int id)
        {
            var result = _service.Get(id);
            return result.CreateWithMap(
                item => new OrganizationViewModel(item));
        }
    }
}
