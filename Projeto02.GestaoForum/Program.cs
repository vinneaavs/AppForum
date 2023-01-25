using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projeto02.GestaoForum.Models;
using Projeto03.AcessoDados.DI;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;

// Add services to the container.
#region ALTERAÇÃO PARA PROJETO03 DLL
//builder.Services.AddDbContext<ForumContext>(options =>
//    options.UseSqlServer(config.GetConnectionString("ForumConnection")));
#endregion

#region INJEÇÃO DE DEPENDENCIA DLL PROJETO03
//using Projeto03.AcessoDados.DI

builder.Services.AddInfStructDB(config);

#endregion


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Autenticacao/Login";
    options.LogoutPath = "/Autenticacao/Logout";
    options.AccessDeniedPath = "/Autenticacao/AccessDenied";

});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// obtendo a referencia ao objeto fornecido via DI (Dependency Injection)
var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

#region ALTERADO PARA PROJETO 03 INJEÇÃO DE DEPENDENCIA

//var context = services.GetRequiredService<ForumContext>();
//DbInitializer.Initialize(context);

#endregion


Utils.CreateRoles(services).Wait();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
