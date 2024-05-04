using System.ComponentModel.DataAnnotations;
namespace EduSpot.Services.CourcesAPI.Models.Dto
{
    public class CourceCreateDto
    {
        public int CourceId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? VideoURl { get; set; }
        public string? VideoLocalPath { get; set; }
        public IFormFile Video { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
