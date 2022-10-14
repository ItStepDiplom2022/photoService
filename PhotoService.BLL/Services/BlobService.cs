using Azure.Storage.Blobs;
using PhotoService.BLL.Interfaces;

namespace PhotoService.BLL.Services
{
    public class BlobService:IBlobService
    {
        private readonly string _blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=photoservicestorage1;AccountKey=zKdnlITPNhvPv0a/4neBnT4ctnRoDR5tVRxglZBGW6Kc7QjowBgvibuZEya3N7WppbiHF5OI30BV+AStKFQH3g==;EndpointSuffix=core.windows.net";
        private readonly string _containerName = "photos";
        private readonly string _blobContainerUrl = "https://photoservicestorage1.blob.core.windows.net/";

        private readonly BlobContainerClient _blobContainerClient;

        public BlobService()
        {
            _blobContainerClient = new BlobContainerClient(_blobStorageConnectionString, _containerName);
        }

        public async Task<string> UploadPhoto(string name, string base64)
        {
            var bytes = Convert.FromBase64String(base64);
            var stream = new MemoryStream(bytes);

            name = name.Replace(" ", "");

            await _blobContainerClient.UploadBlobAsync(name, stream);
            return GetUploadedImageUrl(name);
        }

        private string GetUploadedImageUrl(string title)
        {
            return string.Concat(_blobContainerUrl, _containerName, "/", title);
        }
    }
}
