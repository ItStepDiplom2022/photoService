using PhotoService.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Interfaces
{
    public interface IUserCollectionService
    {
        IList<CollectionModel> GetCollections(string username, bool publicOnly);
        CollectionModel GetCollection(string username, string name);
        Task<CollectionModel> CreateCollection(string username, string name, bool isPublic);
        Task AddImageToCollection(AddImageToCollectionViewModel model);
        public bool ChechIfIsLiked(string username, int imageId);
        Task RemoveImageFromCollection(AddImageToCollectionViewModel model);
    }
}
