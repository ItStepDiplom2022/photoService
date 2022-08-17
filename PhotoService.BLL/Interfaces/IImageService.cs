﻿using PhotoService.BLL.Models;

namespace PhotoService.BLL.Interfaces
{
    public interface IImageService
    {
        IEnumerable<ImageModel> GetImages();
        ImageModel GetImage(int id);
        ImageModel AddImage(ImageAddModel model);
        IEnumerable<ImageModel> GetImagesByUserEmail(string email);
        IEnumerable<ImageModel> GetImagesByUserName(string email);

    }
}
