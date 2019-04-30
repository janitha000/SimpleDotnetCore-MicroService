using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Api.Entities;

namespace Vehicle.Api.Resources
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Driver, DriverResource>();
            CreateMap<Item, ItemResource>();
        }
    }
}
