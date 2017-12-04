using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RecetAgro_WS.Models;
using RecetAgro_WS.Dtos;

namespace RecetAgro_WS.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // These two lines, avoid exceptions on Updating a resource(PUT), avoid updating the Id
            // but if use this, when GETTING returns Id field = 0
            //Mapper.CreateMap<Productor, ProductorDto>().ForMember(p => p.Id, opt => opt.Ignore());
            //Mapper.CreateMap<ProductorDto, Productor>().ForMember(p => p.Id, opt => opt.Ignore());

            Mapper.CreateMap<Productor, ProductorDto>();
            Mapper.CreateMap<ProductorDto, Productor>();

        }
    }
}