﻿using AutoMapper;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
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
    }
}
