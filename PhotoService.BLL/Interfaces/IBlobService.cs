using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Interfaces
{
    public interface IBlobService
    {
        Task<string> UploadPhoto(string name, string base64);
    }
}
