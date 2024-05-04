using AutoMapper;
using EduSpot.Services.LectureAPI.Models;
using EduSpot.Services.LectureAPI.Models.Dto;
namespace EduSpot.Services.LectureAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<LectureDto, Lecture>();
                config.CreateMap<LectureDto, Lecture>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
