using AutoMapper;
using EduSpot.Services.CouponAPI.Models;
using EduSpot.Services.CouponAPI.Models.Dto;

namespace EduSpot.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                var mappingConfig = new MapperConfiguration(config =>
                {
                    config.CreateMap<CouponDto, Coupon>();
                    config.CreateMap<Coupon, CouponDto>();
                });
            });
            return mappingConfig;
        }
    }
}
