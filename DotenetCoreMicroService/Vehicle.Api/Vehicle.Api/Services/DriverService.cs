using Vehicle.Api.Entities;
using Vehicle.Api.Repository.Interfaces;
using Vehicle.Api.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Api.Communication;
using Vehicle.Api.Resources;
using AutoMapper;

namespace Vehicle.Api.Services
{
    public class DriverService : IDriverService
    {
        private readonly ILogger<DriverService> logger;
        private readonly IDriverRepository repositoy;
        private readonly IMapper mapper;

        public DriverService(IDriverRepository repo, ILogger<DriverService> _logger, IMapper _mapper)
        {
            repositoy = repo ?? throw new ArgumentNullException(nameof(repo));
            logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        /// <summary>
        /// Delete driver
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public async Task<BaseResponse<DriverResource>> DeleteDriver(DriverResource driverResource)
        {
            try
            {
                await repositoy.Delete(driver);
                return new ApiResult(true, "Driver deleted");

            }
            catch(Exception ex)
            {
                logger.LogError("Error when deleting driver ", ex);
                return new ApiResult(false, ex);
            }
        }

        /// <summary>
        /// Get single driver
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseResponse<DriverResource>> Get(string id)
        {
            try
            {
                Driver driver = await repositoy.GetSingle(id);
                var resource = mapper.Map<Driver, DriverResource>(driver);
                return new BaseResponse<DriverResource>(resource);

            }catch(Exception ex)
            {
                logger.LogError("Error when getting driver ", ex);
                return new BaseResponse<DriverResource>(ex.Message);
            }
        }

        /// <summary>
        /// Get all drivers
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponse<DriverResource>> GetAllAsync()
        {
            try
            {
                List<Driver> drivers = await repositoy.GetAll();
                return new ApiResult(true, drivers);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error when getting drivers from service");
                return new ApiResult(false, ex); 
            }
        }

        /// <summary>
        /// Add driver
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public async Task<BaseResponse<DriverResource>> PostDriverAsync(DriverResource driverResource)
        {
            try
            {
                Driver driver = mapper.Map<DriverResource, Driver>(driverResource);

                driver.GUID = driver.GetGUID();
                await repositoy.Add(driver);
                var resource = mapper.Map<Driver, DriverResource>(driver);
                return new BaseResponse<DriverResource>(resource);
            }
            catch(Exception ex)
            {
                logger.LogError("Error when adding a driver from service", ex);
                return new BaseResponse<DriverResource>(ex.Message);
            }
        }

        /// <summary>
        /// Update driver details
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public async Task<BaseResponse<DriverResource>> UpdateDriver(DriverResource driverResource)
        {
            try
            {
                driver.GUID = driver.GetGUID();
                await repositoy.Update(driver);
                return new ApiResult(true, driver);
            }
            catch(Exception ex)
            {
                logger.LogError("Error when updating a driver from service", ex);
                return new ApiResult(false, ex);
            }
        }
    }
}
