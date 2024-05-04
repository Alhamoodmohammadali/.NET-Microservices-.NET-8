using EduSpot.Services.MaterialAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace EduSpot.Services.MaterialAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Material> Materials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Material>().HasData(
            new Material
            {
                MaterialId = 1,
                Name = "Computer Skills",
                ArbicName = "مهارات الحاسوب",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "GBS101",
                CountHours = 4,
                MajorId = 1

            },
            new Material
            {
                MaterialId = 2,
                Name = "Introduction to Programming",
                ArbicName = "مقدمة في البرمجة",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IPG101",
                CountHours = 4,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 3,
                Name = "Introduction on-Line Education",
                ArbicName = "مقدمة في التعليم الإلكتروني",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "GBS103",
                CountHours = 4,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 4,
                Name = "Mathe matical Analysls",
                ArbicName = "التحليل الرياضي ",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "GMA101",
                CountHours = 5,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 5,
                Name = "Introduction to Data Modeling",
                ArbicName = "مقدمة في نمذجة المعطيات",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IIS101",
                CountHours = 4,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 6,
                Name = "E-Commerce Technologles",
                ArbicName = "تقانات التجارة الإلكترونية ",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IWB101",
                CountHours = 5,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 7,
                Name = "Procedural Programming",
                ArbicName = "البرمجة الإجرائية",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IPG202",
                CountHours = 5,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 8,
                Name = "Introduction to Networks",
                ArbicName = "مقدمة في الشبكات",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "INT101",
                CountHours = 5,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 9,
                Name = "Introduction to Operating Systems",
                ArbicName = "مقدمة في نظم التشغيل",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IOS101",
                CountHours = 5,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 10,
                Name = "Digital Electronics",
                ArbicName = "إلكترونيات رقمية",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "GDE101",
                CountHours = 5,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 11,
                Name = "Database Archltecture and Design",
                ArbicName = "تصميم وبنيان قواعد المعطيات ",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IIS201",
                CountHours = 5,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 12,
                Name = "Career Preparation",
                ArbicName = "تحضير السيرة المهنية",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "GBS102",
                CountHours = 3,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 13,
                Name = "Web Application Development and Design",
                ArbicName = "تصميم وتطوير تطبيقات الويب",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IWB201",
                CountHours = 6,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 14,
                Name = "Network Operating System",
                ArbicName = "نظم التشغيل الشبكية ",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IOS201",
                CountHours = 5,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 15,
                Name = "Event Driven Programming",
                ArbicName = "البرمجة مقادة بالأحداث",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IPG201",
                CountHours = 5,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 16,
                Name = "Object Oriented Programming",
                ArbicName = "التصميم والبرمجة غرضية التوجه",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IPG203",
                CountHours = 6,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 17,
                Name = "Advanced SQL Programming",
                ArbicName = "البرمجة المتقدمة بلغة SQL",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IIS202",
                CountHours = 6,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 18,
                Name = "windows Platform",
                ArbicName = "منصة ويندز",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IOS202",
                CountHours = 5,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 19,
                Name = "Linux Platform ",
                ArbicName = "منصة لينوكس",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IOS203",
                CountHours = 6,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 20,
                Name = "MS-SQL Server Administration ",
                ArbicName = "إدارة قواعد بيانات",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IIS303",
                CountHours = 6,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 21,
                Name = "Oracle Database Administration ",
                ArbicName = "إدارة قواعد بيانات Oracle",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IIS203",
                CountHours = 6,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 22,
                Name = "Mobile Programming",
                ArbicName = "برمجة التطبيقات النقالة",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IPG204",
                CountHours = 6,
                MajorId = 1
            },
            new Material
            {
                MaterialId = 23,
                Name = "TIC Final Project",
                ArbicName = "مشروع",
                Description = "Description",
                ImageUrl = "https://placehold.co/603x403",
                ShortCut = "IPI201",
                CountHours = 12,
                MajorId = 1
            }

            );
                    modelBuilder.Entity<Material>().HasData(
        new Material
        {
            MaterialId = 24,
            Name = "Computer Skills",
            ArbicName = "مهارات الحاسوب",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "GBS101",
            CountHours = 4,
            MajorId = 2
        
        },
        new Material
        {
            MaterialId = 25,
            Name = "Introduction to Programming",
            ArbicName = "مقدمة في البرمجة",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "IPG101",
            CountHours = 4,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 26,
            Name = "Introduction on-Line Education",
            ArbicName = "مقدمة في التعليم الإلكتروني",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "GBS103",
            CountHours = 4,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 27,
            Name = "Mathe matical Analysls",
            ArbicName = "التحليل الرياضي ",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "GMA101",
            CountHours = 5,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 28,
            Name = "Introduction to Data Modeling",
            ArbicName = "مقدمة في نمذجة المعطيات",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "IIS101",
            CountHours = 4,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 29,
            Name = "E-Commerce Technologles",
            ArbicName = "تقانات التجارة الإلكترونية ",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "IWB101",
            CountHours = 5,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 30,
            Name = "Procedural Programming",
            ArbicName = "البرمجة الإجرائية",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "IPG202",
            CountHours = 5,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 31,
            Name = "Introduction to Networks",
            ArbicName = "مقدمة في الشبكات",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "INT101",
            CountHours = 5,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 32,
            Name = "Introduction to Operating Systems",
            ArbicName = "مقدمة في نظم التشغيل",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "IOS101",
            CountHours = 5,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 33,
            Name = "Digital Electronics",
            ArbicName = "إلكترونيات رقمية",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "GDE101",
            CountHours = 5,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 34,
            Name = "Database Archltecture and Design",
            ArbicName = "تصميم وبنيان قواعد المعطيات ",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "IIS201",
            CountHours = 5,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 35,
            Name = "Career Preparation",
            ArbicName = "تحضير السيرة المهنية",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "GBS102",
            CountHours = 3,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 36,
            Name = "Web Application Development and Design",
            ArbicName = "تصميم وتطوير تطبيقات الويب",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "IWB201",
            CountHours = 6,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 37,
            Name = "Network Operating System",
            ArbicName = "نظم التشغيل الشبكية ",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "IOS201",
            CountHours = 5,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 38,
            Name = "Event Driven Programming",
            ArbicName = "البرمجة مقادة بالأحداث",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "IPG201",
            CountHours = 5,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 39,
            Name = "Object Oriented Programming",
            ArbicName = "التصميم والبرمجة غرضية التوجه",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "IPG203",
            CountHours = 6,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 40,
            Name = "Advanced SQL Programming",
            ArbicName = "البرمجة المتقدمة بلغة SQL",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "IIS202",
            CountHours = 6,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 41,
            Name = "windows Platform",
            ArbicName = "منصة ويندز",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "IOS202",
            CountHours = 5,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 42,
            Name = "Linux Platform ",
            ArbicName = "منصة لينوكس",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "IOS203",
            CountHours = 6,
            MajorId = 2
        },
        new Material
        {
            MaterialId = 43,
            Name = "MS-SQL Server Administration ",
            ArbicName = "إدارة قواعد بيانات",
            Description = "Description",
            ImageUrl = "https://placehold.co/603x403",
            ShortCut = "IIS303",
            CountHours = 6,
            MajorId = 2
        });
        }

    }
}
