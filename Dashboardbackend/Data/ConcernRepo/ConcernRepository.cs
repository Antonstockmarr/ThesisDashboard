using Dashboardbackend.Models;
using System.Collections.Generic;
using System.Linq;

namespace Dashboardbackend.Data
{
    public class ConcernRepository : IConcernRepository
    {
        private readonly ApplicationContext _context;

        public ConcernRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Concern> getAllConcerns()
        {
            return _context.concerns.ToList();
        }

        public Concern getConcernByID(int ID)
        {
            return _context.concerns.FirstOrDefault(p => p.Id == ID);
        }
    }
}
