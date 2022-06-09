using Dashboardbackend.Models;
using System.Collections.Generic;

namespace Dashboardbackend.Data
{
    public interface IConcernRepository
    {
        IEnumerable<Concern> GetAllConcerns();
        Concern GetConcernByID(int ID);
        
    }
}
