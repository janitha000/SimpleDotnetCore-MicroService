using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Api.Entities;
using Vehicle.Api.Resources;

namespace Vehicle.Api.Communication
{
    public  class BaseResponse<T> where T : class , IBaseResource, new()
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public T ObjectEntity { get; set; }

        private BaseResponse(bool success, string message, T objectEntity)
        {
            Success = success;
            Message = message;
            ObjectEntity = objectEntity;
        }

        /// <summary>
        /// Create success response
        /// </summary>
        /// <param name="objectEntity"></param>
        public BaseResponse(T objectEntity) : this(true, string.Empty, objectEntity)
        {

        }

        /// <summary>
        /// Create error response
        /// </summary>
        /// <param name="message"></param>
        public BaseResponse(string message) : this(false, message, null)
        {

        }
    }
}
