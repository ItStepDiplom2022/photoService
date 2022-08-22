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
    public class UserRepository:IUserRepository
    {
        //mock
        //TODO: add connections to DB
        List<User> _users=new List<User>
        {
            new User
            {
                Email="admin@admin.com",
                UserName="admin",
                Password="$2a$11$Am8FabDqHpPhRkqfMs6opOxF9r95/YUAlDpPiLlb3I9kiKkDCTWiW",
                IsVerified=true,
                Country="Ukraine",
                City="Lviv"
            } 
        };

        public User Create(User user)
        {
            _users.Add(user);
            return user;
        }

        public IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate)
        {
            return _users.AsQueryable().Where(predicate);
        }

        public User GetUser(string email)
        {
            return _users.FirstOrDefault(user => user.Email == email);
        }

        public User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(user => user.UserName.ToLower() == username.ToLower());
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public void Update(User user)
        {
            var u=_users.First(x => x.UserName == user.UserName);

            u.IsVerified = user.IsVerified;
            u.Email = user.Email;
            //and so on
        }
    }
}
