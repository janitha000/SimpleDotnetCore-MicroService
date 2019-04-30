using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Api.Entities;

namespace Vehicle.Api.Communication
{
    public  class BaseResponse<T> where T : class , IEntityBase, new()
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public T ObjectEntity { get; set; }

        public BaseResponse(bool success, string message, T objectEntity)
        {
            Success = success;
            Message = message;
            ObjectEntity = objectEntity;
        }

        public BaseResponse(T objectEntity) : this(true, string.Empty, objectEntity)
        {

        }

        public BaseResponse(string message) : this(false, message, null)
        {

        }
    }
}
