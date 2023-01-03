using KarakasWenAdmin.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddDbContext<KarakasContext>
    (opt=> opt.UseSqlServer(builder
    .Configuration.GetConnectionString("DB1")));

builder.Services
              .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(opts =>
              {
                  opts.Cookie.Name = ".KarakasAdminPanel.auth";
                  opts.ExpireTimeSpan = TimeSpan.FromDays(7);
                  opts.SlidingExpiration = false;
                  opts.LoginPath = "/UserAccount/Login";
                  opts.LogoutPath = "/UserAccount/Logout";
                  opts.AccessDeniedPath = "/Home/AccessDenied";
              });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
