using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_site.Core.Entities;

namespace Weather_site.Core.Context
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            //  var (adminID, userID) = _seedRoles(builder);

            var UkraineId = _seedCountry(builder);
            var CitiesId = _seedCity(builder, UkraineId);
            //var UserId = _seedUser(builder, adminID, userID, CitiesId);
        }

        //private static (Guid, Guid) _seedRoles(ModelBuilder builder)
        //{
        //    var ADMIN_ROLE_ID = Guid.NewGuid();
        //    var USER_ROLE_ID = Guid.NewGuid();

        //    builder.Entity<IdentityRole<Guid>>()
        //       .HasData(
        //           new IdentityRole<Guid>
        //           {
        //               Id = ADMIN_ROLE_ID,
        //               Name = "Admin",
        //               NormalizedName = "ADMIN",
        //               ConcurrencyStamp = ADMIN_ROLE_ID.ToString()
        //           },
        //           new IdentityRole<Guid>
        //           {
        //               Id = USER_ROLE_ID,
        //               Name = "User",
        //               NormalizedName = "USER",
        //               ConcurrencyStamp = USER_ROLE_ID.ToString()
        //           }
        //       );


        //    return (ADMIN_ROLE_ID, USER_ROLE_ID);

        //}

        //private static Guid _seedUser(ModelBuilder builder, Guid USER_ROLE_ID, Guid ADMIN_ROLE_ID, Guid CityId)
        //{
        //    var userId = Guid.NewGuid();

        //    var admin = new User
        //    {
        //        Id = userId,
        //        UserName = "admin@projects.kleban.page",
        //        CityId = CityId,
        //        EmailConfirmed = true,
        //        NormalizedUserName = "admin@projects.kleban.page".ToUpper(),
        //        Email = "admin@projects.kleban.page",
        //        NormalizedEmail = "admin@projects.kleban.page".ToUpper(),
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        FullName = "Юрій Клебан"
        //    };

        //    var user = new User
        //    {
        //        Id = Guid.NewGuid(),
        //        UserName = "user@projects.kleban.page",
        //        CityId = CityId,
        //        EmailConfirmed = true,
        //        NormalizedUserName = "user@projects.kleban.page".ToUpper(),
        //        Email = "user@projects.kleban.page",
        //        NormalizedEmail = "user@projects.kleban.page".ToUpper(),
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        FullName = "Іван Петренко"
        //    };

        //    PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
        //    admin.PasswordHash = passwordHasher.HashPassword(admin, "123123");
        //    user.PasswordHash = passwordHasher.HashPassword(user, "123123");

        //    builder.Entity<User>()
        //        .HasData(admin, user);

        //    builder.Entity<IdentityUserRole<Guid>>()
        //      .HasData(
        //          new IdentityUserRole<Guid>
        //          {
        //              RoleId = ADMIN_ROLE_ID,
        //              UserId = userId
        //          },
        //          new IdentityUserRole<Guid>
        //          {
        //              RoleId = USER_ROLE_ID,
        //              UserId = userId
        //          }
        //      );

        //    return userId;
        //}

        private static Guid _seedCity(ModelBuilder builder, Guid UKRAINE_ID)
        {
            var OSTROH_ID = Guid.NewGuid();
            var RIVNE_ID = Guid.NewGuid();
            builder.Entity<City>().HasData(
                new City
                {
                    Id = OSTROH_ID,
                    Name = "Osrtoh",
                    CountryId = UKRAINE_ID,
                },
                new City
                {
                    Id = RIVNE_ID,
                    Name = "Rivne",
                    CountryId = UKRAINE_ID,
                }
            );
            return RIVNE_ID;
        }

        private static Guid _seedCountry(ModelBuilder builder)
        {
            var UKRAINE_ID = Guid.NewGuid();
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = UKRAINE_ID,
                    Name = "UA"
                }
                );
            return UKRAINE_ID;
        }
    }
}
