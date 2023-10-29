using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombaAustra.Shared.Entities
{
    public class Usuario : IdentityUser
    {
        [Key] 
        public string ID_RUT { get; set; } = null!;

 
        [Required(ErrorMessage ="EL campo {0} es obligatorio")]
        [MaxLength(1, ErrorMessage ="El campo {0} no puede ser mas de 1 caracter")]
        public string DV_RUT { get; set; } = null!;

        public string NOMBRE { get; set; } = null!;


        public string APELLIDO_P {  get; set; } = null!;


        public string APELLIDO_M { get; set; } = null!;

        public int TIPO_USUARIOS { get; set; }

    }
}
