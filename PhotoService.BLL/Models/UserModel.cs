namespace PhotoService.BLL.Models
{
    public class UserModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public bool IsVerified { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? AvatarUrl { get; set; }

        public ICollection<RoleModel> Roles { get; set; }= new List<RoleModel>();

        public ICollection<ImageModel> Images { get; set; }

        public ICollection<CommentModel> Comments { get; set; } = new List<CommentModel>();

        public ICollection<CollectionModel> Collections { get; set; }

    }
}
