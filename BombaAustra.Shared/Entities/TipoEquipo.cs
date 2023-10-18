﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombaAustra.Shared.Entities
{
    public class TipoEquipo
    {
        [Key]
        public int ID_TIPO_EQUIPO;

        public string DESCRIPCION = null!;
    }
}
