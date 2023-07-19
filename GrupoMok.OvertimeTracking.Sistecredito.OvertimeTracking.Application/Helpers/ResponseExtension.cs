using GrupoMok.OvertimeTracking.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Application.Helpers
{
    public static class ResponseExtension
    {
        public static ResponseDTO<T> AsResponseDTO<T>(this T resultDTO, int code, string message = "")
        {
            var responseDTO = new ResponseDTO<T>();
            responseDTO.Data = resultDTO;
            responseDTO.Header = new HeaderDTO() { ReponseCode = code, Message = message };

            return responseDTO;
        }
    }
}
