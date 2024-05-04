using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using EduSpot.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EduSpot.Web.Controllers
{
    public class LectureController : Controller
    {

        private readonly IMaterialService _MaterialService;
        private readonly ILectureService _LectureService;
        public LectureController(ILectureService LectureService, IMaterialService MaterialService)
        {
            _MaterialService = MaterialService;
            _LectureService = LectureService;
        }
        public async Task<IActionResult> Index()
        {
            List<LectureDto?> List = new List<LectureDto?>();
            ResponseDto? response = await _LectureService.GetAllLectureAsync();

            if (response != null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<LectureDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(List);
        }
        public async Task<IActionResult> UpSet(int? id)
        {
            List<MaterialDto?> LIstMaterial = new();
            ResponseDto? responseZUniversity = await _MaterialService.GetAllMaterialAsync();
            if (responseZUniversity != null && responseZUniversity.IsSuccess)
            {
                LIstMaterial = JsonConvert.DeserializeObject<List<MaterialDto>>(Convert.ToString(responseZUniversity.Result));
            }
            VMMaterialLecture vMMaterialLecture = new()
            {

                MaterialList = LIstMaterial.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.MaterialId.ToString()
                })
            };


            if (id == null || id == 0)
            {
                return View(vMMaterialLecture);
            }
            else
            {
                ResponseDto? response = await _LectureService.GetLectureByIdAsync((int)id);
                if (response != null && response.IsSuccess)
                {
                    vMMaterialLecture.Lecture = JsonConvert.DeserializeObject<LectureDto>(Convert.ToString(response.Result));
                    return View(vMMaterialLecture);
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpSet(VMMaterialLecture model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = new();
                if (model.Lecture.LectureId == 0)
                {
                    response = await _LectureService.CreateLectureAsync(model.Lecture);
                }
                else
                {
                    response = await _LectureService.UpDateLectureAsync(model.Lecture);
                }
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Lecture Update successfully";

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);

        }
        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _LectureService.GetLectureByIdAsync(id);
            if (response != null && response.IsSuccess)
            {
                LectureDto? model = JsonConvert.DeserializeObject<LectureDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(LectureDto model)
        {
            ResponseDto? response = await _LectureService.DeleteLectureAsync(model.LectureId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Material deleted successfully";

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
