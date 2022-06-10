using System;
using System.Collections.Generic;
using System.Linq;
using Dashboardbackend.Data.ToolRepo;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
	public class ToolService : IToolService
	{
        private readonly IToolRepository _toolRepository;
        private readonly IConfigurationPackageService _configurationPackageService;
        private readonly IApproachToolService _approachToolService;


        public ToolService(
            IToolRepository toolRepository,
            IConfigurationPackageService configurationPackageService,
            IApproachToolService approachToolService
            )
        {
            _toolRepository = toolRepository;
            _configurationPackageService = configurationPackageService;
            _approachToolService = approachToolService;
        }

        public bool ToolExists(int toolId)
        {
            return _toolRepository.GetToolById(toolId) != null;
        }

        public bool ToolsExists(IEnumerable<int> toolIds)
        {
            return toolIds.All(ToolExists);
        }

        public Tool GetToolById(int id)
        {
            return _toolRepository.GetToolById(id);
        }

        public IEnumerable<Tool> GetTools()
        {
            return _toolRepository.GetAllTools();
        }

        public IEnumerable<Tool> GetToolsByConfigurationId(int configurationId)
        {
            IEnumerable<int> approachToolIds = from configurationPackage in _configurationPackageService.GetConfigurationPackages()
                                               where configurationPackage.ConfigurationId == configurationId
                                               select configurationPackage.ApproachToolId;


            IEnumerable<int> toolIds = from toolApproach in approachToolIds
                                       select _approachToolService.GetApproachToolById(toolApproach).ToolId;

            return from toolId in toolIds.Distinct()
                   select GetToolById(toolId);
        }
    }
}

