using AutoMapper;
using EduSpot.Services.MagorAPI.Models;
using EduSpot.Services.MagorAPI.Models.Dto;

namespace EduSpot.Services.MagorAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<MajorDto, Major>();
                config.CreateMap<MajorDto, Major>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
