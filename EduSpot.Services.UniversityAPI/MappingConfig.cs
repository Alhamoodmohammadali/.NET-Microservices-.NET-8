using AutoMapper;
using EduSpot.Services.UniversityAPI.Models;
using EduSpot.Services.UniversityAPI.Models.Dto;

namespace EduSpot.Services.UniversityAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UniversityDto, University>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
