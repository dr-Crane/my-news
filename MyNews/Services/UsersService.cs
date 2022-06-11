using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using MyNews.Models.ViewModels;
using MyNews.Storage;
using System.Security.Claims;

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

        public async Task Login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with email = {model.Email} does not found");
            }

            var claims = new List<Claim>
            {
                new ("Name", user.Name),
                new ("Id", user.Id.ToString()),
                new (ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            if (user.Roles?.Any() == true)
            {
                var roles = user.Roles.Select(x => x.Role).ToList();
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));
            }

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(2), 
                IsPersistent = true
            };

            await _signInManager.SignInWithClaimsAsync(user, authProperties, claims);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }


    }
}
