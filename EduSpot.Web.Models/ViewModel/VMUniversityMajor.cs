using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace EduSpot.Web.Models.ViewModel
{
    public class VMUniversityMajor
    {
        public VMUniversityMajor()
        {
            majorDto = new MajorDto();
        }
        public MajorDto majorDto { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> UniversityList { get; set; }
    }
}