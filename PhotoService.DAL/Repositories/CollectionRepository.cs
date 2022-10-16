using Microsoft.EntityFrameworkCore;
using PhotoService.DAL.Interfaces;
using System.Linq.Expressions;

namespace PhotoService.DAL.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly PhotoServiceDbContext _dbContext;

        public CollectionRepository(PhotoServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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
