using BombaAustra.API.Data;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BombaAustra.API.Controllers
{
    [ApiController]
    [Route ("/api/gastos")]
    public class GastosController : ControllerBase
    {
        private readonly DataContext _context;

        public GastosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            return Ok(await _context.GASTOS.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Gastos gasto)
        {
            try
            {
                _context.GASTOS.Add(gasto);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Este gasto ya fue creado");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Obtener por ID
        [HttpGet("{id}")] //<-- Se utiliza para obtener los datos de la BBDD
        public async Task<IActionResult> GetAsync(string id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var gasto = await _context.GASTOS.FirstOrDefaultAsync(x => x.ID_GASTO == id);
            if (gasto == null)
            {
                return NotFound();
            }
            return Ok(gasto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Gastos gastos) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            try
            {
                _context.Update(gastos);
                await _context.SaveChangesAsync();//<--Aqui se guardan los datos
                return Ok(gastos);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Este gasto ya fue creado");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")] //<-- Se utiliza para ELIMINAR los datos de la BBDD
        public async Task<IActionResult> DeleteAsync(string id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var gastos = await _context.GASTOS.FirstOrDefaultAsync(x => x.ID_GASTO == id);
            if (gastos == null)
            {
                return NotFound();
            }
            _context.Remove(gastos);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return NoContent();
        }
    }
}
