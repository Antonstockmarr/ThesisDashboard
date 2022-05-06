using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Models;

namespace Dashboardbackend.Profiles
{
    public class ApproachProfile : Profile
    {
        public ApproachProfile()
        {
            // By mapping we ensure that the whole domain object dosent get returned
            CreateMap<Approach, ApproachReadDto>();
        }
    }
}
