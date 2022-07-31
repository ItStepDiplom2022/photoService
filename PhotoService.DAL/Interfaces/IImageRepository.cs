using PhotoService.DAL.Entities;
using System.Linq.Expressions;

namespace PhotoService.DAL.Interfaces
{
    public interface IImageRepository
    {
        List<Image> GetImages();
        Image GetImage(int id);
        Image Add(Image image);
        void Update(Image image);
        IEnumerable<Image> FindAll(Expression<Func<Image, bool>> predicate);
    }
}
