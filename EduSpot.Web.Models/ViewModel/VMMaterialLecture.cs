using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.Models.ViewModel
{
    public class VMMaterialLecture
    {
        public VMMaterialLecture()
        {
            Lecture = new LectureDto();
        }
        public LectureDto Lecture { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> MaterialList { get; set; }

    }
}
