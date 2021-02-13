using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobileApplication.Models;

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

        [HttpGet]
        public async Task<IActionResult> ManageUserRole()
        {
            List<UserModel> listUsers = new List<UserModel>();
            foreach (var item in _userManager.Users.ToList())
            {
                UserModel model = new UserModel();
                model.UserName = item.UserName;
                model.Email = item.Email;
                model.IsAdmin = await _userManager.IsInRoleAsync(item, "Administrator");
                model.IsDealer = await _userManager.IsInRoleAsync(item, "Dealer");
                model.IsAppUser = await _userManager.IsInRoleAsync(item, "AppUser");
                listUsers.Add(model);
            }
            return View(listUsers);
        }

        [HttpGet]
        public async Task<IActionResult> AddRole(string id)
        {
            var user = _userManager.Users.Where(p => p.UserName == id).FirstOrDefault();
            var userDetail = new UserModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                IsAdmin = await _userManager.IsInRoleAsync(user, "Administrator"),
                IsDealer = await _userManager.IsInRoleAsync(user, "Dealer"),
                IsAppUser = await _userManager.IsInRoleAsync(user, "AppUser"),
            };
            return View(userDetail);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(UserModel user, string UserName)
        {
            try
            {
                var userDetail = _userManager.Users.Where(p => p.UserName == user.UserName).FirstOrDefault();
                if (user.IsAdmin)
                    await _userManager.AddToRoleAsync(userDetail, "Administrator");
                if (user.IsDealer)
                    await _userManager.AddToRoleAsync(userDetail, "Dealer");
                if (user.IsAppUser)
                   await _userManager.AddToRoleAsync(userDetail, "AppUser");
                return RedirectToAction("ManageUserRole", "Account");
            }
            catch (Exception ex)
            {
                throw;
            }           
            return View();
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
