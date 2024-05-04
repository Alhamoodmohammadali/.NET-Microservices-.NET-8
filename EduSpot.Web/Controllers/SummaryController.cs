using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using EduSpot.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
namespace EduSpot.Web.Controllers
{
    public class SummaryController : Controller
    {
        private readonly IMaterialService _MaterialService;
        private readonly ISummaryService _SummaryService;
        public SummaryController(ISummaryService SummaryService, IMaterialService MaterialService)
        {
            _MaterialService = MaterialService;
            _SummaryService = SummaryService;
        }
        public async Task<IActionResult> Index()
        {
            List<SummaryDto?> List = new List<SummaryDto?>();
            ResponseDto? response = await _SummaryService.GetAllSummaryAsync();

            if (response != null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<SummaryDto>>(Convert.ToString(response.Result));
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
            VMMaterialSummary vMMaterialSummary = new()
            {

                MaterialList = LIstMaterial.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.MaterialId.ToString()
                })
            };


            if (id == null || id == 0)
            {
                return View(vMMaterialSummary);
            }
            else
            {
                ResponseDto? response = await _SummaryService.GetSummaryByIdAsync((int)id);
                if (response != null && response.IsSuccess)
                {
                    vMMaterialSummary.summary = JsonConvert.DeserializeObject<SummaryDto>(Convert.ToString(response.Result));
                    return View(vMMaterialSummary);
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpSet(VMMaterialSummary model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = new();
                if (model.summary.SummarieId == 0)
                {
                    response = await _SummaryService.CreateSummaryAsync(model.summary);
                }
                else
                {
                    response = await _SummaryService.UpDateSummaryAsync(model.summary);
                }
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Summary Update successfully";

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);

        }
        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _SummaryService.GetSummaryByIdAsync(id);
            if (response != null && response.IsSuccess)
            {
                SummaryDto? model = JsonConvert.DeserializeObject<SummaryDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(SummaryDto model)
        {
            ResponseDto? response = await _SummaryService.DeleteSummaryAsync(model.SummarieId);
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