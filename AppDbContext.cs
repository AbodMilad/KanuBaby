using kanusaoft1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kanusaoft1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        public DbSet<supplement> supplements { get; set; }
        public DbSet<location> locations { get; set; }
        public DbSet<TankItem> TankItems { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestDetail> RequestDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<supplement>().HasData(new supplement { name = "Water", amount = 30 });
            modelBuilder.Entity<supplement>().HasData(new supplement { name = "Gazoline", amount = 30 });
            modelBuilder.Entity<supplement>().HasData(new supplement { name = "Disel", amount = 30 });

            modelBuilder.Entity<location>().HasData(new location { name = "Mimar", address = "Wsta" });
            modelBuilder.Entity<location>().HasData(new location { name = "Shamomar", address = "4rbye" });
            modelBuilder.Entity<location>().HasData(new location { name = "al-slam", address = "al-whde str" });

        }

    }
}
