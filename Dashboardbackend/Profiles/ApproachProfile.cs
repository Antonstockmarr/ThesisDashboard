using AutoMapper;
using Dashboardbackend.Dtos;
using Dashboardbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
