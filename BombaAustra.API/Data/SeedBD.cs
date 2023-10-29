//Este controlador se encarga de crear una data base en caso de que NO exista una, tambien actualiza.
//Este no sera ocupado.
namespace BombaAustra.API.Data
{
    public class SeedBD
    {
        private readonly DataContext _context;

        public SeedBD(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

        }

    }
}
