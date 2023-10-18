using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombaAustra.Shared.Entities
{
    public class Compañia
    {
        [Key]
        public int ID_COMPAÑIA;

        public int ID_NOMBRE;
    }
}
