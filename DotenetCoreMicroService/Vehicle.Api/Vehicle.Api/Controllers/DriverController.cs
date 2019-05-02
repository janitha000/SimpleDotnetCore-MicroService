using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vehicle.Api.Entities;
using Vehicle.Api.Extensions;
using Vehicle.Api.Repository.Interfaces;
using Vehicle.Api.Resources;
using Vehicle.Api.Services.Interfaces;

namespace Vehicle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService driverService;
        private readonly ILogger logger;

        public DriverController(IDriverService _service, ILogger<DriverController> _logger)
        {
            driverService = _service ?? throw new ArgumentNullException(nameof(_service));
            logger  = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        /// <summary>
        /// Post drivers
        /// </summary>
        /// <param name="driverResource"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] DriverResource driverResource)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    logger.LogError("ModelState is not valid");
                    return BadRequest(ModelState.GetErrorMessages());

                }

                var result = await driverService.PostDriverAsync(driverResource);

                if (!result.Success)
                {
                    logger.LogError("Posting driver not successfull");
                    return BadRequest(result.Message);
                }

                return Ok(result.ObjectEntity);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error when posting driver");
                return Ok(ex);
            }

        }

        /// <summary>
        /// Get single driver
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                if (id == null)
                    return BadRequest("ID is null");

                var result = await driverService.GetAsync(id);

                if(!result.Success)
                {
                    logger.LogError("Posting driver not successfull");
                    return BadRequest(result.Message);
                }

                return Ok(result.ObjectEntity);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error when posting driver");
                return Ok(ex);
            }
        }

    }
}