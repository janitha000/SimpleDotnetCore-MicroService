using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Api.Entities;

namespace Vehicle.Api.Resources.Profiles
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<DriverResource, Driver>();
        }
    }
}
