using System.ComponentModel.DataAnnotations;

namespace PhotoService.DAL.Entities
{
    public class Image:BaseEntity
    {
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Hashtag> Hashtags { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
    }
}
