using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Domain.Models
{
    public class NationalHoliday
    {
        public int NationalHolidayId { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Legislation { get; set; }
        public string Type { get; set; } // "feriado",
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        //public VariableDates variableDates { get; set; }
    }
}