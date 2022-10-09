using AutoMapper;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.BLL.ViewModels;
using PhotoService.DAL.Entities;
using PhotoService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ImageModel GetImage(int id)
        {
            var model = _mapper.Map<ImageModel>(_unitOfWork.ImageRepository.GetWithInclude(i => i.Id == id,
                c => c.Comments, u => u.User, h => h.Hashtags).First());

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

            var tagsToAdd = new List<Hashtag>();
            foreach (var tagModel in model.Hashtags)
            {
                var tagFromDB = _unitOfWork.HashTagRepository.GetHashTagByTitle(tagModel.Title);
                var tagToAdd = tagFromDB ?? _mapper.Map<Hashtag>(tagModel);

                tagsToAdd.Add(tagToAdd);
            }

            image.Hashtags = new List<Hashtag>();
            var addedImage = await _unitOfWork.ImageRepository.Add(image);
            await _unitOfWork.SaveAsync();

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
