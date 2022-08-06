using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Models
{
    public class ImageFilterModel
    {
        public string Query { get; set; } = "";
        public string Author { get; set; } = "";
        public string Tag { get; set; } = "";
    }
}
