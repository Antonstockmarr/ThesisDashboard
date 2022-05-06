using Dashboardbackend.Models;
using System.Collections.Generic;
using System.Linq;

namespace Dashboardbackend.Data.ApproachRepo
{
    public class ApproachRepository : IApproachRepository
    {
        private readonly ApplicationContext _context;
        public ApproachRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Approach> GetAllApproach()
        {
            return _context.Approaches.ToList();
        }

        public Approach GetApproachByID(int ID)
        {
            return _context.Approaches.FirstOrDefault(p => p.Id == ID);
        }
    }
}
