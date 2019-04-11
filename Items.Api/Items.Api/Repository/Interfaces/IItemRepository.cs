using Items.Api.Entities;
using Items.Api.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Items.Api.Repository.Interfaces
{
    public interface IItemRepository : IRepositryBase<Item>
    {
    }
}
