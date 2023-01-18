using Holidays.Application.DTOs.Request;
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
        Task<GetNationalHolidaysResponse> GetNationalHolidayById(int nationalHolidayId);
        Task<List<GetNationalHolidaysResponse>> GetAllNationalHoliday();
        Task UpdateNationalHoliday(UpdateNationalHolidayRequest updateNationalHolidayRequest);
        Task DeleteNationalHoliday(int nationalHolidayId);
        Task ResetOriginalDataHolidays();
    }
}
