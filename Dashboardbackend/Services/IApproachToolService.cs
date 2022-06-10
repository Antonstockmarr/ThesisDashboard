using System;
using System.Collections.Generic;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
	public interface IApproachToolService
	{
        ApproachTool GetApproachToolById(int id);

        public IEnumerable<ApproachTool> GetApproachTools();
    }
}

