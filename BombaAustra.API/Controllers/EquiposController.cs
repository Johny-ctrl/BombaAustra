using BombaAustra.API.Data;
using BombaAustra.API.Helpers;
using BombaAustra.Shared.DTOs;
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
            try
            {
                _context.EQUIPOS.Add(equipo);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Este equipo ya existe");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginacionDTO paginacion)
        {
            //Paginacion
            var queryable = _context.EQUIPOS.AsQueryable();

            //esto aplica el filtro
            if (!string.IsNullOrWhiteSpace(paginacion.Filter))
            {
                queryable = queryable.Where(x => x.NOMBRE_EQUIPO.ToLower().Contains(paginacion.Filter.ToLower()));
            }
            return Ok(await queryable
                .OrderBy(x => x.NOMBRE_EQUIPO)
                .Paginate(paginacion)
                .ToListAsync());
        }


        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginacionDTO paginacion)
        {
            //Paginacion!
            var queryable = _context.EQUIPOS.AsQueryable();
            //Esto aplica el filtro
            if (!string.IsNullOrWhiteSpace(paginacion.Filter))
            {
                queryable = queryable.Where(x => x.NOMBRE_EQUIPO.ToLower().Contains(paginacion.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / paginacion.RecordsNumber);
            return Ok(totalPages);
        }


        //Obtener por RUT
        [HttpGet("{id}")] //<-- Se utiliza para obtener los datos de la BBDD
        public async Task<IActionResult> GetAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var equipo = await _context.EQUIPOS.FirstOrDefaultAsync(x => x.ID_EQUIPO == id);
            if (equipo == null)
            {
                return NotFound();
            }
            return Ok(equipo);
        }

        [HttpPut] //<-- Se utilizara para ACTUALIZAR registros  a la BBDD
        public async Task<ActionResult> Put(Equipo equipo) //<-- Action result son respuestas de HTTP, empieza por 200 es respuesta valida,400 es error
        {
            try
            {
                _context.Update(equipo);
                await _context.SaveChangesAsync();//<--Aqui se guardan los datos
                return Ok(equipo);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Este equipo ya existe");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")] //<-- Se utiliza para ELIMINAR los datos de la BBDD
        public async Task<IActionResult> DeleteAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var equipo = await _context.EQUIPOS.FirstOrDefaultAsync(x => x.ID_EQUIPO == id);
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
