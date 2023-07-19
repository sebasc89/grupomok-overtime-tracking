using GrupoMok.OvertimeTracking.Application.Interfaces.Core;
using GrupoMok.OvertimeTracking.Application.Services.Core;
using GrupoMok.OvertimeTracking.Core.Entities;
using GrupoMok.OvertimeTracking.Core.Interfaces.Repositories;
using GrupoMok.OvertimeTracking.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupoMok.OvertimeTracking.Infrastructure.Repositories.Core;
using GrupoMok.OvertimeTracking.Application.Helpers;
using Microsoft.Extensions.Caching.Memory;
using GrupoMok.OvertimeTracking.Application.Cache;

namespace GrupoMok.OvertimeTracking.Application.Config
{
    public class DependencyInjectionConfig
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Area>, AreaRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IAreaService, AreaService>();

            services.AddScoped<IBaseRepository<Position>, PositionRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IPositionService, PositionService>();

            services.AddScoped<IBaseRepository<ApprovalStatus>, ApprovalStatusRepository>();
            services.AddScoped<IApprovalStatusRepository, ApprovalStatusRepository>();
            services.AddScoped<IApprovalStatusService, ApprovalStatusService>();

            services.AddScoped<IOvertimeRequestService, OvertimeRequestService>();

            services.AddScoped<IBaseRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IMemoryCacheManager, MemoryCacheManager>();
        }
    }
}
