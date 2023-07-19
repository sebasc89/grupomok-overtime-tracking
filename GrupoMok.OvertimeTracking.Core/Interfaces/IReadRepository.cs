using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Core.Interfaces
{
    public interface IReadRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllPaging(int pageIndex, int pageSize);

        Task<TEntity> FindByIdAsync(object id);
    }
}
