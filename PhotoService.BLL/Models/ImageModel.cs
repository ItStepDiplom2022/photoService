using System.ComponentModel.DataAnnotations;

namespace PhotoService.BLL.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserModel Author { get; set; }
        public DateTime DateAdded { get; set; }
        public int LikesCount { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
        public ICollection<HashtagModel> Hashtags { get; set; }
        public ICollection<CollectionModel> Collections { get; set; }

    }
}
