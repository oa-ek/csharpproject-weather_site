using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_site.Core.Entities
{
    public class Wind : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double speed { get; set; }
        public int deg { get; set; }
        public double Gust { get; set; }
        public ICollection<RootObject> objects { get; set; }
    }
}
