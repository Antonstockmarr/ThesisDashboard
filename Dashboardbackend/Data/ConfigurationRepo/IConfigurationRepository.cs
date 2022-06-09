using Dashboardbackend.Models;
using System.Collections.Generic;

namespace Dashboardbackend.Data.ConfigurationRepo
{
    public interface IConfigurationRepository
    {
        IEnumerable<Configuration> GetAllConfigurations();
        Configuration GetConfigurationById(int id);
    }
}
