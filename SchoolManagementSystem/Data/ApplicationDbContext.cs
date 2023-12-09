using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using System.Collections.Generic;
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // entity configurations

            new ApplicationUserConfigurations().Configure(builder.Entity<ApplicationUser>());



            // Identity Tables
            builder.Entity<ApplicationUser>().ToTable("Users", schema: "Identity");
            builder.Entity<IdentityRole>().ToTable("Roles", schema: "Identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", schema: "Identity");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", schema: "Identity");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", schema: "Identity");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", schema: "Identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", schema: "Identity");


            // data seedding

            // create Roles

            string AdminRoleId = Guid.NewGuid().ToString();
            string AdminId = Guid.NewGuid().ToString();


                // Roles
                builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                    {
                        Id = AdminRoleId,
                        Name = "Admin",
                        NormalizedName = "Admin"
                    },
                new IdentityRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Teacher",
                        NormalizedName = "Teacher"
                    },
                new IdentityRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Student",
                        NormalizedName = "Student"
                    }
                );

            //  create system admin

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
                    new ApplicationUser
                    {
                        Id=AdminId,
                        UserName="Admin",
                        NormalizedUserName="Admin",
                        Email="admin@site.com",
                        NormalizedEmail = "admin@site.com",
                        EmailConfirmed= true,
                        PasswordHash = hasher.HashPassword(null, "12345678"),
                        SecurityStamp = string.Empty

                    });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = AdminRoleId,
                UserId = AdminId
            });


        }

    }
}
