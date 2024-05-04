using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EduSpot.Services.CourcesAPI.Models
{
    public class Cource
    {
        [Key]
        public int CourceId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public string? VideoURl { get; set; }
        public string? VideoLocalPath { get; set; }
        [ForeignKey("category")]
        public int CategoryId { get; set; }
        public Category category  { get; set; }
    }
}
