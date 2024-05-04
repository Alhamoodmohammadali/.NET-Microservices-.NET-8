using AutoMapper;
using EduSpot.Services.SummaryAPI.Models;
using EduSpot.Services.SummaryAPI.Models.Dto;

namespace EduSpot.Services.SummaryAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<SummaryDto, Summary>();
                config.CreateMap<SummaryDto, Summary>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
