using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_site.Core.Entities
{
    public class ResultViewModel : IEntity<Guid>
    {
        
        public Guid Id { get; set; } = Guid.NewGuid();
        public string City { get; set; }
        public string Country { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Description { get; set; }
        public string Humidity { get; set; }
        public string TempFeelsLike { get; set; }
        public string Temp { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public string WeatherIcon { get; set; }
    }
}
