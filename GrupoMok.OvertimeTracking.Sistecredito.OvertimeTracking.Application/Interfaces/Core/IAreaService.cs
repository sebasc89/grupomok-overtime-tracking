using GrupoMok.OvertimeTracking.Application.Dtos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Application.Interfaces.Core
{
    public interface IAreaService : IBaseService<AreaDto>
    {
        Task<IEnumerable<AreaDto>> GetAllPagingAsync(int pageIndex, int pageSize);
    }
}
