using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_site.Core.Entities
{
    public class Main : IEntity<Guid>
    {
       
        public Guid Id { get; set; } = Guid.NewGuid();
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int seaLevel { get; set; }
        public int GroundLevel { get; set; }
        public ICollection<RootObject> objects { get; set; }
    }
}
