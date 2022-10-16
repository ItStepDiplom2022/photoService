using System.Linq.Expressions;

namespace PhotoService.DAL.Interfaces
{
    public interface ICollectionRepository
    {
        IEnumerable<Collection> GetCollections(string username);
        Collection GetCollection(string username, string collectionName);
        Task<Collection> Create(Collection collection);
        IEnumerable<Collection> FindAll(Expression<Func<Collection, bool>> predicate);
        IEnumerable<Collection> GetWithInclude(Func<Collection, bool> predicate,
                params Expression<Func<Collection, object>>[] includeProperties);

    }
}
