using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class OrderBikeParameters : RequestParameters
    {
        public bool showOnlyActiveOrders { get; set; } = false;
        public Guid? Id_Order { get; set; } = null;
    }
}
