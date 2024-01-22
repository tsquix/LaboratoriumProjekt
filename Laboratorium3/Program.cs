using Laboratorium3.Models;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Data;

namespace Laboratorium3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Data.AppDbContext>();
            builder.Services.AddDefaultIdentity<IdentityUser>()       // doda�
                .AddRoles<IdentityRole>()                             //
                .AddEntityFrameworkStores<Data.AppDbContext>();     // 
            builder.Services.AddSingleton<IPostService, MemoryPostService>();
            builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();
            builder.Services.AddTransient<IPostService, EFPostService>();
            builder.Services.AddMemoryCache();                        // doda�
            builder.Services.AddSession();                            // doda�  

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
            app.UseMiddleware<LastVisitCookie>();
            app.UseAuthentication();                                 // doda�
            app.UseAuthorization();                                  // doda�
            app.UseSession();                                        // doda� 
            app.MapRazorPages();                                     // doda�
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
