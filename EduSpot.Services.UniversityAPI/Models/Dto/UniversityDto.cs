namespace EduSpot.Services.UniversityAPI.Models.Dto
{
    public class UniversityDto
    {
        public int UniversityId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        public IFormFile? Image { get; set; }
    }
}
