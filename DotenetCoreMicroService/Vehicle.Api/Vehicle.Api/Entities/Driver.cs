using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api.Entities
{
    public class Driver : IEntityBase
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string NIC { get; set; }
    }
}
