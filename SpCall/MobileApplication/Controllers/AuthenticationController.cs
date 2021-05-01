using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MobileApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MobileApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly SqlDbContext _dbContext;
        public AuthenticationController(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string ReturnUrl)
        {
            if(ModelState.IsValid)
            {
                if (ValidateUser(model))
                {
                    var claims = new List<Claim>
                    {
                        new Claim("user", model.Username),
                        new Claim("role", "member")
                    };

                    await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookie", "user", "role")));
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return Redirect("/");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            return View();
        }

        public bool ValidateUser(LoginModel entity)
        {
            var user = _dbContext.GetUser(entity.Username);
            if (user?.id > 0)
            {
                if(user.UserName == entity.Username && user.Password == entity.Password)
                {
                    return true;
                }
            }
            return false;
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return View();
        }
    }
}
