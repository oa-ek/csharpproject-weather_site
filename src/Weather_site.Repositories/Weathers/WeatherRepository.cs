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

namespace Weather_site.Repositories.Weathers
{
    public class WeatherRepository : Repository<Weather, Guid>, IWeatherRepository
    {
        public WeatherRepository(AppDbContext ctx) : base(ctx) { }

        public virtual async Task<Weather> GetAsync(Guid id)
        {
            return await _ctx.Set<Weather>()
                .Include(w => w.City)
                    .ThenInclude(c => c.Country)
                .Include(w => w.Wind)
                .FirstOrDefaultAsync(w => w.Id == id);
        }
        public async Task<IEnumerable<Weather>> GetAllAsync()
        {
            return await _ctx.Weathers
                                 .Include(w => w.City)
                                 .ThenInclude(c => c.Country)
                                 .Include(w => w.Wind)
                                 .ToListAsync();
        }
    }
}
