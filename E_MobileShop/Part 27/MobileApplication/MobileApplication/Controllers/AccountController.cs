using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MobileApplication.Controllers
{
    public class AccountController : Controller
    {
        MobileDbContext _context;
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        public AccountController(MobileDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "MobileBrand");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password, string Email)
        {
            var user = new IdentityUser
            {
                UserName = username,
                Email = "test@gmail.com"
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "MobileBrand");
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Login(string UserName, string Password)
        //{
        //    if (_context.users.Where(p => p.UserName == UserName && p.Password == Password).Count() > 0)
        //    {
        //        string url = Request.Path;
        //        var customClaim = new List<Claim>()
        //        {
        //            new Claim(ClaimTypes.Name, UserName),
        //            new Claim(ClaimTypes.Role, "Admin")
        //        };
        //        var customIdentity = new ClaimsIdentity(customClaim, "Custom Identity");
        //        var customPrinciple = new ClaimsPrincipal(new[] { customIdentity });
        //        HttpContext.SignInAsync(customPrinciple);

        //        return RedirectToAction("Index", "MobileBrand");
        //    }
        //    else
        //    {
        //        @ViewBag.Error = $"Login Failed for user {UserName}";
        //        return View();
        //    }
        //}
    }
}
