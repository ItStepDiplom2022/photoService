using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.ViewModels
{
    public class AddImageToCollectionViewModel
    {
        public int ImageId { get; set; }
        public string Username { get; set; }
        public string CollectionName { get; set; }
    }
}
