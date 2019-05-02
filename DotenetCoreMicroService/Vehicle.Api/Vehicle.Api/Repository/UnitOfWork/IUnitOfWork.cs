using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
