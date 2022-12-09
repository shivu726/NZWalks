using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;

namespace NZWalks.Data
{
    public class WalkDbContext:DbContext
    {
        public WalkDbContext(DbContextOptions<WalkDbContext> options): base(options)
        {

        }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<WalkDifficulty> walkDifficulties { get; set; }
    }
}
