using PhotoService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.DAL.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly PhotoServiceDbContext _dbContext;

        public CollectionRepository(PhotoServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //private readonly IUserRepository _userRepository;

        //mock
        //TODO: add connections to DB
        // List<Collection> collections = new List<Collection>();

        //public CollectionRepository(IUserRepository userRepository)
        //{
        //    _userRepository = userRepository;
        //    //mock
        //    var user = _userRepository.GetUserByUsername("admin");
        //    var collections = new List<Collection>()
        //    {
        //        new Collection()
        //        {
        //            Id = 1,
        //            User = user,
        //            Name = "Saved Images",
        //            ImageUrl = "/images/collection-images/bookmark.png"
        //        },
        //        new Collection()
        //        {
        //            Id = 2,
        //            User = user,
        //            Name = "Liked Images",
        //            ImageUrl = "/images/collection-images/Heart.png"
        //        },
        //        new Collection()
        //        {
        //            Id = 3,
        //            User = user,
        //            Name = "Collection1",
        //            ImageUrl = "/images/collection-images/Folders.png"
        //        },
        //        new Collection()
        //        {
        //            Id = 4,
        //            User = user,
        //            Name = "Collection2",
        //            ImageUrl = "/images/collection-images/Folders.png"
        //        },
        //        new Collection()
        //        {
        //            Id = 5,
        //            User = user,
        //            Name = "Collection3",
        //            ImageUrl = "/images/collection-images/Folders.png"
        //        },

        //    };

        //    this.collections.AddRange(collections);
        //}

        public async Task<Collection> Create(Collection collection)
        {
            var addedCollection = await _dbContext.Collections.AddAsync(collection);
            return addedCollection.Entity;
        }

        public Collection GetCollection(string username, string collectionName)
        {
            return _dbContext.Collections.First();
            //return _dbContext.Collections.Where(collection => collection.Name == collectionName && collection.User.UserName == username).FirstOrDefault();
        }

        public IEnumerable<Collection> GetCollections(string username)
        {
            return _dbContext.Collections;
           // return _dbContext.Collections.Where(collection => collection.User.UserName.ToLower() == username.ToLower());
        }
    }
}
