using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Capstone_Project.Dtos;
using Capstone_Project.Models;

namespace Capstone_Project
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<UserDto, User>();

            Mapper.CreateMap<Survey, SurveyDto>();
            Mapper.CreateMap<SurveyDto, Survey>();

            // Dto to Domain
            Mapper.CreateMap<UserDto, User>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<SurveyDto, Survey>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}