using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_site.Core.Entities
{
    public class User : IdentityUser<Guid>, IEntity<Guid>
    { 
        public string? FullName { get; set; }
    }
}
