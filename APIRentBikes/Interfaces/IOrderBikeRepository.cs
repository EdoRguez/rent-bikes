using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IOrderBikeRepository
    {
        void CreateOrderBike(OrderBike model);
        Task<IEnumerable<OrderBike>> GetOrderBikes(OrderBikeParameters orderBikeParameters, bool trackChanges);
    }
}
