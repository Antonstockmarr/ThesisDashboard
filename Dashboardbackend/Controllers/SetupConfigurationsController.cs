using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dashboardbackend.Data;
using Dashboardbackend.Models;
using Dashboardbackend.Data.ApproachRepo;
using Dashboardbackend.Services;
using System.Linq;
using Dashboardbackend.Data.ConfigurationRepo;
using Dashboardbackend.Data.ConfigurationPackageRepo;

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


        public SetupConfigurationsController(IApproachRepository appraochRepository, IConfigurationRepository configurationRepository, ISolutionService solutionService)
        {
            _approachRepository = appraochRepository;
            _configurationRepository = configurationRepository;
            _solutionService = solutionService;
        }

        // GET: api/SetupConfigurations
        [HttpGet]
        public ActionResult<IEnumerable<SetupConfiguration>> GetsetupConfigurations([FromQuery] List<int> approachIds)
        {
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
                if (ApproachToolsMatchesSolution(approachToolIds, solution))
                {
                    return Ok(configuration);
                }
            }
            return NotFound();
        }

        private static bool ApproachToolsMatchesSolution(IEnumerable<int> approachToolIds, List<ApproachTool> solution)
        {
            return approachToolIds.All((solution.ConvertAll(approachTool => approachTool.Id).Contains));
        }
    }
}
