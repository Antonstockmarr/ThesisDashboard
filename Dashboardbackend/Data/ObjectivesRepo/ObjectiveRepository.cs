using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //return new Objective { Id = 0, name = "UX", Description = "something cool" };

        }

        public IEnumerable<Objective> GetAllObjectives()
        {
            return _context.objectives.ToList();
        //    var Objectives = new List<Objective>
        //    {
        //       new Objective { Id = 0, name = "UX", Description = "something cool0" },
        //       new Objective { Id = 1, name = "resource", Description = "something cool1" },
        //       new Objective { Id = 2, name = "Incident", Description = "something cool2" },
        //};
        //    return Objectives;
        }
    }
}
