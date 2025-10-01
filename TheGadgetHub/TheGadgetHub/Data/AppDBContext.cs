using Microsoft.EntityFrameworkCore;
using TheGadgetHub.Models;

namespace TheGadgetHub.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        // Tables
        public DbSet<User> Users { get; set; }
        public DbSet<GlobalProductCatlog> GlobalProductCatlogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Enforce unique constraint on Email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Optional: Configure table names explicitly
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<GlobalProductCatlog>().ToTable("GlobalProductCatlog");
        }
    }
}
