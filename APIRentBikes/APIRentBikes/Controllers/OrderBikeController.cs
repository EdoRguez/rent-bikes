using APIRentBikes.Utils;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRentBikes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderBikeController : ControllerBase
    {
        private readonly IRepositoryManager _repo;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public OrderBikeController(IRepositoryManager repo, ILoggerManager logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderBikeCreateDto dto)
        {
            if(dto == null)
            {
                _logger.LogError("Order bike is null");
                return BadRequest("Order bike is null");
            }

            var rentalType = await _repo.RentalType.GetRentalType((Guid)dto.Id_RentalType, false);
            if (rentalType == null)
            {
                _logger.LogError("Rental type was not found");
                return NotFound();
            }

            var bikes = await _repo.Bike.GetBikesByIds(dto.ListIdBikes, true);
            if(bikes.Count() != dto.ListIdBikes.Count())
            {
                _logger.LogError("Some bikes to order were not found");
                return NotFound();
            }
            else
            {
                foreach(var bike in bikes)
                {
                    if((bool) !bike.IsAvailable)
                    {
                        _logger.LogError("Bike with Id " + bike.Id + " is not available");
                        return BadRequest("Bike with Id " + bike.Id + " is not available");
                    }

                    bike.IsAvailable = false;
                }
            }

            Order order = OrderBikeUtils.ManageOrderData(rentalType, bikes.Count(), (int) dto.RentTime);
            _repo.Order.CreateOrder(order);

            foreach(var bike in bikes)
            {
                OrderBike orderBike = new OrderBike()
                {
                    Order = order,
                    Bike = bike
                };

                _repo.OrderBike.CreateOrderBike(orderBike);
            }

            await _repo.SaveAsync();

            var model = await _repo.OrderBike.GetOrderBikes(new OrderBikeParameters() { Id_Order = order.Id }, false);

            var dtoToReturn = _mapper.Map<IEnumerable<OrderBikeDto>>(model);

            return StatusCode(201, dtoToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderBikes([FromQuery] OrderBikeParameters orderBikeParameters)
        {
            var orderBikes = await _repo.OrderBike.GetOrderBikes(orderBikeParameters, false);

            var dto = _mapper.Map<IEnumerable<OrderBikeDto>>(orderBikes);

            return Ok(dto);
        }
    }
}
