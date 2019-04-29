using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vehicle.Api.Repository.Interfaces;

namespace Vehicle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository repository;
        private readonly ILogger logger;

        public DriverController(IDriverRepository repo, ILogger<DriverController> _logger)
        {
            repository = repo;
            logger = _logger;
        }

    }
}