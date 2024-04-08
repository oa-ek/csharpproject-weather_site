using Azure.Core.GeoJson;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Weather_site.Core.Entities;

namespace Weather_site.UI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 
        }

        public DbSet<Clouds> Clouds => Set<Clouds>();

        public DbSet<Coord> Coords => Set<Coord>();

        public DbSet<Main> Mains => Set<Main>();
            
        public DbSet<ResultViewModel> ResultViewModels => Set<ResultViewModel>();

        public DbSet<RootObject> RootObjects => Set<RootObject>();

        public DbSet<Sys> Sys => Set<Sys>();

        public DbSet<Weather> Weathers => Set<Weather>();

        public DbSet<Wind> Winds => Set<Wind>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=.;Database=WeatherDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
