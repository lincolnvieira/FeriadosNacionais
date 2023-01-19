using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Holidays.Application.DTOs.Response;
using Holidays.Application.Interfaces;
using Holidays.Infrastructure.ExternalService.Interfaces;
using Holidays.Application.DTOs.Request;
using Holidays.Domain.Models;

namespace Holidays.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalHolidayController : ControllerBase
    {
        #region Declarations
        private readonly INationalHolidayService _nationalHolidayService;
        #endregion

        #region Constructor
        public NationalHolidayController(INationalHolidayService nationalHolidayService)
        {
            _nationalHolidayService = nationalHolidayService;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        [Route("GetNationalHoliday/{nationalHolidayId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetNationalHolidaysResponse>> GetNationalHoliday(int nationalHolidayId)
        {
            try
            {
                GetNationalHolidaysResponse getNationalHolidaysResponse = await _nationalHolidayService.GetNationalHolidayById(nationalHolidayId);

                if (getNationalHolidaysResponse == null)
                    return NoContent();

                return Ok(getNationalHolidaysResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro: {ex}");
            }
        }

        [HttpGet]
        [Route("GetAllNationalHoliday")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetNationalHolidaysResponse>>> GetAllNationalHoliday()
        {
            try
            {
                List<GetNationalHolidaysResponse> lstGetNationalHolidaysResponse = await _nationalHolidayService.GetAllNationalHoliday();

                if (lstGetNationalHolidaysResponse.Count == 0)
                    return NoContent();

                return Ok(lstGetNationalHolidaysResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro: {ex}");
            }

        }

        [HttpPost]
        [Route("UpdateNationalHoliday")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateNationalHoliday([FromBody] UpdateNationalHolidayRequest updateNationalHolidayRequest)
        {
            try
            {
                await _nationalHolidayService.UpdateNationalHoliday(updateNationalHolidayRequest);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro: {ex}");
            }
        }

        [HttpDelete]
        [Route("DeleteNationalHoliday/{nationalHolidayId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteNationalHoliday(int nationalHolidayId)
        {
            try
            {
                await _nationalHolidayService.DeleteNationalHoliday(nationalHolidayId);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro: {ex}");
            }
        }

        [HttpPost]
        [Route("ResetOriginalDataHolidays")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ResetOriginalDataHolidays()
        {
            try
            {
                await _nationalHolidayService.ResetOriginalDataHolidays();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro: {ex}");
            }
        }
        #endregion
    }
}
