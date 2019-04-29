using Vehicle.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api.Services.Interfaces
{
    public interface IDriverService
    {
        Task<ApiResult> GetAllAsync();
        Task<ApiResult> Get(string id);
        Task<ApiResult> PostDriver(Driver driver);
        Task<ApiResult> UpdateDriver();
        Task<ApiResult> DeleteDriver();

    }
}
