using Microsoft.AspNetCore.Identity;

namespace MyNews.Storage
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public ICollection<UserRole> Roles { get; set; }
    }
}
