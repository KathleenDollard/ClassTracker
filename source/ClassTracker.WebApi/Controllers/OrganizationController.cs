using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KadGen.ClassTracker.Service;
using KadGen.ClassTracker.WebApi.ViewModels;
using System.Linq;
using KadGen.Common;

namespace KadGen.ClassTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrganizationController : Controller
    {
        private OrganizationService _service;

        public OrganizationController(OrganizationService service)
        {
            _service = service;
        }

        [HttpGet]
        public DataResult<IEnumerable<OrganizationViewModel>> Get()
        {
            var result = _service.GetAll();
            return result.CreateWithMap(list => list
                .Select(x => new OrganizationViewModel(x)));
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
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
