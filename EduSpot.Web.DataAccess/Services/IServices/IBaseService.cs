using EduSpot.Web.Models;
namespace EduSpot.Web.DataAccess.Services.IServices
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsunk(RequestDto requestDto, bool withBearer = true);
    }
}
