using PhotoService.BLL.Models;
using PhotoService.BLL.ViewModels;

namespace PhotoService.BLL.Interfaces
{
    public interface IImageService
    {
        IEnumerable<ImageModel> GetImages();
        ImageModel GetImage(int id);
        Task<ImageModel> AddImage(ImageAddModel model);
        Task AddComment(CommentAddViewModel commentAdd);
        IEnumerable<ImageModel> GetImagesByUserEmail(string email);
        IEnumerable<ImageModel> GetImagesByUserName(string email);

    }
}
