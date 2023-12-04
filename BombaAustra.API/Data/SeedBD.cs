//Este controlador se encarga de crear una data base en caso de que NO exista una, tambien actualiza.
//Este no sera ocupado.
using BombaAustra.API.Helpers;
using BombaAustra.Shared.Entities;
using BombaAustra.Shared.Enums;

namespace BombaAustra.API.Data
{
    public class SeedBD
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedBD(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("2222222", "1", "Juan", "juan@yopmail.com", "322 311 4620", "Alvarez","hernan", UserType.AdministradorGeneral);

        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.AdministradorGeneral.ToString());
            await _userHelper.CheckRoleAsync(UserType.Usuario.ToString());
        }

        private async Task<Usuario> CheckUserAsync(string ID_RUT, string DV_RUT, string NOMBRE, string email, string phone, string APELLIDO_P,string APELLIDO_M, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new Usuario
                {
                    ID_RUT = ID_RUT,
                    DV_RUT = DV_RUT,
                    NOMBRE = NOMBRE,
                    APELLIDO_P = APELLIDO_P,
                    APELLIDO_M = APELLIDO_M,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Usertype = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }




    }
}
