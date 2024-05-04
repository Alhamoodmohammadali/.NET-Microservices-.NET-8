using EduSpot.Web.Models.CourseApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.Models
{
    public class OrderDetailsDto
    {
        public int OrderDetailsId { get; set; }
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public CourceDto? Cource { get; set; }
        public int Count { get; set; }
        public string CourceName { get; set; }
        public double Price { get; set; }
    }
}
