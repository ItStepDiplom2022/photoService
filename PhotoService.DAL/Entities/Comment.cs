namespace PhotoService.DAL.Entities
{
    public class Comment:BaseEntity
    {
        public User UserAdded { get; set; }
        public DateTime DateAdded { get; set; }
        public string CommentText { get; set; }
    }
}
