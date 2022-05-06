using System.Collections.Generic;
using Dashboardbackend.Models;

namespace Dashboardbackend.Data.ConfigurationPackageRepo
{
    public interface IConfigurationPackageRepository
    {
        IEnumerable<ConfigurationPackage> GetAllConfigurationPackages();
        ConfigurationPackage GetConfigurationPackageById(int id);
    }
}