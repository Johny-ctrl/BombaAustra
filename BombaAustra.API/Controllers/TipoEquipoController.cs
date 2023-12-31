﻿using BombaAustra.API.Data;
using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BombaAustra.API.Controllers
{
    //Tag de Controlador de api
    [ApiController]
    [Route("/api/TipoEquipo")] //<--Enrutador, las peticiones vendran de aqui, se puede poner cualquier nombre
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TipoEquipoController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoEquipoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]

        public async Task<ActionResult> Post(TipoEquipo TIPO_EQUIPO)
        {
            try
            {
                _context.TIPO_EQUIPO.Add(TIPO_EQUIPO);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Tipo de equipo ya existente");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.TIPO_EQUIPO.ToListAsync());
        }

        //Obtener por RUT
        [HttpGet("{id}")] //<-- Se utiliza para obtener los datos de la BBDD
        public async Task<IActionResult> GetAsync(int id) //<--Mejor es async , los async ocupan todos los procesadores del pc, lo hace mas eficiente
        {
            var tipoEquipo = await _context.TIPO_EQUIPO.FirstOrDefaultAsync(x => x.ID_TIPO_EQUIPO == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }
            return Ok(tipoEquipo);
        }

        [HttpPut] //<-- Se utilizara para ACTUALIZAR registros  a la BBDD
        public async Task<ActionResult> Put(TipoEquipo tipoEquipo) //<-- Action result son respuestas de HTTP, empieza por 200 es respuesta valida,400 es error
        {
            try
            {
                _context.Update(tipoEquipo);
                await _context.SaveChangesAsync();//<--Aqui se guardan los datos
                return Ok(tipoEquipo);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Tipo de equipo ya existente");
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
            var tipoEquipo = await _context.TIPO_EQUIPO.FirstOrDefaultAsync(x => x.ID_TIPO_EQUIPO == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }
            _context.Remove(tipoEquipo);
            await _context.SaveChangesAsync();//<--Aqui se guardan los datos
            return NoContent();
        }
    }
}
