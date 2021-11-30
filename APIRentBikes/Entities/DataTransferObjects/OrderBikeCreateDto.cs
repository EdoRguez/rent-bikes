using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class OrderBikeCreateDto
    {

        [Required]
        public List<Guid?> ListIdBikes { get; set; }

        [Required]
        public Guid? Id_RentalType { get; set; }

        [Required]
        public int? RentTime { get; set; }
    }
}
