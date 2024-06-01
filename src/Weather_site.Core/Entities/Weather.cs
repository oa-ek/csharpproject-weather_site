using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_site.Core.Entities
{
    public class Weather : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public City City { get; set; }
        public double Temp {  get; set; }
        public double MinT { get; set; }
        public double MaxT { get; set; }
        public double FeelsLikeT { get; set; }
       // public Wind Wind { get; set; }
        public DateTime Date { get; set; }
        public string? Icon { get; set; }
        public int Pressure {  get; set; }
        public int SeaLevel {  get; set; }
        public int GrndLevel { get; set; }

    }
}
