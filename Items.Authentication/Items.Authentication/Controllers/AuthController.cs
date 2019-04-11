using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Items.Authentication.Entities;
using Items.Authentication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Items.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthenticationService _authService;
        private readonly ILogger logger;

        public AuthController(IAuthenticationService service, ILogger<AuthController> logger)
        {
            this._authService = service;
            this.logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] User user)
        {
            try
            {
                logger.LogDebug($"Called register endpoint with parameters {user.Name}, {user.Email}");
                ApiResult registered = await this._authService.RegisterAsync(user);
                if (registered.Status)
                {
                    //this._userRepository.Add(user);
                    return Ok("User Created");
                }
                else
                {
                    logger.LogWarning("User not registered");
                    return BadRequest(registered.Message);
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error when registering");
                return Ok(new ApiResult(false, ex));
            }

        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResult>> Signin([FromBody] User user)
        {
            try
            {
                logger.LogDebug($"Called to login using parameters: {user.Name}");
                ApiResult result = await this._authService.SigninAsync(user);
                if (result.Status)
                    return Ok(result.Message);
                else
                    return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error when signin");
                return Ok(new ApiResult(false, ex));
            }

        }
    }
}