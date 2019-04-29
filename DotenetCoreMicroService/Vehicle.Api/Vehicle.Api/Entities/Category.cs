using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api.Entities
{
    public class Category : IEntityBase
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }
}
