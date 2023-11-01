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






    }

}
