using Dashboardbackend.Models;
using System.Collections.Generic;

namespace Dashboardbackend.Data
{
    public interface IConcernRepository
    {
        IEnumerable<Concern> getAllConcerns();
        Concern getConcernByID(int ID);
        
    }
}
