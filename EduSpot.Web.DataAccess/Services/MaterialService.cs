using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using EduSpot.Web.Utility;
namespace EduSpot.Web.DataAccess.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IBaseService _baseService;
        public MaterialService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateMaterialAsync(MaterialDto MaterialDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = MaterialDto,
                Url = SD.MaterialAPIBase + "/api/Material",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
        public async Task<ResponseDto?> DeleteMaterialAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.DELETE,
                Url = SD.MaterialAPIBase + "/api/Material/" + id
            });
        }
        public async Task<ResponseDto?> GetAllMaterialAsync()
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.MaterialAPIBase + "/api/Material"
            });
        }
        public async Task<ResponseDto?> GetMaterialByIdAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.MaterialAPIBase + "/api/Material/" + id
            });
        }
        public async Task<ResponseDto?> UpDateMaterialAsync(MaterialDto MaterialDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.PUT,
                Data = MaterialDto,
                Url = SD.MaterialAPIBase + "/api/Material",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}