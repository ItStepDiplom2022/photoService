using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Interfaces
{
    public interface IUserCollectionService
    {
        IList<CollectionModel> GetCollections(string username);
        CollectionModel GetCollection(string username, string name);
        CollectionModel CreateCollection(string username, string name);
    }
}
