using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_site.Core.Entities;
using static Weather_site.Repositories.Common.IRepository;

namespace Weather_site.Repositories.Countries
{
    public interface ICountryRepository : IRepository<Country, Guid>
    {

    }
}
