using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Protocol;
using System;

namespace FireDepartmentManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            var adminRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
            };

            var userRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
            };

            builder.Entity<IdentityRole>().HasData(
                  new IdentityRole { Id = adminRole.Id, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
                  new IdentityRole { Id = userRole.Id, Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString() }
              );


            var adminEmail = "admin@admin.com";
            var adminPassword = "Admin123!@#";
            var hasher = new PasswordHasher<IdentityUser>();
            var adminUser = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper(),
                UserName = adminEmail,
                NormalizedUserName = adminEmail.ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, adminPassword);

            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = adminUser.Id,
                    UserName = adminEmail,
                    NormalizedUserName = adminEmail.ToUpper(),
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(adminUser, adminPassword),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRole.Id,
                    UserId = adminUser.Id
                }
            );

        }
    }
}