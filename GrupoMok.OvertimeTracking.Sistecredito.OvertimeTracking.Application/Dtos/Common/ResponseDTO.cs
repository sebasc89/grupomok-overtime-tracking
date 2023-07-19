using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Application.Dtos.Common
{
    public class ResponseDTO<T>
    {
        private HeaderDTO _header;
        public HeaderDTO Header
        {
            get
            {
                if (_header == null)
                {
                    _header = new HeaderDTO();
                }

                return _header;
            }
            set
            {
                _header = value;
            }
        }
        public T Data { get; set; }
    }
}
