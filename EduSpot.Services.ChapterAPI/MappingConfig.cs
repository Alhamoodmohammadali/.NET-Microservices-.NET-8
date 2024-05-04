using AutoMapper;
using EduSpot.Services.ChapterAPI.Models;
using EduSpot.Services.ChapterAPI.Models.Dto;

namespace EduSpot.Services.ChapterAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ChapterDto, Chapter>();
                config.CreateMap<ChapterDto, Chapter>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
