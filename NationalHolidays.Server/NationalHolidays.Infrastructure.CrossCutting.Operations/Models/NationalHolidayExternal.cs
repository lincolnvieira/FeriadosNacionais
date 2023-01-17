using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalHolidays.Infrastructure.ExternalService.Models
{
    public class NationalHolidayExternal
    {
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
