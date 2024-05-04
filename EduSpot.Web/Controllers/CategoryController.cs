using EduSpot.Web.DataAccess.Services.IServices.ICourseApi;
using EduSpot.Web.Models;
using EduSpot.Web.Models.CourseApi;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace EduSpot.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            List<CategoryDto?> List = new ();
            ResponseDto? response = await _categoryService.GetAllCategoryAsync();
            if (response != null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(List);
        }

        public async Task<IActionResult> UpSet(int? id)
        {
            CategoryDto? model = new();
            if (id == null || id == 0)
            {
                return View(model);

            }
            else
            {
                ResponseDto? response = await _categoryService.GetCategoryByIdAsync((int)id);
                if (response != null && response.IsSuccess)
                {
                    model = JsonConvert.DeserializeObject<CategoryDto>(Convert.ToString(response.Result));
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
        public async Task<IActionResult> UpSet(CategoryDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = new();
                if (model.CategoryId == 0)
                {
                    response = await _categoryService.CreateCategoryAsync(model);
                }
                else
                {
                    response = await _categoryService.UpDateCategoryAsync(model);
                }
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Category Update successfully";

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _categoryService.GetCategoryByIdAsync(id);
            if (response != null && response.IsSuccess)
            {
                CategoryDto? model = JsonConvert.DeserializeObject<CategoryDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CategoryDto model)
        {
            ResponseDto? response = await _categoryService.DeleteCategoryAsync(model.CategoryId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "coupon deleted successfully";

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
