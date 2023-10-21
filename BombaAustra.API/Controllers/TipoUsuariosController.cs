using BombaAustra.API.Data;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BombaAustra.API.Controllers
{
    //Tag de Controlador de api
    [ApiController]
    [Route("/api/UsersTypes")] //<--Enrutador, las peticiones vendran de aqui, se puede poner cualquier nombre
    public class TipoUsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoUsuariosController(DataContext context)
        {
            _context = context;

        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(TipoUsuario tipoUsuario)
        {
            _context.TIPO_USUARIOS.Add(tipoUsuario);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet] //<-- Se utiliza para obtener los datos de la BBDD
        public async Task<IActionResult> Get() //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            return Ok(await _context.TIPO_USUARIOS.ToListAsync());
        }

    }
}
