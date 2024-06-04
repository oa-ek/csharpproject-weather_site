using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Weather_site.Repositories.Countries;
using Weather_site.Core.Entities;
using Weather_site.Service.DTOS;

namespace Weather_site.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountriesController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = _mapper.Map<IEnumerable<CountryDTO>>(await _countryRepository.GetAllAsync());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCountry(CountryAdd countryAddDto)
        {
            var country = _mapper.Map<Country>(countryAddDto);

            await _countryRepository.CreateAsync(country);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"Country {country.Id} added");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry(Guid id)
        {
            var country = await _countryRepository.GetAsync(id);
            if (country is null)
                return NotFound("Country not found");

            var countryDto = _mapper.Map<CountryDTO>(country);
            return Ok(countryDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCountry(Guid id)
        {
            var country = await _countryRepository.GetAsync(id);
            if (country is null)
                return BadRequest("Country not found");

            await _countryRepository.DeleteAsync(country.Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"Country {country.Id} deleted");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCountry(CountryDTO countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);

            await _countryRepository.UpdateAsync(country);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"Country {country.Id} updated");
        }
    }
}

