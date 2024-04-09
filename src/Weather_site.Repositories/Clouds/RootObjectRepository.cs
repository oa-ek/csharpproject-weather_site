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

namespace Weather_site.Repositories.Clouds
{
    public class CloudsRepository : Repository<Core.Entities.Clouds, Guid>, ICloudsRepository
    {
        public CloudsRepository(ApplicationDbContext ctx) : base(ctx) 
        {
            
        }
        public async override Task<IEnumerable<Core.Entities.Clouds>> GetAllAsync()
        {
            return await _ctx.Clouds
                .ToListAsync();
        }
    }
}
