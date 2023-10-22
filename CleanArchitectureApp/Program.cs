using CleanArchitectureApp.EfCore;
using CleanArchitectureApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.DependenciyEf();

////This allow us to inject in any controller
//builder.Services.AddDbContext<BdventaContext>(optionsBuilder =>
//{
//    optionsBuilder.UseSqlServer("server=DESKTOP-07LAHVE;database=BDVenta;Integrated Security=True;Encrypt=false");
//});

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
