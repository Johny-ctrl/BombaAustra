using BombaAustra.WEB;
using BombaAustra.WEB.Repositories;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sales.WEB.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7240/") }); //<-- por aqui se conecta al web, se coloca la ip de la api para conectar los proyectos

//existen 3 formas de inyectar repositorio
builder.Services.AddScoped<IRepository, Repository>();//Implementa el repositorio, esta es la mas comun, Se usa cuando se quiere crear una nueva instancia
builder.Services.AddSweetAlert2(); //sweet Alert 2

//builder.Services.AddTransient<IRepository, Repository>(); se usa cuando se quiere implementar solo 1 vez
//builder.Services.AddSingleton<>; SON MUY PELIGROSOS, consumen muchos recursos, se quedan dando vueltas los objetos que usan y pueden generar brechas de seguridad, inseguros por naturaleza

await builder.Build().RunAsync();

//Autenticacion
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderTest>();



