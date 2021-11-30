using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderBikeRepository : RepositoryBase<OrderBike>, IOrderBikeRepository
    {
        public OrderBikeRepository(ApplicationDbContext context) : base(context) { }

        public void CreateOrderBike(OrderBike model)
        {
            Create(model);
        }

        public async Task<IEnumerable<OrderBike>> GetOrderBikes(OrderBikeParameters orderBikeParameters, bool trackChanges)
        {
            return await FindAll(trackChanges).Include(x => x.Bike)
                                              .Include(x => x.Order)
                                              .FilterActiveOrders(orderBikeParameters.showOnlyActiveOrders)
                                              .FilterByIdOrder(orderBikeParameters.Id_Order)
                                              .Skip((orderBikeParameters.pageNumber - 1) * orderBikeParameters.pageSize)
                                              .Take(orderBikeParameters.pageSize)
                                              .ToListAsync();
        }
    }
}
