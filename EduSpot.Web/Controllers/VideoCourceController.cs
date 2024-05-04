using EduSpot.Web.DataAccess.Services.IServices.ICourseApi;
using EduSpot.Web.Models;
using EduSpot.Web.Models.CourseApi;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace EduSpot.Web.Controllers
{
    public class VideoCourceController : Controller
    {
        private readonly IVideoCourceService _videoCourceService;
        public VideoCourceController(IVideoCourceService videoCourceService)
        {
            _videoCourceService = videoCourceService;
        }
        public async Task<IActionResult> Index()
        {
            List<VideoCourseDto?> List = new ();
            ResponseDto? response = await _videoCourceService.GetAllVideoCourceAsync();
            if (response != null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<VideoCourseDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(List);
        }
        public async Task<IActionResult> UpSet(int? id)
        {
            VideoCourseDto? model = new();
            if (id == null || id == 0)
            {
                return View(model);

            }
            else
            {
                ResponseDto? response = await _videoCourceService.GetVideoCourceByIdAsync((int)id);
                if (response != null && response.IsSuccess)
                {
                    model = JsonConvert.DeserializeObject<VideoCourseDto>(Convert.ToString(response.Result));
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
        public async Task<IActionResult> UpSet(VideoCourseCreateDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = new();
                if (model.VideoId == 0)
                {
                    response = await _videoCourceService.CreateVideoCourceAsync(model);
                }
                else
                {

                    response = await _videoCourceService.UpDateVideoCourceAsync(model);
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
            ResponseDto? response = await _videoCourceService.GetVideoCourceByIdAsync(id);
            if (response != null && response.IsSuccess)
            {
                VideoCourseDto? model = JsonConvert.DeserializeObject<VideoCourseDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(VideoCourseDto mdoel)
        {
            ResponseDto? response = await _videoCourceService.DeleteVideoCourceAsync(mdoel.VideoId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "coupon deleted successfully";

                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(mdoel);
        }

    }
}
