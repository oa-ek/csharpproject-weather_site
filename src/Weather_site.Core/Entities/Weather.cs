using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_site.Core.Entities
{
    public class Weather : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }

        public ICollection<RootObject> objects { get; set; } 
    }
}
