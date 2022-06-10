using System;
using System.Collections.Generic;
using System.Linq;
using Dashboardbackend.Data.ApproachToolRepo;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
	public class ApproachToolService : IApproachToolService
	{
        private readonly IApproachToolRepository _approachToolRepository;

        public ApproachToolService(IApproachToolRepository approachToolRepository)
        {
            _approachToolRepository = approachToolRepository;
        }

        public ApproachTool GetApproachToolById(int id)
        {
            return _approachToolRepository.GetApproachToolById(id);
        }

        public IEnumerable<ApproachTool> GetApproachTools()
        {
            return _approachToolRepository.GetAllApproachTools();
        }
    }
}

