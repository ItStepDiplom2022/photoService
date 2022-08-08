namespace PhotoService.DAL.Entities
{
    public class Image:BaseEntity
    {
        public string ImageBase64 { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User Author { get; set; }
        public DateTime DateAdded { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Hashtag> Hashtags { get; set; }
        public IEnumerable<Like> Likes { get; set; }

    }
}
