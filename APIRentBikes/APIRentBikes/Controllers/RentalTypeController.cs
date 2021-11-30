using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
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
    public class RentalTypeController : ControllerBase
    {
        private readonly IRepositoryManager _repo;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public RentalTypeController(IRepositoryManager repo, ILoggerManager logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentalTypes()
        {
            var rentalTypes = await _repo.RentalType.GetRentalTypes(false);

            var rentalTypesDto = _mapper.Map<IEnumerable<RentalTypeDto>>(rentalTypes);

            return Ok(rentalTypesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalType(Guid? id)
        {
            if(id == null)
            {
                _logger.LogError("Id to get rental type cannot be null");
                return BadRequest("Id to get rental type cannot be null");
            }

            var rentalType = await _repo.RentalType.GetRentalType((Guid) id, false);

            if(rentalType == null)
            {
                _logger.LogError("Rental type was not found");
                return NotFound();
            }

            var rentalTypeDto = _mapper.Map<RentalTypeDto>(rentalType);

            return Ok(rentalTypeDto);
        }
    }
}
