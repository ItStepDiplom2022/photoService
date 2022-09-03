using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.DAL.Entities
{
    public class CollectionType:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
    }
}
