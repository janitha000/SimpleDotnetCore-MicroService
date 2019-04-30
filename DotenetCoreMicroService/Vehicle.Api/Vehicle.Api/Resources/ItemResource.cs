using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api.Resources
{
    public class ItemResource
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public string CategoryTypeId { get; set; }
        public string GUID { get; set; }
    }
}
