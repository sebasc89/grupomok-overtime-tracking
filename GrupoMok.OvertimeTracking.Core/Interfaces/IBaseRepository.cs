using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Core.Interfaces
{
    public interface IBaseRepository<TEntity>
      : ICreateRepository<TEntity>, IUpdateRepository<TEntity>, IDeleteRepository<TEntity>, IReadRepository<TEntity>
    {
        Task SaveChangesAsync();
    }
}
