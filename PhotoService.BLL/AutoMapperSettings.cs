using AutoMapper;
using PhotoService.BLL.Models;
using PhotoService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL
{
    public class AutoMapperSettings:Profile
    {
        public AutoMapperSettings()
        {
            //TODO: add all necessary mappings
            CreateMap<User, UserLoginModel>()
                .ReverseMap();

            CreateMap<User, UserModel>()
                .ReverseMap();

            CreateMap<UserRegisterModel, User>()
                .ReverseMap();

        }
    }
}
