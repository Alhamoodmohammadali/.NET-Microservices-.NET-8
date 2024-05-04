using EduSpot.Web.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace EduSpot.Web.Models
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
        [ValidateNever]
        public UniversityDto University { get; set; }
        [MaxFileSize(50)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile? Image { get; set; }
        [MaxFileSize(100)]
        [AllowedExtensions(new string[] { ".mp4", ".mov", ".avi" })]
        public IFormFile? Pdf { get; set; }

    }
}
