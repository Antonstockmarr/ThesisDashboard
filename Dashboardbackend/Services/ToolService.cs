using System;
using System.Collections.Generic;
using System.Linq;
using Dashboardbackend.Data.ToolRepo;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
	public class ToolService : IToolService
	{
        private readonly IToolRepository _toolRepository;

        public bool ToolExists(int toolId)
        {
            return _toolRepository.GetToolById(toolId) != null;
        }

        public bool ToolsExists(IEnumerable<int> toolIds)
        {
            return toolIds.All(ToolExists);
        }

        public ToolService(IToolRepository toolRepository)
		{
            _toolRepository = toolRepository;
		}

        public Tool GetToolById(int id)
        {
            return _toolRepository.GetToolById(id);
        }

        public IEnumerable<Tool> GetTools()
        {
            return _toolRepository.GetAllTools();
        }
    }
}

