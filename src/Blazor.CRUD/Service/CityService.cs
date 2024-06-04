using Weather_site.Service;
using Weather_site.Service.DTOS;

namespace Blazor.CRUD.Service
{
    public class CityService : ICityService
    {
        public Task AddAsync(CityDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(CityAdd entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CityDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CityDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CityDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
