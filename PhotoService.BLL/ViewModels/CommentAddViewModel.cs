using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.ViewModels
{
    public class CommentAddViewModel
    {
        public string Username { get; set; }
        public string Comment { get; set; }
        public int ImageId { get; set; }
    }
}
