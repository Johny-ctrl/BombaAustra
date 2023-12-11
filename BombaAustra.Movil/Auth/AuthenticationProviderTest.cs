using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace BombaAustra.Movil.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimous = new ClaimsIdentity();
            var zuluUser = new ClaimsIdentity(new List<Claim>
        {
            new Claim("NOMBRE", "Juan"),
            new Claim("APELLIDO_P", "Alvarez"),
            new Claim(ClaimTypes.Name, "juan@yopmail.com"),
            new Claim(ClaimTypes.Role, "AdministradorGeneral")

        }, authenticationType: "AdministradorGeneral");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(zuluUser)));
        }
    }


}