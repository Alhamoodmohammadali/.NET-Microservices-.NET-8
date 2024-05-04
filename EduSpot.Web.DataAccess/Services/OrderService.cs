using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.Models;
using EduSpot.Web.Models.ViewModel;
using EduSpot.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSpot.Web.DataAccess.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;
        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateOrder(CartDto cartDto)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.OrderAPIBase + "/api/order/CreateOrder"
            });
        }

        //public async Task<ResponseDto?> CreateStripeSession(StripeRequestDto stripeRequestDto)
        //{
        //    return await _baseService.SendAsync(new RequestDto()
        //    {
        //        ApiType = SD.ApiType.POST,
        //        Data = stripeRequestDto,
        //        Url = SD.OrderAPIBase + "/api/order/CreateStripeSession"
        //    });
        //}

        public async Task<ResponseDto?> GetAllOrder(string? userId)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.OrderAPIBase + "/api/order/GetOrders?userId=" + userId
            });
        }

        public async Task<ResponseDto?> GetOrder(int orderId)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.GET,
                Url = SD.OrderAPIBase + "/api/order/GetOrder/" + orderId
            });
        }

        public async Task<ResponseDto?> UpdateOrderStatus(int orderId, string newStatus)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = newStatus,
                Url = SD.OrderAPIBase + "/api/order/UpdateOrderStatus/" + orderId
            });
        }

        public async Task<ResponseDto?> ValidateStripeSession(int orderHeaderId)
        {
            return await _baseService.SendAsunk(new RequestDto()
            {
                apitype = SD.ApiType.POST,
                Data = orderHeaderId,
                Url = SD.OrderAPIBase + "/api/order/ValidateStripeSession"
            });
        }


    }
}
