using CursoOnline.Dominio._Base;
using CursoOnline.Ioc;
using CursoOnline.Web.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// --- Serviços ---
StartupIoc.ConfigureServices(builder.Services, builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});

var app = builder.Build();

// Middleware para Commit do UnitOfWork
app.Use(async (context, next) =>
{
    await next.Invoke();

    var unitOfWork = context.RequestServices.GetRequiredService<IUnitOfWork>();
    await unitOfWork.Commit();
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // BrowserLink foi removido
}

// Arquivos estáticos
app.UseStaticFiles();

// Rotas MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
