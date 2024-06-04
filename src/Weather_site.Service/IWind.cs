using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_site.Service.DTOS;

namespace Weather_site.Service
{
    public interface IWindService
    {
        Task<List<WindDTO>> GetAllAsync();
        Task<WindDTO> GetByIdAsync(Guid id);
        Task AddAsync(WindAdd entity);
        Task UpdateAsync(WindDTO entity);
        Task DeleteAsync(Guid id);
    }
}
