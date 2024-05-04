using EduSpot.Web.Utility;
using Microsoft.AspNetCore.Http;
namespace EduSpot.Web.Models
{
    public class UniversityDto
    {
        public int UniversityId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        [MaxFileSize(50)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile? Image { get; set; }
    }
}
