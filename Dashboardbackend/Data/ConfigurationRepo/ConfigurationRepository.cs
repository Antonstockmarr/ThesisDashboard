using System.Collections.Generic;
using System.Linq;
using Dashboardbackend.Models;

namespace Dashboardbackend.Data.ConfigurationRepo
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ApplicationContext _context;

        public ConfigurationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Configuration> GetAllConfigurations()
        {
            return _context.configurations.ToList();
        }

        public Configuration GetConfigurationById(int id)
        {
            return _context.configurations.FirstOrDefault(p => p.Id == id);
        }
    }
}
