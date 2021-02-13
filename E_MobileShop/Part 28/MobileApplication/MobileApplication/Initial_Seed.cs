using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication
{
    public static class SeedInitial
    {
        public static void SeedDefaultUserDetails(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            AddRoles(roleManager);
            AddUsers(userManager);
        }

        private static void AddRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole{Name = "Administrator"};
                var result = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Dealer").Result)
            {
                var role = new IdentityRole{Name = "Dealer" };
                var result = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("AppUser").Result)
            {
                var role = new IdentityRole { Name = "AppUser" };
                var result = roleManager.CreateAsync(role).Result;
            }
        }

        private static void AddUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new IdentityUser()
                {
                    UserName = "admin",
                    Email = "admin@gmail.com"
                };
                var result = userManager.CreateAsync(user, "Admin@123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }        
    }
}
