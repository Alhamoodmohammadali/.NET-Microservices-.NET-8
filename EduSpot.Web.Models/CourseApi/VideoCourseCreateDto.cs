using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.Models.CourseApi
{
    public class VideoCourseCreateDto
    {
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? VideoURl { get; set; }
        public string? VideoLocalPath { get; set; }
        public IFormFile Video { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
