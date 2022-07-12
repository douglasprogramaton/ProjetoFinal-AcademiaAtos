using ControleDeContatos.NovaPasta3;
using ControleDeContatos.Repositorio;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer("Data Source=DESKTOP-Q888IKU\\SQLEXPRESS;Initial Catalog=DB_SistemaContatos;User ID=sa;Password=12957534"));

builder.Services.AddScoped<IContatoRepositorio,ContatoRepositorio>();//Estou dizendo que toda vez que a interfacie IContatoRepositorio for invocada a injeção de dependencia vai usar tudo dentro de ContatoRepositorio.
builder.Services.AddScoped<IUsuarioRepositorio,UsuarioRepositorio>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

namespace services
{
    class AddScoped<T>
    {
    }
}