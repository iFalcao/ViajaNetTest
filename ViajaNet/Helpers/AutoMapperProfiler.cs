using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajaNet.Domain.DTOs;
using ViajaNet.Domain.Models;

namespace ViajaNet.Helpers
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<VisitDTO, Visit>()
                .ForMember(domain => domain.Id, 
                           options => options.Ignore());
        }
    }
}
