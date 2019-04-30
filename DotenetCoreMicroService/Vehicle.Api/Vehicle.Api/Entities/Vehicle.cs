using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Api.Entities.Enums;

namespace Vehicle.Api.Entities
{
    public class VehicleEntity : IEntityBase
    {
        public string GUID { get; set; }
        public string Id { get; set; }
        public string VehicleNumber { get; set; }
        public PriceCategory Category { get; set; }

        public string GetGUID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
