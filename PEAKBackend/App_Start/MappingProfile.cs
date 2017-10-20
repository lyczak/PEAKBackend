using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PEAKBackend.Dtos;
using PEAKBackend.Models;

namespace PEAKBackend.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Hint, HintDto>();
            Mapper.CreateMap<HintDto, Hint>();

            Mapper.CreateMap<HintCategory, HintCategoryDto>();
            Mapper.CreateMap<HintCategoryDto, HintCategory>();

            Mapper.CreateMap<Location, LocationDto>();
            Mapper.CreateMap<LocationDto, Location>();

            Mapper.CreateMap<Module, ModuleDto>();
            Mapper.CreateMap<ModuleDto, Module>();

            Mapper.CreateMap<ApplicationUser, ApplicationUserDto>();
        }
    }
}