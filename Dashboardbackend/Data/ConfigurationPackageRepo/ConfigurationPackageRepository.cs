using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dashboardbackend.Data.ConfigurationPackageRepo
{
    public class ConfigurationPackageRepository : IConfigurationPackageRepository
    {
        private readonly ApplicationContext _context;
        public ConfigurationPackageRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<ConfigurationPackage> GetAllConfigurationPackages()
        {
            return _context.configurationPackages.ToList();
        }

        public ConfigurationPackage GetConfigurationPackageById(int id)
        {
            return _context.configurationPackages.FirstOrDefault(c => c.Id == id);
        }
    }
}
