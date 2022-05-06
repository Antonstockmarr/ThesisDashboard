using Dashboardbackend.Models;
using System.Collections.Generic;
using System.Linq;

namespace Dashboardbackend.Data.ApproachToolRepo
{
    public class ApproachToolRepository : IApproachToolRepository
    {
        private readonly ApplicationContext _context;
        public ApproachToolRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<ApproachTool> GetAllApproachTools()
        {
            return _context.approachTools.ToList();
        }

        public ApproachTool GetApproachToolById(int id)
        {
            return _context.approachTools.FirstOrDefault(p => p.Id == id);
        }
    }
}

