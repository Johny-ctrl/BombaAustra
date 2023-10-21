using BombaAustra.API.Data;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BombaAustra.API.Controllers
{
    [ApiController]
    [Route("/api/Ncompania")]
    public class NombreCompaniasController : ControllerBase
    {
        private readonly DataContext _context;

        public NombreCompaniasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(NombreCompañia nombreCompañia)
        {
            _context.NOMBRE_COMPANIAS.Add(nombreCompañia);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.REPORTES.ToListAsync());
        }
    }
}
