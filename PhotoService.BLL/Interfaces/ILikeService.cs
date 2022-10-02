using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Interfaces
{
    public interface ILikeService
    {
        Task<bool> IsLiked(int imageId, string username);
        Task Like(int imageId, string username);
        Task Dislike(int imageId, string username);

    }
}
