using PhotoService.DAL.Entities;

namespace PhotoService.DAL.Interfaces
{
    public interface IHashTagRepository
    {
        Hashtag GetHashTagByTitle(string title);
    }
}
