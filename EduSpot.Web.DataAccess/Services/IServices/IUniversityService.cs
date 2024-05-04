using EduSpot.Web.Models;
namespace EduSpot.Web.DataAccess.Services.IServices
{
    public interface IUniversityService
    {
        Task<ResponseDto?> GetAllUniversityAsync();
        Task<ResponseDto?> GetUniversityByIdAsync(int id);
        Task<ResponseDto?> CreateUniversityAsync(UniversityDto universityDto);
        Task<ResponseDto?> UpDateUniversityAsync(UniversityDto universityDto);
        Task<ResponseDto?> DeleteUniversityAsync(int id);
    }
}
