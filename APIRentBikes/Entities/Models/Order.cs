using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Order
    {
        [Key]
        [Required]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Init rent date is required")]
        public DateTime? InitDate { get; set; }

        [Required(ErrorMessage = "End rent date is required")]
        public DateTime? EndDate { get; set; }


        [Required]
        public decimal? Discount { get; set; }


        [Required]
        public decimal? Total { get; set; }


        [Required(ErrorMessage = "Total with discount is required")]
        public decimal? TotalWithDiscount { get; set; }


        [Required]
        [ForeignKey(nameof(RentalType))]
        public Guid? Id_RentalType { get; set; }
        public RentalType RentalType { get; set; }

        public ICollection<OrderBike> ListOrderBike { get; set; }

    }
}
