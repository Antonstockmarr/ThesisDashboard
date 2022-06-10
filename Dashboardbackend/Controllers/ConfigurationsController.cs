using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Models;
using Dashboardbackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dashboardbackend.Controllers
{
    [Route("api/configurations")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IApproachService _approachService;
        private readonly IConfigurationService _configurationService;
        private readonly IMapper _mapper;


        public ConfigurationsController(
            IApproachService appraochService,
            IConfigurationService configurationService,
            IMapper mapper
        )
        {
            _approachService = appraochService;
            _configurationService = configurationService;
            _mapper = mapper;
        }

        // GET: api/Configuration
        [HttpGet]
        public ActionResult<IEnumerable<Configuration>> GetConfiguration([FromQuery][BindRequired] List<int> approachIds)
        {
            if (!_approachService.ApproachesExists(approachIds))
            {
                return NotFound();
            }

            try
            {
                var configuration = _configurationService.GetConfigurationFromApproachIds(approachIds);
                return configuration == null
                    ? NotFound()
                    : Ok(_mapper.Map<ConfigurationReadDto>(configuration));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }
    }
}
