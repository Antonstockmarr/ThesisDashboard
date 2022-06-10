using System;
using System.Collections.Generic;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
	public interface IToolService
	{
		bool ToolExists(int toolId);

        bool ToolsExists(IEnumerable<int> toolIds);

        Tool GetToolById(int id);

        public IEnumerable<Tool> GetTools();

        IEnumerable<Tool> GetToolsByConfigurationId(int configurationId);
    }
}

