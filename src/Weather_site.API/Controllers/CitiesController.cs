using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Weather_site.Repositories.Cities;
using Weather_site.API.DTOS;
using Weather_site.Core.Entities;

namespace Weather_site.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = _mapper.Map<IEnumerable<CityDTO>>(await _cityRepository.GetAllAsync());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cities);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCity(CityAdd cityAddDto)
        {
            var city = _mapper.Map<City>(cityAddDto);

            await _cityRepository.CreateAsync(city);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"City {city.Id} added");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(Guid id)
        {
            var city = await _cityRepository.GetAsync(id);
            if (city is null)
                return NotFound("City not found");

            var cityDto = _mapper.Map<CityDTO>(city);
            return Ok(cityDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            var city = await _cityRepository.GetAsync(id);
            if (city is null)
                return BadRequest("City not found");

            await _cityRepository.DeleteAsync(city.Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"City {city.Id} deleted");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCity(CityDTO cityDto)
        {
            var city = _mapper.Map<City>(cityDto);

            await _cityRepository.UpdateAsync(city);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"City {city.Id} updated");
        }
    }
}

