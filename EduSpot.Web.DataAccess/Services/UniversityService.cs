using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using EduSpot.Web.Utility;
namespace EduSpot.Web.DataAccess.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IBaseService _baseService;
        public UniversityService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateUniversityAsync(UniversityDto universityDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = universityDto,
                Url = SD.UniversityAPIBase + "/api/University",
                ContentType = SD.ContentType.MultipartFormData
            });
        }

        public async Task<ResponseDto?> DeleteUniversityAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.DELETE,
                Url = SD.UniversityAPIBase + "/api/University/" + id
            });
        }

        public async Task<ResponseDto?> GetAllUniversityAsync()
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.UniversityAPIBase + "/api/University"
            });
        }

        public async Task<ResponseDto?> GetUniversityByIdAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.UniversityAPIBase + "/api/University/" + id
            });
        }
        public async Task<ResponseDto?> UpDateUniversityAsync(UniversityDto universityDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.PUT,
                Data = universityDto,
                Url = SD.UniversityAPIBase + "/api/University",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
  
    
    }
}
