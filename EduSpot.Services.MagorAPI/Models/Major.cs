using EduSpot.Services.MagorAPI.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduSpot.Services.MagorAPI.Models
{
    public class Major
    {

        [Key]
        public int MajorId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ArbicName { get; set; }
        [Required]
        public string Description { get; set; }
        public int CountHours { get; set; }
        public string ShortCut { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        public string? PdfUrl { get; set; }
        public string? PdfLocalPath { get; set; }
        public int UniversityId { get; set; }

    }
}
