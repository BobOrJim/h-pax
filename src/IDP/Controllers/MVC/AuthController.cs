using IDP.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IDP.ViewModels.Auth;
using IdentityServer4.Services;
using Serilog;
using Common;
using System;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace IDP.Controllers.MVC
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIdentityServerInteractionService _identityServerInteractionService;
        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IIdentityServerInteractionService identityServerInteractionService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _identityServerInteractionService = identityServerInteractionService;
        }


        [HttpGet("Login")]
        public IActionResult Login(string returnUrl)
        {
            return View("Login", new LoginViewModel { ReturnUrl = returnUrl ?? uri.IDP });
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var result = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, false, false);

            if (result.Succeeded)
            {
                //Solution-big-picture strategy:
                //A: Client login to IDP-microservice, and IDP create a cookie with a GUID. The guid is from CoreIdentity user management.
                //B: Client connect to UI-head(MVC) with access-token.If endpoint is reached and token has proper access, mvc read the cookie, and use the guid as a key in a sessionStorage. The value in the sessionStorage is a Basket.
                //C: Session storage is global, and every ViewModel contain a Basket through inheritance.

                //Conclusion: here we write a cookie to the client with the GUID. This is no security risk, becouse the accesstoken protect all endpoints
                //And the guid is only used to link the basket to the client.
                //CreateCookie("h-pax.cookie", "myGuid");

                var appUser = _signInManager.UserManager.Users.SingleOrDefault(r => r.UserName == vm.Username);
                CreateCookie("h-pax.cookie", appUser.Id.ToString());

                return Redirect(vm.ReturnUrl ?? uri.IDP);
            }
            return View("Login", new LoginViewModel { ReturnUrl = vm.ReturnUrl ?? uri.IDP });
        }

        public void CreateCookie(string key, string value)
        {
            CookieOptions option = new CookieOptions()
            {
                Path = "/",
                HttpOnly = false, //True = prevent client-side JS from accessing the cookie vlaue
                Secure = false, //True = only HTTPS
                Expires = DateTime.Now.AddMinutes(10)
            };

            Response.Cookies.Append(key, value, option);
        }
    }
}



