using EduSpot.Web.Models;
namespace EduSpot.Web.DataAccess.Services.IServices
{
    public interface IMaterialService
    {
        Task<ResponseDto?> GetAllMaterialAsync();
        Task<ResponseDto?> GetMaterialByIdAsync(int id);
        Task<ResponseDto?> CreateMaterialAsync(MaterialDto MaterialDto);
        Task<ResponseDto?> UpDateMaterialAsync(MaterialDto MaterialDto);
        Task<ResponseDto?> DeleteMaterialAsync(int id);
    }
}
