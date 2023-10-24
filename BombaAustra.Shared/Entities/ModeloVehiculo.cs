using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombaAustra.Shared.Entities
{
    public class ModeloVehiculo
    {
        [Key]
        public int ID_MODELO {  get; set; }

        public string DESCRIPCION { get; set; } = null!;
        
    }
}
