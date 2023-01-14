using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using NToastNotify;

namespace SocialMediaApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
             AddCookie(options => { options.LoginPath = "/Admin/Login"; });
            builder.Services.AddControllers(config =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                                     .RequireAuthenticatedUser()
                                     .Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                });
            builder.Services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions
            {
                ProgressBar = true,
                Timeout = 5000
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
          
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "Admin", pattern: "Admin/AdminList", defaults: new { controller = "Admin", action = "Index" }
                );
            app.MapControllerRoute(
                name: "Admin", pattern: "Admin/AdminInsert", defaults: new { controller = "Admin", action = "Add" }
                );
            app.MapControllerRoute(
                name: "User", pattern: "User/UserList", defaults: new { controller = "User", action = "Index" }
                );
            app.MapControllerRoute(
                name: "User", pattern: "User/UserInsert", defaults: new { controller = "User", action = "Add" }
                );
            app.MapControllerRoute(
                name: "Post", pattern: "Post/PostList", defaults: new { controller = "Post", action = "Index" }
                );
            app.MapControllerRoute(
                name: "Post", pattern: "Post/PostInsert", defaults: new { controller = "Post", action = "Add" }
                );
            

            app.Run();
        }
    }
}