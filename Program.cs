using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Magazyn.Data;
using Microsoft.AspNetCore.Identity;

namespace Magazyn
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MagazynContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MagazynContext") ?? throw new InvalidOperationException("Connection string 'MagazynContext' not found.")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<MagazynContext>()
            .AddDefaultTokenProviders();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string[] roleNames = { "Admin", "User" }; // Przykładowe role

                foreach (var roleName in roleNames)
                {
                    var roleExist = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                // Tworzenie domyślnego użytkownika z rolą Admin
                var adminUser = new IdentityUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com"
                };

                string adminPassword = "Admin123!"; // Pamiętaj o zasadach bezpieczeństwa przy tworzeniu haseł

                var user = await userManager.FindByEmailAsync(adminUser.Email);
                if (user == null)
                {
                    var createAdminUser = await userManager.CreateAsync(adminUser, adminPassword);
                    if (createAdminUser.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
