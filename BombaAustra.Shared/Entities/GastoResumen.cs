using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombaAustra.Shared.Entities
{
    public class GastosResumen
    {
        [Key]
        public int ID_RESUMEN { get; set; }
        public int AÑO_ACTUAL { get; set; }

        public int AÑO_PASADO { get; set; }

        public int COSTO_REVISION_TEC { get; set; }

        public int ID_GASTO { get; set; } 

        public string SIGLA { get; set; } = null!;
    }
}

