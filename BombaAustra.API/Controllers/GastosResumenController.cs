using BombaAustra.API.Data;
using BombaAustra.API.Helpers;
using BombaAustra.Shared.DTOs;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BombaAustra.API.Controllers
{
    [ApiController]
    [Route("/api/gastosResumen")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GastosResumenController : ControllerBase
    {
        private readonly DataContext _context;

        public GastosResumenController(DataContext context)
        {
            _context = context;
        }


        //Get de todo los datos
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginacionDTO paginacion) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            //Paginacion
            var queryable = _context.GASTO_RESUMEN.AsQueryable();

            //esto aplica el filtro
            if (!string.IsNullOrWhiteSpace(paginacion.Filter))
            {
                queryable = queryable.Where(x => x.SIGLA.ToLower().Contains(paginacion.Filter.ToLower()));
            }


            return Ok(await queryable
                .OrderBy(x => x.SIGLA)
                .Paginate(paginacion)
                .ToListAsync());
        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginacionDTO paginacion)
        {
            //Paginacion!
            var queryable = _context.GASTO_RESUMEN.AsQueryable();
            //Esto aplica el filtro
            if (!string.IsNullOrWhiteSpace(paginacion.Filter))
            {
                queryable = queryable.Where(x => x.SIGLA.ToLower().Contains(paginacion.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / paginacion.RecordsNumber);
            return Ok(totalPages);
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync(GastosResumen gastos)
        {
            try
            {
                _context.GASTO_RESUMEN.Add(gastos);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Este gasto ya existe");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        //Obtener por ID
        [HttpGet("{ID}")] //<-- Se utiliza para obtener los datos de la BBDD

        public async Task<IActionResult> GetAsync(string ID) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var gastos = await _context.GASTO_RESUMEN.FirstOrDefaultAsync(x => x.SIGLA == ID);
            if (gastos == null)
            {
                return NotFound();
            }
            return Ok(gastos);
        }

        [HttpPut]
        public async Task<ActionResult> Put(GastosResumen gasto) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            try
            {
                _context.Update(gasto);
                await _context.SaveChangesAsync();//<--Aqui se guardan los datos
                return Ok(gasto);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Este gasto ya esxiste");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{ID}")] //<-- Se utiliza para ELIMINAR los datos de la BBDD
        public async Task<IActionResult> DeleteAsync(string ID) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var gasto = await _context.GASTO_RESUMEN.FirstOrDefaultAsync(x => x.SIGLA == ID);
            if (gasto == null)
            {
                return NotFound();
            }
            _context.Remove(gasto);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return NoContent();
        }
    }
}
