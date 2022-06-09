using System;
using System.Collections.Generic;
using System.Linq;
using Dashboardbackend.Data;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
	public class ObjectiveService : IObjectiveService
	{
        private readonly IObjectiveRepository _objectiveRepository;

		public ObjectiveService(IObjectiveRepository objectiveRepository)
		{
            _objectiveRepository = objectiveRepository;
		}

        public bool ObjectiveExists(int objectiveId)
        {
            return _objectiveRepository.GetObjectiveById(objectiveId) != null;
        }

        public bool ObjectivesExists(IEnumerable<int> objectiveIds)
        {
            return objectiveIds.All(ObjectiveExists);
        }

        public Objective GetObjectiveById(int id)
        {
            return _objectiveRepository.GetObjectiveById(id);
        }

        public IEnumerable<Objective> GetObjectives()
        {
            return _objectiveRepository.GetAllObjectives();
        }
    }
}

