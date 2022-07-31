
using System.ComponentModel.DataAnnotations;

namespace PhotoService.BLL.Models
{
    public class ImageModel
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserModel Author { get; set; }
        public DateTime DateAdded { get; set; }
        public IEnumerable<CommentModel> Comments { get; set; }
        public IEnumerable<HashtagModel> Hashtags { get; set; }
        public IEnumerable<LikeModel> Likes { get; set; }
    }
}
