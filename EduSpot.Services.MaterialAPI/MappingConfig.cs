using AutoMapper;
using EduSpot.Services.MaterialAPI.Models;
using EduSpot.Services.MaterialAPI.Models.Dto;
namespace EduSpot.Services.MaterialAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<MaterialDto, Material>();
                config.CreateMap<MaterialDto, Material>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
