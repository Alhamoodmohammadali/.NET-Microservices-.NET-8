using EduSpot.Web.Models;
using EduSpot.Web.Models.CourseApi;
namespace EduSpot.Web.DataAccess.Services.IServices.ICourseApi
{
    public interface ICategoryService
    {
        Task<ResponseDto?> GetAllCategoryAsync();
        Task<ResponseDto?> GetCategoryByIdAsync(int id);
        Task<ResponseDto?> CreateCategoryAsync(CategoryDto CategoryDto);
        Task<ResponseDto?> UpDateCategoryAsync(CategoryDto CategoryDto);
        Task<ResponseDto?> DeleteCategoryAsync(int id);
    }
}