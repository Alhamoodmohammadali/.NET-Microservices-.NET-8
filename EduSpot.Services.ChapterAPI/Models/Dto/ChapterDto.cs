namespace EduSpot.Services.ChapterAPI.Models.Dto
{
    public class ChapterDto
    {
        public int ChapterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? PdfUrl { get; set; }
        public string? PdfLocalPath { get; set; }
        public int MaterialId { get; set; }
        public IFormFile? Pdf { get; set; }
    }
}
