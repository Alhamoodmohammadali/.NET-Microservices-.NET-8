using EduSpot.Services.LectureAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EduSpot.Services.LectureAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Lecture> Lectures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
