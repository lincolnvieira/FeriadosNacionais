using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NationalHolidays.Application.DTOs.Response;
using NationalHolidays.Application.Interfaces;
using NationalHolidays.Infrastructure.ExternalService.Interfaces;

namespace NationalHolidays.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalHolidayController : ControllerBase
    {
        private readonly INationalHolidayService _nationalHolidayService;

        public NationalHolidayController(INationalHolidayService nationalHolidayService)
        {
            _nationalHolidayService = nationalHolidayService;
        }

        [HttpPost]
        [Route("ResetOriginalDataHolidays")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ResetOriginalDataHolidays()
        {
            await _nationalHolidayService.ResetOriginalDataHolidays();

            return Ok();
        }
    }
}
