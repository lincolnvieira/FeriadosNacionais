using Holidays.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Application.Interfaces
{
    public interface INationalHolidayService
    {
        Task<List<GetNationalHolidaysResponse>> GetAllNationalHoliday();
        Task<GetNationalHolidaysResponse> GetNationalHolidayById(int nationalHolidayId);
        Task ResetOriginalDataHolidays();
    }
}
