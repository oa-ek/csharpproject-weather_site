using Weather_site.Service;
using Weather_site.Service.DTOS;

namespace Blazor.CRUD.Service
{
    public class WeatherService : IWeatherService
    {

        public Task AddAsync(WeatherModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<WeatherModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<WeatherModel>> GetByCityIdAsync(Guid cityId)
        {
            throw new NotImplementedException();
        }

        public Task<WeatherModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WeatherModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
