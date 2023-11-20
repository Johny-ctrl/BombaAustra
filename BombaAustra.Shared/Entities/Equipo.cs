
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombaAustra.Shared.Enums;

namespace BombaAustra.Shared.Entities
{
    public class Equipo
    {
        [Key]
        public int ID_EQUIPO {  get; set; }
        public TiposEquipo TIPO_EQUIPO { get; set; }

        public string NOMBRE_EQUIPO { get; set; } = null!;



    }
}
