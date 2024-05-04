using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EduSpot.Services.UniversityAPI.Models
{
    public class University
    {
        [Key]
        public int UniversityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }

    }
}