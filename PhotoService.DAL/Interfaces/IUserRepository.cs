using PhotoService.DAL.Entities;
using System.Linq.Expressions;

namespace PhotoService.DAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(string email);
        User GetUserByUsername(string username);
        Task<User> Create(User user);
        void Update(User user);
        IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate);
        void AddRole(User user, Role role);
        void AddCollection(User user, Collection collection);
        IEnumerable<User> GetWithInclude(Func<User, bool> predicate,
                params Expression<Func<User, object>>[] includeProperties);
    }
}
