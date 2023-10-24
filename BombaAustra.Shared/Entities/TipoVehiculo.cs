using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombaAustra.Shared.Entities
{

    public class TipoVehiculo
    {
        [Key]
        public string SIGLA { get; set; } = null!;

        public string PATENTE { get; set; } = null!;

        public string MARCA { get; set; } = null!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ULTIMA_REVISION_TEC { get; set; }


        public int ID_MODELO { get; set; }



    }




}
