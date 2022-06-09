using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Models;
using Dashboardbackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dashboardbackend.Controllers
{
    [Route("api/configuration")]
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
        public ActionResult<IEnumerable<Configuration>> Getconfiguration([FromQuery] List<int> approachIds)
        {
            if (!approachIds.Any())
            {
                return BadRequest();
            }

            if (!_approachService.ApproachesExists(approachIds))
            {
                return NotFound();
            }

            try
            {
                var configuration = _configurationService.GetConfigurationFromApproachIds(approachIds);
                Console.WriteLine(configuration);
                return configuration == null
                    ? NotFound()
                    : Ok(_mapper.Map<ConfigurationReadDto>(configuration));
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
