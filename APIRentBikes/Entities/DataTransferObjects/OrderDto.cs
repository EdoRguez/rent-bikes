using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime? InitDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalWithDiscount { get; set; }
        public Guid? Id_RentalType { get; set; }
        public RentalTypeDto RentalType { get; set; }
        public ICollection<OrderBikeDto> ListOrderBike { get; set; }
    }
}
