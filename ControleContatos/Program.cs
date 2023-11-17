
using ControleContatos.Data;
using ControleContatos.Helper;
using ControleContatos.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

//Configuração Banco Dados
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<BancoContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

// Confing das Session do Usuario

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
//Configuração envolvendo os Usuarios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Confing das Session do Usuario

builder.Services.AddScoped<ISessao, SessaoUsuario>();

// Confing das Session do Usuario
builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});


// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
