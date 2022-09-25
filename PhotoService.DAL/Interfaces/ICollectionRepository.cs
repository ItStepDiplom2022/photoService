using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.DAL.Interfaces
{
    public interface ICollectionRepository
    {
        IEnumerable<Collection> GetCollections(string username);
        Collection GetCollection(string username, string collectionName);
        Task<Collection> Create(Collection collection);
        IEnumerable<Collection> GetWithInclude(Func<Collection, bool> predicate,
                params Expression<Func<Collection, object>>[] includeProperties);

    }
}
