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
            var configuration = new List<SetupConfiguration>
            {
                new SetupConfiguration { Id= 0, ImageURL = "prometheus-grafana-conf/SystemDesignPromGraf.png", SetupURL = ".zip", MainObjective = "Maybe we dont need this", ConfigurationDescription = "nice it works" },
                new SetupConfiguration { Id= 1, ImageURL = "logstash-netdata/SystemDesignPromGraf.png", SetupURL = ".zip", MainObjective = "Maybe we dont need this", ConfigurationDescription = "nice it works" },
                new SetupConfiguration { Id= 2, ImageURL = "prometheus-grafana-conf/SystemDesignPromGraf.png", SetupURL = ".zip", MainObjective = "Maybe we dont need this", ConfigurationDescription = "nice it works" },
                new SetupConfiguration { Id= 3, ImageURL = "prometheus-grafana-conf/SystemDesignPromGraf.png", SetupURL = ".zip", MainObjective = "Maybe we dont need this", ConfigurationDescription = "nice it works" },
            };
            return configuration;

            //return _context.configurations.ToList();
        }

        public SetupConfiguration GetConfigurationById(int id)
        {
            //return _context.setupConfigurations.FirstOrDefault(p => p.Id == id);
            return new SetupConfiguration { Id = 0, ImageURL = "prometheus-grafana-conf/SystemDesignPromGraf.png", SetupURL = ".zip", MainObjective = "Maybe we dont need this", ConfigurationDescription = "nice it works" };
        }
    }
}
