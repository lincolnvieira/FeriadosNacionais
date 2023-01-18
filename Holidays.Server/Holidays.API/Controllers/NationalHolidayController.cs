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
        public async Task<ActionResult<GetNationalHolidaysResponse>> GetNationalHoliday(int nationalHolidayId)
        {
            GetNationalHolidaysResponse getNationalHolidaysResponse = await _nationalHolidayService.GetNationalHolidayById(nationalHolidayId);

            if (getNationalHolidaysResponse == null)
                return NoContent();

            return Ok(getNationalHolidaysResponse);
        }

        [HttpGet]
        [Route("GetAllNationalHoliday")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<GetNationalHolidaysResponse>>> GetAllNationalHoliday()
        {
            List<GetNationalHolidaysResponse> lstGetNationalHolidaysResponse = await _nationalHolidayService.GetAllNationalHoliday();

            if (lstGetNationalHolidaysResponse.Count == 0)
                return NoContent();

            return Ok(lstGetNationalHolidaysResponse);
        }

        [HttpPost]
        [Route("UpdateNationalHoliday")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateNationalHoliday([FromBody] UpdateNationalHolidayRequest updateNationalHolidayRequest)
        {
            await _nationalHolidayService.UpdateNationalHoliday(updateNationalHolidayRequest);

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteNationalHoliday/{nationalHolidayId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteNationalHoliday(int nationalHolidayId)
        {
            await _nationalHolidayService.DeleteNationalHoliday(nationalHolidayId);

            return Ok();
        }

        [HttpPost]
        [Route("ResetOriginalDataHolidays")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> ResetOriginalDataHolidays()
        {
            await _nationalHolidayService.ResetOriginalDataHolidays();

            return Ok();
        } 
        #endregion
    }
}
