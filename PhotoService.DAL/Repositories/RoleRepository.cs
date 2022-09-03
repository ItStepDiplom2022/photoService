using Microsoft.EntityFrameworkCore;
using PhotoService.DAL.Entities;
using PhotoService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
