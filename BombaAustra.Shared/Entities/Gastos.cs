
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BombaAustra.Shared.Entities
{
    public class Gastos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_GASTO { get; set; }
        public string SIGLA { get; set; } = null!;

        public int MONTO {  get; set; }

        public string DESCRIPCION { get; set; } = null!;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;




    }
}
