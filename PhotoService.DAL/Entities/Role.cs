using System.ComponentModel.DataAnnotations;

namespace PhotoService.DAL.Entities
{
    public class Role:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
