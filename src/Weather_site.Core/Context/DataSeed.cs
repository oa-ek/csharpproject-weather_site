using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_site.Core.Entities;

namespace ProjectInit.Core.Context
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            var (adminID, userID) = _seedRoles(builder);
            
            var UserId = _seedUser(builder, adminID, userID);
        }

        private static (Guid, Guid) _seedRoles(ModelBuilder builder)
        {
            var ADMIN_ROLE_ID = Guid.NewGuid();
            var USER_ROLE_ID = Guid.NewGuid();

            builder.Entity<IdentityRole<Guid>>()
               .HasData(
                   new IdentityRole<Guid>
                   {
                       Id = ADMIN_ROLE_ID,
                       Name = "Admin",
                       NormalizedName = "ADMIN",
                       ConcurrencyStamp = ADMIN_ROLE_ID.ToString()
                   },
                   new IdentityRole<Guid>
                   {
                       Id = USER_ROLE_ID,
                       Name = "User",
                       NormalizedName = "USER",
                       ConcurrencyStamp = USER_ROLE_ID.ToString()
                   }
               );


            return (ADMIN_ROLE_ID, USER_ROLE_ID);

        }

        private static Guid _seedUser(ModelBuilder builder, Guid USER_ROLE_ID, Guid ADMIN_ROLE_ID)
        {
            var userId = Guid.NewGuid();

            var admin = new User
            {
                Id = userId,
                UserName = "admin@projects.kleban.page",
                EmailConfirmed = true,
                NormalizedUserName = "admin@projects.kleban.page".ToUpper(),
                Email = "admin@projects.kleban.page",
                NormalizedEmail = "admin@projects.kleban.page".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Юрій Клебан"
            };

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = "teacher@projects.kleban.page",
                EmailConfirmed = true,
                NormalizedUserName = "teacher@projects.kleban.page".ToUpper(),
                Email = "teacher@projects.kleban.page",
                NormalizedEmail = "teacher@projects.kleban.page".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Іван Петренко"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "123123");
            user.PasswordHash = passwordHasher.HashPassword(user, "123123");

            builder.Entity<User>()
                .HasData(admin, user);

            builder.Entity<IdentityUserRole<Guid>>()
              .HasData(
                  new IdentityUserRole<Guid>
                  {
                      RoleId = ADMIN_ROLE_ID,
                      UserId = userId
                  },
                  new IdentityUserRole<Guid>
                  {
                      RoleId = USER_ROLE_ID,
                      UserId = userId
                  }
              );

            return userId;
        }
    }
}
