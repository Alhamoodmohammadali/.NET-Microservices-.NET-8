using EduSpot.Services.CourcesAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace EduSpot.Services.CourcesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cource> Cources { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<VideoCourse> video { get; set; }

    }
}
