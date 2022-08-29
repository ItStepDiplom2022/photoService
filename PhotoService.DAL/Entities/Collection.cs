using PhotoService.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace PhotoService.DAL
{
    public class Collection : BaseEntity
    {
        [Required]
        public string ImageBase64 { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        [Required]
        public User Owner { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        [Required]
        public virtual CollectionType CollectionType { get; set; }
    }
}