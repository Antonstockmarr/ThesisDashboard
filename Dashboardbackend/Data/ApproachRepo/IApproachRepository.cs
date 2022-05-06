using Dashboardbackend.Models;
using System.Collections.Generic;

namespace Dashboardbackend.Data.ApproachRepo
{
    public interface IApproachRepository
    {
        IEnumerable<Approach> getAllApproach();
        Approach getApproachByID(int ID);
    }
}
