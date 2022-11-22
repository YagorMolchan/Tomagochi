using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tomagochi.WEB.Data;
using Tomagochi.DAL.EFCore;
using Tomagochi.DAL.Entities;
using Tomagochi.DAL.Interfaces;
using Tomagochi.DAL.Repositories;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TomagochiDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TomagochiDbContext>();

builder.Services.AddScoped<IPetRepository, PetRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
//app.UseStaticFiles(
//        new StaticFileOptions
//        {
//            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/img"))
//        }
//    );
//app.UseDirectoryBrowser(
//    new DirectoryBrowserOptions
//    {
//        FileProvider = new PhysicalFileProvider(
//            Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img"))
//    }
//);


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
