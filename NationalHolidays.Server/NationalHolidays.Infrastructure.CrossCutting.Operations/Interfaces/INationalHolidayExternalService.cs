using NationalHolidays.Infrastructure.ExternalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalHolidays.Infrastructure.ExternalService.Interfaces
{
    public interface INationalHolidayExternalService
    {
        Task<List<NationalHolidayExternal>> GetNationalHolidaysFromExternalAPI();
    }
}
