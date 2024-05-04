using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.Models.CourseApi
{
    public class CourceDto
    {
        public int CourceId { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public string? VideoURl { get; set; }
        public string? VideoLocalPath { get; set; }
        public IFormFile Video { get; set; }
        public int Count { get; set; }
        public CategoryDto category { get; set; }

    }
}
