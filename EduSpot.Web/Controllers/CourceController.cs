using EduSpot.Web.Models.CourseApi;
using EduSpot.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EduSpot.Web.DataAccess.Services.IServices.ICourseApi;
namespace EduSpot.Web.Controllers
{
    public class CourceController : Controller
    {
        private readonly ICourceService _courceService;
        public CourceController(ICourceService courceService)
        {
            _courceService = courceService;
        }
        public async Task<IActionResult> Index()
        {

            List<CourceDto?> List = new List<CourceDto?>();
            ResponseDto? response = await _courceService.GetAllCourceAsync();
            if (response != null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<CourceDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(List);
        }
        public async Task<IActionResult> UpSet(int? id)
        {
            CourceDto? model = new();
            if (id == null || id == 0)
            {
                return View(model);

            }
            else
            {
                ResponseDto? response = await _courceService.GetCourceByIdAsync((int)id);
                if (response != null && response.IsSuccess)
                {
                    model = JsonConvert.DeserializeObject<CourceDto>(Convert.ToString(response.Result));
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
        public async Task<IActionResult> UpSet(CourceCreateDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = new();
                if (model.CourceId == 0)
                {
                    response = await _courceService.CreateCourceAsync(model);
                }
                else
                {

                    //response = await _courceService.UpDateCourceAsync(model);
                }
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Cource Update successfully";

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);

        }
        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _courceService.GetCourceByIdAsync(id);
            if (response != null && response.IsSuccess)
            {
                CourceDto? model = JsonConvert.DeserializeObject<CourceDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CourceDto Cource)
        {
            ResponseDto? response = await _courceService.DeleteCourceAsync(Cource.CourceId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "coupon deleted successfully";

                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(Cource);
        }

    }
}
