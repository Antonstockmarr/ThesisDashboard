using System;
using System.Collections.Generic;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
    public interface ISolutionService
    {
        List<ApproachTool> ComputeSolution(List<Approach> approaches);
    }
}
