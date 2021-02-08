using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MobileApplication.Controllers
{
    public class AccountController : Controller
    {
        MobileDbContext _context;
        public AccountController(MobileDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string UserName, string Password)
        {
            if (_context.users.Where(p => p.UserName == UserName && p.Password == Password).Count() > 0)
            {
                string url = Request.Path;
                var customClaim = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, UserName),
                    new Claim(ClaimTypes.Role, "Admin")
                };
                var customIdentity = new ClaimsIdentity(customClaim, "Custom Identity");
                var customPrinciple = new ClaimsPrincipal(new[] { customIdentity });
                HttpContext.SignInAsync(customPrinciple);

                return RedirectToAction("Index", "MobileBrand");
            }
            else
            {
                @ViewBag.Error = $"Login Failed for user {UserName}";
                return View();
            }
        }
    }
}
