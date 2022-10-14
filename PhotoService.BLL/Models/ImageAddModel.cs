using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PhotoService.BLL.Models
{
    public class ImageAddModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string  Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string UserEmail { get; set; }
        [Required]
        public IEnumerable<HashtagModel> Hashtags { get; set; }
    }
}
