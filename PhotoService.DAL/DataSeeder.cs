using PhotoService.DAL.Entities;

namespace PhotoService.DAL
{
    public static class DataSeeder
    {
        public static CollectionType[] GetCollectionTypes()
        {
            var allTypes = Enum.GetValues(typeof(CollectionTypes));
            var allTypesList = new List<CollectionType>();

            foreach (var item in allTypes)
            {
                allTypesList.Add(
                    new CollectionType
                    {
                        Id = (allTypesList.LastOrDefault()?.Id + 1) ?? 1,
                        Title = item.ToString()
                    }
                );
            }

            return allTypesList.ToArray();
        }
        public static Role[] GetRoles()
        {
            var allRoles = Enum.GetValues(typeof(UserRoles));
            var allRolesList = new List<Role>();

            foreach (var item in allRoles)
            {
                allRolesList.Add(
                    new Role
                    {
                        Id = (allRolesList.LastOrDefault()?.Id + 1) ?? 1,
                        Title = item.ToString()
                    }
                ) ;
            }

            return allRolesList.ToArray();
        }
        public static User[] GetDefaultUsers()
        {
            return new User[]
            {
                new User
                {
                    Id=1,
                    Email="admin@admin.com",
                    UserName="admin",
                    IsVerified=true,
                    PasswordHash="$2a$11$Am8FabDqHpPhRkqfMs6opOxF9r95/YUAlDpPiLlb3I9kiKkDCTWiW",
                    AvatarUrl="https://upload.wikimedia.org/wikipedia/commons/9/9a/Gull_portrait_ca_usa.jpg"
                }
            };
        }

    }
}
