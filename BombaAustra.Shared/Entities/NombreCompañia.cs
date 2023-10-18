using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombaAustra.Shared.Entities
{
    public class NombreCompañia
    {
        [Key]
        public int ID_NOMBRE_COMPAÑIA;

        public string NOMBRE_COMPAÑIA = null!;

    }
}
