using EduSpot.Services.MagorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EduSpot.Services.MagorAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Major> Majors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

     
            modelBuilder.Entity<Major>().HasData(new Major
            {
                MajorId = 1,
                Name = "Tincncal Iinternal City",
                ArbicName = "معهد التقاني للحاسوب ",
                Description = @"allowing students to study at any time and from anywhere that suits them.
                                The university also focuses on providing excellent technical and academic 
                                support to students to ensure their academic success
                ",
                CountHours = 60,
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "TIC",
                UniversityId = 1
            });
            modelBuilder.Entity<Major>().HasData(new Major
            {
                MajorId = 2,
                Name = "B incncal Binternal Bity",
                ArbicName = "كلية التقاني للحاسوب ",
                Description = @"allowing students to study at any time and from anywhere that suits them.
                                The university also focuses on providing excellent technical and academic 
                                support to students to ensure their academic success",
                CountHours = 120,
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "Bait ",
                UniversityId = 1

            });
        }
    }
}
