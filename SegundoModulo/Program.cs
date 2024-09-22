using SegundoModulo.Models;
using SegundoModulo.Services;
using Microsoft.EntityFrameworkCore;
using SegundoModulo.Data;



var builder = WebApplication.CreateBuilder(args);

// Configura el DbContext para usar la cadena de conexión
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(10, 4, 14))));




//Registramos interfaces / servicios
builder.Services.AddTransient<IPruebaServices, PruebaServices>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Registrar servicios

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Prueba}/{action=Login}/{id?}");

app.Run();
