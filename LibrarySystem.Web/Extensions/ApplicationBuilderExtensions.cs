using LibrarySystem.Domain.Entities;
using LibrarySystem.Infrastructure.Seeders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LibrarySystem.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task SeedIdentityAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            await IdentitySeeder.SeedAdminAsync(userManager, roleManager);

            if (!await roleManager.RoleExistsAsync("Member"))
                await roleManager.CreateAsync(new IdentityRole<Guid>("Member"));
        }
    }
}
