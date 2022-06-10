using System;
using System.Collections.Generic;
using System.Linq;
using Dashboardbackend.Data.ConfigurationPackageRepo;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
	public class ConfigurationPackageService : IConfigurationPackageService
	{
		private readonly IConfigurationPackageRepository _configurationPackageRepository;

		public ConfigurationPackageService(IConfigurationPackageRepository configurationPackageRepository)
        {
			_configurationPackageRepository = configurationPackageRepository;
        }

		public IEnumerable<ConfigurationPackage> GetConfigurationPackages()
        {
			return _configurationPackageRepository.GetAllConfigurationPackages();
        }

        public IEnumerable<ConfigurationPackage> GetConfigurationPackagesWithConfigurationId(int configurationId)
        {
            return from configurationPackage in GetConfigurationPackages()
                   where configurationPackage.ConfigurationId == configurationId
                   select configurationPackage;
        }
    }
}

