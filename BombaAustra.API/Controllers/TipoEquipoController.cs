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

        //Obtener por RUT
        [HttpGet("{id}")] //<-- Se utiliza para obtener los datos de la BBDD
        public async Task<IActionResult> GetAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var tipoEquipo = await _context.TIPO_EQUIPO.FirstOrDefaultAsync(x => x.ID_TIPO_EQUIPO == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }
            return Ok(tipoEquipo);
        }

        [HttpPut] //<-- Se utilizara para ACTUALIZAR registros  a la BBDD
        public async Task<ActionResult> Put(TipoEquipo tipoEquipo) //<-- Action result son respuestas de HTTP, empieza por 200 es respuesta valida,400 es error
        {
            _context.Update(tipoEquipo);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return Ok(tipoEquipo);
        }


        [HttpDelete("{id}")] //<-- Se utiliza para ELIMINAR los datos de la BBDD
        public async Task<IActionResult> DeleteAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var tipoEquipo = await _context.TIPO_EQUIPO.FirstOrDefaultAsync(x => x.ID_TIPO_EQUIPO == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }
            _context.Remove(tipoEquipo);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return NoContent();
        }
    }
}
