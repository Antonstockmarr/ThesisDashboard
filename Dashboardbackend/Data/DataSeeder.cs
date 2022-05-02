using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboardbackend.Models;

namespace Dashboardbackend.Data
{
    public class DataSeeder
    {
        private ApplicationContext _context;

        public DataSeeder(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (!_context.objectives.Any())
            {
                _context.AddRange(_objectives);
                await _context.SaveChangesAsync();
            }

            if (!_context.concerns.Any())
            {
                _context.AddRange(_concerns);
                await _context.SaveChangesAsync();
            }
            if (!_context.approaches.Any())
            {
                _context.AddRange(_approaches);
                await _context.SaveChangesAsync();
            }
        }

        List<Objective> _objectives = new List<Objective>
        {
            new Objective()
            {
                //Id = 1,
                Name = "obj1",
                Description = "desc"
            },
            new Objective()
            {
               // Id = 2,
                Name = "obj2",
                Description = "desc"
            },
        };

        List<Concern> _concerns = new List<Concern>
        {
            new Concern()
            {
                //Id = 1,
                Name = "concern1",
                Description = "desc",
                ObjectiveId = 1
            }
        };

        List<Approach> _approaches = new List<Approach>
        {
            new Approach()
            {
                //Id = 1,
                Name = "appr1",
                Description = "desc",
                ImplementationDifficulty = "easy",
                MaintenanceDifficulty = "easy",
                ConcernId = 1
            }
        };
    }
}
