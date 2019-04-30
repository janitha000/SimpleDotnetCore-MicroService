using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api
{
    public static class ExceptionHelper
    {
        public static object ProcessError(Exception ex)
        {
            return new
            {
                error = new
                {
                    code = ex.HResult,
                    message = ex.Message,
                    innerMessage = ex.InnerException.Message
                }
            };
        }
    }
}
