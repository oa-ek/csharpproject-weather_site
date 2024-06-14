using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_site.Core.Entities
{
    public class City : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        [ForeignKey("Country")]
        public Guid? CountryId { get; set; }
        public Country? Country { get; set; } 

        public ICollection<Weather> Weathers { get; set; } = new List<Weather>();
    }
}
