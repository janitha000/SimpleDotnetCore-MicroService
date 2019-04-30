using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api.Entities
{
    public interface IEntityBase
    {
        string GUID { get; set; }
        string Id { get; set; }

        string GetGUID();
    }
}
