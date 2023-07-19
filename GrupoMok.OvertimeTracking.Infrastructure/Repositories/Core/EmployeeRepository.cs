using GrupoMok.OvertimeTracking.Core.Entities;
using GrupoMok.OvertimeTracking.Core.Interfaces.Repositories;
using GrupoMok.OvertimeTracking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Infrastructure.Repositories.Core
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public ApplicationDbContext Context
        {
            get
            {
                return (ApplicationDbContext)_context;
            }
        }

        public EmployeeRepository(ApplicationDbContext database)
            : base(database)
        {
        }
    }
}
