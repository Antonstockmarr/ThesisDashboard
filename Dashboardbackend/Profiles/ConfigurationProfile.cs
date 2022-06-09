using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Models;

namespace Dashboardbackend.Profiles
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<Configuration, ConfigurationReadDto>();
        }
    }
}
