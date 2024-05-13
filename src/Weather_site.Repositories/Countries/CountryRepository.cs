using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_site.Core.Context;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Common;

namespace Weather_site.Repositories.Countries
{
    public class CountryRepository : Repository<Country, Guid>, ICountryRepository
    {
        public CountryRepository(AppDbContext ctx) : base(ctx) { }

        public async Task<Country> GetByName(string countryName)
        {
            return await _ctx.Countries.FirstOrDefaultAsync(g => g.Name == countryName);
        }

        public async Task<Country> GetCountryByName(string countryName)
        {
            return await _ctx.Countries.FirstOrDefaultAsync(g => g.Name == countryName);
        }
    }
}
