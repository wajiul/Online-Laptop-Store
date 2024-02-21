using LaptopStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopStoreAPI.Persistence
{
    public class LaptopStoreDbContext: DbContext
    {
        public LaptopStoreDbContext(DbContextOptions<LaptopStoreDbContext> options): base(options)
        {
            
        }
        public DbSet<Processor> processors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Processor>()
                .HasIndex(p => new { p.Model})
                .IsUnique();
        }
    }
}
