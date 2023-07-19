using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Application.Dtos.Core
{
    public class AreaDto
    {
        public int AreaId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
