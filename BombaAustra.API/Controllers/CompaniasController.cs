﻿using BombaAustra.API.Data;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BombaAustra.API.Controllers
{
    [ApiController]
    [Route("/api/Companias")]
    public class CompaniasController :ControllerBase
    {
        private readonly DataContext _context;

        public CompaniasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostASync(Compañia compañia)
        {
            _context.COMPANIAS.Add(compañia);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetASync()
        {
            return Ok(await _context.COMPANIAS.ToListAsync());
        }

        //Obtener por RUT
        [HttpGet("{id}")] //<-- Se utiliza para obtener los datos de la BBDD
        public async Task<IActionResult> GetAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var compania = await _context.COMPANIAS.FirstOrDefaultAsync(x => x.ID_COMPAÑIA == id);
            if (compania == null)
            {
                return NotFound();
            }
            return Ok(compania);
        }

        [HttpPut] //<-- Se utilizara para ACTUALIZAR registros  a la BBDD
        public async Task<ActionResult> Put(Compañia compania) //<-- Action result son respuestas de HTTP, empieza por 200 es respuesta valida,400 es error
        {
            _context.Update(compania);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return Ok(compania);
        }


        [HttpDelete("{id}")] //<-- Se utiliza para ELIMINAR los datos de la BBDD
        public async Task<IActionResult> DeleteAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var compania = await _context.COMPANIAS.FirstOrDefaultAsync(x => x.ID_COMPAÑIA == id);
            if (compania == null)
            {
                return NotFound();
            }
            _context.Remove(compania);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return NoContent();
        }
    }
}
