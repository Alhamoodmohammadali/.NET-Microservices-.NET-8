

using EduSpot.Web.Models;

namespace EduSpot.Web.DataAccess.Services.IServices
{
    public interface ILectureService
    {
        Task<ResponseDto?> GetAllLectureAsync();
        Task<ResponseDto?> GetLectureByIdAsync(int id);
        Task<ResponseDto?> CreateLectureAsync(LectureDto LectureDto);
        Task<ResponseDto?> UpDateLectureAsync(LectureDto LectureDto);
        Task<ResponseDto?> DeleteLectureAsync(int id);
    }
}
