using PhotoService.BLL.Models;

namespace PhotoService.BLL.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentModel> RetrieveComments(int imageId);
    }
}
