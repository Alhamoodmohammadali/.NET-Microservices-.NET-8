using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using EduSpot.Web.Utility;
namespace EduSpot.Web.DataAccess.Services
{
    public class MajorService : IMajorService
    {
        private readonly IBaseService _baseService;
        public MajorService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateMajorAsync(MajorDto majorDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = majorDto,
                Url = SD.MajorAPIBase + "/api/Major",
                ContentType = SD.ContentType.MultipartFormData
            });

        }

        public async Task<ResponseDto?> DeleteMajorAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.DELETE,
                Url = SD.MajorAPIBase + "/api/Major/" + id
            });
        }

        public async Task<ResponseDto?> GetAllMajorAsync()
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.MajorAPIBase + "/api/Major"
            });
        }

        public async Task<ResponseDto?> GetMajorByIdAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.MajorAPIBase + "/api/Major/" + id
            });
        }

        public async Task<ResponseDto?> UpDateMajorAsync(MajorDto majorDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.PUT,
                Data = majorDto,
                Url = SD.MajorAPIBase + "/api/Major",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}

