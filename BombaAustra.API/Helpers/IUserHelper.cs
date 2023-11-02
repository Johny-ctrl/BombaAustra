using BombaAustra.Shared.DTOs;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Identity;

namespace BombaAustra.API.Helpers
{
    public interface IUserHelper
    {
        Task<Usuario> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(Usuario user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(Usuario user, string roleName);

        Task<bool> IsUserInRoleAsync(Usuario user, string roleName);

        Task<SignInResult> LoginAsync(LoginDTO model);

        Task LogoutAsync();

        Task<IdentityResult> ChangePasswordAsync(Usuario user, string currentPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(Usuario user);

        Task<Usuario> GetUserAsync(Guid userId);

        Task<string> GenerateEmailConfirmationTokenAsync(Usuario user);

        Task<IdentityResult> ConfirmEmailAsync(Usuario user, string token);

        Task<string> GeneratePasswordResetTokenAsync(Usuario user);

        Task<IdentityResult> ResetPasswordAsync(Usuario user, string token, string password);





    }
}
