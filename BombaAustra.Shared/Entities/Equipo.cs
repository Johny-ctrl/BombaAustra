﻿
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
        public DateTime FECHA_ESTIMADO { get; set; }

        public DateTime FECHA_INGRESO {  get; set; } =  DateTime.Now;

        public int Cantidad { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_EQUIPO {  get; set; }
        public TiposEquipo TIPO_EQUIPO { get; set; }

        [Required(ErrorMessage = "EL campo NOMBRE EQUIPO es obligatorio")]
        public string NOMBRE_EQUIPO { get; set; } = null!;



    }
}
