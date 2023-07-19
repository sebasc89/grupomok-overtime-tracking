using AutoMapper;
using GrupoMok.OvertimeTracking.Application.Dtos.Common;
using GrupoMok.OvertimeTracking.Application.Dtos.Core;
using GrupoMok.OvertimeTracking.Application.Interfaces;
using GrupoMok.OvertimeTracking.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Application.Services
{
    public class BaseService<TDTO, TEntity> : IBaseService<TDTO>
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<TDTO>> CreateAsync(TDTO dto, bool autoSave)
        {
            var responseDto = new ResponseDTO<TDTO>();

            if (dto == null)
            {
                responseDto.Header.Message = "Los datos para la creación son requeridos"; ;
                responseDto.Header.ReponseCode = (int)HttpStatusCode.NotFound;
                throw new ArgumentNullException(responseDto.Header.Message);
            }

            var entity = _mapper.Map<TEntity>(dto);
            responseDto.Data = _mapper.Map<TDTO>(await _baseRepository.CreateAsync(entity));
            responseDto.Header.Message = "Registro creado con éxito";
            responseDto.Header.ReponseCode = (int)HttpStatusCode.OK;
            await _baseRepository.SaveChangesAsync();
            return responseDto;
        }

        public async Task<ResponseDTO<TDTO>> UpdateAsync(TDTO dto)
        {
            var responseDto = new ResponseDTO<TDTO>();

            if (dto == null)
            {
                responseDto.Header.Message = "Los datos para la actualización son requeridos"; ;
                responseDto.Header.ReponseCode = (int)HttpStatusCode.NotFound;
                throw new ArgumentNullException(responseDto.Header.Message);
            }

            var entity = _mapper.Map<TEntity>(dto);
            responseDto.Data = _mapper.Map<TDTO>(await _baseRepository.UpdateAsync(entity));
            responseDto.Header.Message = "Registro actualizado con éxito";
            responseDto.Header.ReponseCode = (int)HttpStatusCode.OK;
            await _baseRepository.SaveChangesAsync();

            return responseDto;
        }

        public async Task<ResponseDTO<TDTO>> DeleteAsync(object id)
        {
            var responseDto = new ResponseDTO<TDTO>();

            var entity = await _baseRepository.FindByIdAsync(id);
            var response = await _baseRepository.DeleteAsync(entity);
            responseDto.Data = _mapper.Map<TDTO>(response);
            responseDto.Header.Message = "Registro eliminado con éxito";
            responseDto.Header.ReponseCode = (int)HttpStatusCode.OK;
            await _baseRepository.SaveChangesAsync();
            return responseDto;
        }

        public async Task<ResponseDTO<TDTO>> FindByIdAsync(object id)
        {
            var responseDto = new ResponseDTO<TDTO>();

            responseDto.Data = _mapper.Map<TDTO>(await _baseRepository.FindByIdAsync(id));
            responseDto.Header.ReponseCode = (int)HttpStatusCode.OK;
            return responseDto;
        }

        public async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            return _mapper.Map<List<TDTO>>(_baseRepository.GetAll());
        }

        public async Task SaveChangesAsync()
        {
            await _baseRepository.SaveChangesAsync();
        }
    }
}
