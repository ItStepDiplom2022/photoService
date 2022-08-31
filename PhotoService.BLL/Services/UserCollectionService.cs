using AutoMapper;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.DAL;
using PhotoService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Services
{
    public class UserCollectionService : IUserCollectionService
    {
        //private readonly ICollectionRepository _collectionRepository;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserCollectionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CollectionModel> CreateCollection(string username, string name, bool isPublic)
        {
            var user = _unitOfWork.UserRepository.GetUserByUsername(username);

            Collection entity = new Collection()
            {
                Name = name,
                Owner = user,
                IsPublic = isPublic,
                ImageUrl= "/images/collection-images/Folders.png",
                CollectionType = _unitOfWork.CollectionTypeRepository.GetCollectionTypeByTitle(CollectionTypes.CUSTOM.ToString())
            };

            var addedCollection = await _unitOfWork.CollectionRepository.Create(entity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<CollectionModel>(addedCollection);
        }

        public CollectionModel GetCollection(string username, string name)
        {
            var collections = GetCollections(username);

            var collectionName = collections.First(collection => collection.UrlName == name).Name;

            return _mapper.Map<CollectionModel>(_unitOfWork.CollectionRepository.GetCollection(username, collectionName));
        }

        public IList<CollectionModel> GetCollections(string username)
        {
            return _mapper.Map<IList<CollectionModel>>(_unitOfWork.CollectionRepository.GetCollections(username));
        }
    }
}
