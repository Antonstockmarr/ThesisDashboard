using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Data
{
    public class focusAreaRepository : IfocusAreaRepository 
    {
        public FocusArea GetFocusAreaById(int id)
        {
            return new FocusArea { Id = 0, name = "UX", Description = "something cool" };
        }

        public IEnumerable<FocusArea> GetFocusAreas()
        {
            var focusAreas = new List<FocusArea>
            {
               new FocusArea { Id = 0, name = "UX", Description = "something cool0" },
               new FocusArea { Id = 1, name = "resource", Description = "something cool1" },
               new FocusArea { Id = 2, name = "Incident", Description = "something cool2" },
        };
            return focusAreas;
    }
    }
}
