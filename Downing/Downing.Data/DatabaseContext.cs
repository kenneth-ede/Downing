using Downing.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Downing.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Investor> Investors { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasKey(x => x.Id);
            modelBuilder.Entity<Company>().Property(x => x.CompanyName).HasMaxLength(100);
            modelBuilder.Entity<Company>().Property(x => x.Code).HasMaxLength(100);
            modelBuilder.Entity<Company>().Property(x => x.SharePrice).HasPrecision(18, 4);

            modelBuilder.Entity<Investor>().HasKey(x => x.Id);
            modelBuilder.Entity<Investor>().HasOne(x => x.Company);
            modelBuilder.Entity<Investor>().Property(x => x.Title).HasMaxLength(100);
            modelBuilder.Entity<Investor>().Property(x => x.FirstName).HasMaxLength(100);
            modelBuilder.Entity<Investor>().Property(x => x.LastName).HasMaxLength(100);
        }
    }
}
