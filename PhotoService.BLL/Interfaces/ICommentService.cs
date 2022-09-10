using PhotoService.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentModel> RetrieveComments(int imageId);
    }
}
