using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Core.Interfaces
{
    public interface IUpdateRepository<TEntity>
    {
        Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = true);
    }
}
