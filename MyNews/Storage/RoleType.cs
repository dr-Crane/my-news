using System.ComponentModel.DataAnnotations;

namespace MyNews.Storage
{
    public enum RoleType
    {
        [Display(Name = ApplicationRoleNames.Moderator)]
        Administrator,
        [Display(Name = ApplicationRoleNames.User)]
        User
    }
}
