using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
