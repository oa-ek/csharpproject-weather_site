using Weather_site.Service;
using Weather_site.Service.DTOS;

namespace Blazor.CRUD.Service
{
    public class WindService : IWindService
    {
        public Task AddAsync(WindDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(WindAdd entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<WindDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WindDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WindDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
