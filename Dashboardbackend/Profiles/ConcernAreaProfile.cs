using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Models;

namespace Dashboardbackend.Profiles
{
    public class ConcernAreaProfile : Profile
    {
        public ConcernAreaProfile()
        {
            CreateMap<Concern, ConcernReadDto>();
        }
    }
}
