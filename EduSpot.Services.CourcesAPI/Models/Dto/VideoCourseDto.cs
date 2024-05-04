namespace EduSpot.Services.CourcesAPI.Models.Dto
{
    public class VideoCourseDto
    {
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? VideoURl { get; set; }
        public string? VideoLocalPath { get; set; }
        public IFormFile Video { get; set; }
        public Cource cource { get; set; }

    }
}
