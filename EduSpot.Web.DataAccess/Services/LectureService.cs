using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using EduSpot.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.DataAccess.Services
{
    public class LectureService : ILectureService
    {
        private readonly IBaseService _baseService;
        public LectureService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateLectureAsync(LectureDto LectureDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = LectureDto,
                Url = SD.LectureAPIBase + "/api/Lecture",
                ContentType = SD.ContentType.MultipartFormData
            });
        }

        public async Task<ResponseDto?> DeleteLectureAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.DELETE,
                Url = SD.LectureAPIBase + "/api/Lecture/" + id
            });
        }

        public async Task<ResponseDto?> GetAllLectureAsync()
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.LectureAPIBase + "/api/Lecture"
            });
        }

        public async Task<ResponseDto?> GetLectureByIdAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.LectureAPIBase + "/api/Lecture/" + id
            });
        }

        public async Task<ResponseDto?> UpDateLectureAsync(LectureDto LectureDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.PUT,
                Data = LectureDto,
                Url = SD.LectureAPIBase + "/api/Lecture",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
