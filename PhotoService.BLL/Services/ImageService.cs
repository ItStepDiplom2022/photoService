using AutoMapper;
using Azure;
using PhotoService.BLL.Enums;
using PhotoService.BLL.Exceptions;
using PhotoService.BLL.ExtensionMethods;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.BLL.ViewModels;
using PhotoService.DAL.Entities;
using PhotoService.DAL.Interfaces;

namespace PhotoService.BLL.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;

        public ImageService(IUnitOfWork unitOfWork, IMapper mapper, IBlobService blobService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blobService = blobService;
        }

        public ImageModel GetImage(int id)
        {
            var entity = _unitOfWork.ImageRepository.GetWithInclude(i => i.Id == id,
                c => c.Comments, u => u.User, h => h.Hashtags).First();

            var model = _mapper.Map<ImageModel>(entity);
            model.Author = new UserModel { UserName = entity.User.UserName };

            var images = _unitOfWork.CollectionRepository.GetWithInclude(c => c.Name == "Likes", i => i.Images).Select(x => x.Images);
            model.LikesCount = images.Where(x => x.Any(img => img.Id == id)).Count();

            return model;
        }

        public IEnumerable<ImageModel> GetImages()
        {
            return _mapper.Map<IEnumerable<ImageModel>>(_unitOfWork.ImageRepository.GetImages());
        }

        public async Task<ImageModel> AddImage(ImageAddModel model)
        {
            var image = _mapper.Map<DAL.Entities.Image>(model);
            image.User = _unitOfWork.UserRepository.GetUser(model.UserEmail);
            image.DateAdded = DateTime.Now;

            //adding hashtags to db
            var tagsToAdd = new List<Hashtag>();
            foreach (var tagModel in model.Hashtags)
            {
                var tagFromDB = _unitOfWork.HashTagRepository.GetHashTagByTitle(tagModel.Title);
                var tagToAdd = tagFromDB ?? _mapper.Map<Hashtag>(tagModel);

                tagsToAdd.Add(tagToAdd);
            }
            image.Hashtags = new List<Hashtag>();

            //saving image in blob container
            try
            {
                image.ImageUrl = await _blobService.UploadPhoto($"{image.User.UserName}_{image.Title}.png", image.ImageUrl.Substring(image.ImageUrl.LastIndexOf(',') + 1));
            }
            catch (RequestFailedException)
            {
               throw new BlobException(PhotoServiceExceptions.IMAGE_ALREADY_UPLOADED.GetDescription());
            }

            var addedImage = await _unitOfWork.ImageRepository.Add(image);

            await _unitOfWork.SaveAsync();

            //adding hashtags to image
            foreach (var hashTag in tagsToAdd)
            {
                _unitOfWork.ImageRepository.AddHashTag(addedImage, hashTag);
            }
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ImageModel>(addedImage);
        }

        public async Task AddComment(CommentAddViewModel commentAdd)
        {
            var image = _unitOfWork.ImageRepository.GetWithInclude(img => img.Id == commentAdd.ImageId, i => i.Comments).First();
            var comment = new Comment
            {
                CommentText = commentAdd.Comment,
                DateAdded = DateTime.Now,
                UserAdded = _unitOfWork.UserRepository.GetWithInclude(u => u.UserName == commentAdd.Username,i=>i.Comments).First()
            };

            _unitOfWork.ImageRepository.AddComment(image,comment);
            await _unitOfWork.SaveAsync();
        }


        public IEnumerable<ImageModel> GetImagesByUserEmail(string email)
        {
            return _mapper.Map<IEnumerable<ImageModel>>
                            (_unitOfWork.ImageRepository.GetWithInclude(i => i.User.Email==email,
                c => c.Comments, u => u.User, h => h.Hashtags));
        }

        public IEnumerable<ImageModel> GetImagesByUserName(string username)
        {
            return _mapper.Map<IEnumerable<ImageModel>>
                            (_unitOfWork.ImageRepository.GetWithInclude(i => i.User.UserName==username,
                c => c.Comments, u => u.User, h => h.Hashtags));
        }
    }
}
