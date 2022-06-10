using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Models;
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

        private readonly IToolService _toolService;
        private readonly IConfigurationService _configurationService;
        private readonly IMapper _mapper;

        public ToolsController(IToolService toolService, IConfigurationService configurationService, IMapper mapper)
        {
            _toolService = toolService;
            _configurationService = configurationService;
            _mapper = mapper;
        }

        // GET: api/Tools
        [HttpGet]
        public ActionResult<IEnumerable<ToolReadDto>> GetTools([FromQuery] int? configurationId)
        {
            IEnumerable<Tool> tools;
            if (configurationId == null)
            {
                tools = _toolService.GetTools();
            }
            else
            {
                if (!_configurationService.ConfigurationExists(configurationId.Value))
                {
                    return NotFound();
                }
                else
                {
                    tools = _toolService.GetToolsByConfigurationId(configurationId.Value);
                }
            }
            return Ok(_mapper.Map<IEnumerable<ToolReadDto>>(tools));
        }

        // GET: api/Tools/5
        [HttpGet("{id}")]
        public ActionResult<ToolReadDto> GetToolById(int id)
        {
            var tool = _toolService.GetToolById(id);

            if (tool != null)
            {
                return Ok(_mapper.Map<ToolReadDto>(tool));
            }

            return NotFound();
        }
    }
}
