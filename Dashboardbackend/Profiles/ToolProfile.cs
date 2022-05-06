using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Models;

namespace Dashboardbackend.Profiles
{
    public class ToolProfile : Profile
    {
        public ToolProfile()
        {
            CreateMap<Tool, ToolReadDto>();
        }
    }
}
