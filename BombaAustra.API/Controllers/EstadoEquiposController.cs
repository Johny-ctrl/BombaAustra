using BombaAustra.API.Data;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BombaAustra.API.Controllers
{
    [ApiController]
    [Route("/api/EstadoEquipos")]
    public class EstadoEquiposController : ControllerBase
    {
        private readonly DataContext _context;

        public EstadoEquiposController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(EstadoEquipo estadoEquipo)
        {
            _context.ESTADO_EQUIPO.Add(estadoEquipo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPost()
        {
            return Ok(await _context.ESTADO_EQUIPO.ToListAsync());
        }
    }
}
