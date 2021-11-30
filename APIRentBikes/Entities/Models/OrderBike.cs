using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class OrderBike
    {
        [Key]
        [Required]
        public Guid? Id { get; set; }

        [Required]
        [ForeignKey(nameof(Order))]
        public Guid? Id_Order { get; set; }
        public Order Order { get; set; }


        [Required]
        [ForeignKey(nameof(Bike))]
        public Guid? Id_Bike { get; set; }
        public Bike Bike { get; set; }
    }
}
