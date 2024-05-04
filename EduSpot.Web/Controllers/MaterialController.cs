using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using EduSpot.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
namespace EduSpot.Web.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMajorService _majorService;
        private readonly IMaterialService _materialService;
        public MaterialController(IMaterialService materialService , IMajorService majorService )
        {
            _majorService = majorService;
            _materialService = materialService;
        }
        public async Task<IActionResult> Index()
        {
            List<MaterialDto?> List = new List<MaterialDto?>();
            ResponseDto? response = await _materialService.GetAllMaterialAsync();

            if (response != null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<MaterialDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(List);
        }
        public async Task<IActionResult> UpSet(int? id)
        {
            List<MajorDto?> LIstMajor = new ();
            ResponseDto? responseZUniversity = await _majorService.GetAllMajorAsync();
            if (responseZUniversity != null && responseZUniversity.IsSuccess)
            {
                LIstMajor = JsonConvert.DeserializeObject<List<MajorDto>>(Convert.ToString(responseZUniversity.Result));
            }

            VMMajorMaterial vMMajorMaterial = new()
            {

                MajorList = LIstMajor.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.MajorId.ToString()
                })
            };


            if (id == null || id == 0)
            {
                return View(vMMajorMaterial);
            }
            else
            {
                ResponseDto? response = await _materialService.GetMaterialByIdAsync((int)id);
                if (response != null && response.IsSuccess)
                {
                    vMMajorMaterial.material = JsonConvert.DeserializeObject<MaterialDto>(Convert.ToString(response.Result));
                    return View(vMMajorMaterial);
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpSet(VMMajorMaterial model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = new();
                if (model.material.MajorId == 0)
                {
                    response = await _materialService.CreateMaterialAsync(model.material);
                }
                else
                {
                    response = await _materialService.UpDateMaterialAsync(model.material);
                }
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Material Update successfully";

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);

        }
        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? response = await _materialService.GetMaterialByIdAsync(id);
            if (response != null && response.IsSuccess)
            {
                MaterialDto? model = JsonConvert.DeserializeObject<MaterialDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(MaterialDto model)
        {
            ResponseDto? response = await _materialService.DeleteMaterialAsync(model.MaterialId);
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
