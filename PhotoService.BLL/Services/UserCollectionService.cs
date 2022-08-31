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
        private readonly ICollectionRepository _collectionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserCollectionService(IMapper mapper, ICollectionRepository collectionRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _collectionRepository = collectionRepository;
            _mapper = mapper;
        }

        public CollectionModel CreateCollection(string username, string name)
        {
            var user = _userRepository.GetUserByUsername(username);

            Collection entity = new Collection()
            {
                Name = name,
                Owner = user,
                ImageUrl= "/images/collection-images/Folders.png",
            };

            return _mapper.Map<CollectionModel>(_collectionRepository.Create(entity));
        }

        public CollectionModel GetCollection(string username, string name)
        {
            var collections = GetCollections(username);

            var collectionName = collections.First(collection => collection.UrlName == name).Name;

            return _mapper.Map<CollectionModel>(_collectionRepository.GetCollection(username, collectionName));
        }

        public IList<CollectionModel> GetCollections(string username)
        {
            return _mapper.Map<IList<CollectionModel>>(_collectionRepository.GetCollections(username));
        }
    }
}
