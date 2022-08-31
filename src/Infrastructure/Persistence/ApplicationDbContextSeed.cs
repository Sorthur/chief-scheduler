using System.Reflection;
using chief_schedule.Domain.Entities;
using chief_schedule.Domain.ValueObjects;
using chief_schedule.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace chief_schedule.Infrastructure.Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        await SeedRoles(roleManager);
        await SeedAdministratorUser(userManager, roleManager);
        await SeedWorkerUser(userManager, roleManager);
    }

    private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        var roles = typeof(RoleName).GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy)
                        .Select(filedInfo => new IdentityRole(filedInfo.GetValue(null)!.ToString()))
                        .ToList();

        foreach (var role in roles)
        {
            if (roleManager.Roles.All(r => r.Name != role.Name))
            {
                await roleManager.CreateAsync(role);
            }
        }
    }

    private static async Task SeedAdministratorUser(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        var administratorRole = new IdentityRole(RoleName.ADMINISTRATOR);

        if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await roleManager.CreateAsync(administratorRole);
        }

        var administrator = new ApplicationUser { UserName = "administrator", Email = "administrator@localhost" };

        if (userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await userManager.CreateAsync(administrator, "ASDqwe123");
            await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
        }
    }

    private static async Task SeedWorkerUser(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        var workerRole = new IdentityRole(RoleName.WORKER);

        if (roleManager.Roles.All(r => r.Name != workerRole.Name))
        {
            await roleManager.CreateAsync(workerRole);
        }

        var administrator = new ApplicationUser { UserName = "user", Email = "user@localhost" };

        if (userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await userManager.CreateAsync(administrator, "ASDqwe123");
            await userManager.AddToRolesAsync(administrator, new[] { workerRole.Name });
        }
    }

    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        // Seed, if necessary
        if (!context.TodoLists.Any())
        {
            context.TodoLists.Add(new TodoList
            {
                Title = "Shopping",
                Colour = Colour.Blue,
                Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" }
                    }
            });

            await context.SaveChangesAsync();
        }
    }
}
