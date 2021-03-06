﻿using Vehicle.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Api.Resources;
using Vehicle.Api.Communication;

namespace Vehicle.Api.Services.Interfaces
{
    public interface IDriverService
    {
        Task<List<BaseResponse<DriverResource>>> GetAllAsync();
        Task<BaseResponse<DriverResource>> GetAsync(string id);
        Task<BaseResponse<DriverResource>> PostDriverAsync(DriverResource driver);
        Task<BaseResponse<DriverResource>> UpdateDriverAsync(string id, DriverResource driver);
        Task<bool> DeleteDriver(DriverResource driver);

    }
}
