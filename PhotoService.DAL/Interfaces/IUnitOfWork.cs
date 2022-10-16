namespace PhotoService.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IImageRepository ImageRepository { get; }
        ICollectionRepository CollectionRepository { get; }
        IRoleRepository RoleRepository { get; }
        IHashTagRepository HashTagRepository { get; }
        ICollectionTypeRepository CollectionTypeRepository { get; }
        ICommentRepository CommentRepository { get; }

        Task<int> SaveAsync();
    }
}
