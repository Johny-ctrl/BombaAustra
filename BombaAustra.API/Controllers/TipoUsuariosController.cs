using BombaAustra.API.Data;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BombaAustra.API.Controllers
{
    //Tag de Controlador de api
    [ApiController]
    [Route("/api/UsersTypes")] //<--Enrutador, las peticiones vendran de aqui, se puede poner cualquier nombre
    public class TipoUsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoUsuariosController(DataContext context)
        {
            _context = context;

        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(TipoUsuario tipoUsuario)
        {
            try
            {
                _context.TIPO_USUARIOS.Add(tipoUsuario);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Tipo de usuario ya existente");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet] //<-- Se utiliza para obtener los datos de la BBDD
        public async Task<IActionResult> Get() //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            return Ok(await _context.TIPO_USUARIOS.ToListAsync());
        }

        //Obtener por RUT
        [HttpGet("{id}")] //<-- Se utiliza para obtener los datos de la BBDD
        public async Task<IActionResult> GetAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var tipoUsuario = await _context.TIPO_USUARIOS.FirstOrDefaultAsync(x => x.ID_TIPO_USUARIO == id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }
            return Ok(tipoUsuario);
        }

        [HttpPut] //<-- Se utilizara para ACTUALIZAR registros  a la BBDD
        public async Task<ActionResult> Put(TipoUsuario tipoUsuario) //<-- Action result son respuestas de HTTP, empieza por 200 es respuesta valida,400 es error
        {
            try
            {
                _context.Update(tipoUsuario);
                await _context.SaveChangesAsync();//<--Aqui se guardan los datos
                return Ok(tipoUsuario);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Tipo de usuario ya existente");
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
            var tipoUsuario = await _context.TIPO_USUARIOS.FirstOrDefaultAsync(x => x.ID_TIPO_USUARIO == id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }
            _context.Remove(tipoUsuario);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return NoContent();
        }

    }
}
