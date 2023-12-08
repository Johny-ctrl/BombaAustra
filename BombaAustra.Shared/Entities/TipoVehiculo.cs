
using BombaAustra.Shared.Enums;
using System.ComponentModel.DataAnnotations;


namespace BombaAustra.Shared.Entities
{

    public class TipoVehiculo
    {
        [Key]
        [Required(ErrorMessage = "EL campo {0} es obligatorio")]
        public string SIGLA { get; set; } = null!;

        [Required(ErrorMessage = "EL campo {0} es obligatorio")]
        [MaxLength(6, ErrorMessage = "El campo {0} no puede ser mas de 8 caracter")]
        public string PATENTE { get; set; } = null!;

        [Required(ErrorMessage = "EL campo {0} es obligatorio")]
        public string MARCA { get; set; } = null!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "EL campo REVISION TECNICA es obligatorio")]
        public DateTime ULTIMA_REVISION_TEC { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "EL campo {0} es obligatorio")]
        public Modelos Modelo { get; set; }




    }




}
