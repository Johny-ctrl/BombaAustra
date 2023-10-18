using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombaAustra.Shared.Entities
{
    public class Equipo
    {
        [Key]
        public int ID_EQUIPO;

        
        public int TIPO_EQUIPO;

        public string NOMBRE_EQUIPO = null!;

        public int ESTADO_EQUIPO;

    }
}
