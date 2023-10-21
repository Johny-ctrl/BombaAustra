using BombaAustra.API.Data;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BombaAustra.API.Controllers
{
    //Tag de Controlador de api
    [ApiController]
    [Route("/api/TipoEquipo")] //<--Enrutador, las peticiones vendran de aqui, se puede poner cualquier nombre
    public class TipoEquipoController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoEquipoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]

        public async Task<ActionResult> Post(TipoEquipo TIPO_EQUIPO)
        {
            _context.TIPO_EQUIPO.Add(TIPO_EQUIPO);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.TIPO_EQUIPO.ToListAsync());
        }
    }
}
