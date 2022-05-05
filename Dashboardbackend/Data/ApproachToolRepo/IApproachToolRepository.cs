using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Data.ApproachToolRepo
{
    public interface IApproachToolRepository
    {
        IEnumerable<ApproachTool> GetAllApproachTools();
        ApproachTool GetApproachToolById(int id);
    }
}
