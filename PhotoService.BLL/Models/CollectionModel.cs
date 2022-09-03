using PhotoService.BLL.Models;

namespace PhotoService.BLL
{
    public class CollectionModel
    {
        public string UrlName { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public UserModel User { get; set; }
        public IList<ImageModel> Images { get; set; }
    }
}