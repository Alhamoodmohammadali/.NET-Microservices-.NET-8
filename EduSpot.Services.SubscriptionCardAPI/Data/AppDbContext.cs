using EduSpot.Services.SubscriptionCardAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace EduSpot.Services.SubscriptionCardAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

    }
}
