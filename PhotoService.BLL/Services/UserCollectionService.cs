using AutoMapper;
using PhotoService.BLL.Enums;
using PhotoService.BLL.Exceptions;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.BLL.ViewModels;
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
        private readonly IUnitOfWork _unitOfWork;
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
            var collection = _unitOfWork.CollectionRepository.GetCollection(username, name);

            if (collection == null)
                throw new CollectionException(PhotoServiceExceptions.COLLECTION_DOES_NOT_EXIST.GetDescription());

            return _mapper.Map<CollectionModel>(collection);
        }

        public IList<CollectionModel> GetCollections(string username, bool publicOnly)
        {
            IEnumerable<Collection> collections;
            if (publicOnly)
                collections = _unitOfWork.CollectionRepository.FindAll(x => x.Owner.UserName.ToLower() == username.ToLower()&&x.IsPublic);
            else
                collections = _unitOfWork.CollectionRepository.GetCollections(username);

            return _mapper.Map<IList<CollectionModel>>(collections);
        }

        public bool ChechIfIsLiked(string username, int imageId)
        {
            var collection = _unitOfWork.CollectionRepository.GetCollection(username,"Likes");

            if (collection == null)
                throw new CollectionException(PhotoServiceExceptions.COLLECTION_DOES_NOT_EXIST.GetDescription());

            return collection.Images.Any(i=>i.Id == imageId);
        }

        public async Task AddImageToCollection(AddImageToCollectionViewModel model)
        {
            var collection = _unitOfWork.CollectionRepository.GetCollection(model.Username,model.CollectionName);
            var image = _unitOfWork.ImageRepository.GetWithInclude(x=>x.Id==model.ImageId,i=>i.Collections).First();

            if(collection==null)
                throw new CollectionException(PhotoServiceExceptions.COLLECTION_DOES_NOT_EXIST.GetDescription());

            if (image.Collections.Any(c => c.Name == model.CollectionName))
                throw new CollectionException(PhotoServiceExceptions.COLLECTION_ALREADY_CONTAINS_IMAGE.GetDescription());

            image.Collections.Add(collection);
            _unitOfWork.ImageRepository.Update(image);
            await _unitOfWork.SaveAsync();
        }

        public async Task RemoveImageFromCollection(AddImageToCollectionViewModel model)
        {
            var collection = _unitOfWork.CollectionRepository.GetCollection(model.Username, model.CollectionName);
            var image = _unitOfWork.ImageRepository.GetWithInclude(x => x.Id == model.ImageId, i => i.Collections).First();

            if (collection == null)
                throw new CollectionException(PhotoServiceExceptions.COLLECTION_DOES_NOT_EXIST.GetDescription());

            if (!image.Collections.Any(c => c.Name == model.CollectionName))
                throw new CollectionException(PhotoServiceExceptions.IMAGE_IS_NOT_PRESENT_IN_LIKES.GetDescription());

            image.Collections.Remove(collection);
            _unitOfWork.ImageRepository.Update(image);
            await _unitOfWork.SaveAsync();
        }
    }
}
