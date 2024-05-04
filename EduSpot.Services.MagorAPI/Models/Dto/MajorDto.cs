using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EduSpot.Services.MagorAPI.Models.Dto
{
    public class MajorDto
    {
        public int MajorId { get; set; }
        public string Name { get; set; }
        public string ArbicName { get; set; }
        public string Description { get; set; }
        public int CountHours { get; set; }
        public string ShortCut { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        public string? PdfUrl { get; set; }
        public string? PdfLocalPath { get; set; }
        public int UniversityId { get; set; }
        public IFormFile? Image { get; set; }
        public IFormFile? Pdf { get; set; }

    }
}
