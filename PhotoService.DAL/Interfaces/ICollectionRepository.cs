using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.DAL.Interfaces
{
    public interface ICollectionRepository
    {
        IList<Collection> GetCollections(string username);
        Collection GetCollection(string username, string collectionName);
        Collection Create(Collection collection);
    }
}
