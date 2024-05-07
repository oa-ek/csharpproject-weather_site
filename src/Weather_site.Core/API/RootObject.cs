using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_site.Core.Entities;

namespace Weather_site.Core.API
{
    public class RootObject : IEntity<Guid>
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public Coord coord { get; set; }
        public List<Weather_api> weather_api { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds all { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
