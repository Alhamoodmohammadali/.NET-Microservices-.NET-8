using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using EduSpot.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
namespace EduSpot.Web.Controllers
{
    public class MajorController : Controller
    {
        private readonly IMajorService _majorService;
        private readonly IUniversityService _universityService;
        public MajorController(IMajorService majorService, IUniversityService universityService)
        {
            _majorService = majorService;
            _universityService = universityService;
        }
        public async Task<IActionResult> Index()
        {
            List<MajorDto?> List = new List<MajorDto?>();
            ResponseDto? response = await _majorService.GetAllMajorAsync();

            if (response != null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<MajorDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(List);
        }
        public async Task<IActionResult> UpSet(int? id)
        {
            List<UniversityDto?> ListUniversity = new List<UniversityDto?>();
            ResponseDto? responseZUniversity = await _universityService.GetAllUniversityAsync();
            if (responseZUniversity != null && responseZUniversity.IsSuccess)
            {
                ListUniversity = JsonConvert.DeserializeObject<List<UniversityDto>>(Convert.ToString(responseZUniversity.Result));
            }

            VMUniversityMajor vMUniversityMajor = new()
            {

                UniversityList = ListUniversity.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.UniversityId.ToString()
                }),
                majorDto = new MajorDto()
            };
            if (id == null || id == 0)
            {
                return View(vMUniversityMajor);
            }
            else
            {
                ResponseDto? response = await _majorService.GetMajorByIdAsync((int)id);
                if (response != null && response.IsSuccess)
                {
                    vMUniversityMajor.majorDto = JsonConvert.DeserializeObject<MajorDto>(Convert.ToString(response.Result));
                    return View(vMUniversityMajor);
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpSet(VMUniversityMajor model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = new();
                if (model.majorDto.MajorId == 0)
                {
                    response = await _majorService.CreateMajorAsync(model.majorDto);
                }
                else
                {
                    response = await _majorService.UpDateMajorAsync(model.majorDto);
                }
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Major Update successfully";

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);

        }
        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _majorService.GetMajorByIdAsync(id);
            if (response != null && response.IsSuccess)
            {
                MajorDto? model = JsonConvert.DeserializeObject<MajorDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(MajorDto model)
        {
            ResponseDto? response = await _majorService.DeleteMajorAsync(model.MajorId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Major deleted successfully";

                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(model);
        }
    }
}
