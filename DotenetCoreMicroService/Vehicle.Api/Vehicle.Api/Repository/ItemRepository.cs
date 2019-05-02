using Vehicle.Api.Entities;
using Vehicle.Api.Repository.Context;
using Vehicle.Api.Repository.Generic;
using Vehicle.Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Api.Repository.UnitOfWork;

namespace Vehicle.Api.Repository
{
    public class ItemRepository : Repositorybase<Item> , IItemRepository
    {
        public ItemRepository(DatabaseContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }

    }
}
