using Microsoft.EntityFrameworkCore;
using MyPortfolio.API.Entities;
using System.Reflection;

namespace MyPortfolio.API
{
    public class MyPortfolioDbContext : DbContext
    {
        public DbSet<PortfolioType> PortfolioTypes { get;set;}
        public DbSet<Skill> Skills { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database\\MyPortfolioLiteDB.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<PortfolioType>().ToTable("PortfolioType");
            modelBuilder.Entity<PortfolioType>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasIndex(e => e.Type).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Skill>().ToTable("Skill");
            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.Description).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
