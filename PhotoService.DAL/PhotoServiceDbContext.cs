using Microsoft.EntityFrameworkCore;
using PhotoService.DAL.Entities;

namespace PhotoService.DAL
{
    public class PhotoServiceDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Role> Roles { get; set; }

        public PhotoServiceDbContext(DbContextOptions<PhotoServiceDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<CollectionType>(e =>
            {
                e.HasData(DataSeeder.GetCollectionTypes());
            });

            modelBuilder.Entity<Role>(e =>
            {
                e.HasData(DataSeeder.GetRoles());
            });

            modelBuilder.Entity<User>(e =>
            {
                e.HasData(DataSeeder.GetDefaultUsers());
            });

        }
    }
}
