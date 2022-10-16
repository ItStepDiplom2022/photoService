namespace PhotoService.BLL.Interfaces
{
    public interface IBlobService
    {
        Task<string> UploadPhoto(string name, string base64);
    }
}
