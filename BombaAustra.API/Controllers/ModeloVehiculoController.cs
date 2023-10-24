using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BombaAustra.API.Data;

namespace BombaAustra.API.Controllers
{
    [ApiController]
    [Route ("/api/Modelo")]
    public class ModeloVehiculoController : ControllerBase
    {
        private readonly DataContext _context;

        public ModeloVehiculoController(DataContext context)
        {
            _context = context;
        }

        //Get de todo los datos
        [HttpGet]
        public async Task<IActionResult> GetAsync() //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            return Ok(await _context.MODELO_VEHICULO.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(ModeloVehiculo modeloVehiculo)
        {
            _context.MODELO_VEHICULO.Add(modeloVehiculo);
            await _context.SaveChangesAsync();
            return Ok();
        }


        //Obtener por ID
        [HttpGet("{id}")] //<-- Se utiliza para obtener los datos de la BBDD
        public async Task<IActionResult> GetAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var modeloVehiculo = await _context.MODELO_VEHICULO.FirstOrDefaultAsync(x => x.ID_MODELO == id);
            if (modeloVehiculo == null)
            {
                return NotFound();
            }
            return Ok(modeloVehiculo);
        }

        [HttpPut]
        public async Task<ActionResult> Put(ModeloVehiculo modeloVehiculo) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            _context.Update(modeloVehiculo);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return Ok(modeloVehiculo);
        }

        [HttpDelete("{id}")] //<-- Se utiliza para ELIMINAR los datos de la BBDD
        public async Task<IActionResult> DeleteAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var modeloVehiculo = await _context.MODELO_VEHICULO.FirstOrDefaultAsync(x => x.ID_MODELO == id);
            if (modeloVehiculo == null)
            {
                return NotFound();
            }
            _context.Remove(modeloVehiculo);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return NoContent();
        }
    }
}
