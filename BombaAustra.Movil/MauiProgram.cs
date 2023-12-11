using BombaAustra.Movil;
using BombaAustra.Movil.Auth;
using BombaAustra.Movil.Repositories;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace BombaAustra.Movil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<HttpClient>(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7240/") });
            //<-- por aqui se conecta al web, se coloca la ip de la api para conectar los proyectos


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddScoped<IRepository, Repository>();//Implementa el repositorio, esta es la mas comun, Se usa cuando se quiere crear una nueva instancia
            builder.Services.AddSweetAlert2(); //sweet Alert 2

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationProviderJWT>();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());
            builder.Services.AddScoped<ILoginService, AuthenticationProviderJWT>(x => x.GetRequiredService<AuthenticationProviderJWT>());

            return builder.Build();
        }
    }
}