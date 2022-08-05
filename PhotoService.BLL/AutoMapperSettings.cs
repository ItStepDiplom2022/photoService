using AutoMapper;
using PhotoService.BLL.Models;
using PhotoService.DAL.Entities;

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

            CreateMap<ImageModel, Image>()
                .ReverseMap();

            CreateMap<CommentModel, Comment>()
                .ReverseMap();

            CreateMap<HashtagModel, Hashtag>()
                .ReverseMap();

            CreateMap<LikeModel, Like>()
                .ReverseMap();

        }
    }
}
