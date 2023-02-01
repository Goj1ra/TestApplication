using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>();
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Category>();
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.Products)
                .WithOne(x => x.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
