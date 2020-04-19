using GUIEX2PROJECT.Models;
using Microsoft.AspNetCore.Identity;

namespace GUIEX2PROJECT.Controllers
{
    public class AuthController
    {
        private SignInManager<Employee> _signInManager;
        private UserManager<Employee> _userManager;

        public AuthController(UserManager<Employee> userManager,
            SignInManager<Employee> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
    }
}