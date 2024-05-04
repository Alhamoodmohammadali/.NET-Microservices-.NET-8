using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.DataAccess.Services.IServices.ICourseApi;
using EduSpot.Web.Models;
using EduSpot.Web.Models.CourseApi;
using EduSpot.Web.Utility;
namespace EduSpot.Web.DataAccess.Services.CourseApi
{
    public  class CategoryService : ICategoryService
    {
        private readonly IBaseService _baseService;
        public CategoryService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateCategoryAsync(CategoryDto CategoryDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = CategoryDto,
                Url = SD.CourceAPIBase + "/api/Category",
                ContentType = SD.ContentType.MultipartFormData
            });
        }

        public async Task<ResponseDto?> DeleteCategoryAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.DELETE,
                Url = SD.CourceAPIBase + "/api/Category/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCategoryAsync()
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.CourceAPIBase + "/api/Category"
            });
        }

        public async Task<ResponseDto?> GetCategoryByIdAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.CourceAPIBase + "/api/Category/" + id
            });
        }

        public async Task<ResponseDto?> UpDateCategoryAsync(CategoryDto CategoryDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.PUT,
                Data = CategoryDto,
                Url = SD.CourceAPIBase + "/api/Category",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
