using AutoMapper;
using ecomm.Domain.Dtos.User;
using ecomm.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm.Crosscutting
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<UserAddDto, UserModel>().ReverseMap();
            CreateMap<UserGetAllDto, UserModel>().ReverseMap();
            CreateMap<UserLoginDto, UserModel>().ReverseMap();
            CreateMap<UserLogonDto, UserModel>().ReverseMap();

        }

        
    }
}
