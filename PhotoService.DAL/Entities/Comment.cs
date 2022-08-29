using System.ComponentModel.DataAnnotations;

namespace PhotoService.DAL.Entities
{
    public class Comment:BaseEntity
    {
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public string CommentText { get; set; }
        public virtual Image Image { get; set; }
        public virtual User UserAdded { get; set; }
    }
}
