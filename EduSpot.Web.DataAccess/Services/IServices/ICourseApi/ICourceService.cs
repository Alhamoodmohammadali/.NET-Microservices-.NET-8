using EduSpot.Web.Models;
using EduSpot.Web.Models.CourseApi;

namespace EduSpot.Web.DataAccess.Services.IServices.ICourseApi
{
    public interface ICourceService
    {
        Task<ResponseDto?> GetAllCourceAsync();
        Task<ResponseDto?> GetCourceByIdAsync(int id);
        Task<ResponseDto?> CreateCourceAsync(CourceCreateDto CourceDto);
        Task<ResponseDto?> UpDateCourceAsync(CourceUpdateDto CourceDto);
        Task<ResponseDto?> DeleteCourceAsync(int id);
    }
}
