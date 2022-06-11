using Microsoft.AspNetCore.Identity;

namespace MyNews.Storage
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate{ get; set; }
        public string Email { get; set; }
        public ICollection<UserRole> Roles { get; set; }
    }
}
