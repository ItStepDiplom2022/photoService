using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(string key, string email);
    }
}
