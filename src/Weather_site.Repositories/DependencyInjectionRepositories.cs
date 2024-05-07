using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_site.Repositories.Cities;
using Weather_site.Repositories.Countries;
using Weather_site.Repositories.Weathers;
using Weather_site.Repositories.Winds;

namespace Weather_site.Repositories
{
    public static class DependencyInjectionRepositories
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IWindRepository, WindRepository>();
            services.AddScoped<IWeatherRepository, WeatherRepository>();
        }
    }
}
