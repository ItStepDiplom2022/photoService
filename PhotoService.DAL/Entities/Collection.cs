using PhotoService.DAL.Entities;

namespace PhotoService.DAL
{
    public class Collection : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public IList<Image> Images { get; set; }
    }
}