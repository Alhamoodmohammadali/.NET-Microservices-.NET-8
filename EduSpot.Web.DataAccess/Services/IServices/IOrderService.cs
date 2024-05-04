using EduSpot.Web.Models;
using EduSpot.Web.Models.ViewModel;

namespace EduSpot.Web.DataAccess.Services.IServices
{
    public interface IOrderService
    {
        Task<ResponseDto?> CreateOrder(CartDto cartDto);
        //Task<ResponseDto?> CreateStripeSession(StripeRequestDto stripeRequestDto);
        Task<ResponseDto?> ValidateStripeSession(int orderHeaderId);
        Task<ResponseDto?> GetAllOrder(string? userId);
        Task<ResponseDto?> GetOrder(int orderId);
        Task<ResponseDto?> UpdateOrderStatus(int orderId, string newStatus);
    }
}
