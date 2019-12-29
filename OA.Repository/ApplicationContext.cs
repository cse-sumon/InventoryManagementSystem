using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repository
{
   public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
