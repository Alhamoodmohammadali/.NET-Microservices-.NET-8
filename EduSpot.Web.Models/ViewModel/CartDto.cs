using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.Models.ViewModel
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailsDto>? CartDetails { get; set; }
    }
}
