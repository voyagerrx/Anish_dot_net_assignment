using Microsoft.AspNetCore.Identity;
using onlinebooksstore.Areas.Identity.Data;
using onlinebooksstore.Data;

namespace onlinebooksstore.Models
{
    public static class dninitializer
    {
        public static async Task InitializeAsync(onlinebooksstoreContext context, IServiceProvider serviceProvider, UserManager<onlinebooksstoreUser> userManager)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin",  "User" };
            IdentityResult roleResult;
            foreach (var RoleName in roleNames)
            {
                var roleExists = await RoleManager.RoleExistsAsync(RoleName);
                if (!roleExists)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(RoleName));

                }
            }
            string Email = "admin@eemc.com";
            string Password = "Admin@123";
            if (userManager.FindByEmailAsync(Email).Result == null)
            {
                onlinebooksstoreUser user = new onlinebooksstoreUser();
                user.UserName = Email;
                user.Email = Email;
                IdentityResult result = userManager.CreateAsync(user, Password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }


        }
    }
}