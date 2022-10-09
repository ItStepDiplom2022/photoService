using Microsoft.EntityFrameworkCore;
using PhotoService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            return _dbContext.Collections.Where(collection => collection.Name == collectionName && collection.Owner.UserName == username)
               .Include(x=>x.Images)
               .ThenInclude(x=>x.Hashtags)
               .Include(x=>x.Images)
               .ThenInclude(x=>x.User)
               .Include(x=>x.Owner)
               .FirstOrDefault();
        }

        public IEnumerable<Collection> GetCollections(string username)
        {
            return _dbContext.Collections.Where(collection => collection.Owner.UserName.ToLower() == username.ToLower())
                .Include(i=>i.Images);
        }

        public IQueryable<Collection> Include(params Expression<Func<Collection, object>>[] includeProperties)
        {
            IQueryable<Collection> query = _dbContext.Collections;
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IEnumerable<Collection> GetWithInclude(params Expression<Func<Collection, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<Collection> GetWithInclude(Func<Collection, bool> predicate,
                params Expression<Func<Collection, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        public IEnumerable<Collection> FindAll(Expression<Func<Collection, bool>> predicate)
        {
            return _dbContext.Collections.Where(predicate);
        }
    }
}
