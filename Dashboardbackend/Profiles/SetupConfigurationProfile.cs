using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Models;

namespace Dashboardbackend.Profiles
{
    public class SetupConfigurationProfile : Profile
    {
        public SetupConfigurationProfile()
        {
            CreateMap<SetupConfiguration, SetupConfigurationReadDto>();
        }
    }
}
