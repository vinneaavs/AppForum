using Microsoft.AspNetCore.Identity;

namespace Projeto02.GestaoForum.Models
{
    public class Utils
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            List<string> rolesNames = new List<string>();
            rolesNames.Add("ADMIN");
            rolesNames.Add("USER");
            rolesNames.Add("GUEST");

            IdentityResult result;

            foreach (var roleName in rolesNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist) 
                { 
                    result = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

        }
    }
}
