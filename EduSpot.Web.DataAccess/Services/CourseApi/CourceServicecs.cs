using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.DataAccess.Services.IServices.ICourseApi;
using EduSpot.Web.Models;
using EduSpot.Web.Models.CourseApi;
using EduSpot.Web.Utility;
namespace EduSpot.Web.DataAccess.Services.CourseApi
{
    public class CourceServicecs : ICourceService
    {
        private readonly IBaseService _baseService;
        public CourceServicecs(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCourceAsync(CourceCreateDto CourceDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = CourceDto,
                Url = SD.CourceAPIBase + "/api/Cource",
                ContentType = SD.ContentType.MultipartFormData
            });
        }

        public async Task<ResponseDto?> DeleteCourceAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.DELETE,
                Url = SD.CourceAPIBase + "/api/Cource/" + id
            });
        }
        public async Task<ResponseDto?> GetAllCourceAsync()
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.CourceAPIBase + "/api/Cource"
            });
        }
        public async Task<ResponseDto?> GetCourceByIdAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.CourceAPIBase + "/api/Cource/" + id
            });
        }
        public async Task<ResponseDto?> UpDateCourceAsync(CourceUpdateDto CourceDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.PUT,
                Data = CourceDto,
                Url = SD.CourceAPIBase + "/api/Cource",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
