using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombaAustra.Shared.Entities
{
    public class Reporte
    {
        [Key]
        public int ID_REPORTE { get; set; }

        public string DESCRIPCION { get; set; } = null!;


    }
}
