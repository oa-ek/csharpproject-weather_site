using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_site.Core.Context;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Common;
using Weather_site.Repositories.Countries;

namespace Weather_site.Repositories.Cities
{
    public class CityRepository : Repository<City, Guid>, ICityRepository
    {
        public CityRepository(AppDbContext ctx) : base(ctx) { }
        public async Task<City> GetByName(string cityName)
        {
            return await _ctx.Cities.FirstOrDefaultAsync(g => g.Name == cityName);
        }

        public async Task<City> GetCityByName(string cityName)
        {
            return await _ctx.Cities.FirstOrDefaultAsync(g => g.Name == cityName);
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _ctx.Cities
                                 .Include(c => c.Country)
                                 .ToListAsync();
        }
    }
}
