using System.Reflection;
using EntityLayer;
using FluentValidation.AspNetCore;
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
            app.UseStatusCodePagesWithReExecute("/Error/HandleError/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
            name: "Home", pattern: "Home/Anasayfa", defaults: new { controller = "Home", action = "Index" }
            );
            app.MapControllerRoute(
                name: "Admin", pattern: "Admin/AdminList", defaults: new { controller = "Admin", action = "Index" }
                );
            app.MapControllerRoute(
                name: "Admin", pattern: "Admin/AdminInsert", defaults: new { controller = "Admin", action = "Add" }
                );
            app.MapControllerRoute(
               name: "Admin", pattern: "Admin/AdminProfile", defaults: new { controller = "Admin", action = "Profile" }
               );
            app.MapControllerRoute(
               name: "Admin", pattern: "Admin/AdminUpdate", defaults: new { controller = "Admin", action = "Update" }
               );
            app.MapControllerRoute(
                name: "User", pattern: "User/UserList", defaults: new { controller = "User", action = "Index" }
                );
            app.MapControllerRoute(
                name: "User", pattern: "User/UserInsert", defaults: new { controller = "User", action = "Add" }
                );
            app.MapControllerRoute(
                name: "Message", pattern: "Message/MessageList", defaults: new { controller = "Message", action = "Index" }
                );
            app.MapControllerRoute(
                name: "Message", pattern: "Message/MessageInsert", defaults: new { controller = "Message", action = "Add" }
                );
            app.MapControllerRoute(
                name: "Saved", pattern: "Saved/SavedList", defaults: new { controller = "Saved", action = "Index" }
                );
            app.MapControllerRoute(
                name: "Saved", pattern: "Saved/SavedInsert", defaults: new { controller = "Saved", action = "Add" }
                );
            app.MapControllerRoute(
                name: "SavedCollection", pattern: "SavedCollection/SavedCollectionList", defaults: new { controller = "SavedCollection", action = "Index" }
                );
            app.MapControllerRoute(
                name: "SavedCollection", pattern: "SavedCollection/SavedCollectionInsert", defaults: new { controller = "SavedCollection", action = "Add" }
                );
            //Post
            app.MapControllerRoute(
                name: "Post", pattern: "Post/PostList", defaults: new { controller = "Post", action = "Index" }
                );
            app.MapControllerRoute(
                name: "Post", pattern: "Post/PostInsert", defaults: new { controller = "Post", action = "Add" }
                );
            //PostLike
            app.MapControllerRoute(
              name: "PostLike", pattern: "PostLike/PostLikeList", defaults: new { controller = "PostLike", action = "Index" }
              );
            app.MapControllerRoute(
                name: "PostLike", pattern: "PostLike/PostLikeInsert", defaults: new { controller = "PostLike", action = "Add" }
                );
            //Comment
            app.MapControllerRoute(
                name: "Comment", pattern: "Comment/comment-list", defaults: new { controller = "Comment", action = "Index" }
                );
            app.MapControllerRoute(
                name: "Comment", pattern: "Comment/comment-insert", defaults: new { controller = "Comment", action = "Add" }
                );
            //CommentLike
            app.MapControllerRoute(
             name: "CommentLike", pattern: "CommentLike/CommentLikeList", defaults: new { controller = "CommentLike", action = "Index" }
             );
            app.MapControllerRoute(
                name: "Comment", pattern: "CommentLike/CommentLikeInsert", defaults: new { controller = "CommentLike", action = "Add" }
                );
            //Collection
            app.MapControllerRoute(
                name: "Collection", pattern: "Collection/collection-list", defaults: new { controller = "Collection", action = "Index" }
                );
            app.MapControllerRoute(
                name: "Collection", pattern: "Collection/collection-insert", defaults: new { controller = "Collection", action = "Add" }
                );

            //Tag
            app.MapControllerRoute(
                name: "Tag", pattern: "Tag/tag-list", defaults: new { controller = "Tag", action = "Index" }
                );
            app.MapControllerRoute(
                name: "Tag", pattern: "Tag/tag-insert", defaults: new { controller = "Tag", action = "Add" }
                );

            //Location
            app.MapControllerRoute(
                name: "Location", pattern: "Location/location-list", defaults: new { controller = "Location", action = "Index" }
                );
            app.MapControllerRoute(
                name: "Location", pattern: "Location/location-insert", defaults: new { controller = "Location", action = "Add" }
                );

            //Type
            app.MapControllerRoute(
                name: "Genre", pattern: "Genre/genre-list", defaults: new { controller = "Genre", action = "Index" }
                );
            app.MapControllerRoute(
                name: "Genre", pattern: "Genre/genre-insert", defaults: new { controller = "Genre", action = "Add" }
                );
            //Request
                app.MapControllerRoute(
                name: "Request", pattern: "Request/RequestList", defaults: new { controller = "Request", action = "Index" }
                );
            app.MapControllerRoute(
                name: "Request", pattern: "Request/RequestInsert", defaults: new { controller = "Request", action = "Add" }
                );
            
            app.MapControllerRoute(
                name: "Home", pattern: "AnaSayfa", defaults: new { controller = "Home", action = "Index" }
                );
            app.MapControllerRoute(
                name: "Home", pattern: "Yorumlar", defaults: new { controller = "Home", action = "Comment" }
                );


            app.Run();
        }
    }
}