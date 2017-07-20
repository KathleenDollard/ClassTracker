using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KadGen.ClassTracker.Service;
using KadGen.ClassTracker.WebApi.ViewModels;

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
        public IEnumerable<OrganizationViewModel> Get()
        {
            // TODO: Mapping
            return null;
            //return _service.GetOrganizations();
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
