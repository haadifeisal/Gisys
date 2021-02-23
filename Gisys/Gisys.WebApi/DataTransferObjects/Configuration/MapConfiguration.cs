using AutoMapper;
using Gisys.WebApi.Repository.Gisys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gisys.WebApi.DataTransferObjects.Configuration
{
    public class MapConfiguration : Profile
    {

        public MapConfiguration()
        {
            CreateMap<ConsultantRequestDto, Consultant>();
            CreateMap<Consultant, ConsultantResponseDto>();
            CreateMap<NetResult, NetResultResponseDto>();
        }

    }
}
