using BombaAustra.API.Data;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BombaAustra.API.Controllers// <--- Agrega esto
{
    //Tag de Controlador de api
    [ApiController]
    [Route("api/bomberos")] //<--Enrutador, las peticiones vendran de aqui, se puede poner cualquier nombre
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
            _context.Add(USUARIO);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return Ok(USUARIO);
        }
        [HttpGet] //<-- Se utiliza para obtener los datos de la BBDD
        public async Task<IActionResult> GetASync() //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            return Ok(await _context.USUARIOS.ToListAsync());
        }
    }
}
