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

namespace Vehicle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository repository;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public DriverController(IDriverRepository repo, ILogger<DriverController> _logger, IMapper _mapper)
        {
            repository = repo;
            logger = _logger;
            mapper = _mapper;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] DriverResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var driver = mapper.Map<DriverResource, Driver>(resource);
        }

    }
}