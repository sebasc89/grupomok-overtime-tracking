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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Method for create an Employee record
        /// </summary>
        /// <param name="EmployeeDto">Dto Employee parameter</param>
        /// <returns>Dto employee response Object</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                var response = await _employeeService.CreateAsync(employeeDto, true);
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
        public async Task<IActionResult> UpdateAsync([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                var response = await _employeeService.UpdateAsync(employeeDto);
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
        public async Task<IActionResult> DeleteAsync([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                var response = await _employeeService.DeleteAsync(employeeDto.EmployeeId);
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
                var responseDto = new ResponseDTO<IEnumerable<EmployeeDto>>();
                responseDto.Data = await _employeeService.GetAllAsync();
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
                var responseDto = new ResponseDTO<EmployeeDto>();
                responseDto.Data = _employeeService.FindByIdAsync(id).Result.Data;
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
