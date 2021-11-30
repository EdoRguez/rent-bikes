using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryOrderBikeExtension
    {
        public static IQueryable<OrderBike> FilterActiveOrders(this IQueryable<OrderBike> orderBikes, bool showOnlyActiveOrders)
        {
            if(showOnlyActiveOrders)
            {
                return orderBikes.Where(x => x.Order.EndDate >= DateTime.Now);
            }

            return orderBikes;
        }

        public static IQueryable<OrderBike> FilterByIdOrder(this IQueryable<OrderBike> orderBikes, Guid? id_Order)
        {
            if (id_Order != null)
            {
                return orderBikes.Where(x => x.Id_Order == (Guid) id_Order);
            }

            return orderBikes;
        }

    }
}
