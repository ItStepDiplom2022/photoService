using AutoMapper;
using PhotoService.BLL.Models;
using PhotoService.BLL.ViewModels;
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
            
            CreateMap<SimpleUserViewModel, UserModel>()
                .ReverseMap();

            CreateMap<ImageModel, Image>()
                .ReverseMap();
            
            CreateMap<SimpleImageViewModel, ImageModel>()
                .ReverseMap();

            CreateMap<CommentModel, Comment>()
                .ReverseMap();

            CreateMap<HashtagModel, Hashtag>()
                .ReverseMap();

            CreateMap<LikeModel, Like>()
                .ReverseMap();


            CreateMap<HashtagModel, SearchResultModel>()
                .ConvertUsing(tag => new SearchResultModel()
                {
                    Text = tag.Title,
                    Type = Enums.SearchResultType.Tag
                });

            CreateMap<UserModel, SearchResultModel>()
                .ConvertUsing(user => new SearchResultModel()
                {
                    Text = user.UserName,
                    Type = Enums.SearchResultType.Author,
                    ImageUrl = user.AvatarUrl
                });
        }
    }
}
