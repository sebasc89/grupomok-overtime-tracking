using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Application.Dtos.Common
{
    public class HeaderDTO
    {
        public int ReponseCode { get; set; }

        public string Message { get; set; }

        public bool Success
        {
            get
            {
                if (ReponseCode >= 200 && ReponseCode < 300)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
