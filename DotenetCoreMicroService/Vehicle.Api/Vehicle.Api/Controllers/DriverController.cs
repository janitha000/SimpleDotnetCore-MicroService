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
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await driverService.PostDriverAsync(driverResource);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.ObjectEntity);

        }

    }
}