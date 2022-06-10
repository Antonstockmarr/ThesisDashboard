using System.Collections.Generic;
using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Services;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboardbackend.Controllers
{
    [Route("api/objectives")]
    [ApiController]
    public class ObjectivesController : ControllerBase
    {
        private readonly IObjectiveService _service;
        private readonly IMapper _mapper;

        public ObjectivesController(IObjectiveService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/objectives
        [HttpGet]
        public ActionResult <IEnumerable<ObjectiveReadDto>> GetAllObjective()
        {
            var objectives = _service.GetObjectives();
            return Ok(_mapper.Map<IEnumerable<ObjectiveReadDto>>(objectives));
        }

        // GET api/objectives/5
        [HttpGet("{id}")]
        public ActionResult <ObjectiveReadDto> GetObjectiveById(int id)
        {
            var Objective = _service.GetObjectiveById(id);
            if (Objective != null)
            {
                return Ok(_mapper.Map<ObjectiveReadDto>(Objective));

            }

            return NotFound();
        }

    }
}
