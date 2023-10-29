using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Identity;

namespace BombaAustra.API.Helpers
{
    public interface IUserHelper
    {
        Task<Usuario> GetUserAsync(string ID_RUT);

        Task<IdentityResult> AddUserAsync(Usuario user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(Usuario user, string roleName);

        Task<bool> IsUserInRoleAsync(Usuario user, string roleName);

    }
}
