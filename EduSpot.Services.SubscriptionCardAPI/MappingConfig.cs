using AutoMapper;
using EduSpot.Services.SubscriptionCardAPI.Models;
using EduSpot.Services.SubscriptionCardAPI.Models.Dto;

namespace EduSpot.Services.SubscriptionCardAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
