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

        //Obtener por RUT
        [HttpGet("{id}")] //<-- Se utiliza para obtener los datos de la BBDD
        public async Task<IActionResult> GetAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var equipo = await _context.ESTADO_EQUIPO.FirstOrDefaultAsync(x => x.ID_ESTADO == id);
            if (equipo == null)
            {
                return NotFound();
            }
            return Ok(equipo);
        }

        [HttpPut] //<-- Se utilizara para ACTUALIZAR registros  a la BBDD
        public async Task<ActionResult> Put(EstadoEquipo equipo) //<-- Action result son respuestas de HTTP, empieza por 200 es respuesta valida,400 es error
        {
            _context.Update(equipo);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return Ok(equipo);
        }


        [HttpDelete("{id}")] //<-- Se utiliza para ELIMINAR los datos de la BBDD
        public async Task<IActionResult> DeleteAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var equipo = await _context.ESTADO_EQUIPO.FirstOrDefaultAsync(x => x.ID_ESTADO == id);
            if (equipo == null)
            {
                return NotFound();
            }
            _context.Remove(equipo);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return NoContent();
        }
    }
}
