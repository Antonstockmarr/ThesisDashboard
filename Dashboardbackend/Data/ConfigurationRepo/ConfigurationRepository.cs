using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Data.ConfigurationRepo
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ApplicationContext _context;

        public ConfigurationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<SetupConfiguration> GetAllConfigurations()
        {
            return _context.setupConfigurations.ToList();
        }

        public SetupConfiguration GetConfigurationById(int id)
        {
            return _context.setupConfigurations.FirstOrDefault(p => p.Id == id);
        }
    }
}
