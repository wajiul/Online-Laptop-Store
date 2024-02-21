﻿using LaptopStoreAPI.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopStoreAPI.Persistence
{
    public class LaptopStoreDbContext: DbContext
    {
        public LaptopStoreDbContext(DbContextOptions<LaptopStoreDbContext> options): base(options)
        {
            
        }
        public DbSet<Processor> processors { get; set; }
        public DbSet<Ram> rams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Processor>()
                .HasIndex(p => new { p.Model})
                .IsUnique();

            modelBuilder.Entity<Ram>()
                .HasIndex(r => new { r.Model})
                .IsUnique();

        }
    }
}
