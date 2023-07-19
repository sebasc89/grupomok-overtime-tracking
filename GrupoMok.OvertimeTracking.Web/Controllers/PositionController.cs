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
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        /// <summary>
        /// Method for create an Position record
        /// </summary>
        /// <param name="PositionDto">Dto Position parameter</param>
        /// <returns>Position dto object</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] PositionDto positionDto)
        {
            try
            {
                var response = await _positionService.CreateAsync(positionDto, true);
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

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] PositionDto positionDto)
        {
            try
            {
                var response = await _positionService.UpdateAsync(positionDto);
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
        public async Task<IActionResult> DeleteAsync([FromBody] PositionDto positionDto)
        {
            try
            {
                var response = await _positionService.DeleteAsync(positionDto.PositionId);
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

        [HttpGet("get")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var responseDto = new ResponseDTO<IEnumerable<PositionDto>>();
                responseDto.Data = await _positionService.GetAllAsync();
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
        public async Task<IActionResult> GFindByIdAsync(int id)
        {
            try
            {
                var responseDto = new ResponseDTO<PositionDto>();
                responseDto.Data = _positionService.FindByIdAsync(id).Result.Data;
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
