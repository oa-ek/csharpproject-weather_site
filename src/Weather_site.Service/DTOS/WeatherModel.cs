using Weather_site.Core.Entities;

namespace Weather_site.API.DTOS
{
    public class WeatherModel
    {
        public Guid Id { get; set; } 
        public double Temp { get; set; }
        public double MinT { get; set; }
        public double MaxT { get; set; }
        public double FeelsLikeT { get; set; }
        public CityDTO City { get; set; }
        
    }
    public class WeatherAdd
    {
        public Guid CityId { get; set; }
        public double Temp { get; set; }
        public double MinT { get; set; }
        public double MaxT { get; set; }
        public double FeelsLikeT { get; set; }
        public string? Icon { get; set; }
        public int Pressure { get; set; }
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }

    }
    public class CityDTO 
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public CountryDTO Country { get; set; }

    }
    public class CountryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

}
