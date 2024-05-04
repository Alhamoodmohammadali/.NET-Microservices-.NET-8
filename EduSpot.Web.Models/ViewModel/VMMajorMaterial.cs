using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.Models.ViewModel
{
    public class VMMajorMaterial
    {
        public VMMajorMaterial()
        {
            material = new MaterialDto();
        }
        public MaterialDto material { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> MajorList { get; set; }
    }
}
