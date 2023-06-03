using BarkodWeb.Data.Context;
using BarkodWeb.Data.Extensions;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Service.Extensions;
using BarkodWeb.Service.FluentValidations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using NToastNotify;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new ToastrOptions()
{
    PositionClass = ToastPositions.TopRight,
    TimeOut = 3000,
    Title = "Ýþlem"
}).AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssemblyContaining<SaleValidator>();
    opt.RegisterValidatorsFromAssemblyContaining<StockAddViewModelValidator>();
    opt.RegisterValidatorsFromAssemblyContaining<StockValidator>();
    opt.DisableDataAnnotationsValidation = true;



    opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
});
builder.Services.AddSession();


builder.Services.LoadDataLayerExtansion(builder.Configuration);
//runtime for html dosyasýný görme için
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddIdentity<AppUser, AppRole>().AddRoleManager<RoleManager<AppRole>>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.LoadServiceLayerExtansion();


builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Ana/Giris/index");
    config.LogoutPath = new PathString("/Ana/Giris/Cikis");
    config.Cookie = new CookieBuilder
    {
        Name = "BuNeBilmiyorum",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest

    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7);
    config.AccessDeniedPath = new PathString("/Ana/Anasyfa/Basarisiz");


});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseNToastNotify();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{


    endpoints.MapAreaControllerRoute(
        name: "Ana",
        areaName: "Ana",
        pattern: "Ana/{controller=Anasayfa}/{action=Index}/{id?}"

            );

    endpoints.MapControllerRoute(
        name:"Default",
            pattern: "{controller=Sales}/{action=Index}/{id?}"

        );

}

 );
app.Run();
