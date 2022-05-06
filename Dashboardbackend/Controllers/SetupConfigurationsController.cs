using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dashboardbackend.Data;
using Dashboardbackend.Models;
using Dashboardbackend.Data.ConfigurationRepo;

namespace Dashboardbackend.Controllers
{
    [Route("api/setupConfigurationController")]
    [ApiController]
    public class SetupConfigurationsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IConfigurationRepository _repository;

        public SetupConfigurationsController(IConfigurationRepository repository)
        {
            _repository = repository;
        }

        // GET: api/SetupConfigurations
        [HttpGet]
        public ActionResult<IEnumerable<SetupConfiguration>> GetsetupConfigurations()
        {
            var configurations = _repository.GetAllConfigurations();
            return Ok(configurations);
        }

        // GET: api/SetupConfigurations/5
        [HttpGet("{id}")]
        public ActionResult<SetupConfiguration> GetSetupConfiguration(int id)
        {
            var setupConfiguration = _repository.GetConfigurationById(id);

            if (setupConfiguration != null)
            {
                return Ok(setupConfiguration);
            }

            return NotFound();
        }
    }
}
