using Microsoft.EntityFrameworkCore;
using PhotoService.DAL.Entities;
using PhotoService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.DAL.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly PhotoServiceDbContext _dbContext;

        public CommentRepository(PhotoServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Comment> Include(params Expression<Func<Comment, object>>[] includeProperties)
        {
            IQueryable<Comment> query = _dbContext.Comments;
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IEnumerable<Comment> GetWithInclude(params Expression<Func<Comment, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<Comment> GetWithInclude(Func<Comment, bool> predicate,
                params Expression<Func<Comment, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }
    }
}
