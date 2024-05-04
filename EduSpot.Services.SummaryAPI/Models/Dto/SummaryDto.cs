namespace EduSpot.Services.SummaryAPI.Models.Dto
{
    public class SummaryDto
    {
        public int SummarieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? PdfUrl { get; set; }
        public string? PdfLocalPath { get; set; }
        public IFormFile? Pdf { get; set; }
        public int MaterialId { get; set; }
    }
}
