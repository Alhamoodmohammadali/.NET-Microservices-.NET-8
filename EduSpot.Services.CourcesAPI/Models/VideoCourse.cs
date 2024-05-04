using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduSpot.Services.CourcesAPI.Models
{
    public class VideoCourse
    {
        [Key]
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? VideoURl { get; set; }
        public string? VideoLocalPath { get; set; }
        [ForeignKey("cource")]
        public int CourseId { get; set; }
        public Cource cource { get; set; }

    }
}