using Azure.Messaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_site.Core.Context;
using Weather_site.Core.Entities;
using Weather_site.Repositories.Common;

namespace Weather_site.Repositories.RootObject
{
    public class RootObjectRepository : Repository<Core.Entities.RootObject, Guid>, IRootObjectRepository
    {
        public RootObjectRepository(ApplicationDbContext ctx) : base(ctx) 
        {
            
        }
        public async override Task<IEnumerable<Core.Entities.RootObject>> GetAllAsync()
        {
            return await _ctx.RootObjects
                .Include(x => x.Id)
                .Include(x => x.coord)
                .Include(x => x.weather)
                .Include(x => x.@base)
                .Include(x => x.main)
                .Include(x => x.visibility)
                .Include(x => x.)
                .ToListAsync();
        }
    }
}
