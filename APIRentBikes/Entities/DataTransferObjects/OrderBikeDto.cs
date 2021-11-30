using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class OrderBikeDto
    {
        public Guid? Id { get; set; }
        public Guid? Id_Order { get; set; }
        public OrderDto Order { get; set; }
        public Guid? Id_Bike { get; set; }
        public BikeDto Bike { get; set; }
    }
}
