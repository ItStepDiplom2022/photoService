using PhotoService.DAL.Entities;
using PhotoService.DAL.Interfaces;

namespace PhotoService.DAL.Repositories
{
    public class RoleRepository:IRoleRepository
    {
        private readonly PhotoServiceDbContext _dbContext;

        public RoleRepository(PhotoServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Role GetRoleByTitle(string title)
        {
            return _dbContext.Roles.FirstOrDefault(role => role.Title == title);
        }
    }
}
