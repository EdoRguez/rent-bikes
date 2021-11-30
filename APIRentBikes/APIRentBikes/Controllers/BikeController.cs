using AutoMapper;
using Entities.DataTransferObjects;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    [ResponseCache(CacheProfileName = "120SecondsCache")]
    public class BikeController : ControllerBase
    {
        private readonly IRepositoryManager _repo;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BikeController(IRepositoryManager repo, ILoggerManager logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]    
        public async Task<IActionResult> GetBikes()
        {
            var bikes = await _repo.Bike.GetBikes(false);

            var bikesDto = _mapper.Map<IEnumerable<BikeDto>>(bikes);

            return Ok(bikesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBike(Guid? id)
        {
            if(id == null)
            {
                _logger.LogError("Id to get bike is null");
                return BadRequest("Id to get bike is null");
            }

            var bike = await _repo.Bike.GetBike((Guid) id, false);

            if (bike == null)
            {
                _logger.LogError("Bike not found");
                return NotFound();
            }

            var bikeDto = _mapper.Map<BikeDto>(bike);

            return Ok(bikeDto);
        }
    }
}
