using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboardbackend.Models;
using Dashboardbackend.Data;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboardbackend.Controllers
{
    [Route("api/focusAreas")]
    [ApiController]
    public class FocusAreaController : ControllerBase
    {
        private readonly IfocusAreaRepository _repository;

        public FocusAreaController(IfocusAreaRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<FocusAreaController>
        [HttpGet]
        public ActionResult <IEnumerable<FocusArea>> GetAllFocusArea()
        {
            var focusAreas = _repository.GetFocusAreas();
            return Ok(focusAreas);
        }

        // GET api/<FocusAreaController>/5
        [HttpGet("{id}")]
        public ActionResult <FocusArea> GetFocusAreaById(int id)
        {
            var FocusArea = _repository.GetFocusAreaById(id);
            return Ok(FocusArea);
        }

        // POST api/<FocusAreaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FocusAreaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FocusAreaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
