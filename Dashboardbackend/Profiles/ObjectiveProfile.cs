using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Models;

namespace Dashboardbackend.Profiles
{
    public class ObjectivesProfile : Profile
    {
        public ObjectivesProfile()
        {
            // By mapping we ensure that the whole domain object dosent get returned
            CreateMap<Objective, ObjectiveReadDto>();
        }
    }
}
