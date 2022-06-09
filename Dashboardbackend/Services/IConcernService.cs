using System.Collections.Generic;
using Dashboardbackend.Models;

namespace Dashboardbackend.Services
{
    public interface IConcernService
    {
        bool ConcernExists(int concernId);

        bool ConcernsExists(IEnumerable<int> concernIds);

        Concern GetConcernById(int id);

        public IEnumerable<Concern> GetConcerns();

    }
}