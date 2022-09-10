using PhotoService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.DAL.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetWithInclude(Func<Comment, bool> predicate,
                params Expression<Func<Comment, object>>[] includeProperties);
    }
}
