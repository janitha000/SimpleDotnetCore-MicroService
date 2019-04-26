using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Items.Api.Entities
{
    public class Item : IEntityBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public string CategoryTypeId { get; set; }


    }
}
