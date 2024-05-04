using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using EduSpot.Web.Utility;
namespace EduSpot.Web.DataAccess.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly IBaseService _baseService;
        public SummaryService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateSummaryAsync(SummaryDto SummaryDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = SummaryDto,
                Url = SD.SummaryAPIBase + "/api/Summary",
                ContentType = SD.ContentType.MultipartFormData
            });
        }

        public async Task<ResponseDto?> DeleteSummaryAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.DELETE,
                Url = SD.SummaryAPIBase + "/api/Summary/" + id
            });
        }

        public async Task<ResponseDto?> GetAllSummaryAsync()
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.SummaryAPIBase + "/api/Summary"
            });
        }

        public async Task<ResponseDto?> GetSummaryByIdAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.SummaryAPIBase + "/api/Summary/" + id
            });
        }

        public async Task<ResponseDto?> UpDateSummaryAsync(SummaryDto SummaryDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.PUT,
                Data = SummaryDto,
                Url = SD.SummaryAPIBase + "/api/Summary",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
