using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OptimumHR.DatabaseContext;
using OptimumHR.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));



// Add services to the container.
builder.Services.AddControllersWithViews();




builder.Services.AddIdentity<Account, IdentityRole>(
    op =>
    {
        op.Password.RequireUppercase = false;
        op.Password.RequireDigit = false;
        op.Password.RequireLowercase = false;
        op.Password.RequireNonAlphanumeric = false;


    }
    ).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication("MyCookie").AddCookie("MyCookie",
    op =>
    {
        op.Cookie.Name = "MyCookie";
    }
    );





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
