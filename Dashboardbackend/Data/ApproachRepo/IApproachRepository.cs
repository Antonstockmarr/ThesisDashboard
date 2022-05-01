using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboardbackend.Data.ApproachRepo
{
    public interface IApproachRepository
    {
        IEnumerable<Approach> getAllApproach();
        Approach getApproachByID(int ID);
    }
}
