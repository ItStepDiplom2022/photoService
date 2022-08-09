using AutoMapper;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
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
        private readonly IImageRepository _imageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, IUserRepository userRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ImageModel GetImage(int id)
        {
            return _mapper.Map<ImageModel>(_imageRepository.GetImage(id));
        }

        public IEnumerable<ImageModel> GetImages()
        {
            return _mapper.Map<IEnumerable<ImageModel>>(_imageRepository.GetImages());
        }

        public ImageModel AddImage(ImageAddModel model)
        {
            var image = _mapper.Map<DAL.Entities.Image>(model);
            image.Author = _userRepository.GetUser(model.UserEmail);
            image.DateAdded = DateTime.Now;

            return _mapper.Map<ImageModel>(_imageRepository.Add(image));
        }
    }
}
