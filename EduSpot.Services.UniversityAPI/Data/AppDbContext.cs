using EduSpot.Services.UniversityAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EduSpot.Services.UniversityAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { 
        }
        public DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<University>().HasData(
           new University
           {
               UniversityId = 1,
               Name = "Syrian Virtual University",
               Location = "Syrian",
               ImageUrl = "https://placehold.co/603x403",

               Description = @"The Syrian Virtual University is distinguished by offering flexible  
                                    and accessible online academic programs, 
                                    allowing students to study at any time and from anywhere that suits them.
                                    The university also focuses on providing excellent technical and academic 
                                    support to students to ensure their academic success"
           },
           new University
           {
               UniversityId = 2,
               Name = "Damascus International University",
               Location = "Damascus",
               ImageUrl = "https://placehold.co/603x403",
               Description = @"Damascus International University is considered one of the leading universities in Syria,\n
                                    providing high-quality education in a variety of academic disciplines.\n
                                    The university aims to develop students' skills and enhance their capabilities \n
                                    through comprehensive academic programs and updated curricula that meet the needs of the job market.\n
                                    The university is characterized by a modern academic environment and advanced facilities that facilitate\n
                                    the learning process and motivate students to achieve their academic and professional goals.\n"
           },
           new University
           {
               UniversityId = 3,
               Name = "Syrian Private University",
               Location = "Damascus",
               ImageUrl = "https://placehold.co/603x403",
               Description = @"The Syrian Private University is considered a prestigious educational destination in Syria, \n
                                   providing a distinctive learning environment that helps students achieve their academic and professional goals. \n
                                   The university is known for offering diverse academic programs covering a wide range of specialties, \n
                                   allowing students to choose the field that suits their interests and professional inclinations. Additionally,\n
                                   the university provides modern infrastructure and educational facilities equipped with the latest technologies,\n
                                   which help enhance the learning process and develop students' skills effectively"

           });

        }

    }
}

