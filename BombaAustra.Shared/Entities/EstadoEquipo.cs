using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BombaAustra.Shared.Entities
{
   public class EstadoEquipo
    {
        [Key]
        public int ID_ESTADO;

        public string NOMBRE_COMPANIA = null!;
    }
}
