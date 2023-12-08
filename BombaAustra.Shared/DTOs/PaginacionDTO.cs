using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombaAustra.Shared.DTOs
{
    public class PaginacionDTO
    {

        public int Page { get; set; } = 1;

        public int RecordsNumber { get; set; } = 5;

        public string? Filter { get; set; }
    }
}
