using GrupoMok.OvertimeTracking.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Application.Interfaces
{
    public interface IBaseService<TDTO>
    {
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<ResponseDTO<TDTO>> FindByIdAsync(object Id);
        Task<ResponseDTO<TDTO>> CreateAsync(TDTO dto, bool autoSave);
        Task<ResponseDTO<TDTO>> DeleteAsync(object id);
        Task<ResponseDTO<TDTO>> UpdateAsync(TDTO dto);
        Task SaveChangesAsync();
    }
}
