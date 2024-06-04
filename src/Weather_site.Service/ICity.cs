using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_site.Service.DTOS;

namespace Weather_site.Service
{
    public interface ICityService
    {
        Task<List<CityDTO>> GetAllAsync();
        Task<CityDTO> GetByIdAsync(Guid id);
        Task AddAsync(CityAdd entity);
        Task UpdateAsync(CityDTO entity);
        Task DeleteAsync(Guid id);
    }
}
