using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Data.ToolRepo
{
    public interface IToolRepository
    {
        public Tool GetToolById(int id);

        public IEnumerable<Tool> GetAllTools();
    }
}
