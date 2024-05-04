using System.ComponentModel.DataAnnotations;

namespace EduSpot.Services.CourcesAPI.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
