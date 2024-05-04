using EduSpot.Services.SubscriptionCardAPI.Models.Dto;
namespace EduSpot.Services.SubscriptionCardAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
