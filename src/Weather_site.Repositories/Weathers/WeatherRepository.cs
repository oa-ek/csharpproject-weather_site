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
    }
}
