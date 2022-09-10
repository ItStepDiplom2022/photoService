using PhotoService.DAL.Entities;
using System.Linq.Expressions;

namespace PhotoService.DAL.Interfaces
{
    public interface IImageRepository
    {
        IEnumerable<Image> GetImages();
        Task<Image> GetImage(int id);
        Task<Image> Add(Image image);
        void Update(Image image);
        void AddHashTag(Image image, Hashtag hashtag);
        void AddComment(Image image, Comment comment);
        IEnumerable<Image> FindAll(Expression<Func<Image, bool>> predicate);
        IEnumerable<Image> GetWithInclude(Func<Image, bool> predicate,
               params Expression<Func<Image, object>>[] includeProperties);
    }
}
