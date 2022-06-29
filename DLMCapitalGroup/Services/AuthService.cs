using DLMCapitalGroup.DTOs;
using DLMCapitalGroup.Model;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace DLMCapitalGroup.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Customer> _userMgr;
        private readonly SignInManager<Customer> _signMgr;
        private readonly IJwtService _jwtService;
        public AuthService(UserManager<Customer> userManager, SignInManager<Customer> signInManager, IJwtService jwtService)
        {
            _userMgr = userManager;
            _signMgr = signInManager;
            _jwtService = jwtService;
        }
        public async Task<LoginCredResponse> Login(LoginCred model)
        {
            var user = await _userMgr.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new LoginCredResponse { Status = false };
            }
            var res = await _signMgr.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

            if (!res.Succeeded)
            {
                return new LoginCredResponse { Status = false };
            }
      
            var userRoles = await _userMgr.GetRolesAsync(user);
            var token = _jwtService.GenerateJWTToken(user, userRoles.ToList());

            return new LoginCredResponse { Status = true, Id = user.Id, token = token };
        }
    }
}
