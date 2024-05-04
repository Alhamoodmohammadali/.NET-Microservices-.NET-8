using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using EduSpot.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
namespace EduSpot.Web.Controllers
{
    public class ChapterController : Controller
    {
        private readonly IMaterialService _MaterialService;
        private readonly IChapterService _ChapterService;
        public ChapterController(IChapterService ChapterService, IMaterialService MaterialService)
        {
            _MaterialService = MaterialService;
            _ChapterService = ChapterService;
        }
        public async Task<IActionResult> Index()
        {
            List<ChapterDto?> List = new List<ChapterDto?>();
            ResponseDto? response = await _ChapterService.GetAllChapterAsync();

            if (response != null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<ChapterDto>>(Convert.ToString(response.Result));
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
            VMMaterialChapter vMMaterialChapter = new()
            {

                MaterialList = LIstMaterial.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.MaterialId.ToString()
                })
            };


            if (id == null || id == 0)
            {
                return View(vMMaterialChapter);
            }
            else
            {
                ResponseDto? response = await _ChapterService.GetChapterByIdAsync((int)id);
                if (response != null && response.IsSuccess)
                {
                    vMMaterialChapter.Chapter = JsonConvert.DeserializeObject<ChapterDto>(Convert.ToString(response.Result));
                    return View(vMMaterialChapter);
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpSet(VMMaterialChapter model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = new();
                if (model.Chapter.ChapterId == 0)
                {
                    response = await _ChapterService.CreateChapterAsync(model.Chapter);
                }
                else
                {
                    response = await _ChapterService.UpDateChapterAsync(model.Chapter);
                }
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Chapter Update successfully";

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _ChapterService.GetChapterByIdAsync(id);
            if (response != null && response.IsSuccess)
            {
                ChapterDto? model = JsonConvert.DeserializeObject<ChapterDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ChapterDto model)
        {
            ResponseDto? response = await _ChapterService.DeleteChapterAsync(model.ChapterId);
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
