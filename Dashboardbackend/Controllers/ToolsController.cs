using AutoMapper;
using Dashboardbackend.Data.ToolRepo;
using Dashboardbackend.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboardbackend.Controllers
{
    [Route("api/Tools")]
    [ApiController]
    public class ToolsController : ControllerBase
    {

        private readonly IToolRepository _repository;
        private readonly IMapper _mapper;

        public ToolsController(IToolRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Tools
        [HttpGet]
        public ActionResult<IEnumerable<ToolReadDto>> Getapproaches()
        {
            var tools = _repository.GetAllTools();
            return Ok(_mapper.Map<IEnumerable<ToolReadDto>>(tools));
        }

        // GET: api/Tools/5
        [HttpGet("{id}")]
        public ActionResult<ToolReadDto> GetApproach(int id)
        {
            var tool = _repository.GetToolById(id);

            if (tool != null)
            {
                return Ok(_mapper.Map<ApproachReadDto>(tool));
            }

            return NotFound();
        }
    }
}
