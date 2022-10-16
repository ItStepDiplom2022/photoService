using System.ComponentModel.DataAnnotations;

namespace PhotoService.DAL.Entities
{
    public class Hashtag:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
