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
            return Ok(await _context.NOMBRE_COMPANIAS.ToListAsync());
        }

        //Obtener por RUT
        [HttpGet("{id}")] //<-- Se utiliza para obtener los datos de la BBDD
        public async Task<IActionResult> GetAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var Ncompania = await _context.NOMBRE_COMPANIAS.FirstOrDefaultAsync(x => x.ID_NOMBRE_COMPAÑIA == id);
            if (Ncompania == null)
            {
                return NotFound();
            }
            return Ok(Ncompania);
        }

        [HttpPut] //<-- Se utilizara para ACTUALIZAR registros  a la BBDD
        public async Task<ActionResult> Put(NombreCompañia Ncompania) //<-- Action result son respuestas de HTTP, empieza por 200 es respuesta valida,400 es error
        {
            _context.Update(Ncompania);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return Ok(Ncompania);
        }


        [HttpDelete("{id}")] //<-- Se utiliza para ELIMINAR los datos de la BBDD
        public async Task<IActionResult> DeleteAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var Ncompania = await _context.NOMBRE_COMPANIAS.FirstOrDefaultAsync(x => x.ID_NOMBRE_COMPAÑIA == id);
            if (Ncompania == null)
            {
                return NotFound();
            }
            _context.Remove(Ncompania);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return NoContent();
        }
    }
}
