using PhotoService.DAL.Entities;
using System.Linq.Expressions;

namespace PhotoService.DAL.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetWithInclude(Func<Comment, bool> predicate,
                params Expression<Func<Comment, object>>[] includeProperties);
    }
}
