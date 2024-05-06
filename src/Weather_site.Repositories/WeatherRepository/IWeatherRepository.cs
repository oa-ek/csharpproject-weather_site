using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Weather_site.Repositories.Common.IRepository;

namespace Weather_site.Repositories.WeatherRepository
{
    public interface IWeatherRepository : IRepository<Core.Entities.Weather, Guid>
    {

    }
}
