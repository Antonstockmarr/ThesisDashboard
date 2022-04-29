using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Models;

namespace Dashboardbackend.Profiles
{
    public class FocusAreasProfile : Profile
    {
        public FocusAreasProfile()
        {
            // By mapping we ensure that the whole domain object dosent get returned
            CreateMap<FocusArea, FocusAreaReadDto>();
        }
    }
}
