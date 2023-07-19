using AutoMapper;
using Bogus;
using GrupoMok.OvertimeTracking.Application.Cache;
using GrupoMok.OvertimeTracking.Application.Dtos.Core;
using GrupoMok.OvertimeTracking.Application.Helpers;
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
    public class AreaService : BaseService<AreaDto, Area>, IAreaService
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCacheManager _memoryCacheManager;   
        public string _cacheKey = $"list_{typeof(AreaDto).Name}";
        public int _cacheTimeExp = 30;

        public AreaService(IAreaRepository areaRepository, IMapper mapper,IMemoryCacheManager memoryCacheManager)
        : base(areaRepository, mapper)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
            _memoryCacheManager = memoryCacheManager;
        }

        public async Task<IEnumerable<AreaDto>> GetAllPagingAsync(int pageIndex, int pageSize)
        {
            List<AreaDto> list;
            string cacheKey = $"{_cacheKey}page={pageIndex}size={pageSize}";
            var cacheEntry = await _memoryCacheManager.GetOrCreateAsync(cacheKey, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(_cacheTimeExp);
                list = _mapper.Map<List<AreaDto>>(_areaRepository.GetAllPaging(pageIndex, pageSize));
                return Task.FromResult(list);
            });

            return cacheEntry;
        }
    }
}
