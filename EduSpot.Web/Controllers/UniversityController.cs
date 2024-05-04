using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace EduSpot.Web.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IUniversityService _universityService;
        public UniversityController(IUniversityService universityService)
        {
            _universityService = universityService;
        }
        public async Task<IActionResult> UniversityIndex()
        {

            List<UniversityDto?> List = new List<UniversityDto?>();
            ResponseDto? response = await _universityService.GetAllUniversityAsync();
            if (response != null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<UniversityDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(List);
        }
        public async Task<IActionResult> UpSet(int? Universityid)
        {
            UniversityDto? model = new();
            if (Universityid == null || Universityid == 0)
            {
                return View(model);

            }
            else
            {
                ResponseDto? response = await _universityService.GetUniversityByIdAsync((int)Universityid);
                if (response != null && response.IsSuccess)
                {
                    model = JsonConvert.DeserializeObject<UniversityDto>(Convert.ToString(response.Result));
                    return View(model);
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpSet(UniversityDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = new();
                if (model.UniversityId == 0)
                {
                    response = await _universityService.CreateUniversityAsync(model);
                }
                else
                {
                    response = await _universityService.UpDateUniversityAsync(model);
                }
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "university Update successfully";

                    return RedirectToAction(nameof(UniversityIndex));
                }
            }
            return View(model);

        }
   
        
        
        
        public async Task<IActionResult> UniversityDelete(int Universityid)
        {
            ResponseDto? response = await _universityService.GetUniversityByIdAsync(Universityid);
            if (response != null && response.IsSuccess)
            {
                UniversityDto? model = JsonConvert.DeserializeObject<UniversityDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> UniversityDelete(UniversityDto university)
        {
            ResponseDto? response = await _universityService.DeleteUniversityAsync(university.UniversityId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "coupon deleted successfully";

                return RedirectToAction(nameof(UniversityIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(university);
        }
  
    
    }
}
