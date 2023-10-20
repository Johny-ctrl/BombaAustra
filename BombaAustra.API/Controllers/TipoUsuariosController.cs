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
        public async Task<ActionResult> PostAsync(Equipo EQUIPOS)
        {
            _context.EQUIPOS.Add(EQUIPOS);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
