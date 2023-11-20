
using System.ComponentModel.DataAnnotations;


namespace BombaAustra.Shared.Entities
{
    public class Gastos
    {
        [Key]
        public int ID_GASTO { get; set; }
        public string SIGLA { get; set; } = null!;

        public int MONTO {  get; set; }

        public string DESCRIPCION { get; set; } = null!;




    }
}
