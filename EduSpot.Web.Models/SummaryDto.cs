using EduSpot.Web.Utility;
using Microsoft.AspNetCore.Http;

namespace EduSpot.Web.Models
{
    public class SummaryDto
    {
        public int SummarieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? PdfUrl { get; set; }
        public string? PdfLocalPath { get; set; }
        [MaxFileSize(50)]
        [AllowedExtensions(new string[] { ".pdf"})]
        public IFormFile? Pdf { get; set; }
        public int MaterialId { get; set; }
    }
}
