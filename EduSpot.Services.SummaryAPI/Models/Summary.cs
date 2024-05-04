using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduSpot.Services.SummaryAPI.Models
{
    public class Summary
    {

        [Key]
        public int SummarieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? PdfUrl { get; set; }
        public string? PdfLocalPath { get; set; }
        public int MaterialId { get; set; }

    }
}
