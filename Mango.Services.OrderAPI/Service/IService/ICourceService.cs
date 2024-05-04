using Mango.Services.OrderAPI.Models.Dto;

namespace Mango.Services.OrderAPI.Service.IService
{
    public interface ICourceService
    {
        Task<IEnumerable<CourceDto>> GetProducts();

    }
}
