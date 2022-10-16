using System.ComponentModel.DataAnnotations;

namespace PhotoService.DAL.Entities
{
    public class CollectionType:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
    }
}
