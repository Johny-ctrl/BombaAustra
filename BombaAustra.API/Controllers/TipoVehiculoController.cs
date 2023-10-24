using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BombaAustra.API.Data;
namespace BombaAustra.API.Controllers
{
    [ApiController]
    [Route ("/api/TipoV")]
    public class TipoVehiculoController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoVehiculoController(DataContext context)
        {
            _context = context;
        }
        //Get de todo los datos
        [HttpGet]
        public async Task<IActionResult> GetAsync() //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            return Ok(await _context.TIPO_VEHICULO.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(TipoVehiculo tipoVehiculo)
        {
            _context.TIPO_VEHICULO.Add(tipoVehiculo);
            await _context.SaveChangesAsync();
            return Ok();
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
            _context.Update(tipoVehiculo);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return Ok(tipoVehiculo);
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
    }
}
