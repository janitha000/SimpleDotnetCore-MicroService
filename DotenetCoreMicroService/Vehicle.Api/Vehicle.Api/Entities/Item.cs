using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api.Entities
{
    public class Item : IEntityBase
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public string CategoryTypeId { get; set; }
        public string GUID { get; set; }

        public string GetGUID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
