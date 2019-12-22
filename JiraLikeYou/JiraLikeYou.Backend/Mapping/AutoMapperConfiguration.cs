using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JiraLikeYou.Backend.Dto;
using JiraLikeYou.BLL.Models;

namespace JiraLikeYou.Backend.Mapping
{
    public class AutoMapperConfiguration
    {
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = CreateMapperConfiguration();

            mapperConfiguration.AssertConfigurationIsValid();

            return mapperConfiguration.CreateMapper();
        }

        public static MapperConfiguration CreateMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<History, HistoryDto>();
            });
        }
    }
}
