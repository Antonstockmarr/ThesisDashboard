using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Models;

namespace Dashboardbackend.Profiles
{
    public class ConcernProfile : Profile
    {
        public ConcernProfile()
        {
            CreateMap<Concern, ConcernReadDto>();
        }
    }
}
