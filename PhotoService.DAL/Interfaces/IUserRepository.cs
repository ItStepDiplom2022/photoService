using PhotoService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.DAL.Interfaces
{
    //TODO: make all methods asynchronuous, when DB will be done
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(string email);
        User GetUserByUsername(string username);
        Task<User> Create(User user);
        void Update(User user);
        IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate);
    }
}
