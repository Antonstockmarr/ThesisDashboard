using System;
using System.Collections.Generic;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
	public interface IApproachService
	{
		bool ApproachExists(int approachId);

        bool ApproachesExists(IEnumerable<int> approachIds);

        Approach GetApproachById(int id);

        public IEnumerable<Approach> GetApproaches();
    }
}

