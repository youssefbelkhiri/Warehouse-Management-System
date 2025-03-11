using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Backend.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Movement> Movements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);


            List<IdentityRole> Roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Name="Admin",
                    NormalizedName="ADMIN"
                },
                new IdentityRole()
                {
                    Name="SuperAdmin",
                    NormalizedName="SUPERADMIN"
                },
                new IdentityRole()
                {
                    Name="visiter",
                    NormalizedName="VISITER"
                }

            };
            builder.Entity<IdentityRole>().HasData(Roles);

        }
    }
}
