using PhotoService.DAL.Entities;
using PhotoService.DAL.Interfaces;

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

        public IEnumerable<Hashtag> GetHashTags()
        {
            return _dbContext.Hashtags;
        }
    }
}
