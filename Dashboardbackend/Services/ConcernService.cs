using System;
using System.Collections.Generic;
using System.Linq;
using Dashboardbackend.Data;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
	public class ConcernService : IConcernService
	{
        private readonly IConcernRepository _concernRepository;

		public ConcernService(IConcernRepository concernRepository)
		{
            _concernRepository = concernRepository;
		}

        public bool ConcernExists(int concernId)
        {
            return _concernRepository.GetConcernByID(concernId) != null;
        }

        public bool ConcernsExists(IEnumerable<int> concernIds)
        {
            return concernIds.All(ConcernExists);
        }

        public Concern GetConcernById(int id)
        {
            return _concernRepository.GetConcernByID(id);
        }

        public IEnumerable<Concern> GetConcerns()
        {
            return _concernRepository.GetAllConcerns();
        }
    }
}

