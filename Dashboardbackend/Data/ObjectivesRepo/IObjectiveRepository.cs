using Dashboardbackend.Models;
using System.Collections.Generic;

namespace Dashboardbackend.Data
{
    public interface IObjectiveRepository
    {
        IEnumerable<Objective> GetAllObjectives();
        Objective GetObjectiveById(int id);
    }
}
