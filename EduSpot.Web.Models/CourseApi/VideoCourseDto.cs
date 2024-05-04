using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.Models.CourseApi
{
    public class VideoCourseDto
    {
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? VideoURl { get; set; }
        public string? VideoLocalPath { get; set; }
        public IFormFile Video { get; set; }
        public CourceDto cource { get; set; }

    }
}
