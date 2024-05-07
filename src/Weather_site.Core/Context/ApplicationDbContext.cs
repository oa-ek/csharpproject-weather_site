using Azure.Core.GeoJson;
using Microsoft.EntityFrameworkCore;
using Weather_site.Core.API;
using Weather_site.Core.Entities;
using Wind = Weather_site.Core.Entities.Wind;

namespace Weather_site.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Wind> Winds { get; set; }
        public DbSet<Weather> Weathers { get; set; }


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=.;Database=WeatherDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }*/
    }
}
