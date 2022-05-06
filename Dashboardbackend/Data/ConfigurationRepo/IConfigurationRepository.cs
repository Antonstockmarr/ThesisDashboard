using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Data.ConfigurationRepo
{
    public interface IConfigurationRepository
    {
        IEnumerable<SetupConfiguration> GetAllConfigurations();
        SetupConfiguration GetConfigurationById(int id);
    }
}
