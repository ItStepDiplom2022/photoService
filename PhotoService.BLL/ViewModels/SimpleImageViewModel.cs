using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.ViewModels
{
    public class SimpleImageViewModel
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public SimpleUserViewModel Author { get; set; }
    }
}
