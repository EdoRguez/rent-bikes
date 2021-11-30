using APIRentBikes.Utils;
using APIRentBikesTests.Config;
using APIRentBikesTests.FakeData;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace APIRentBikesTests
{
    public class OrderBikeTestUnit
    {
        [Fact]
        public void Test1()
        {
            var _dbc = DbContextInMemory.Get();

            // We create list of rental types
            List<RentalType> rentalTypes = Data.GetRentalTypes();
            _dbc.Set<RentalType>().AddRange(rentalTypes);

            // We create list of bikes
            List<Bike> bikes = Data.GetBikes();
            _dbc.Set<Bike>().AddRange(bikes);

            _dbc.SaveChanges();

            // We create object to rent bikes
            OrderBikeCreateDto orderBikeCreateDto = new OrderBikeCreateDto()
            {
                ListIdBikes = new List<Guid?>()
                {
                    Guid.Parse("6fe98c41-f2fe-4d45-860e-3042dd182751"),
                    Guid.Parse("1c4a515a-56d1-43a8-8a80-39343fe2654f")
                },
                Id_RentalType = Guid.Parse("b090a296-d3a3-4828-b2f9-0b6c360ad77b"),
                RentTime = 5
            };

            // We validate if rental type exist
            var dbRentalType = _dbc.Set<RentalType>().FirstOrDefault(x => x.Id == orderBikeCreateDto.Id_RentalType);
            Assert.NotNull(dbRentalType);

            // We validate if all bikes exist
            var dbBikes = _dbc.Set<Bike>().Where(x => orderBikeCreateDto.ListIdBikes.Contains(x.Id));
            Assert.Equal(dbBikes.Count(), orderBikeCreateDto.ListIdBikes.Count());

            // We create the new order
            Order order = OrderBikeUtils.ManageOrderData(dbRentalType, bikes.Count(), (int)orderBikeCreateDto.RentTime);
            order.Id = Guid.NewGuid();
            _dbc.Set<Order>().Add(order);


            foreach (Bike forBike in dbBikes)
            {
                OrderBike orderBike = new OrderBike()
                {
                    Order = order,
                    Bike = forBike
                };

                _dbc.Set<OrderBike>().Add(orderBike);
            }

            _dbc.SaveChanges();

            // We validate all models were created
            var orderBikes = _dbc.Set<OrderBike>().Where(x => x.Id_Order == order.Id);

            Assert.Equal(orderBikeCreateDto.ListIdBikes.Count(), orderBikes.Count());
        }
    }
}
