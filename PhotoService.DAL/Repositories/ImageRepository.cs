using Microsoft.EntityFrameworkCore;
using PhotoService.DAL.Entities;
using PhotoService.DAL.Interfaces;
using System.Linq.Expressions;

namespace PhotoService.DAL.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly PhotoServiceDbContext _dbContext;

        public ImageRepository(PhotoServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Image> Add(Image image)
        {
            var addedImage =await _dbContext.Images.AddAsync(image);
            return addedImage.Entity;
        }

        public IEnumerable<Image> FindAll(Expression<Func<Image, bool>> predicate)
        {
            return _dbContext.Images.Where(predicate);
        }

        public async Task<Image> GetImage(int id)
        {
            return await _dbContext.Images.FindAsync(id);
        }

        public IEnumerable<Image> GetImages()
        {
            return _dbContext.Images.AsEnumerable();
        }

        public void AddHashTag(Image image, Hashtag hashtag)
        {
            if (image.Hashtags.Any())
                image.Hashtags.Add(hashtag);
            else
                image.Hashtags = new List<Hashtag> { hashtag };

            _dbContext.Images.Update(image);
        }

        public void AddComment(Image image, Comment comment)
        {
            if (image.Comments.Any())
                image.Comments.Add(comment);
            else
                image.Comments = new List<Comment> { comment };

            _dbContext.Images.Update(image);
        }

        public void Update(Image image)
        {
            _dbContext.Images.Update(image);
        }

        public IQueryable<Image>Include(params Expression<Func<Image, object>>[] includeProperties)
        {
            IQueryable<Image> query = _dbContext.Images;
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IEnumerable<Image> GetWithInclude(params Expression<Func<Image, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<Image> GetWithInclude(Func<Image, bool> predicate,
                params Expression<Func<Image, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

    }
}
