using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRentBikes
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RentalType, RentalTypeDto>();

            CreateMap<Bike, BikeDto>();

            CreateMap<OrderBike, OrderBikeDto>();

            CreateMap<Order, OrderDto>();
        }
    }
}
