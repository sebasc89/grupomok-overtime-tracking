using GrupoMok.OvertimeTracking.Application.Dtos.Common;
using GrupoMok.OvertimeTracking.Application.Dtos.Core;
using GrupoMok.OvertimeTracking.Application.Helpers;
using GrupoMok.OvertimeTracking.Application.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GrupoMok.OvertimeTracking.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        /// <summary>
        /// Method for create an Area record
        /// </summary>
        /// <param name="areaDto">Dto Area parameter</param>
        /// <returns>Area Dto Object</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] AreaDto areaDto)
        {
            try
            {
                var response = await _areaService.CreateAsync(areaDto, true);
                return Ok("1");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.NotFound, ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] AreaDto areaDto)
        {
            try
            {
                var response = await _areaService.UpdateAsync(areaDto);
                return Ok(response);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.NotFound, ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError, "Ocurrió un error en el servidor"));
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] AreaDto areaDto)
        {
            try
            {
                var response = await _areaService.DeleteAsync(areaDto.AreaId);
                return Ok(response);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.NotFound, ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError, "Ocurrió un error en el servidor"));
            }
        }

        [HttpGet("get/{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> GetAllAsync(int pageIndex,int pageSize)
        {
            try
            {
                var responseDto = new ResponseDTO<IEnumerable<AreaDto>>();
                responseDto.Data = await _areaService.GetAllPagingAsync(pageIndex,pageSize);
                responseDto.Header.ReponseCode = (int)HttpStatusCode.OK;
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError, "Ocurrió un error en el servidor"));
            }
        }

        [HttpGet]
        [Route("getById/{id:int}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            try
            {
                var responseDto = new ResponseDTO<AreaDto>();
                responseDto.Data = _areaService.FindByIdAsync(id).Result.Data;
                responseDto.Header.ReponseCode = (int)HttpStatusCode.OK;
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError, "Ocurrió un error en el servidor"));
            }
        }
    }
}
