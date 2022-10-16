namespace PhotoService.BLL.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<UserModel> Users { get; set; }
    }
}
