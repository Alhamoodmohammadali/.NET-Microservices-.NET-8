using EduSpot.Services.SummaryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EduSpot.Services.SummaryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Summary> Summaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
