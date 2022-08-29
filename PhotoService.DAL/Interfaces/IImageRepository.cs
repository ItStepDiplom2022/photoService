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
        IEnumerable<Image> FindAll(Expression<Func<Image, bool>> predicate);
    }
}
