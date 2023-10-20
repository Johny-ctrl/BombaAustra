
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
        public int ID_EQUIPO {  get; set; }

        public int TIPO_EQUIPO { get; set; }

        public string NOMBRE_EQUIPO { get; set; } = null!;

        public int ESTADO_EQUIPO { get; set; }

    }
}
