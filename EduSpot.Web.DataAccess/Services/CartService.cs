using EduSpot.Web.DataAccess.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduSpot.Web.Models;
using EduSpot.Web.Models.ViewModel;
using EduSpot.Web.Utility;
namespace EduSpot.Web.DataAccess.Services
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;
        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.SubscriptionCardAPIBase + "/api/cart/ApplyCoupon"
            });
        }

        //public async Task<ResponseDto?> EmailCart(CartDto cartDto)
        //{
        //    return await _baseService.SendAsunk(new RequestDto()
        //    {
        //        apitype = SD.ApiType.POST,
        //        Data = cartDto,
        //        Url = SD.SubscriptionCardAPIBase + "/api/cart/EmailCartRequest"
        //    });
        //}

        public async Task<ResponseDto?> GetCartByUserIdAsnyc(string userId)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.SubscriptionCardAPIBase + "/api/cart/GetCart/" + userId
            });
        }


        public async Task<ResponseDto?> RemoveFromCartAsync(int cartDetailsId)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = cartDetailsId,
                Url = SD.SubscriptionCardAPIBase + "/api/cart/RemoveCart"
            });
        }


        public async Task<ResponseDto?> UpsertCartAsync(CartDto cartDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.SubscriptionCardAPIBase + "/api/cart/CartUpsert"
            });
        }
    }
}
