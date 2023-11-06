
using System.ComponentModel.DataAnnotations;


namespace BombaAustra.Shared.Entities
{
    public class Gastos
    {
        [Key]
        public string ID_GASTO { get; set; } = null!;

        public int AÑO_ACTUAL {  get; set; }

        public int AÑO_PASADO { get; set; }

        public int COSTO_REVISION_TEC { get; set; }

        public string SIGLA { get; set; } = null!;


    }
}
