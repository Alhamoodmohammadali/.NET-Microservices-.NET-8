using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.DataAccess.Services.IServices.ICourseApi;
using EduSpot.Web.Models;
using EduSpot.Web.Models.CourseApi;
using EduSpot.Web.Utility;
namespace EduSpot.Web.DataAccess.Services.CourseApi
{
    public  class VideoCourceService : IVideoCourceService
    {
        private readonly IBaseService _baseService;

        public VideoCourceService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateVideoCourceAsync(VideoCourseCreateDto VideoCourceDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = VideoCourceDto,
                Url = SD.CourceAPIBase + "/api/VideoCourse",
                ContentType = SD.ContentType.MultipartFormData
            });
        }

        public async Task<ResponseDto?> DeleteVideoCourceAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.DELETE,
                Url = SD.CourceAPIBase + "/api/VideoCourse/" + id
            });
        }

        public async Task<ResponseDto?> GetAllVideoCourceAsync()
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.CourceAPIBase + "/api/VideoCourse"
            });
        }

        public async Task<ResponseDto?> GetVideoCourceByIdAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.CourceAPIBase + "/api/VideoCourse/" + id
            });
        }

        public async Task<ResponseDto?> UpDateVideoCourceAsync(VideoCourseCreateDto VideoCourceDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.PUT,
                Data = VideoCourceDto,
                Url = SD.CourceAPIBase + "/api/VideoCourse",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
