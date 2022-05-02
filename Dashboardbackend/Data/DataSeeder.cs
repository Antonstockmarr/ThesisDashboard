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
            if (!_context.objectives.Any() && !_context.concerns.Any() && !_context.approaches.Any())
            {
                Console.WriteLine("objectives");
                _context.AddRange(GetObjectives());
                await _context.SaveChangesAsync();
                Console.WriteLine("concerns");
                _context.AddRange(GetConcerns());
                await _context.SaveChangesAsync();
                Console.WriteLine("approaches");
                _context.AddRange(GetApproaches());
                await _context.SaveChangesAsync();
            }
        }

        private List<Objective> GetObjectives()
        {
            return new List<Objective>()
            {
                new Objective()
                {
                    Name = "obj1",
                    Description = "desc"
                },
                new Objective()
                {
                    Name = "obj2",
                    Description = "desc"
                },
            };
        }

        private List<Concern> GetConcerns()
        {
            return new List<Concern>
            {
                new Concern()
                {
                    Name = "concern1",
                    Description = "desc",
                    ObjectiveId = _context.objectives.First(objective => objective.Name == "obj1").Id
                }
            };
        }

        private List<Approach> GetApproaches()
        {
            return new List<Approach>
            {
                new Approach()
                {
                    Name = "appr1",
                    Description = "desc",
                    ImplementationDifficulty = "easy",
                    MaintenanceDifficulty = "easy",
                    ConcernId = _context.concerns.First(concern => concern.Name == "concern1").Id
                }
            };
        }
    }
}
