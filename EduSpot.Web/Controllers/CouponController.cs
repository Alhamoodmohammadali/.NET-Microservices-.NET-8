using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace EduSpot.Web.Controllers
{
    public class CouponController : Controller
    {

        private readonly ICouponService _CouponService;
        public CouponController(ICouponService CouponService)
        {
            _CouponService = CouponService;
        }
        public async Task<IActionResult> Index()
        {

            List<CouponDto?> List = new List<CouponDto?>();
            ResponseDto? response = await _CouponService.GetAllCouponAsync();
            if (response != null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(List);
        }
        public async Task<IActionResult> UpSet(int? id)
        {
            CouponDto? model = new();
            if (id == null || id == 0)
            {
                return View(model);

            }
            else
            {
                ResponseDto? response = await _CouponService.GetCouponByIdAsync((int)id);
                if (response != null && response.IsSuccess)
                {
                    model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
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
        public async Task<IActionResult> UpSet(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = new();
                if (model.CouponId == 0)
                {
                    response = await _CouponService.CreateCouponAsync(model);
                }
                else
                {
                    response = await _CouponService.UpDateCouponAsync(model);
                }
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Coupon Update successfully";

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);

        }
        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _CouponService.GetCouponByIdAsync(id);
            if (response != null && response.IsSuccess)
            {
                CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CouponDto Coupon)
        {
            ResponseDto? response = await _CouponService.DeleteCouponAsync(Coupon.CouponId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "coupon deleted successfully";

                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(Coupon);
        }
    }
}
