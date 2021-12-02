using APIRentBikes;
using APIRentBikes.Controllers;
using APIRentBikes.Utils;
using APIRentBikesTests.Config;
using APIRentBikesTests.FakeData;
using AutoMapper;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Interfaces;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Repository;
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
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryManager _repo;

        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public OrderBikeTestUnit()
        {
            var config = new MapperConfiguration(x => {
                x.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
            _logger = new LoggerManager();

            _context = DbContextInMemory.Get();

            _repo = new RepositoryManager(_context);
        }

        [Fact]
        public async void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            _context.AddRange(Data.GetRentalTypes());
            _context.AddRange(Data.GetBikes());
            _context.SaveChanges();

            var controller = new OrderBikeController(_repo, _logger, _mapper);

            OrderBikeCreateDto dto = new OrderBikeCreateDto()
            {
                ListIdBikes =  new List<Guid?>()
                {
                    Guid.Parse("C8F84C17-23C2-4822-B611-80B05C945D17"),
                    Guid.Parse("B8CB8AA8-97E3-4049-B31D-8CD5D15503E8")
                },
                Id_RentalType = Guid.Parse("3CDB0CE0-6C5E-4C2D-9252-54ED5683B854"),
                RentTime = 4
            };

            // Act
            var createdResponse = await controller.Create(dto);

            // Assert
            Assert.IsType<ObjectResult>(createdResponse);
        }
    }
}
