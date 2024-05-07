﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Weather_site.Repositories.Common.IRepository;
using Weather_site.Core.Entities;

namespace Weather_site.Repositories.Winds
{
    public interface IWindRepository : IRepository<Wind, Guid>
    {

    }
}