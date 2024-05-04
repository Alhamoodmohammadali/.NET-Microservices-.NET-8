using EduSpot.Web.Models.CourseApi;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.Models.ViewModel.CourseApi
{
    public class VMVideoCourseCreate
    {
        public VMVideoCourseCreate()
        {
            video = new VideoCourseCreateDto();
        }
        public VideoCourseCreateDto video { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? CategoryList { get; set; }
    }
}
