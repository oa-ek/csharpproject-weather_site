using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_site.Service.DTOS;

namespace Weather_site.Service
{
    public interface IWeatherService
    {
        Task<List<WeatherModel>> GetAllAsync();
        Task<WeatherModel> GetByIdAsync(Guid id);
        Task AddAsync(WeatherModel entity);
        Task UpdateAsync(WeatherModel entity);
        Task DeleteAsync(Guid id);
        Task<List<WeatherModel>> GetByCityIdAsync(Guid cityId);
    }
}
