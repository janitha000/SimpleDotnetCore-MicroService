using System;
using System.Collections.Generic;
using Vehicle.Api.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api.Resources
{
    public class DriverResource
    {
        public string GUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIC { get; set; }
        public ICollection<VehicleEntity> Vehicles { get; set; }

    }
}
