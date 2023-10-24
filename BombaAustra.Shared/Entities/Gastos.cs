using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombaAustra.Shared.Entities
{
    public class Gastos
    {
        [Key]
        public string ID_GASTO { get; set; } = null!;

        public int AÑO_ACTUAL {  get; set; }

        public int AÑO_PASADO { get; set; }

        public int COSTO_REVISION_TEC { get; set; }
    }
}
