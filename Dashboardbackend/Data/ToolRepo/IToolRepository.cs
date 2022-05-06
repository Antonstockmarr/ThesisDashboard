using Dashboardbackend.Models;
using System.Collections.Generic;

namespace Dashboardbackend.Data.ToolRepo
{
    public interface IToolRepository
    {
        public Tool GetToolById(int id);

        public IEnumerable<Tool> GetAllTools();
    }
}
