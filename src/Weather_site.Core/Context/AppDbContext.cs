using Azure.Core.GeoJson;
using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Context;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                 .Entity<Weather>()
                 .HasMany(x => x.User)
                 .WithMany(x => x.StudentProjects);

            builder.Seed();

            base.OnModelCreating(builder);
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Wind> Winds { get; set; }
        public DbSet<Weather> Weathers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=.;Database=WeatherDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
