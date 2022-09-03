using System.ComponentModel.DataAnnotations;

namespace PhotoService.DAL.Entities
{
    public class Image:BaseEntity
    {
        [Required]
        public string ImageBase64 { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        public int DownloadsCount { get; set; } = 0;
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Hashtag> Hashtags { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
    }
}
