using Vehicle.Authentication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Authentication.Services
{
    public interface IAuthenticationService
    {
        Task<ApiResult> RegisterAsync(User user);
        Task<ApiResult> SigninAsync(User user);
    }
}
