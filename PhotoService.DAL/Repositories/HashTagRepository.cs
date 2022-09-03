using PhotoService.DAL.Entities;
using PhotoService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.DAL.Repositories
{
    public class HashTagRepository : IHashTagRepository
    {
        private readonly PhotoServiceDbContext _dbContext;

        public HashTagRepository(PhotoServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Hashtag GetHashTagByTitle(string title)
        {
            return _dbContext.Hashtags.FirstOrDefault(tag => tag.Title == title);
        }
    }
}
