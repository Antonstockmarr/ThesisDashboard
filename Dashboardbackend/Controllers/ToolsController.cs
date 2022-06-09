using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboardbackend.Controllers
{
    [Route("api/Tools")]
    [ApiController]
    public class ToolsController : ControllerBase
    {

        private readonly IToolService _service;
        private readonly IMapper _mapper;

        public ToolsController(IToolService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Tools
        [HttpGet]
        public ActionResult<IEnumerable<ToolReadDto>> Getapproaches()
        {
            var tools = _service.GetTools();
            return Ok(_mapper.Map<IEnumerable<ToolReadDto>>(tools));
        }

        // GET: api/Tools/5
        [HttpGet("{id}")]
        public ActionResult<ToolReadDto> GetApproach(int id)
        {
            var tool = _service.GetToolById(id);

            if (tool != null)
            {
                return Ok(_mapper.Map<ToolReadDto>(tool));
            }

            return NotFound();
        }
    }
}
