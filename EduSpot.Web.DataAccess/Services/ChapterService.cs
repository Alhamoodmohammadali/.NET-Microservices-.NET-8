using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using EduSpot.Web.Utility;
namespace EduSpot.Web.DataAccess.Services
{
    public class ChapterService : IChapterService
    {
        private readonly IBaseService _baseService;
        public ChapterService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateChapterAsync(ChapterDto ChapterDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = ChapterDto,
                Url = SD.ChapterAPIBase + "/api/Chapter",
                ContentType = SD.ContentType.MultipartFormData
            });
        }

        public async Task<ResponseDto?> DeleteChapterAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.DELETE,
                Url = SD.ChapterAPIBase + "/api/Chapter/" + id
            });
        }

        public async Task<ResponseDto?> GetAllChapterAsync()
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.ChapterAPIBase + "/api/Chapter"
            });
        }

        public async Task<ResponseDto?> GetChapterByIdAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.ChapterAPIBase + "/api/Chapter/" + id
            });
        }

        public async Task<ResponseDto?> UpDateChapterAsync(ChapterDto ChapterDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.PUT,
                Data = ChapterDto,
                Url = SD.ChapterAPIBase + "/api/Chapter",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
