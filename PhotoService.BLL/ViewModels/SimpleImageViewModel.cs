namespace PhotoService.BLL.ViewModels
{
    public class SimpleImageViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public SimpleUserViewModel Author { get; set; }
    }
}
