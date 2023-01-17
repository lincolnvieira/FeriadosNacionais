using NationalHolidays.Application.Interfaces;
using NationalHolidays.Infrastructure.ExternalService.Interfaces;
using NationalHolidays.Infrastructure.ExternalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalHolidays.Application.Services
{
    public class NationalHolidayService : INationalHolidayService
    {
        private readonly INationalHolidayExternalService _nationalHolidayExternalService;

        public NationalHolidayService(INationalHolidayExternalService nationalHolidayExternalService)
        {
            _nationalHolidayExternalService = nationalHolidayExternalService;
        }

        public async Task ResetOriginalDataHolidays()
        {
            List<NationalHolidayExternal> nationalHolidayExternal = await _nationalHolidayExternalService.GetNationalHolidaysFromExternalAPI();
        }
    }
}
