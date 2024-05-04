using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using EduSpot.Web.Utility;
namespace EduSpot.Web.DataAccess.Services
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateCouponAsync(CouponDto CouponDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = CouponDto,
                Url = SD.CouponAPIBase + "/api/Coupon",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.DELETE,
                Url = SD.CouponAPIBase + "/api/Coupon/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCouponAsync()
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/Coupon"
            });
        }
        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/Coupon/" + id
            });
        }
        public async Task<ResponseDto?> UpDateCouponAsync(CouponDto CouponDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.PUT,
                Data = CouponDto,
                Url = SD.CouponAPIBase + "/api/Coupon",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
