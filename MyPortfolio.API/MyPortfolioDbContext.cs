using Microsoft.EntityFrameworkCore;
using MyPortfolio.API.Entities;
using System.Reflection;

namespace MyPortfolio.API
{
    public class MyPortfolioDbContext : DbContext
    {
        public DbSet<PortfolioType> PortfolioTypes { get;set;}
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioSummary> PortfolioSummaries { get; set; }
        public DbSet<PortfolioUser> PortfolioUsers { get; set; }
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
                entity.HasIndex(e => e.IsActive).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Skill>().ToTable("Skill");
            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.Description).IsUnique();
                entity.HasIndex(e => e.IsActive).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Portfolio>().ToTable("Portfolio");
            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.ContactNumber).IsUnique();
                entity.HasIndex(e => e.SkypeId).IsUnique();
                entity.HasIndex(e => e.Linkedin).IsUnique();
                entity.HasIndex(e => e.Twitter).IsUnique();
                entity.HasIndex(e => e.IsActive).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            modelBuilder.Entity<PortfolioSummary>().ToTable("PortfolioSummary");
            modelBuilder.Entity<PortfolioSummary>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasIndex(e => e.PortfolioID).IsUnique();
                entity.HasIndex(e => e.Title).IsUnique();
                entity.HasIndex(e => e.ShortTitle).IsUnique();
                entity.HasIndex(e => e.Summary).IsUnique();
                entity.HasIndex(e => e.IsActive).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            modelBuilder.Entity<PortfolioSummary>()
              .HasOne(x => x.Portfolio)
              .WithMany(d => d.PortfolioSummaries)
              .HasForeignKey(x => x.PortfolioID)
              .IsRequired();
            modelBuilder.Entity<Portfolio>()
                .HasMany(x => x.PortfolioSummaries)
                .WithOne(p => p.Portfolio)
                .IsRequired();

            modelBuilder.Entity<PortfolioUser>().ToTable("PortfolioUser");
            modelBuilder.Entity<PortfolioUser>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasIndex(e => e.PortfolioID).IsUnique();
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.ContactNumber).IsUnique();
                entity.HasIndex(e => e.SkypeId).IsUnique();
                entity.HasIndex(e => e.Linkedin).IsUnique();
                entity.HasIndex(e => e.Twitter).IsUnique();
                entity.HasIndex(e => e.Others).IsUnique();
                entity.HasIndex(e => e.IsActive).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<PortfolioUser>()
                  .HasOne(x => x.Portfolio)
                  .WithMany(x => x.PortfolioUsers)
                  .HasForeignKey(x => x.PortfolioID);
            modelBuilder.Entity<Portfolio>()
                .HasMany(x => x.PortfolioUsers)
                .WithOne(x => x.Portfolio)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

    }
}
