using CursosAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace CursosAPI.Data.Seed
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<Usuario> userManager)
        {
            if (!await roleManager.RoleExistsAsync(nameof(Roles.ADMIN)))
            {
                await roleManager.CreateAsync(new IdentityRole(nameof(Roles.ADMIN)));
            }

            if (!await roleManager.RoleExistsAsync(nameof(Roles.INSTRUTOR)))
            {
                await roleManager.CreateAsync(new IdentityRole(nameof(Roles.INSTRUTOR)));
            }

            if (!await roleManager.RoleExistsAsync(nameof(Roles.ESTUDANTE)))
            {
                await roleManager.CreateAsync(new IdentityRole(nameof(Roles.ESTUDANTE)));
            }

            var admin = await userManager.FindByNameAsync("admin");

            if (admin == null)
            {
                admin = new Usuario
                {
                    UserName = "admin",
                    Email = "admin@email.com"
                };

                var resultado = await userManager.CreateAsync(admin, "Admin@123");

                if (resultado.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, nameof(Roles.ADMIN));
                }
            }
        }
    }
}
