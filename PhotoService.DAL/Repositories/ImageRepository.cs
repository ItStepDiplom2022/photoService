using PhotoService.DAL.Entities;
using PhotoService.DAL.Interfaces;
using System.Linq.Expressions;

namespace PhotoService.DAL.Repositories
{
    public class ImageRepository : IImageRepository
    {
        //mock
        //TODO: add connections to DB
        List<Image> _images = new List<Image>
        {
            new Image
            {
                Id = 1,
                Title = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. ",
                ImageUrl = "https://source.unsplash.com/random/?tech,care",
                DateAdded = new DateTime(2021,10,12),
                Author = new User
                {
                    Email = "email@mail.com",
                    UserName = "username1"
                },
                Likes = new List<Like>
                {
                    new Like{
                        Id=1,
                        User = new User
                        {
                            Id=10,
                            UserName="qwerty",
                            Email="qwerty@qwerty.com"
                        },
                    },
                     new Like{
                        Id=2,
                        User = new User
                        {
                            Id=11,
                            UserName="qwerty2",
                            Email="gaizler02@gmail.com"
                        },
                     }
                },
                Hashtags = new List<Hashtag>
                {
                   new Hashtag{
                       Id=1,
                       Title="tag1"
                   },
                    new Hashtag{
                       Id=2,
                       Title="tag2"
                   }
                },
                Comments = new List<Comment>
                {
                    new Comment
                    {
                        Id=1,
                        UserAdded = new User
                        {
                            Id=999,
                            UserName="Someone"
                        },
                        DateAdded=DateTime.Now,
                        CommentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur."
                    },
                    new Comment
                    {
                        Id=1,
                        UserAdded = new User
                        {
                            Id=999,
                            UserName="Someone"
                        },
                        DateAdded=DateTime.Now,
                        CommentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
                    }
                }
            }
        };

        public Image Add(Image image)
        {
            _images.Add(image);
            return image;
        }

        public IEnumerable<Image> FindAll(Expression<Func<Image, bool>> predicate)
        {
            return _images.AsQueryable().Where(predicate);
        }

        public Image GetImage(int id)
        {
            return _images.FirstOrDefault(image => image.Id == id);
        }

        public List<Image> GetImages()
        {
            return _images;
        }

        public void Update(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
