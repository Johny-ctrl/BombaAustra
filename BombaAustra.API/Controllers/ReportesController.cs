using BombaAustra.API.Data;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BombaAustra.API.Controllers
{
    [ApiController]
    [Route("/api/Reportes")]
    public class ReportesController :ControllerBase
    {
        private readonly DataContext _context;

        public ReportesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Reporte Reportes)
        {
            try
            {
                _context.REPORTES.Add(Reportes);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("No pueden existir reportes duplicados");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.REPORTES.ToListAsync());
        }

        //Obtener por RUT
        [HttpGet("{id}")] //<-- Se utiliza para obtener los datos de la BBDD
        public async Task<IActionResult> GetAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var reporte = await _context.REPORTES.FirstOrDefaultAsync(x => x.ID_REPORTE == id);
            if (reporte == null)
            {
                return NotFound();
            }
            return Ok(reporte);
        }

        [HttpPut] //<-- Se utilizara para ACTUALIZAR registros  a la BBDD
        public async Task<ActionResult> Put(Reporte reporte) //<-- Action result son respuestas de HTTP, empieza por 200 es respuesta valida,400 es error
        {
            try
            {
                _context.Update(reporte);
                await _context.SaveChangesAsync();//<--Aqui se guardan los datos
                return Ok(reporte);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("No pueden existir reportes duplicados");
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
            var reporte = await _context.REPORTES.FirstOrDefaultAsync(x => x.ID_REPORTE == id);
            if (reporte == null)
            {
                return NotFound();
            }
            _context.Remove(reporte);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return NoContent();
        }
    }
}
