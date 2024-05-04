using System.ComponentModel.DataAnnotations;
namespace EduSpot.Services.LectureAPI.Models
{
    public class Lecture
    {
        [Key]
        public int LectureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? VideoUrl { get; set; }
        public string? VideoLocalPath { get; set; }
        public int MaterialId { get; set; }
    }
}
