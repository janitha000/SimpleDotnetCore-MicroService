using Items.Api.Entities;
using Items.Api.Repository.Context;
using Items.Api.Repository.Generic;
using Items.Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Items.Api.Repository
{
    public class ItemRepository : Repositorybase<Item> , IItemRepository
    {
        public ItemRepository(DatabaseContext context) : base(context)
        {
        }

    }
}
