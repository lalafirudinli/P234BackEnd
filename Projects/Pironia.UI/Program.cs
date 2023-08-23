using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Pironia.Business.Mappers;
using Pironia.Business.Services.Interfaces;
using Pironia.DataAccess.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(SliderProfile).Assembly);
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<İFileService, İFileService>();
var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"

    );

// Middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"

    );

app.Run();
