using MyNews.Models.ViewModels;

namespace MyNews.Services
{
    public interface IUsersService
    {
        Task Register(RegisterViewModel model);
        Task Login(LoginViewModel model);
        Task Logout();
    }

}
