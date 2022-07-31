
namespace PhotoService.BLL.Models
{
    public class CommentModel
    {
        public UserModel UserAdded { get; set; }
        public DateTime DateAdded { get; set; }
        public string CommentText { get; set; }
    }
}
