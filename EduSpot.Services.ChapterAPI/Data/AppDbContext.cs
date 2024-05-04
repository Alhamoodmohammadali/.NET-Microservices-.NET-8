using EduSpot.Services.ChapterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EduSpot.Services.ChapterAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Chapter> Chapters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
