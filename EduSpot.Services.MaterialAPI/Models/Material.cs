using System.ComponentModel.DataAnnotations;

namespace EduSpot.Services.MaterialAPI.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ArbicName { get; set; }
        [Required]
        public string Description { get; set; }
        public int CountHours { get; set; }
        public string? ShortCut { get; set; }

        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        public string? PdfUrl { get; set; }
        public string? PdfLocalPath { get; set; }
        public int MajorId { get; set; }

    }
}
