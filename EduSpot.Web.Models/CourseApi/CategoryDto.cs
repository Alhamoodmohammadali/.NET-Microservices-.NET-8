using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.Models.CourseApi
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; }
    }
}
