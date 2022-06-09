using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dashboardbackend.Data;
using Dashboardbackend.Models;
using Dashboardbackend.Data.ApproachRepo;
using Dashboardbackend.Services;
using System.Linq;
using Dashboardbackend.Data.ConfigurationRepo;
using Dashboardbackend.Data.ConfigurationPackageRepo;
using Dashboardbackend.Dtos;
using AutoMapper;

namespace Dashboardbackend.Controllers
{
    [Route("api/setupConfiguration")]
    [ApiController]
    public class SetupConfigurationsController : ControllerBase
    {
        private readonly IApproachRepository _approachRepository;
        private readonly IConfigurationRepository _configurationRepository;
        private readonly ISolutionService _solutionService;
        private readonly IConfigurationPackageRepository _configurationPackageRepository;
        private readonly IMapper _mapper;


        public SetupConfigurationsController(
            IApproachRepository appraochRepository,
            IConfigurationRepository configurationRepository,
            IConfigurationPackageRepository configurationPackageRepository,
            ISolutionService solutionService,
            IMapper mapper
        )
        {
            _approachRepository = appraochRepository;
            _configurationRepository = configurationRepository;
            _configurationPackageRepository = configurationPackageRepository;
            _solutionService = solutionService;
            _mapper = mapper;
        }

        // GET: api/SetupConfiguration
        [HttpGet]
        public ActionResult<IEnumerable<SetupConfiguration>> GetsetupConfiguration([FromQuery] List<int> approachIds)
        {
            if (!approachIds.Any())
            {
                return BadRequest();
            }
            List<Approach> approaches = new List<Approach>();
            foreach (int id in approachIds)
            {
                Approach approach = _approachRepository.GetApproachByID(id);
                if (approach is null)
                {
                    return NotFound();
                }
                else
                {
                    if (!approaches.Any(a => a.Id == approach.Id))
                        approaches.Add(approach);
                }
            }
            List<ApproachTool> solution = _solutionService.ComputeSolution(approaches);

            IEnumerable<SetupConfiguration> configurations = _configurationRepository.GetAllConfigurations();
            IEnumerable<ConfigurationPackage> configurationPackages = _configurationPackageRepository.GetAllConfigurationPackages();

            foreach (SetupConfiguration configuration in configurations)
            {
                IEnumerable<int> approachToolIds = from configurationPackage in configurationPackages
                                                          where configurationPackage.SetupConfigurationId == configuration.Id
                                                          select configurationPackage.ApproachToolId;
                if (!approachToolIds.Any())
                {
                    // Database in incomplete
                    return StatusCode(500);
                }

                if (ApproachToolsMatchesSolution(approachToolIds, solution))
                {
                    return Ok(_mapper.Map<SetupConfigurationReadDto>(configuration));
                }
            }
            return NotFound();
        }

        private static bool ApproachToolsMatchesSolution(IEnumerable<int> approachToolIds, List<ApproachTool> solution)
        {
            return approachToolIds.All(solution.ConvertAll(approachTool => approachTool.Id).Contains) && approachToolIds.Count() == solution.Count();
        }
    }
}
