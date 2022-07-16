using CadastrosBiblioteca.Repositorio;
using CadastrosBiblioteca.Services;
using ControleDeContatos.Helper;
using ControleDeContatos.NovaPasta3;
using ControleDeContatos.Repositorio;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.Web.Caching;
using SixLabors.ImageSharp.Web.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer("Data Source=DESKTOP-Q888IKU\\SQLEXPRESS;Initial Catalog=DB_SistemaContatos;User ID=sa;Password=12957534"));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddScoped<IContatoRepositorio,ContatoRepositorio>();//Estou dizendo que toda vez que a interfacie IContatoRepositorio for invocada a injeção de dependencia vai usar tudo dentro de ContatoRepositorio.
builder.Services.AddScoped<IUsuarioRepositorio,UsuarioRepositorio>();
builder.Services.AddScoped<IGaleriaRepositorio, GaleriaRepositorio>();
builder.Services.AddSingleton<IProcessadorImagens, ProcessadorImagmService>();

builder.Services.AddScoped<ISessao, Sessao>();
builder.Services.AddImageSharp(Options =>
{
    Options.BrowserMaxAge = TimeSpan.FromDays(8);// define a duração do cash de imagem no navegador 
    Options.CacheMaxAge = TimeSpan.FromDays(365);// define a duração do cash de imagem  no servidor
    Options.CacheHashLength = 8;// quer dizer que os arquivos que serão armazenados em cash terá o nome com o tamanho de 8 digitos

}).Configure<PhysicalFileSystemCacheOptions>(options =>
{
    options.CacheFolder = "img/cache";
});



builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly= true;
    o.Cookie.IsEssential= true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseImageSharp();
app.UseStaticFiles();

app.UseRouting();
app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

namespace services
{
    class AddScoped<T>
    {
    }
}