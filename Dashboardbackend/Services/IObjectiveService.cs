using System;
using System.Collections.Generic;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
	public interface IObjectiveService
	{
		bool ObjectiveExists(int approachId);

        bool ObjectivesExists(IEnumerable<int> approachIds);

        Objective GetObjectiveById(int id);

        public IEnumerable<Objective> GetObjectives();
    }
}

