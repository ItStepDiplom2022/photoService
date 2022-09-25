using AutoMapper;
using PhotoService.BLL.Models;
using PhotoService.BLL.ViewModels;
using PhotoService.DAL;
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
                .ForMember(urm => urm.PasswordHash, u => u.MapFrom(cd => cd.Password))
                .ReverseMap();
            
            CreateMap<SimpleUserViewModel, UserModel>()
                .ReverseMap();

            CreateMap<ImageModel, Image>()
                .ForMember(i => i.User, im => im.MapFrom(s=>s.Author))
                .ReverseMap();
            
            CreateMap<SimpleImageViewModel, ImageModel>()
                .ReverseMap();

            CreateMap<ImageAddModel, Image>()
                .ReverseMap();

            CreateMap<CommentModel, Comment>()
                .ReverseMap();

            CreateMap<HashtagModel, Hashtag>()
                .ReverseMap();

            CreateMap<RoleModel, Role>()
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
                    ImageBase64 = user.AvatarUrl
                });

            CreateMap<Collection, CollectionModel>()
                .ForMember(c=>c.User, cm => cm.MapFrom(x=>x.Owner))
                .AfterMap((collection, collectionModel) => collectionModel.UrlName = collection.Name.ToLower().Replace(' ', '-'))
                .ReverseMap();
        }
    }
}
