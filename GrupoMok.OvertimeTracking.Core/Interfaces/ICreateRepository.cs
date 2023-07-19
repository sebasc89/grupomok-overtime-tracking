using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Core.Interfaces
{
    public interface ICreateRepository<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entity, bool autoSave = true);
    }
}
