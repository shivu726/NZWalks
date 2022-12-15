using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;

namespace NZWalks.Data
{
    public class WalkDbContext:DbContext
    {
        public WalkDbContext(DbContextOptions<WalkDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole_Model>()
                .HasOne(x => x.Roles)
                .WithMany(a => a.UserRole)
                .HasForeignKey(x => x.Role_Id);

            modelBuilder.Entity<UserRole_Model>()
                .HasOne(x => x.Users)
                .WithMany(a => a.UserRole)
                .HasForeignKey(x => x.UserId);
        }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<WalkDifficulty> WalkDifficulties { get; set; }

        public DbSet<UserInfo> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole_Model> UserRoles { get; set; }
    }
}
