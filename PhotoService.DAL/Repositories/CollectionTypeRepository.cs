using PhotoService.DAL.Entities;
using PhotoService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.DAL.Repositories
{
    public class CollectionTypeRepository : ICollectionTypeRepository
    {
        private readonly PhotoServiceDbContext _dbContext;

        public CollectionTypeRepository(PhotoServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CollectionType GetCollectionTypeByTitle(string title)
        {
            return _dbContext.CollectionType.First(type => type.Title == title);
        }
    }
}
