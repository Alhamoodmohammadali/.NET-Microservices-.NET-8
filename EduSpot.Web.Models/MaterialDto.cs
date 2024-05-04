﻿using Microsoft.AspNetCore.Http;

namespace EduSpot.Web.Models
{
    public class MaterialDto
    {
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public string ArbicName { get; set; }
        public string Description { get; set; }
        public int CountHours { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        public IFormFile? Image { get; set; }
        public string? PdfUrl { get; set; }
        public string? PdfLocalPath { get; set; }
        public IFormFile? Pdf { get; set; }
        public int MajorId { get; set; }    
    }
}