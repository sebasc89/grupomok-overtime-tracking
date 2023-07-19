using AutoMapper;
using GrupoMok.OvertimeTracking.Application.Dtos.Core;
using GrupoMok.OvertimeTracking.Application.Interfaces.Core;
using GrupoMok.OvertimeTracking.Core.Entities;
using GrupoMok.OvertimeTracking.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Application.Services.Core
{
    public class EmployeeService : BaseService<EmployeeDto, Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        : base(employeeRepository, mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
    }
}
