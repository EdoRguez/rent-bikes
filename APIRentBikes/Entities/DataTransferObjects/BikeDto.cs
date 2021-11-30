using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class BikeDto
    {
        public Guid? Id { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        public bool? IsAvailable { get; set; }
    }
}
