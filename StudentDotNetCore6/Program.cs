using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentDotNetCore6.Models;
using StudentDotNetCore6.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//var connectionString = builder.Configuration.GetConnectionString("AppCon");

builder.Services.AddDbContext<StudentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppCon")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<StudentContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true; 
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
});

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/login";

});

builder.Services.AddControllersWithViews();



builder.Services.AddScoped<IAccountRepository, AccountRepository>();

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
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
