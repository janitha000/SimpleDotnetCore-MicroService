using Vehicle.Api.Entities;
using Vehicle.Api.Repository.Context;
using Vehicle.Api.Repository.Generic;
using Vehicle.Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api.Repository
{
    public class DriverRepository : Repositorybase<Driver> , IDriverRepository
    {
        public DriverRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
