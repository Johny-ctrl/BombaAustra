using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BombaAustra.API.Data;
using BombaAustra.API.Helpers;
using BombaAustra.Shared.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace BombaAustra.API.Controllers
{
    [ApiController]
    [Route("/api/TipoV")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TipoVehiculoController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoVehiculoController(DataContext context)
        {
            _context = context;
        }


        //Get de todo los datos
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginacionDTO paginacion) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            //Paginacion
            var queryable = _context.TIPO_VEHICULO.AsQueryable();

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
            var queryable = _context.TIPO_VEHICULO.AsQueryable();
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
        public async Task<ActionResult> PostAsync(TipoVehiculo tipoVehiculo)
        {
            try
            {
                _context.TIPO_VEHICULO.Add(tipoVehiculo);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Este vehiculo ya existe");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        //Obtener por ID
        [HttpGet("{sigla}")] //<-- Se utiliza para obtener los datos de la BBDD

        public async Task<IActionResult> GetAsync(string sigla) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var tipovehiculo = await _context.TIPO_VEHICULO.FirstOrDefaultAsync(x => x.SIGLA == sigla);
            if (tipovehiculo == null)
            {
                return NotFound();
            }
            return Ok(tipovehiculo);
        }

        [HttpPut]
        public async Task<ActionResult> Put(TipoVehiculo tipoVehiculo) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            try
            {
                _context.Update(tipoVehiculo);
                await _context.SaveChangesAsync();//<--Aqui se guardan los datos
                return Ok(tipoVehiculo);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Este vehiculo ya existe");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{sigla}")] //<-- Se utiliza para ELIMINAR los datos de la BBDD
        public async Task<IActionResult> DeleteAsync(string sigla) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var tipovehiculo = await _context.TIPO_VEHICULO.FirstOrDefaultAsync(x => x.SIGLA == sigla);
            if (tipovehiculo == null)
            {
                return NotFound();
            }
            _context.Remove(tipovehiculo);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return NoContent();
        }

        [HttpGet ("TotalVehiculos")]

        public async Task<IActionResult> GetEverything()
        {
            return Ok(await _context.TIPO_VEHICULO.ToListAsync());
        }
    }
}
