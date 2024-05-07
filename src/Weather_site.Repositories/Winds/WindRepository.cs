using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_site.Core.Context;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Common;
using Weather_site.Repositories.Countries;

namespace Weather_site.Repositories.Winds
{
    public class WindRepository : Repository<Wind, Guid>, IWindRepository
    {
        public WindRepository(ApplicationDbContext ctx) : base(ctx) { }
    }
}
