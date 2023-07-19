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
    public class PositionService : BaseService<PositionDto, Position>, IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository positionRepository, IMapper mapper)
        : base(positionRepository, mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }
    }
}
