using Dashboardbackend.Models;
using System.Collections.Generic;
using System.Linq;

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
    }
}
