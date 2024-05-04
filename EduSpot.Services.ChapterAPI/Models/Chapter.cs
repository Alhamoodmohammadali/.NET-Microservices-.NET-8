using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduSpot.Services.ChapterAPI.Models
{
    public class Chapter
    {
        [Key]
        public int ChapterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? PdfUrl { get; set; }
        public string? PdfLocalPath { get; set; }
        public int MaterialId { get; set; }
    }
}
