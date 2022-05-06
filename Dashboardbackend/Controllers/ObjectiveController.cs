using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboardbackend.Models;
using Dashboardbackend.Data;
using AutoMapper;
using Dashboardbackend.Dtos;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboardbackend.Controllers
{
    [Route("api/Objectives")]
    [ApiController]
    public class ObjectiveController : ControllerBase
    {
        private readonly IObjectiveRepository _repository;
        private readonly IMapper _mapper;

        public ObjectiveController(IObjectiveRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Objectives
        [HttpGet]
        public ActionResult <IEnumerable<ObjectiveReadDto>> GetAllObjective()
        {
            var Objectives = _repository.GetAllObjectives();
            return Ok(_mapper.Map<IEnumerable<ObjectiveReadDto>>(Objectives));
        }

        // GET api/objectives/5
        [HttpGet("{id}")]
        public ActionResult <ObjectiveReadDto> GetObjectiveById(int id)
        {
            var Objective = _repository.GetObjectiveById(id);
            if (Objective != null)
            {
                return Ok(_mapper.Map<ObjectiveReadDto>(Objective));

            }

            return NotFound();
        }

    }
}
