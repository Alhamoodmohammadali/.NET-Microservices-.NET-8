using Microsoft.AspNetCore.Http;
namespace EduSpot.Web.Models
{
    public class LectureDto
    {
        public int LectureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? VideoUrl { get; set; }
        public string? VideoLocalPath { get; set; }
        public IFormFile? Video { get; set; }
        public int MaterialId { get; set; }
    }
}
