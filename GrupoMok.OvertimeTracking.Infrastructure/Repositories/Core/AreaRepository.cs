using GrupoMok.OvertimeTracking.Core.Entities;
using GrupoMok.OvertimeTracking.Core.Interfaces.Repositories;
using GrupoMok.OvertimeTracking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Infrastructure.Repositories.Core
{
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public ApplicationDbContext Context
        {
            get
            {
                return (ApplicationDbContext)_context;
            }
        }

        public AreaRepository(ApplicationDbContext database)
            : base(database)
        {
        }
    }
}
