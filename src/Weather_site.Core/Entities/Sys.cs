using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_site.Core.Entities
{
    public class Sys : IEntity<Guid>
    {
      
        public Guid Id { get; set; } = Guid.NewGuid();
        public int type { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }

        public ICollection<RootObject> objects { get; set; }
    }
}
