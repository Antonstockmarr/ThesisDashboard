using Dashboardbackend.Models;
using System.Collections.Generic;

namespace Dashboardbackend.Data.ApproachRepo
{
    public interface IApproachRepository
    {
        IEnumerable<Approach> GetAllApproach();
        Approach GetApproachByID(int ID);
    }
}
