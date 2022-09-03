using System.ComponentModel.DataAnnotations;

namespace PhotoService.DAL.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
