using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather_site.API.DTOS;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Cities;
using Weather_site.Repositories.Countries;
using Weather_site.Repositories.Weathers;
using Weather_site.Repositories.Winds;

namespace Weather_site.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        
            private readonly IWeatherRepository _weatherRepository;
            private readonly ICityRepository _cityRepository;
            private readonly IWindRepository _windRepository;
            private readonly ICountryRepository _countryRepository;
            private readonly IMapper _mapper;

            public WeathersController(
                IWeatherRepository weatherRepository,
                ICityRepository cityRepository,
                IWindRepository windRepository,
                ICountryRepository countryRepository,
                IMapper mapper)
            {
                _weatherRepository = weatherRepository;
                _cityRepository = cityRepository;
                _windRepository = windRepository;
                _countryRepository = countryRepository;
                _mapper = mapper;
            }

            [HttpGet("all")]
            public async Task<IActionResult> GetAllWeathers()
            {
                var weathers = _mapper.Map<IEnumerable<WeatherModel>>(await _weatherRepository.GetAllAsync());

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(weathers);
            }

            [HttpPost("add")]
            //[RoleAuth(Role = "Admin")]
            public async Task<IActionResult> AddWeather(WeatherAdd weatherCreateDto)
            {
                var weather = _mapper.Map<Weather>(weatherCreateDto);
                var city = await _cityRepository.GetAsync(weatherCreateDto.CityId);
                if (weather.Temp < -273.15)
                    return BadRequest("Temperature must be above absolute zero");

                if (city is null)
                    return BadRequest("City not found");

                weather.City = city;
                await _weatherRepository.CreateAsync(weather);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok($"Weather {weather.Id} added");
            }

            [HttpGet("{id}")]
           // [RoleAuth(Role = "Admin")]
            public async Task<IActionResult> GetWeather(Guid id)
            {
                var weather = await _weatherRepository.GetAsync(id);
                if (weather is null)
                    return NotFound("Weather not found");

                var weatherDto = _mapper.Map<WeatherModel>(weather);
                return Ok(weatherDto);
            }

            [HttpDelete("delete/{id}")]
           // [RoleAuth(Role = "Admin")]
            public async Task<IActionResult> DeleteWeather(Guid id)
            {
                var weather = await _weatherRepository.GetAsync(id);
                if (weather is null)
                    return BadRequest("Weather not found");

                await _weatherRepository.DeleteAsync(weather.Id);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok($"Weather {weather.Id} deleted");
            }

            [HttpPut("update")]
          //  [RoleAuth(Role = "Admin")]
            public async Task<IActionResult> UpdateWeather(WeatherModel weatherDto)
            {
                var weather = _mapper.Map<Weather>(weatherDto);

                var city = await _cityRepository.GetAsync(weatherDto.City.Id);

                if (weatherDto.Temp < -273.15)
                    return BadRequest("Temperature must be above absolute zero");

                if (city is null)
                    return BadRequest("City not found");

                weather.City = city;
                await _weatherRepository.UpdateAsync(weather);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok($"Weather {weather.Id} updated");
            }


        }
}

