﻿using System;
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
        public CountryRepository(ApplicationDbContext ctx) : base(ctx) { }
    }
}