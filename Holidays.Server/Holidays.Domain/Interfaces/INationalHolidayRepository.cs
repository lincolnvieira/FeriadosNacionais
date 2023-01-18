using Holidays.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Domain.Interfaces
{
    public interface INationalHolidayRepository
    {
        Task Add(NationalHoliday nationalHoliday);
        Task<NationalHoliday> Get();
        Task<List<NationalHoliday>> List();
        Task Update(int natinalHolidayId);
        Task Delete(int natinalHolidayId);
        Task DeleteAll();
    }
}
