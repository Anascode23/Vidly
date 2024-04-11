using Microsoft.EntityFrameworkCore;
using Vidly.Access.Data;
using Vidly.Repository_Pattern.Implementation;
using Vidly.Repository_Pattern.Interface;
using Microsoft.AspNetCore.Identity;
using Vidly.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<VidlyDBContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("VidlyDb")));


builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<VidlyDBContext>().AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});


builder.Services.AddAuthentication().AddFacebook(opt =>
{
    opt.ClientId = "1892404791183593";
    opt.ClientSecret = "2267561b15bfa8aea6660347e9e75f08";
});


builder.Services.AddRazorPages();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IEmailSender, EmailSender>();

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
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Guest2}/{controller=Home}/{action=Index}/{id?}");

app.Run();
