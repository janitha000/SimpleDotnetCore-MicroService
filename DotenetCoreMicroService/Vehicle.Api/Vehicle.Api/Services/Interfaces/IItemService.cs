using Vehicle.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api.Services.Interfaces
{
    public interface IItemService
    {
        Task<ApiResult> GetAllItemsAsync();
        Task<ApiResult> GetSingleAsync(string id);
        Task<ApiResult> PostItem(Item item);
        Task<ApiResult> UpdateItem(Item item);
        Task<ApiResult> DeleteItem(string id);
    }
}
