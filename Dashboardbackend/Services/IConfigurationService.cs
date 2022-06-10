using System;
using System.Collections.Generic;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
	public interface IConfigurationService
	{
        bool ConfigurationExists(int configurationId);
        Configuration GetConfigurationFromApproachIds(IEnumerable<int> approachIds);
        Configuration GetConfigurationFromApproachToolIds(IEnumerable<int> approachToolIds);
        IEnumerable<Configuration> GetConfigurations();
    }
}

