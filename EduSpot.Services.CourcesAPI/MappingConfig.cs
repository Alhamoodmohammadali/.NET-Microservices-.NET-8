using AutoMapper;
using EduSpot.Services.CourcesAPI.Models;
using EduSpot.Services.CourcesAPI.Models.Dto;

namespace EduSpot.Services.CourcesAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CourceDto, Cource>().ReverseMap();
                config.CreateMap<CategoryDto, Category>().ReverseMap();
                config.CreateMap<VideoCourseDto, VideoCourse>().ReverseMap();


                config.CreateMap<VideoCourse, VideoCourseCreateDto>().ReverseMap();
                config.CreateMap<VideoCourse, VideoCourseUpdateDto>().ReverseMap();
                config.CreateMap<Cource, CourceCreateDto>().ReverseMap();
                config.CreateMap<Cource, CourceUpdateDto>().ReverseMap();


            });
            return mappingConfig;
        }
    }
}
