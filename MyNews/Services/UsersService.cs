using Microsoft.AspNetCore.Identity;
using MyNews.Models.ViewModels;
using MyNews.Storage;

namespace MyNews.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UsersService(UserManager<User> userManager,
                SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task Register(RegisterViewModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.Email,
                BirthDate = model.BirthDate,
                Name = model.Name, 
                Surname = model.Surname
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded) 
            {
                await _signInManager.SignInAsync(user, false);
                return;
            }
            var errors = string.Join(", ", result.Errors.Select(x => x.Description));
            throw new ArgumentException(errors);
        }

    }
}
