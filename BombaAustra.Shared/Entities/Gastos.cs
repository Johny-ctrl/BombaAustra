
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BombaAustra.Shared.Entities
{
    public class Gastos
    {
        public string DESCRIPCION { get; set; } = null!;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_GASTO { get; set; }

        public int MONTO { get; set; }
        public string SIGLA { get; set; } = null!;










    }
}
