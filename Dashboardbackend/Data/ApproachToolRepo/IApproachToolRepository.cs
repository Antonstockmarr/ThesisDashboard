using Dashboardbackend.Models;
using System.Collections.Generic;

namespace Dashboardbackend.Data.ApproachToolRepo
{
    public interface IApproachToolRepository
    {
        IEnumerable<ApproachTool> GetAllApproachTools();
        ApproachTool GetApproachToolById(int id);
    }
}
