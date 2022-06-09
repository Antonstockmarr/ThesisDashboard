using Dashboardbackend.Models;
using System.Collections.Generic;
using System.Linq;

namespace Dashboardbackend.Data
{
    public class ObjectiveRepository : IObjectiveRepository 
    {
        private readonly ApplicationContext _context;
        public ObjectiveRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Objective GetObjectiveById(int id)
        {
            return _context.objectives.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Objective> GetAllObjectives()
        {
            return _context.objectives.ToList();
        }
    }
}
