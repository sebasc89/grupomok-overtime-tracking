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
    public class ApprovalStatusService : BaseService<ApprovalStatusDto, ApprovalStatus>, IApprovalStatusService
    {
        private readonly IApprovalStatusRepository _approvalStatusRepository;
        private readonly IMapper _mapper;

        public ApprovalStatusService(IApprovalStatusRepository approvalStatusRepository, IMapper mapper)
        : base(approvalStatusRepository, mapper)
        {
            _approvalStatusRepository = approvalStatusRepository;
            _mapper = mapper;
        }
    }
}
