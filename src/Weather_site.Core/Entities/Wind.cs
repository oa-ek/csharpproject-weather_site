using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_site.Core.Entities
{
    public class Wind : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double Speed {  get; set; }
        public double Humidity { get; set; }

        public ICollection<Weather> Weathers { get; set; } = new List<Weather>();
    }
}
