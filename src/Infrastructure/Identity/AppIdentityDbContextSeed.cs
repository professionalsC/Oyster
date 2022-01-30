using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Oyster.ApplicationCore.Constants;

namespace Oyster.Infrastructure.Identity;

public class AppIdentityDbContextSeed
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(Constants.Roles.ADMINISTRATORS));
        await roleManager.CreateAsync(new IdentityRole(Constants.Roles.MERCHANTS));
        await roleManager.CreateAsync(new IdentityRole(Constants.Roles.CUSTOMERS));

        string customerUserName = "9818068718";
        var customerUser = new ApplicationUser { UserName = customerUserName, Email = "demouser@microsoft.com" };
        await userManager.CreateAsync(customerUser, AuthorizationConstants.DEFAULT_PASSWORD);
        customerUser = await userManager.FindByNameAsync(customerUserName);
        await userManager.AddToRoleAsync(customerUser, Constants.Roles.ADMINISTRATORS);

        string adminUserName = "admin@microsoft.com";
        var adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName };
        await userManager.CreateAsync(adminUser, AuthorizationConstants.DEFAULT_PASSWORD);
        adminUser = await userManager.FindByNameAsync(adminUserName);
        await userManager.AddToRoleAsync(adminUser, Constants.Roles.ADMINISTRATORS);
    }
}
