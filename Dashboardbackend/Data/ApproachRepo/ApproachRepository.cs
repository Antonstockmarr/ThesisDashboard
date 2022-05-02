using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Data.ApproachRepo
{
    public class ApproachRepository : IApproachRepository
    {
        private readonly ApplicationContext _context;
        public ApproachRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Approach> getAllApproach()
        {
            return _context.approaches.ToList();
        }

        public Approach getApproachByID(int ID)
        {
            return _context.approaches.FirstOrDefault(p => p.Id == ID);
        }
    }
}
