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
        Task<NationalHoliday> GetById(int nationalHolidayId);
        Task<List<NationalHoliday>> GetAll();
        Task Update(NationalHoliday NationalHoliday);
        Task Delete(int natinalHolidayId);
        Task DeleteAll();
    }
}
