using BombaAustra.API.Data;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BombaAustra.API.Controllers
{
    [ApiController]
    [Route("/api/Equipos")]
    public class EquiposController : ControllerBase
    {
        private readonly DataContext _context;

        public EquiposController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Equipo equipo)
        {
            _context.EQUIPOS.Add(equipo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.EQUIPOS.ToListAsync());
        }
    }
}
