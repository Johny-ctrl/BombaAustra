using BombaAustra.API.Data;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BombaAustra.API.Controllers
{
    [ApiController]
    [Route("/api/Companias")]
    public class CompaniasController :ControllerBase
    {
        private readonly DataContext _context;

        public CompaniasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostASync(Compañia compañia)
        {
            _context.COMPANIAS.Add(compañia);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetASync()
        {
            return Ok(await _context.COMPANIAS.ToListAsync());
        }
    }
}
