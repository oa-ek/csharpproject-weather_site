using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_site.Core.Entities
{
    public class User : IdentityUser<Guid>, IEntity<Guid>
    { 
        public string? FullName { get; set; }
        [ForeignKey("City")]
        public Guid CityId { get; set; }
        public virtual City? City { get; set; }
    }
}
