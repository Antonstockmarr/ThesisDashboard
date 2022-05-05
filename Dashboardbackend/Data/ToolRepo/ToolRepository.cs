using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Data.ToolRepo
{
    public class ToolRepository : IToolRepository
    {
        private readonly ApplicationContext _context;
        public ToolRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Tool> GetAllTools()
        {
            return _context.tools.ToList();
        }

        public Tool GetToolById(int id)
        {
            return _context.tools.FirstOrDefault(p => p.Id == id);
        }

        // get a list of all tools with certain ID
        //public List<Tool> GetApproachById(int id)
        //{
            
        //}
    }
}
