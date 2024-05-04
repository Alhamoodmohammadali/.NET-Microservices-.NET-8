using EduSpot.Web.Models;

namespace EduSpot.Web.DataAccess.Services.IServices
{
    public interface IChapterService
    {
        Task<ResponseDto?> GetAllChapterAsync();
        Task<ResponseDto?> GetChapterByIdAsync(int id);
        Task<ResponseDto?> CreateChapterAsync(ChapterDto ChapterDto);
        Task<ResponseDto?> UpDateChapterAsync(ChapterDto ChapterDto);
        Task<ResponseDto?> DeleteChapterAsync(int id);
    }
}
