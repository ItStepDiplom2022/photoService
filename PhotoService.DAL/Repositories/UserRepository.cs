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
    public class UserRepository:IUserRepository
    {
        private readonly PhotoServiceDbContext _dbContext;

        public UserRepository(PhotoServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Create(User user)
        {
            user.AvatarUrl = "https://photoservicestorage1.blob.core.windows.net/photos/user.png";
            var addedUser = await _dbContext.Users.AddAsync(user);
            return addedUser.Entity;
        }

        public IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate)
        {
            return _dbContext.Users.AsQueryable().Where(predicate);
        }

        public User GetUser(string email)
        {
            return GetWithInclude(user => user.Email.ToLower() == email.ToLower(),
                i => i.Images, i => i.Collections, i => i.Roles).First();
            //return _dbContext.Users.FirstOrDefault(user => user.Email == email);
        }

        public User GetUserByUsername(string username)
        {
            return GetWithInclude(user => user.UserName.ToLower() == username.ToLower(),
                i => i.Images, i => i.Collections, i => i.Roles).First();
            //return _dbContext.Users.FirstOrDefault(user => user.UserName.ToLower() == username.ToLower());
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.AsEnumerable();
        }

        public void AddRole(User user, Role role)
        {
            if(user.Roles.Any())
                user.Roles.Add(role);
            else
                user.Roles = new List<Role> { role};

            _dbContext.Users.Update(user);
        }

        public void AddCollection(User user, Collection collection)
        {
            if (user.Collections!=null&&user.Collections.Any())
                user.Collections.Add(collection);
            else
                user.Collections = new List<Collection> { collection };

            _dbContext.Users.Update(user);
        }

        public void Update(User user)
        {
            _dbContext.Users.Update(user);
        }

        public IQueryable<User> Include(params Expression<Func<User, object>>[] includeProperties)
        {
            IQueryable<User> query = _dbContext.Users;
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IEnumerable<User> GetWithInclude(params Expression<Func<User, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<User> GetWithInclude(Func<User, bool> predicate,
                params Expression<Func<User, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

    }
}
