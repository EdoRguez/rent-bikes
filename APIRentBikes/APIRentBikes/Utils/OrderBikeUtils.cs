using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRentBikes.Utils
{
    public static class OrderBikeUtils
    {
        public static Order ManageOrderData(RentalType rentalType, int totalBikes, int rentTime)
        {
            DateTime currentDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            decimal discount = 0;
            decimal total = (decimal) rentalType.Price * totalBikes * rentTime;

            // 30% Discount
            if (totalBikes >= 3)
            {
                discount = total * Convert.ToDecimal(0.3);
            }
            
            if(rentalType.Id == Guid.Parse("B090A296-D3A3-4828-B2F9-0B6C360AD77B")) // Hours
            {
                endDate = endDate.AddHours(rentTime);
            }
            else if(rentalType.Id == Guid.Parse("3CDB0CE0-6C5E-4C2D-9252-54ED5683B854")) // Days
            {
                endDate = endDate.AddDays(rentTime);
            }
            else // Weeks
            {
                rentTime *= 7;
                endDate = endDate.AddDays(rentTime);
            }

            return new Order()
            {
                InitDate = currentDate,
                EndDate = endDate,
                Discount = discount,
                Total = total,
                TotalWithDiscount = total - discount,
                Id_RentalType = rentalType.Id
            };
        }
    }
}
