using PhotoService.DAL.Entities;

namespace PhotoService.DAL.Interfaces
{
    public interface ICollectionTypeRepository
    {
        CollectionType GetCollectionTypeByTitle(string title);
    }
}
