using System;
using System.Collections.Generic;
using System.Linq;
using Dashboardbackend.Data.ApproachRepo;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
	public class ApproachService : IApproachService
	{
        private readonly IApproachRepository _approachRepository;

		public ApproachService(IApproachRepository approachRepository)
		{
            _approachRepository = approachRepository;
		}

        public bool ApproachExists(int approachId)
        {
            return _approachRepository.GetApproachByID(approachId) != null;
        }

        public bool ApproachesExists(IEnumerable<int> approachIds)
        {
            return approachIds.All(ApproachExists);
        }

        public Approach GetApproachById(int id)
        {
            return _approachRepository.GetApproachByID(id);
        }

        public IEnumerable<Approach> GetApproaches()
        {
            return _approachRepository.GetAllApproach();
        }
    }
}

