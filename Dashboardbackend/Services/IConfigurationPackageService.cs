using System;
using System.Collections.Generic;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
	public interface IConfigurationPackageService
	{
		IEnumerable<ConfigurationPackage> GetConfigurationPackages();

		IEnumerable<ConfigurationPackage> GetConfigurationPackagesWithConfigurationId(int configurationId);
	}
}

