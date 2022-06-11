using MyNews.Models.ViewModels;

namespace MyNews.Services
{
    public interface IUsersService
    {
        Task Register(RegisterViewModel model);
    }

}
