using EduSpot.Web.Models;

namespace EduSpot.Web.DataAccess.Services.IServices
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetAllCouponAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateCouponAsync(CouponDto CouponDto);
        Task<ResponseDto?> UpDateCouponAsync(CouponDto CouponDto);
        Task<ResponseDto?> DeleteCouponAsync(int id);
    }
}
