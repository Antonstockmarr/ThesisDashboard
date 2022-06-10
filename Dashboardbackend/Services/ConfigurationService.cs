using System;
using System.Collections.Generic;
using System.Linq;
using Dashboardbackend.Data.ConfigurationRepo;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
	public class ConfigurationService : IConfigurationService
	{
        private readonly IApproachService _approachService;
        private readonly ISolutionService _solutionService;
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IConfigurationPackageService _configurationPackageService;

        public ConfigurationService(
            IApproachService approachService,
            ISolutionService solutionService,
            IConfigurationRepository configurationRepository,
            IConfigurationPackageService configurationPackageService
        )
		{
            _approachService = approachService;
            _solutionService = solutionService;
            _configurationRepository = configurationRepository;
            _configurationPackageService = configurationPackageService;
		}

        public bool ConfigurationExists(int configurationId)
        {
            return _configurationRepository.GetConfigurationById(configurationId) != null;
        }

        public Configuration GetConfigurationFromApproachIds(IEnumerable<int> approachIds)
        {
            if (!_approachService.ApproachesExists(approachIds))
            {
                throw new Exception("approaches does not exist");
            }

            List<Approach> approaches = (from id in approachIds
                                            select _approachService.GetApproachById(id)
                                        ).ToList();

            
            List<ApproachTool> solution = _solutionService.ComputeSolution(approaches);

            return GetConfigurationFromApproachToolIds(solution.ConvertAll(approachTool => approachTool.Id));
        }

        public Configuration GetConfigurationFromApproachToolIds(IEnumerable<int> approachToolIds)
        {
            IEnumerable<Configuration> configurations = GetConfigurations();
            return configurations.FirstOrDefault(configuration => ConfigurationMatchesApproachTools(approachToolIds, configuration));
        }

        public IEnumerable<Configuration> GetConfigurations()
        {
            return _configurationRepository.GetAllConfigurations();
        } 

        private bool ConfigurationMatchesApproachTools(IEnumerable<int> approachToolIds, Configuration configuration)
        {
            IEnumerable<ConfigurationPackage> configurationPackages = _configurationPackageService.GetConfigurationPackagesWithConfigurationId(configuration.Id);
            IEnumerable<int> configurationApproachToolIds = from configurationPackage in configurationPackages
                                                            select configurationPackage.ApproachToolId;

            return CollectionEqual(approachToolIds, configurationApproachToolIds);
        }

        private bool CollectionEqual(IEnumerable<int> e1, IEnumerable<int> e2)
        {
            return e1.All(e2.Contains)
                && e2.All(e1.Contains)
                && e1.Count() == e2.Count();
        }
    }
}

