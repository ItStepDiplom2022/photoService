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


        //mock
        //TODO: add connections to DB
        //List<Image> _images = new List<Image>
        //{
        //    new Image
        //    {
        //        Id = 1,
        //        Title = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
        //        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. ",
        //        ImageBase64 = "https://source.unsplash.com/random/?tech,care",
        //        DateAdded = new DateTime(2021,10,12),
        //        Author = new User
        //        {
        //            Email = "email@mail.com",
        //            UserName = "username1",
        //            AvatarUrl = "https://source.unsplash.com/random/?tech,studied"
        //        },
        //        Likes = new List<Like>
        //        {
        //            new Like{
        //                Id=1,
        //                User = new User
        //                {
        //                    Id=10,
        //                    UserName="qwerty",
        //                    Email="qwerty@qwerty.com"
        //                },
        //            },
        //             new Like{
        //                Id=2,
        //                User = new User
        //                {
        //                    Id=11,
        //                    UserName="qwerty2",
        //                    Email="gaizler02@gmail.com"
        //                },
        //             }
        //        },
        //        Hashtags = new List<Hashtag>
        //        {
        //           new Hashtag{
        //               Id=1,
        //               Title="tag1"
        //           },
        //            new Hashtag{
        //               Id=2,
        //               Title="tag2"
        //           }
        //        },
        //        Comments = new List<Comment>
        //        {
        //            new Comment
        //            {
        //                Id=1,
        //                UserAdded = new User
        //                {
        //                    Id=999,
        //                    UserName="Someone"
        //                },
        //                DateAdded=DateTime.Now,
        //                CommentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur."
        //            },
        //            new Comment
        //            {
        //                Id=1,
        //                UserAdded = new User
        //                {
        //                    Id=999,
        //                    UserName="Someone"
        //                },
        //                DateAdded=DateTime.Now,
        //                CommentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
        //            }
        //        }
        //    }
        //};

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

        public void Update(Image image)
        {
            throw new NotImplementedException();
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
