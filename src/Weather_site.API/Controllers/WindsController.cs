using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Winds;
using Weather_site.Service.DTOS;
//using Weather_site.UI.Models;

namespace Weather_site.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindsController : ControllerBase
    {
        private readonly IWindRepository _windRepository;
        private readonly IMapper _mapper;

        public WindsController(
            IWindRepository windRepository,
            IMapper mapper)
        {
            _windRepository = windRepository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllWinds()
        {
            var winds = _mapper.Map<IEnumerable<WindDTO>>(await _windRepository.GetAllAsync());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(winds);
        }

        [HttpPost("add")]
        //[RoleAuth(Role = "Admin")]
        public async Task<IActionResult> AddWind(WindAdd windCreateDto)
        {
            var wind = _mapper.Map<Wind>(windCreateDto);

            await _windRepository.CreateAsync(wind);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"Wind {wind.Id} added");
        }

        [HttpGet("{id}")]
        // [RoleAuth(Role = "Admin")]
        public async Task<IActionResult> GetWind(Guid id)
        {
            var wind = await _windRepository.GetAsync(id);
            if (wind is null)
                return NotFound("Wind not found");

            var windDto = _mapper.Map<WindDTO>(wind);
            return Ok(windDto);
        }

        [HttpDelete("delete/{id}")]
        // [RoleAuth(Role = "Admin")]
        public async Task<IActionResult> DeleteWind(Guid id)
        {
            var wind = await _windRepository.GetAsync(id);
            if (wind is null)
                return BadRequest("Wind not found");

            await _windRepository.DeleteAsync(wind.Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"Wind {wind.Id} deleted");
        }

        [HttpPut("update")]
        //  [RoleAuth(Role = "Admin")]
        public async Task<IActionResult> UpdateWind(WindDTO windDto)
        {
            var wind = _mapper.Map<Wind>(windDto);

            await _windRepository.UpdateAsync(wind);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"Wind {wind.Id} updated");
        }
    }
}