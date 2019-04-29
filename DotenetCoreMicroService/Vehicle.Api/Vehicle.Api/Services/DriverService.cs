using Vehicle.Api.Entities;
using Vehicle.Api.Repository.Interfaces;
using Vehicle.Api.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api.Services
{
    public class DriverService : IDriverService
    {
        private readonly ILogger<DriverService> logger;
        private readonly IDriverRepository repositoy;

        public DriverService(IDriverRepository repo, ILogger<DriverService> _logger)
        {
            repositoy = repo ?? throw new ArgumentNullException(nameof(repo));
            logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public async Task<ApiResult> DeleteDriver(Driver driver)
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
        public async Task<ApiResult> Get(string id)
        {
            try
            {
                Driver driver = await repositoy.GetSingle(id);
                return new ApiResult(true, driver);

            }catch(Exception ex)
            {
                logger.LogError("Error when getting driver ", ex);
                return new ApiResult(false, ex);
            }
        }

        /// <summary>
        /// Get all drivers
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResult> GetAllAsync()
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
        public async Task<ApiResult> PostDriver(Driver driver)
        {
            try
            {
                await repositoy.Add(driver);
                return new ApiResult(true, driver);
            }
            catch(Exception ex)
            {
                logger.LogError("Error when adding a driver from service", ex);
                return new ApiResult(false, ex);
            }
        }

        public Task<ApiResult> UpdateDriver(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
