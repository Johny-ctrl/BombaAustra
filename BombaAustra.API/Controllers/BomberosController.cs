using BombaAustra.API.Data;
using BombaAustra.API.Helpers;
using BombaAustra.Shared.DTOs;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BombaAustra.API.Controllers// <--- Agrega esto
{
    //Tag de Controlador de api
    [ApiController]
    [Route("/api/bomberos")] //<--Enrutador, las peticiones vendran de aqui, se puede poner cualquier nombre
    public class BomberosController : ControllerBase //<-- Se agrega controller base para que sea completamente un controlador
    {
        private readonly DataContext _context;

        public BomberosController(DataContext context) //<-- Constructor, se le entrega el data context, esto evita agregar cosas demas de la BBDD
        {
            _context = context; //De esta manera ya se tiene conexion a la BBDD
        }

        [HttpPost] //<-- Se utilizara para agregar registros  a la BBDD
        public async Task<ActionResult> Post(Usuario USUARIO) //<-- Action result son respuestas de HTTP, empieza por 200 es respuesta valida,400 es error
        {
            try
            {
                _context.Add(USUARIO);
                await _context.SaveChangesAsync();//<--Aqui se guardan los datos
                return Ok(USUARIO);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Este usuario ya existe");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Obtener por RUT
        [HttpGet("{rut}")] //<-- Se utiliza para obtener los datos de la BBDD
        public async Task<IActionResult> GetAsync(string rut) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var usuario = await _context.USUARIOS.FirstOrDefaultAsync(x => x.ID_RUT == rut);
            if (usuario == null)
            {
                return NotFound();  
            }
            return Ok(usuario);
        }

        [HttpPut] //<-- Se utilizara para ACTUALIZAR registros  a la BBDD
        public async Task<ActionResult> Put(Usuario USUARIO) //<-- Action result son respuestas de HTTP, empieza por 200 es respuesta valida,400 es error
        {
            try
            {
                _context.Update(USUARIO);
                await _context.SaveChangesAsync();//<--Aqui se guardan los datos
                return Ok(USUARIO);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Este usuario ya existe");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{rut}")] //<-- Se utiliza para ELIMINAR los datos de la BBDD
        public async Task<IActionResult> DeleteAsync(string rut) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var usuario = await _context.USUARIOS.FirstOrDefaultAsync(x => x.ID_RUT == rut);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Remove(usuario);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return NoContent();
        }

        //Get General
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginacionDTO paginacion)
        {
            //Paginacion
            var queryable = _context.USUARIOS.AsQueryable();

            //esto aplica el filtro
            if (!string.IsNullOrWhiteSpace(paginacion.Filter))
            {
                queryable = queryable.Where(x => x.ID_RUT.ToLower().Contains(paginacion.Filter.ToLower()));
            }
            return Ok(await queryable
                .OrderBy(x => x.ID_RUT )
                .Paginate(paginacion)
                .ToListAsync());
        }


        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginacionDTO paginacion)
        {
            //Paginacion!
            var queryable = _context.USUARIOS.AsQueryable();
            //Esto aplica el filtro
            if (!string.IsNullOrWhiteSpace(paginacion.Filter))
            {
                queryable = queryable.Where(x => x.ID_RUT.ToLower().Contains(paginacion.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / paginacion.RecordsNumber);
            return Ok(totalPages);
        }




    }

}
