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

        //mock
        //TODO: add connections to DB
        //List<User> _users=new List<User>
        //{
        //    new User
        //    {
        //        Email="admin@admin.com",
        //        UserName="admin",
        //        PasswordHash="$2a$11$Am8FabDqHpPhRkqfMs6opOxF9r95/YUAlDpPiLlb3I9kiKkDCTWiW",
        //        IsVerified=true,
        //        Country="Ukraine",
        //        City="Lviv",
        //        AvatarUrl="https://upload.wikimedia.org/wikipedia/commons/9/9a/Gull_portrait_ca_usa.jpg"
        //    } 
        //};

        public async Task<User> Create(User user)
        {
            var addedUser = await _dbContext.Users.AddAsync(user);
            return addedUser.Entity;
        }

        public IEnumerable<User> FindAll(Expression<Func<User, bool>> predicate)
        {
            return _dbContext.Users.AsQueryable().Where(predicate);
        }

        public User GetUser(string email)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Email == email);
        }

        public User GetUserByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(user => user.UserName.ToLower() == username.ToLower());
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.AsEnumerable();
        }

        public void Update(User user)
        {
            _dbContext.Users.Update(user);
        }
    }
}
